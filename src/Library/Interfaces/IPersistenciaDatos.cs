namespace Library
{
    public interface IPersistanciaDatos
    {
        void CargarInfo(string info);
        string GuardarInfo();
        
    }
}