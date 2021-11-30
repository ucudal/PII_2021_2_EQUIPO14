using NUnit.Framework;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="UserAdmin"/>.
    /// </summary>
    [TestFixture]
    public class UserEmpresaTests
    {
        /// <summary>
        /// Test para revisar si se agrega un rubro correctamente a los datos de la Empresa
        /// </summary>
        [Test]
        public void AgregarRubroTest()
        {
            UserEmpresa userTest = new UserEmpresa("TestID","Pepe Argento");
            Empresa empresaTest = new Empresa ("Pepe Argento CORP","Ubicacion",new Rubro("RubroTest"));
            userTest.Empresa = empresaTest;
            Rubro expected = new Rubro("RubroTest2");
            userTest.AgregarRubro("RubroTest2");
            Assert.AreEqual(expected.Rubros,userTest.Empresa.Rubro.Rubros);
        }

        /// <summary>
        /// Test para revisar si se agrega una empresa correctamente al usuarioEmpresa
        /// </summary>
        [Test]
        public void CrearEmpresaTest()
        {
            UserEmpresa userTest = new UserEmpresa("TestID","Pepe Argento");
            Empresa expected = new Empresa ("Pepe Argento CORP","Ubicacion",new Rubro("RubroTest"));
            userTest.CrearEmpresa("Pepe Argento CORP","Ubicacion","RubroTest");
            Assert.AreEqual(expected.Nombre,userTest.Empresa.Nombre);
        }

        /// <summary>
        /// Test para revisar si la Empresa puede agregar correctamente una palabra clave.
        /// </summary>
        [Test]
        public void CrearMsjClaveTest()
        {
            UserEmpresa userTest = new UserEmpresa("TestID","Pepe Argento");
            userTest.CrearEmpresa("Pepe Argento CORP","Ubicacion","RubroTest");

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            userTest.Empresa.Ofertas.Add(ofertaTest);
            userTest.CrearMsjClave(ofertaTest.Id,"Messi");

            Assert.Contains("Messi",userTest.Empresa.Ofertas[0].PalabrasClave);
        }

        /// <summary>
        /// Test para revisar si la Empresa puede agregar correctamente una palabra clave.
        /// </summary>
        [Test]
        public void CrearOfertaTest()
        {
            UserEmpresa userTest = new UserEmpresa("TestID","Pepe Argento");
            userTest.CrearEmpresa("Pepe Argento CORP","Ubicacion","RubroTest");

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            userTest.CrearOferta("NombreOferta","HabilitacionTest","2","Madera de Roble","Descripcion","Ubicacion",100,"2",1000,"Madera");

            Assert.IsTrue(ofertaTest == userTest.Empresa.Ofertas[0]);
        }
    }
}