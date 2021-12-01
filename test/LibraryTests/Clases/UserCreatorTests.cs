using NUnit.Framework;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="UserCreator"/>.
    /// </summary>
    [TestFixture]

    
    public class UserCreatorTests
    {
        /// <summary>
        /// Test para revisar si 
        /// </summary>
        [Test]
        public void CrearUserEmprendedorTest()
        {
            Singleton<Datos>.Instance.ListaUsuarioEmprendedor().Clear();
            Singleton<Temp>.Instance.AddDataById("EmprendedorID","nombreEmprendedor","Lionel Messi");
            Singleton<Temp>.Instance.AddDataById("EmprendedorID","ubicacionEmprendedor","Gral. Urquiza 2784");
            Singleton<Temp>.Instance.AddDataById("EmprendedorID","rubroEmprendedor","Rubro-1");
            Singleton<Temp>.Instance.AddDataById("EmprendedorID","habilitacionEmprendedor","Habilitacion-1");

            Singleton<UserCreator>.Instance.CrearUserEmprendedor("EmprendedorID");

            UserEmprendedor userEmprendedorTest = new UserEmprendedor("EmprendedorID","Lionel Messi");
            Emprendedor emprendedorTest = new Emprendedor("Gral. Urquiza 2784",new Rubro("Rubro-1"),new Habilitaciones("Habilitacion-1"));
            userEmprendedorTest.Emprendedor = emprendedorTest;

            Assert.IsTrue((userEmprendedorTest.Id == Singleton<Datos>.Instance.ListaUsuarioEmprendedor()[0].Id) && (userEmprendedorTest.Nombre == Singleton<Datos>.Instance.ListaUsuarioEmprendedor()[0].Nombre) && (userEmprendedorTest.Emprendedor.Ubicacion == Singleton<Datos>.Instance.ListaUsuarioEmprendedor()[0].Emprendedor.Ubicacion) && (userEmprendedorTest.Emprendedor.Rubro.Rubros == Singleton<Datos>.Instance.ListaUsuarioEmprendedor()[0].Emprendedor.Rubro.Rubros) && (userEmprendedorTest.Emprendedor.Habilitacion.Habilitacion == Singleton<Datos>.Instance.ListaUsuarioEmprendedor()[0].Emprendedor.Habilitacion.Habilitacion));
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CrearUserEmpresaTest()
        {
            Singleton<Datos>.Instance.ListaUsuarioEmpresa().Clear();
            Singleton<Temp>.Instance.AddDataById("EmpresaID","nombreEmpresa","Lionel Messi");
            Singleton<Temp>.Instance.AddDataById("EmpresaID","ubicacionEmpresa","Gral. Urquiza 2784");
            Singleton<Temp>.Instance.AddDataById("EmpresaID","rubroEmpresa","Rubro-1");

            Singleton<UserCreator>.Instance.CrearUserEmpresa("EmpresaID");

            UserEmpresa userEmpresaTest = new UserEmpresa("EmpresaID","Lionel Messi");
            Empresa empresaTest = new Empresa("Lionel Messi","Gral. Urquiza 2784",new Rubro("Rubro-1"));
            userEmpresaTest.Empresa = empresaTest;
            
            Assert.IsTrue((userEmpresaTest.Id == Singleton<Datos>.Instance.ListaUsuarioEmpresa()[0].Id) && (userEmpresaTest.Nombre == Singleton<Datos>.Instance.ListaUsuarioEmpresa()[0].Nombre) && (userEmpresaTest.Empresa.Ubicacion == Singleton<Datos>.Instance.ListaUsuarioEmpresa()[0].Empresa.Ubicacion) && (userEmpresaTest.Empresa.Rubro.Rubros == Singleton<Datos>.Instance.ListaUsuarioEmpresa()[0].Empresa.Rubro.Rubros));
        }
    }
}