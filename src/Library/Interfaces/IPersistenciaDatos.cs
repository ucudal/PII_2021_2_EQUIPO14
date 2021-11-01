namespace Library
{
    /// <summary>
    /// Esta clase permite guardar y cargar información.
    /// </summary>
    public interface IPersistanciaDatos
    {
        /// <summary>
        /// Permite cargar información en base a un string.
        /// </summary>
        /// <param name="info"></param> 
        
        void CargarInfo(string info);

        /// <summary>
        /// Permite guardar información al transformarla a un string.
        /// </summary>
        /// <returns>Retorna un string</returns>
        string GuardarInfo();
        
    }
}