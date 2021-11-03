using NUnit.Framework;
using System.Collections;

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
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            Emprendedor emprendedor = new Emprendedor("Av. 8 de Octubre 2738",this.rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Gral. Urquiza 2784", this.rb1);
            userEmprendedor.Emprendedor = emprendedor;
            userEmpresa.Empresa = empresa;
            Producto newProducto = new Producto("Meta;", "Desc", "Av3221", 10, 400, this.tipo1);
            Oferta newOferta = new Oferta("Metal", newProducto, this.hab1);
            newOferta.IsVendido = true;
            newOferta.Comprador = userEmprendedor;
            this.userEmpresa.Empresa.Ofertas.Add(newOferta);
            
            string expected = $"Compró esta oferta: \n Nombre: Plastico \n Descripción: Desc \n Tipo: Tipo-1 \n Ubicación: Direccion \n Valor: $10 \n Cantidad: 100 \n Habilitaciones requeridas: {hab1.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.ConsumoXTiempo());
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasUbicacionTest()
        {
            
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasTipoTest()
        {
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            Emprendedor emprendedor = new Emprendedor("Av. 8 de Octubre 2738",this.rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Gral. Urquiza 2784", this.rb1);
            userEmprendedor.Emprendedor = emprendedor;
            userEmpresa.Empresa = empresa;
            userEmpresa.Empresa.Ofertas.Clear();
            Producto newProducto = new Producto("Metal", "Desc", "Av3221", 10, 400, this.tipo1);
            Oferta newOferta = new Oferta("Metal", newProducto, this.hab1);
            userEmpresa.Empresa.Ofertas.Add(newOferta);

            string expected = $"Esta oferta concuerda con el tipo que describió: \n Nombre: {newOferta.Product.Nombre} \n Descripción: {newOferta.Product.Descripcion} \n Tipo: {newOferta.Product.Tipo.Nombre} \n Ubicación: {newOferta.Product.Ubicacion} \n Valor: ${newOferta.Product.Valor} \n Cantidad: {newOferta.Product.Cantidad} \n Habilitaciones requeridas: {newOferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.VerOfertasTipo($"{this.tipo1.Nombre}"));
        }

        /// <summary>
        /// Prueba que se buscan correctamente las ofertas según .
        /// </summary>
        [Test]
        public void VerOfertasPalabraClaveTest()
        {
            UserEmprendedor userEmprendedor = new UserEmprendedor("UserEmprendedor");
            UserEmpresa userEmpresa = new UserEmpresa("UserEmpresa");
            Emprendedor emprendedor = new Emprendedor("Av. 8 de Octubre 2738",this.rb1,hab1);
            Empresa empresa = new Empresa("Empresa","Gral. Urquiza 2784", this.rb1);
            userEmprendedor.Emprendedor = emprendedor;
            userEmpresa.Empresa = empresa;
            Producto newProducto = new Producto("Metal", "Desc", "Av3221", 10, 400, this.tipo1);
            Oferta newOferta = new Oferta("Metal", newProducto, this.hab1);
            userEmpresa.Empresa.Ofertas.Add(newOferta);
            userEmpresa.CrearMsjClave(("Metal","Quiero"));

            string expected = $"Esta oferta concuerda con la palabra clave que colocó: \n Nombre: {newOferta.Product.Nombre} \n Descripción: {newOferta.Product.Descripcion} \n Tipo: {newOferta.Product.Tipo.Nombre} \n Ubicación: {newOferta.Product.Ubicacion} \n Valor: ${newOferta.Product.Valor} \n Cantidad: {newOferta.Product.Cantidad} \n Habilitaciones requeridas: {newOferta.HabilitacionesOferta.Habilitacion} \n";
            Assert.AreEqual(expected,userEmprendedor.VerOfertasPalabraClave("Quiero"));
        }
    }
}