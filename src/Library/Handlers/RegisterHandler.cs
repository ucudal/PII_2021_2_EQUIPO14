
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "registro".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        private string[] allowedStatus;

        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandler"/>. Esta clase procesa el mensaje "registro".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"registro"};
            this.AllowedStatus = new string[] {
                                               "STATUS_REGISTER_RESPONSE",
                                               "STATUS_REGISTER_EMPRENDEDOR",
                                               "STATUS_REGISTER_EMPRENDEDOR_NAME",
                                               "STATUS_REGISTER_EMPRENDEDOR_UBICACION",
                                               "STATUS_REGISTER_EMPRENDEDOR_RUBRO",
                                               "STATUS_REGISTER_EMPRENDEDOR_HABILITACION",
                                               "STATUS_REGISTER_EMPRESA",
                                               "STATUS_REGISTER_EMPRESA_NAME",
                                               "STATUS_REGISTER_EMPRESA_UBICACION"
                                              };  
        }

        /// <summary>
        /// Procesa el mensaje "registro" y retorna true; retorna false en caso contrario.
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
                    response = "¿Tienes un token de registro? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_RESPONSE");
                    return true;
                }
                else if (check == "STATUS_REGISTER_RESPONSE")
                {
                    if (message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese su token: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRESA");
                        return true;
                    }
                    else
                    {
                        response = "¿Deseas registrarte como Emprendedor? Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR");
                        return true;
                    }
                }
                else if (check == "STATUS_REGISTER_EMPRESA")
                {
                    if (Singleton<Datos>.Instance.IsTokenValid(message.Text))
                    {
                        response = $"Token valido.\n\nIngrese su nombre: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRESA_NAME");
                        return true;
                    }
                    else
                    {
                        response = "Token invalido.\n¿Quieres intentarlo de nuevo? Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_RESPONSE");
                        return true;
                    }
                }
                else if (check == "STATUS_REGISTER_EMPRESA_NAME")
                {
                    response = $"Su nombre es: {message.Text}.\n\nIngrese su ubicacion: ";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRESA_UBICACION");
                    return true;
                }
                else if (check == "STATUS_REGISTER_EMPRESA_UBICACION")
                {
                    response = $"Su ubicacion es: {message.Text}.\n\nREGISTRO COMPLETO!!!.\n\nAhora estas registrado como empresa. ";

                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR_HABILITACION");

                    return true;
                }
                else if (check == "STATUS_REGISTER_EMPRENDEDOR")
                {
                    if (message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese su nombre: ";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR_NAME");
                        return true;
                    }
                    else
                    {
                        response = "Registro anulado.";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
                else if (check == "STATUS_REGISTER_EMPRENDEDOR_NAME")
                {
                    response = $"Su nombre es: {message.Text}.\n\nIngrese su ubicacion: ";

                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR_UBICACION");

                    return true;
                }
                else if (check == "STATUS_REGISTER_EMPRENDEDOR_UBICACION")
                {
                    response = $"Su ubicacion es: {message.Text}.\n\nIngrese su rubro: ";

                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR_HABILITACION");

                    return true;
                }
                else if (check == "STATUS_REGISTER_EMPRENDEDOR_HABILITACION")
                {
                    response = $"Su rubro es: {message.Text}.\n\nIngrese su habilitacion:";

                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_REGISTER_EMPRENDEDOR_RUBRO");

                    return true;
                }
                else if (check == "STATUS_REGISTER_EMPRENDEDOR_RUBRO")
                {
                    response = $"Su habilitacion es: {message.Text}.\n\nREGISTRO COMPLETO!!!.\n\nAhora eres un Emprendedor.";

                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}






