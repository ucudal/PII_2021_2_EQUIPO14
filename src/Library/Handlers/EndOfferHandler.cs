using System.Linq;
using System;
using Ucu.Poo.Locations.Client;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Publicar".
    /// </summary>
    public class EndOfferHandler : BaseHandler
    {
        private string[] allowedStatus;
        /// <summary>
        /// Otorga un array con los status validos.
        /// </summary>
        /// <value>Array de status</value>
        public string[] AllowedStatus { get; set;}
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "/concretar_publicacion".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public EndOfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/concretar_publicacion"};
            this.AllowedStatus = new string[] {"STATUS_END_OFFER_RESPONSE",
                                                "STATUS_END_OFFER_OFFER_SELECTED",
                                                "STATUS_END_OFFER_TYPO"
                                               };  
        }

        /// <summary>
        /// Procesa el mensaje "/concretar_publicacion" y retorna true; retorna false en caso contrario.
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
                        response = $"¿Quiere finalizar una oferta Y/N";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_END_OFFER_RESPONSE");
                        return true;
                    }
                    else if (check == "STATUS_END_OFFER_RESPONSE")
                    {
                        if (message.Text == "Y")
                        {
                            response = $"Procederé a mostrarle todas sus ofertas existentes. Responda con el ID de la oferta .";
                            UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(message.UserId);
                            foreach (Oferta oferta in user.Empresa.Ofertas)
                            {
                                if (oferta.IsVendido == false)
                                {
                                    response += $"\nID: {oferta.Id} \nNombre: {oferta.Product.Nombre} \nDescripción: {oferta.Product.Descripcion} \nTipo: {oferta.Product.Tipo.Nombre} \nUbicación: {oferta.Product.Ubicacion} \nValor: {oferta.Product.MonetaryValue()}{oferta.Product.Valor} \nCantidad: {oferta.Product.Cantidad} {Singleton<Datos>.Instance.GetUnidadMedida(oferta.Product.Tipo.Nombre)} \nHabilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n";
                                }
                            }
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_END_OFFER_OFFER_SELECTED");
                            return true;
                        }
                        else if (message.Text == "N")
                        {
                            response = "Operacion abortada correctamente.";
                            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_IDLE");
                            return true;
                        }
                        else
                        {
                            response = $"No entendí, por favor, responda \"Y\" para concretar una oferta o escriba \"N\" para cancelar la operación.";
                            return true;
                        }
                    }
                    else if(check == "STATUS_END_OFFER_OFFER_SELECTED")
                    {
                        UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(message.UserId);
                        foreach (Oferta oferta in user.Empresa.Ofertas)
                        {
                            if (oferta.Id == message.Text)
                            {
                                if (oferta.Comprador != null)
                                {
                                    user.ConcretarOferta("Y", oferta.Id);
                                    response = $"Se ha concretado correctamente la oferta.";
                                    UserEmprendedor userEmprendedor = (UserEmprendedor) Singleton<Datos>.Instance.GetUserById(oferta.Comprador.Id);
                                    userEmprendedor.Emprendedor.Compras.Add(oferta);
                                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_IDLE");
                                    Singleton<Datos>.Instance.UpdateOfersData();
                                    Singleton<Datos>.Instance.UpdateEmprendedoresData();
                                    return true;
                                }
                                else
                                {
                                    response = $"¿Está seguro de que quiere concretar esta oferta? Nadie ha mostrado interés en ella. Si quiere hacerlo de todas formas, escriba la ID de la oferta que quiere borrar nuevamente. En caso contrario, escriba \"CANCELAR\"";
                                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_END_OFFER_TYPO");
                                    return true;
                                }
                            }
                        }
                        response = $"Disculpe, no encontré la oferta a la que le corresponde la ID que escribió. Pruebe de nuevo.";
                        response += $"\nProcederé a mostrarle todas sus ofertas existentes. Responda con el ID de la oferta.";
                        foreach (Oferta offer in user.Empresa.Ofertas)
                        {
                            response += $"\nID: {offer.Id} \nNombre: {offer.Product.Nombre} \nDescripción: {offer.Product.Descripcion} \nTipo: {offer.Product.Tipo.Nombre} \nUbicación: {offer.Product.Ubicacion} \nValor: {offer.Product.MonetaryValue()}{offer.Product.Valor} \nCantidad: {offer.Product.Cantidad} \nHabilitaciones requeridas: {offer.HabilitacionesOferta.Habilitacion} \n";
                        }
                    }
                    else if (check == "STATUS_END_OFFER_TYPO")
                    {
                       if (message.Text == "CANCELAR")
                        {
                            response = "Operacion abortada correctamente.";
                            return true;
                        }
                        else if (Singleton<Datos>.Instance.IsOfferValid(message.UserId,message.Text))
                        {
                            UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(message.UserId);
                            foreach (Oferta offer in user.Empresa.Ofertas)
                            {
                                if(offer.Id == message.Text)
                                {
                                    response = $"Oferta removida correctamente";
                                    user.Empresa.Ofertas.Remove(offer);
                                    Singleton<Datos>.Instance.UpdateOfersData();
                                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId,"STATUS_IDLE");
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            response = $"No encontré la oferta que esperabas. A menos que no hayas querido escribir una oferta. En ese caso, por favor, escriba \"CANCELAR\".";
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
            response = String.Empty;
            return false;
        }
    }
}