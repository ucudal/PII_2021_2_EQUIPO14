namespace Proyecto_Final
{
    public interface IUserInterface
    {
        string CrearOferta();
        (string, string, string) AceptarInvitacion();
        void AgregarEspecializacion(Empresa empresa);
    }
}