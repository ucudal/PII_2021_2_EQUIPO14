namespace Proyecto_Final
{  
    /// <summary>
    /// Esta interfaz se utiliza para agrupar todas las clases usuario dentro de un solo tipo, el cual tiene como atributo el ID, aquello que hace cada objeto único dentro de los datos que tenemos.
    /// La función de esta clase es permitir polimorfizar las clases y guardarlas todas dentro de una lista, la de los usuarios almacenados, y es la única razón por la que funcióna el método "GetUserByID" de Datos. <see cref="Datos.GetUserById(string)"/>
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// String con el Id de un usuario registrado.
        /// </summary>
        /// <value>Devuelve el ID con el que se registro.</value>
        string Id {get; set;}
    }
}