using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using Ucu.Poo.Locations.Client;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/publicar".
    /// </summary>
    public class PublishHandler : BaseHandler
    {
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "/publicar".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PublishHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/publicar"};
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
        /// Procesa el mensaje "/publicar" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (Singleton<Datos>.Instance.IsUserEmpresa(message.UserId))
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
                        response = $"El nombre de la oferta es: {message.Text}.\n\n¿Su oferta es recurrente o puntual?\nIngrese \"1\" para una oferta puntual.\nIngrese \"2\" para una oferta recurrente.";
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"nombreOferta",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE_RECURRENCY_VALUE");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_RESPONSE_RECURRENCY_VALUE")
                    {
                        if(message.Text == "1")
                        {
                            response = "La oferta es puntual.\nIngrese el nombre del producto:";
                            Singleton<Temp>.Instance.AddDataById(message.UserId,"recurrenciaOferta",message.Text);
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTNAME");
                            return true;
                        }
                        else if (message.Text == "2")
                        {
                            response = "La oferta es recurrente.\nIngrese el nombre del producto:";
                            Singleton<Temp>.Instance.AddDataById(message.UserId,"recurrenciaOferta",message.Text);
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
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"nombreProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTDESCRIPTION");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_PRODUCTDESCRIPTION")
                    {
                        response = $"La descripción del producto es: {message.Text}.\n\nIngrese el tipo de producto dentro de los tipos válidos: ";
                        response += generarListaTipoProducto();
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"descripcionProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTTYPE");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_PRODUCTTYPE")
                    {
                        foreach (KeyValuePair<string,string> tipo_Unidad in Singleton<Datos>.Instance.ListaTipos())
                        {
                            if(tipo_Unidad.Key == message.Text)
                            {
                                response = $"El tipo del producto es: {message.Text}.\n\nIngrese la ubicación del producto:";
                                Singleton<Temp>.Instance.AddDataById(message.UserId,"tipoProducto",message.Text);
                                Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTLOCATION");
                                return true;
                            }
                            else
                            {
                                response = $"Disculpe, lo que escribió no es un tipo válido. Debe de escribir un tipo dentro de la lista de los tipos válidos de producto:";
                                response += generarListaTipoProducto() + "Ingrese nuevamente un tipo de producto válido.";
                                return true;
                            }
                        }
                        
                    }
                    else if (check == "STATUS_PUBLISH_PRODUCTLOCATION")
                    {
                        response = $"La ubicación del producto es: {message.Text}.\n\n¿En qué moneda desea registrar el valor? \nIngrese \"1\" para dolares estadounidenses.\nIngrese \"2\" para pesos uruguayos.";
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"ubicacionProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_RESPONSE_MONETARY_VALUE")
                    {
                        if(message.Text == "1")
                        {
                            response = "Se ha asignado al precio en dólares.\nIndique el valor unitario del producto:";
                            Singleton<Temp>.Instance.AddDataById(message.UserId,"valorMonedaProducto",message.Text);
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTVALUE");
                            return true;
                        }
                        else if (message.Text == "2")
                        {
                            response = "Se ha asignado al precio en pesos uruguayos.\nIndique el valor unitario del producto:";
                            Singleton<Temp>.Instance.AddDataById(message.UserId,"valorMonedaProducto",message.Text);
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
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"valorUnitarioProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_PRODUCTQUANTITY");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_PRODUCTQUANTITY")
                    {
                        response = $"La cantidad del producto es: {message.Text}.\n\nIngrese una habilitacion válida:\n";
                        response += generarListaHabilitaciones();
                        Singleton<Temp>.Instance.AddDataById(message.UserId,"cantidadProducto",message.Text);
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PUBLISH_HABILITACION");
                        return true;
                    }
                    else if (check == "STATUS_PUBLISH_HABILITACION")
                    {
                        if(Singleton<Datos>.Instance.ListaHabilitaciones().Contains(message.Text))
                        {
                            response = $"Su habilitación es: {message.Text}.\n\nPublicación de la oferta realizada correctamente!";
                            Singleton<Temp>.Instance.AddDataById(message.UserId,"habilitacionProducto",message.Text);

                            UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(message.UserId);
                            
                            user.CrearOferta(
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "nombreOferta"),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "habilitacionProducto"),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "recurrenciaOferta"),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "nombreProducto"),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "descripcionProducto"),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "ubicacionProducto"),
                                Convert.ToInt32(Singleton<Temp>.Instance.GetDataByKey(message.UserId, "valorUnitarioProducto")),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "valorMonedaProducto"),
                                Convert.ToInt32(Singleton<Temp>.Instance.GetDataByKey(message.UserId, "cantidadProducto")),
                                Singleton<Temp>.Instance.GetDataByKey(message.UserId, "tipoProducto")
                            );
                            
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                            return true;
                        }
                        else
                        {
                            response = $"Disculpe, la habilitación que escribió no se encuentra dentro de las habilitaciones válidas.";
                            response += generarListaHabilitaciones() + "Ingrese nuevamente una habilitación válida.";
                            return true;
                        }
                    }
                }
                else
                {
                    response = "Usted no tiene los permisos necesarios para realizar esta acción";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
        private StringBuilder generarListaHabilitaciones()
        {
            StringBuilder str = new StringBuilder();
            foreach (string habilitacion in Singleton<Datos>.Instance.ListaHabilitaciones())
            {
                str.Append($"- {habilitacion}\n");
            }
            return str;
        }
        private StringBuilder generarListaTipoProducto()
        {
            StringBuilder str = new StringBuilder();
            foreach(KeyValuePair<string,string> tipo_Unidad in Singleton<Datos>.Instance.ListaTipos())
            {
                str.Append($"\n{tipo_Unidad.Key}");
            }
            return str;
        }
    }
}