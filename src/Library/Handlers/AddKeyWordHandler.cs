using System.Linq;
using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Palabra".
    /// </summary>
    public class AddKeyWordHandler : BaseHandler
    {
        /// <summary>
        /// El nombre de la oferta que el usuario luego ingresará.
        /// </summary>
        private string Oferta;
        
        /// <summary>
        /// La palabra clave que el usuario luego ingresará.
        /// </summary>
        private string KeyWord;
        private string[] allowedStatus;

        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddKeyWordHandler"/>. Esta clase procesa el mensaje "Palabra".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddKeyWordHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Palabra"};
            this.AllowedStatus = new string[] {"STATUS_KEYWORD_RESPONSE",
                                               "STATUS_KEYWORD_OFERTNAME",
                                               "STATUS_KEYWORD_KEYWORD",
                                               };  
        }
    
        /// <summary>
        /// Procesa el mensaje "Palabra" y retorna true; retorna false en caso contrario.
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
                    response = "¿Desea agregarle una palabra clave a una oferta? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_RESPONSE");
                    return true;
                }
                else if (check == "STATUS_KEYWORD_RESPONSE")
                {
                    if (message.Text.ToUpper() == "Y")
                    {
                        response = "Ingrese el nombre de la oferta a asignarle una palabra clave";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_OFERTNAME");
                        return true;
                    }
                    else
                    {
                        response = "Se ha cancelado la asignación de una palabra clave";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }
                }
                else if (check == "STATUS_KEYWORD_OFERTNAME")
                {
                    response = $"El nombre de la oferta es: {message.Text}.\n\nIngrese la palabra clave a asignarle: "; 
                    Oferta = message.Text;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_KEYWORD_KEYWORD");
                    return true;
                }
                else if (check == "STATUS_KEYWORD_KEYWORD")
                {
                    response = $"La palabra clave es: {message.Text}.\n\nPalabra clave asignada correctamente!! ";
                    KeyWord = message.Text;
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    /*foreach (KeyValuePair<string,Oferta> oferta in Singleton<Datos>.Instance.ListaOfertas())
                    {
                        if (oferta.Nombre == Oferta)
                        {
                            oferta.PalabrasClave.Add(KeyWord);
                        }
                    }*/
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}