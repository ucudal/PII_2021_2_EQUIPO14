using System;

namespace Proyecto_Final
{
    /// <summary>
    /// La función de esta clase es la de independizar la codificación del ChatBot de la API que se utiliza, aunque es necesario que exista una API para hacer funcionar este programa.
    /// Esta clase tiene una sola responsabilidad, que es la de obtener datos de una API y polimorfizarlos en datos de una interfaz, 
    /// en pos de separar la API del código, por lo cual es un SRP de Polimorfismo.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// El ID del usuario que envía un mensaje
        /// </summary>
        /// <value>String del usuario</value>
        string UserId {get;}

        /// <summary>
        /// El ID del chat en el que se envía el mensaje
        /// </summary>
        /// <value></value>
        string ChatId {get;}

        /// <summary>
        /// El mensaje en sí.
        /// </summary>
        /// <value></value>
        string Text {get;}

        /// <summary>
        /// El Nombre de la persona según los datos registrados en la API.
        /// </summary>
        /// <value></value>
        string FirstName {get;}

        /// <summary>
        /// El Apellido de la persona según los datos registrados en la API.
        /// </summary>
        /// <value></value>
        string LastName {get;}

        /// <summary>
        /// La fecha en la que se realizó el mensaje.
        /// </summary>
        /// <value></value>
        DateTime Date {get;}
    }
}