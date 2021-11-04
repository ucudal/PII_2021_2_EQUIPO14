using NUnit.Framework;
using System.Collections;
using Ucu.Poo.Locations.Client;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="UserEmprendedor"/>.
    /// </summary>
    [TestFixture]
    public class EmprendedorTests
    {
        private UserEmpresa userEmpresa;
        private Empresa empresa;
        private UserEmprendedor userEmprendedor; 
        private UserAdmin userAdmin;
        private ConsoleInteraction userInterface;
        private Emprendedor emprendedor;
        private Habilitaciones hab1;
        private Rubro rb1;
        private TipoProducto tipo1;
        
        /// <summary>
        /// Crea un usuario empresa para probar.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.userEmpresa = new UserEmpresa("UsuarioEmpresa");
            this.userEmprendedor = new UserEmprendedor("UsuarioEmprendedor");
            this.userAdmin = new UserAdmin("Admin");
            this.userInterface = new ConsoleInteraction();
            this.hab1 = new Habilitaciones("Hab-1");
            Singleton<Datos>.Instance.AgregarHabilitacion(hab1);
            this.rb1 = new Rubro("Rub-1");
            Singleton<Datos>.Instance.AgregarRubro(rb1);
            this.tipo1 = new TipoProducto("Tipo-1");
            Singleton<Datos>.Instance.AgregarTipo(tipo1);
            this.empresa = new Empresa("Empresa","Gral. Urquiza 2784", this.rb1);
            this.emprendedor = new Emprendedor("Av. 8 de Octubre 2738",this.rb1,hab1);
            userEmprendedor.Emprendedor = this.emprendedor;
        }
        
        /// <summary>
        /// Prueba que se agregan especializaciones correctamente.
        /// </summary>
        [Test]
        public void AgregarEspecializacionTest()
        {
            string especializacion = "Especialización";
            ArrayList listaTest = new ArrayList();
            listaTest.Add(especializacion);
            userEmprendedor.AgregarEspecializacion(especializacion);
            Assert.AreEqual(listaTest,userEmprendedor.Emprendedor.Especializaciones);
        }

        /// <summary>
        /// Prueba que se eliminan especializaciones correctamente.
        /// </summary>
        [Test]
        public void EliminarEspecializacionTest()
        {
            string especializacion = "Especialización";
            ArrayList listaTest = new ArrayList();
            userEmprendedor.AgregarEspecializacion(especializacion);
            userEmprendedor.EliminarEspecializacion(especializacion);
            Assert.AreEqual(listaTest,userEmprendedor.Emprendedor.Especializaciones);
        }
        
        /// <summary>
        /// Prueba que se muestran correctamente las ofertas consumidas.
        /// </summary>
        [Test]
        public void ConsumoXTiempoTest()
        {
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            Emprendedor emprendedor = new Emprendedor("Ubicacion",rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Ubicacion",rb1);
            userEmpresa.Empresa = empresa;
            userEmprendedor.Emprendedor = emprendedor;

            Singleton<Datos>.Instance.ListaOfertas().Clear();
            Producto producto = new Producto("Metal","Desc","Ubicacion",1000,100,tipo1);
            Oferta oferta = new Oferta("Hierro",producto,hab1);
            oferta.IsVendido = true;
            oferta.Comprador = userEmprendedor;

            string expected = $"Compró esta oferta: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.ConsumoXTiempo());
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasUbicacionTest()
        {
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            Emprendedor emprendedor = new Emprendedor("Av. 8 de Octubre 2738",rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Gral. Urquiza 2784",rb1);
            userEmpresa.Empresa = empresa;
            userEmprendedor.Emprendedor = emprendedor;

            Singleton<Datos>.Instance.ListaOfertas().Clear();
            Producto producto = new Producto("Metal","Desc","Gral. Urquiza 2784",1000,100,tipo1);
            Oferta oferta = new Oferta("Hierro",producto,hab1);
            
            LocationApiClient client = new LocationApiClient();
            var taskDistance = client.GetDistanceAsync("Av. 8 de Octubre 2738","Gral. Urquiza 2784");
            Distance distance = taskDistance.Result;

            string expected = $"Esta oferta está a {distance.TravelDistance}km de su ubicación: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.VerOfertasUbicacion());
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasTipoTest()
        {
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            Emprendedor emprendedor = new Emprendedor("Av. 8 de Octubre 2738",rb1,hab1);
            Empresa empresa = new Empresa("Comandante Braga 2715","Ubicacion",rb1);
            userEmpresa.Empresa = empresa;
            userEmprendedor.Emprendedor = emprendedor;

            Singleton<Datos>.Instance.ListaOfertas().Clear();
            Producto producto = new Producto("Metal","Desc","Gral. Urquiza 2784",1000,100,tipo1);
            Oferta oferta = new Oferta("Hierro",producto,hab1);

            string expected = $"Esta oferta concuerda con el tipo que describió: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.VerOfertasTipo("Tipo-1"));
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasPalabraClaveTest()
        {
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            Emprendedor emprendedor = new Emprendedor("Ubicacion",rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Ubicacion",rb1);
            userEmpresa.Empresa = empresa;
            userEmprendedor.Emprendedor = emprendedor;

            Singleton<Datos>.Instance.ListaOfertas().Clear();
            Producto producto = new Producto("Metal","Desc","Ubicacion",1000,100,tipo1);
            Oferta oferta = new Oferta("Hierro",producto,hab1);
            userEmpresa.Empresa.Ofertas.Add(oferta);
            userEmpresa.CrearMsjClave(("Hierro","Clave"));

            string expected = $"Esta oferta concuerda con la palabra clave que colocó: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.VerOfertasPalabraClave("Clave"));
        }
    }
}