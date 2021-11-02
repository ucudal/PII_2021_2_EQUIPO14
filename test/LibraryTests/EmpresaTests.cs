using NUnit.Framework;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="Empresa"/> y la clase <see cref="UserEmpresa"/>.
    /// </summary>
    [TestFixture]
    public class EmpresaTests
    {
        private UserEmpresa userEmpresa; 
        private UserAdmin userAdmin;
        private ConsoleInteraction userInterface;
        private Invitacion invitacion;
        private Empresa empresa;
        private Habilitaciones hab1;
        private Rubro rb1;
        private TipoProducto tipo1;
        private Producto producto;
        private Oferta oferta;
    

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
            this.hab1 = new Habilitaciones("Hab-1");
            Singleton<Datos>.Instance.AgregarHabilitacion(hab1);
            this.rb1 = new Rubro("Rub-1");
            Singleton<Datos>.Instance.AgregarRubro(rb1);
            this.tipo1 = new TipoProducto("Tipo-1");
            Singleton<Datos>.Instance.AgregarTipo(tipo1);
            this.empresa = new Empresa("Empresa", "Direccion", this.rb1);
            this.producto = new Producto("Metal", "Desc", "Direccion", 10, 100, this.tipo1);
            this.oferta = new Oferta("Plastico", this.producto, this.hab1);
        }

        /// <summary>
        /// Prueba que se pueda aceptar una invitacion.
        /// </summary>
        [Test]
        public void AceptarInvitacionTest()
        {
            this.userEmpresa.Invitacion = this.invitacion;
            this.userEmpresa.AceptarInvitacion("Y");
            bool expected = true;
            Assert.AreEqual(expected, this.userEmpresa.IsInvited);
        }

        /// <summary>
        /// Prueba que se pueda rechazar una invitacion.
        /// </summary>
        [Test]
        public void RechazarInvitacionTest()
        {
            this.userEmpresa.Invitacion = this.invitacion;
            this.userEmpresa.AceptarInvitacion("N");
            bool expected = false;
            Assert.AreEqual(expected, this.userEmpresa.IsInvited);
        }

        /// <summary>
        /// Prueba que se pueda crear una oferta.
        /// </summary>
        [Test]
        public void CrearOfertaTest()
        {
            this.userEmpresa.Empresa = this.empresa;
            this.userEmpresa.CrearOferta("Plastico", "Hab-1", ("Plasctico", "Desc", "Direccion", 10, 100), "Tipo-1");
            int expected = 1;
            Assert.AreEqual(expected, this.userEmpresa.Empresa.Ofertas.Count);
            Assert.AreEqual(expected, Singleton<Datos>.Instance.ListaOfertas().Count);
        }

        /// <summary>
        /// Prueba que se pueda agregar un mensaje clave a una publicacion.
        /// </summary>
        [Test]
        public void AgregarMsjClaveTest()
        {
            this.userEmpresa.Empresa = this.empresa;
            this.empresa.Ofertas.Add(this.oferta);
            this.userEmpresa.CrearMsjClave(("Metal", "Clave"));
            int expected = 1;
            Assert.AreEqual(expected, this.oferta.PalabrasClave.Count);
        }
    }
}