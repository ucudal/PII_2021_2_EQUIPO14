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
                                               "STATUS_PUBLISH_OFFERNAME",
                                               "STATUS_PUBLISH_RESPONSE_RECURRENCY_VALUE",
                                               "STATUS_PUBLISH_PRODUCTNAME",
                                               "STATUS_PUBLISH_PRODUCTDESCRIPTION",
                                               "STATUS_PUBLISH_PRODUCTLOCATION",
                                               "STATUS_PUBLISH_PRODUCTVALUE",
                                               "STATUS_PUBLISH_PRODUCTQUANTITY",
                                               "STATUS_PUBLISH_PRODUCTTYPE",
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
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_OFFERNAME");
                        return true;
                    }
                    else
                    {
                        response = "Se ha cancelado la creación de una oferta nueva";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
                else if (check == "STATUS_PUBLISH_OFFERNAME")
                {
                    response = $"El nombre de la oferta es: {message.Text}.\n\n¿Su oferta es recurrente o puntual?\nIngrese \"1\" para una oferta puntual.\ningrese \"2\" para una oferta recurrente.";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"nombreOferta",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE_RECURRENCY_VALUE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_RESPONSE_RECURRENCY_VALUE")
                {
                    if(message.Text == "1")
                    {
                        response = "La oferta es puntual.\nIngrese el nombre del producto:";
                        Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"recurrenciaOferta",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTNAME");
                        return true;
                    }
                    else if (message.Text == "2")
                    {
                        response = "La oferta es recurrente.\nIngrese el nombre del producto:";
                        Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"recurrenciaOferta",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTNAME");
                        return true;
                    }
                    else
                    {
                        response = "No entendí, por favor, responda \"1\" para definir a la oferta como puntual o ingrese \"2\" para definir a la oferta como recurrente.";
                        return true;
                    }
                }
                else if (check == "STATUS_PUBLISH_PRODUCTNAME")
                {
                    response = $"El nombre del producto es: {message.Text}.\n\nIngrese la descripción del producto: ";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"nombreProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTDESCRIPTION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTDESCRIPTION")
                {
                    response = $"La descripción del producto es: {message.Text}.\n\nIngrese el tipo de producto (Tela,Metal,Madera,Cerámica,etc...):";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"descripcionProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTTYPE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTTYPE")
                {
                    response = $"El tipo del producto es: {message.Text}.\n\nIngrese la ubicación del producto:";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"tipoProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTLOCATION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTLOCATION")
                {
                    response = $"La ubicación del producto es: {message.Text}.\n\n¿En qué moneda desea registrar el valor? \nIngrese \"1\" para dolares estadounidenses.\nIngrese \"2\" para pesos uruguayos.";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"ubicacionProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE")
                {
                    if(message.Text == "1")
                    {
                        response = "Se ha asignado al precio en dólares.\nIndique el valor unitario del producto:";
                        Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"valorMonedaProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTVALUE");
                        return true;
                    }
                    else if (message.Text == "2")
                    {
                        response = "Se ha asignado al precio en pesos uruguayos.\nIndique el valor unitario del producto:";
                        Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"valorMonedaProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTVALUE");
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
                    response = $"El valor unitario del producto es: {message.Text}.\n\nIngrese la cantidad del producto:";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"valorUnitarioProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTQUANTITY");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTQUANTITY")
                {
                    response = $"La cantidad del producto es: {message.Text}.\n\nIngrese la habilitacion requerida para obtener el producto:";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"cantidadProducto",message.Text);
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_HABILITACION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_HABILITACION")
                {
                    response = $"Su habilitación es: {message.Text}.\n\nPublicación de la oferta realizada correctamente!";
                    Singleton<CreadorOferta>.Instance.AddDataById(message.UserId,"habilitacionProducto",message.Text);


                    Singleton<CreadorOferta>.Instance.EntregarDatosOferta(message.UserId);
                    
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}