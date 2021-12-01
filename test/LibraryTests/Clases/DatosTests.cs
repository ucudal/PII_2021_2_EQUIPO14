using NUnit.Framework;
using System.Text.Json;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="Datos"/>.
    /// </summary>
    [TestFixture]

    
    public class DatosTests
    {
        
        /// <summary>
        /// Test para ver si el método "GetUserById" retorna un UserEmprendedor
        /// </summary>
        [Test]
        public void GetUserByIdTest_Emprendedor()
        {
            Singleton<Datos>.Instance.ListaUsuarioEmprendedor().Clear();
            UserEmprendedor userTest = new UserEmprendedor("TestID","TestNombre");
            Singleton<Datos>.Instance.ListaUsuarioEmprendedor().Add(userTest);
            Assert.AreEqual(userTest,Singleton<Datos>.Instance.GetUserById("TestID"));
        }
        
        /// <summary>
        /// Test para ver si el método "GetUserById" retorna un UserEmpresa
        /// </summary>
        [Test]
        public void GetUserByIdTest_Empresa()
        {
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Clear();
            UserEmpresa userTest = new UserEmpresa("TestID2","TestNombre");
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Add(userTest);
            Assert.AreEqual(userTest,Singleton<Datos>.Instance.GetUserById("TestID2"));
        }

        /// <summary>
        /// Test para ver si el método "GetUserById" retorna null cuando no encuentra una ID
        /// </summary>
        [Test]
        public void GetUserByIdTest_Null()
        {
            UserEmpresa userTest = new UserEmpresa("TestID3","TestNombre");
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Add(userTest);
            Assert.AreEqual(null,Singleton<Datos>.Instance.GetUserById("Messi"));
        }

        /// <summary>
        /// Test para ver si el método "GetOfertaById" retorna correctamente una oferta si la encuentra en la lista del usuario.
        /// </summary>
        [Test]
        public void GetOfertaByIdTest()
        {
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Clear();
            UserEmpresa userTest = new UserEmpresa("TestID4","TestNombre");
            Producto productoTest = new Producto("Nombre","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Tipo"));
            Oferta ofertaExpected = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Empresa empresaTest = new Empresa("Lionel Messi","Ubicacion",new Rubro("RubroTest"));
            userTest.Empresa = empresaTest;
            userTest.Empresa.Ofertas.Add(ofertaExpected);
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Add(userTest);
            Assert.AreEqual(ofertaExpected,Singleton<Datos>.Instance.GetOfertaById("TestID4",ofertaExpected.Id));
        }

        /// <summary>
        /// Test para ver si el método "GetOfertaById" retorna correctamente el valor "null" si no encuentra la oferta ene el usuario.
        /// </summary>
        [Test]
        public void GetOfertaByIdTest_Null()
        {
            UserEmpresa userTest = new UserEmpresa("TestID5","TestNombre");
            Producto productoTest = new Producto("Nombre","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Tipo"));
            Oferta ofertaExpected = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Empresa empresaTest = new Empresa("Lionel Messi","Ubicacion",new Rubro("RubroTest"));
            userTest.Empresa = empresaTest;
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Add(userTest);
            Assert.AreEqual(null,Singleton<Datos>.Instance.GetOfertaById("TestID5","Messi"));
        }

        /// <summary>
        /// Test para ver si el método "GetUnidadMedida" retorna una unidad según el tipo de material que se coloca (tiene que ser un tipo de unidad ya registrado).
        /// </summary>
        [Test]
        public void GetUnidadMedidaTest()
        {
            string expected = "unidades";
            Assert.AreEqual(expected,Singleton<Datos>.Instance.GetUnidadMedida("Madera"));
        }
    }
}