using System.Linq;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Publicar".
    /// </summary>
    public class PublishHandler : BaseHandler
    {
        private string[] allowedStatus;

        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "Publicar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PublishHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Publicar"};
            this.AllowedStatus = new string[] {"STATUS_PUBLISH_RESPONSE",
                                               "STATUS_PUBLISH_OFERTANAME",
                                               "STATUS_PUBLISH_PRODUCTNAME",
                                               "STATUS_PUBLISH_PRODUCTDESCRIPTION",
                                               "STATUS_PUBLISH_PRODUCTLOCATION",
                                               "STATUS_PUBLISH_PRODUCTVALUE",
                                               "STATUS_PUBLISH_PRODUCTQUANTITY",
                                               "STATUS_PUBLISH_PRODUCTTIPE",
                                               "STATUS_PUBLISH_HABILITACION"
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
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_RESPONSE");
                    return true;
                }
                else if (check == "STATUS_REGISTER_RESPONSE")
                {
                    if (message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese el nombre de la oferta";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_OFERTANAME");
                        return true;
                    }
                }
                else if (check == "STATUS_PUBLISH_OFERTANAME")
                {
                    response = $"El nombre de la oferta es: {message.Text}.\n\nIngrese el nombre del producto: ";
                    Oferta oferta = new Oferta(message.Text, new Producto("", "", "", 0, 0, new TipoProducto("")), new Habilitaciones("")); 
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTNAME");
                    // TODO: GUARDAR EL USUARIO CREADO.
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTNAME")
                {
                    response = $"El nombre del producto es: {message.Text}.\n\nIngrese la descripción del producto: ";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTDESCRIPTION");
                    // TODO: GUARDAR EL USUARIO CREADO.
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTDESCRIPTION")
                {
                    response = $"La descripción del producto es: {message.Text}.\n\nIngrese la ubicación del producto: ";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTLOCATION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTLOCATION")
                {
                    response = $"La ubicación del producto es: {message.Text}.\n\nIngrese el valor del producto:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTVALUE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTVALUE")
                {
                    response = $"El valor del producto es: {message.Text}.\n\nIngrese la cantidad del producto:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTQUANTITY");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTQUANTITY")
                {
                    response = $"La cantidad del producto es: {message.Text}.\n\nIngrese el tipo del producto:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTTIPE");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_PRODUCTTIPE")
                {
                    response = $"El tipo del producto es: {message.Text}.\n\nIngrese su habilitación:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_HABILITACION");
                    return true;
                }
                else if (check == "STATUS_PUBLISH_HABILITACION")
                {
                    response = $"Su habilitación es: {message.Text}.\n\nPublicación de la oferta realizada correctamente!!";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}