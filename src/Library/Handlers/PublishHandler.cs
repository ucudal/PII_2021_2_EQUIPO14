using System.Linq;
using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Publicar".
    /// </summary>
    public class PublishHandler : BaseHandler
    {
        /// <summary>
        /// El nombre de la oferta que el usuario creará.
        /// </summary>
        private string OfertName;
        /// <summary>
        /// El nombre del producto de la oferta que el usuario creará.
        /// </summary>
        private string ProductName;
        
        /// <summary>
        /// La descripción del producto de la oferta que el usuario creará.
        /// </summary>
        private string ProductDescription;
        /// <summary>
        /// La ubicación del producto de la oferta que el usuario creará.
        /// </summary>
        private string ProductLocation;
        /// <summary>
        /// El valor del producto de la oferta que el usuario creará.
        /// </summary>
        private int ProductValue;
        /// <summary>
        /// La cantidad del producto de la oferta que el usuario creará.
        /// </summary>
        private int ProductQuantity;
        /// <summary>
        /// El tipo del producto de la oferta que el usuario creará.
        /// </summary>
        private TipoProducto tipo; 
        /// <summary>
        /// Las habilitaciones requeridas para comprar la oferta del producto de la oferta que el usuario creará.
        /// </summary>
        private Habilitaciones habilitacion;
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "Publicar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PublishHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Publicar"};
            this.AllowedStatus = new string[] {"STATUS_PUBLISH_RESPONSE",
                                               "STATUS_PUBLISH_OFERTNAME",
                                               "STATUS_PUBLISH_PRODUCTNAME",
                                               "STATUS_PUBLISH_PRODUCTDESCRIPTION",
                                               "STATUS_PUBLISH_PRODUCTLOCATION",
                                               "STATUS_PUBLISH_PRODUCTVALUE",
                                               "STATUS_PUBLISH_PRODUCTQUANTITY",
                                               "STATUS_PUBLISH_PRODUCTTIPE",
                                               "STATUS_PUBLISH_HABILITACION",
                                               "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE",
                                               };  
        }

        /// <summary>
        /// Procesa el mensaje "Publicar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {   
                    response = "¿Desea publicar una nueva oferta? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_RESPONSE")
                {
                    if (message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese el nombre de la oferta";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_OFERTNAME");
                        foreach (KeyValuePair<string,List<string>> item in Singleton<CreadorOferta>.Instance.DatosOferta())
                        {
                            if (message.UserId == item.Key)
                            {
                               Singleton<CreadorOferta>.Instance.DeleteData(message.UserId);
                            }
                        }
                        return true;
                    }
                    else
                    {
                        response = "Se ha cancelado la creación de una oferta nueva";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
                else if (check == "STATUS_PUBLISH_OFERTNAME")
                {
                    response = $"El nombre de la oferta es: {message.Text}.\n\nIngrese el nombre del producto: ";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTNAME");

                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTNAME")
                {
                    response = $"El nombre del producto es: {message.Text}.\n\nIngrese la descripción del producto: ";
                    ProductName = message.Text;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTDESCRIPTION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTDESCRIPTION")
                {
                    response = $"La descripción del producto es: {message.Text}.\n\nIngrese la ubicación del producto: ";
                    ProductDescription = message.Text;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTLOCATION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTLOCATION")
                {
                    response = $"La ubicación del producto es: {message.Text}.\n\n¿En qué moneda desea registrar el valor? \nIngrese \"1\" para dolares estadounidenses.\nIngrese \"2\" para pesos uruguayos.";
                    ProductLocation = message.Text;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE")
                {
                    if(message.Text == "1")
                    {
                        response = "Se ha asignado al precio en dólares.\nIndique el valor unitario del producto:";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTVALUE");
                        return true;
                    }
                    else if (message.Text == "2")
                    {
                        response = "Se ha asignado al precio en pesos uruguayos.\nIndique el valor unitario del producto:";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.ChatId, "STATUS_PUBLISH_PRODUCTVALUE");
                        return true;
                    }
                    else
                    {
                        response = "No entendí, por favor, responda \"1\" para dólares estadounidenses o ingrese \"2\" para pesos uruguayos";
                        return true;
                    }
                }
                else if (check == "STATUS_PUBLISH_PRODUCTVALUE")
                {
                    response = $"El valor del producto es: {message.Text}.\n\nIngrese la cantidad del producto:";
                    ProductValue = Convert.ToInt32(message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTQUANTITY");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTQUANTITY")
                {
                    response = $"La cantidad del producto es: {message.Text}.\n\nIngrese el tipo del producto:";
                    ProductQuantity = Convert.ToInt32(message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTTIPE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTTIPE")
                {
                    response = $"El tipo del producto es: {message.Text}.\n\nIngrese su habilitación:";
                    tipo = new TipoProducto(message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_HABILITACION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_HABILITACION")
                {
                    response = $"Su habilitación es: {message.Text}.\n\nPublicación de la oferta realizada correctamente!!";
                    habilitacion = new Habilitaciones(message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    Oferta oferta = new Oferta(OfertName, new Producto(ProductName, ProductDescription, ProductLocation, ProductValue, ProductQuantity, tipo), habilitacion); 
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}