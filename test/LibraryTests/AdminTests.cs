using NUnit.Framework;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="UserAdmin"/>.
    /// </summary>
    [TestFixture]
    public class AdminTests
    {
        private UserEmpresa userEmpresa; 
        private UserAdmin userAdmin;
        private ConsoleInteraction userInterface;
        private Invitacion invitacion;

     

        /// <summary>
        /// Crea un usuario empresa para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.userEmpresa = new UserEmpresa("Empresa");
            this.userAdmin = new UserAdmin("Admin");
            this.userInterface = new ConsoleInteraction();
            this.invitacion = new Invitacion();
        }

        /// <summary>
        /// Prueba que se pueda aceptar una invitacion.
        /// </summary>
        [Test]
        public void InvitarEmpresaTest()
        {
            Singleton<Datos>.Instance.AgregarUsuarioEmpresa(this.userEmpresa);
            this.userAdmin.InvitarEmpresa("Empresa");
            Invitacion expected = null;
            Assert.AreNotEqual(expected, this.userEmpresa.Invitacion);
        }
    }
}