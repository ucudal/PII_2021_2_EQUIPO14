namespace Proyecto_Final
{   
    /// <summary>
    /// Interfaz capaz de polimorfizar las distintas clases usuario en el caso en el que se quieran almacenar que se pueda realizar en una sola lista.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// String identificador del tipo de clase, se utilizará para discernir de qué clase se trata.
        /// </summary>
        /// <value>Un string que dice "Admin", "Emprendedor" o "Empresa".</value>
        string Es {get; set;}
    }
}