using NUnit.Framework;
using System;
using Ucu.Poo.Locations.Client;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="UserEmprendedor"/>.
    /// </summary>
    [TestFixture]

    
    public class UserEmprendedorTests
    {
        
        /// <summary>
        /// Test para revisar si se agrega una habilitacion correctamente a los datos del emprendedor.
        /// </summary>
        
        [Test]
        public void AgregarHabilitacionTest()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;
            Habilitaciones expected = new Habilitaciones("HabTest2");
            userTest.AgregarHabilitacion("HabTest2");
            Assert.AreEqual(expected.Habilitacion,userTest.Emprendedor.Habilitacion.Habilitacion);
        }

        /// <summary>
        /// Test para revisar si se agrega un rubro correctamente a los datos del emprendedor.
        /// </summary>
        [Test]
        public void AgregarRubroTest()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;
            Rubro expected = new Rubro("RubroTest2");
            userTest.AgregarRubro("RubroTest2");
            Assert.AreEqual(expected.Rubros,userTest.Emprendedor.Rubro.Rubros);
        }

        /// <summary>
        /// Test para revisar si la clase es capaz de verificar el consumo de un Emprendedor correctamente.
        /// </summary>
        [Test]
        public void VerificarConsumoTest()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            
            ofertaTest.Comprador = userTest;
            ofertaTest.IsVendido = true;
            userTest.Emprendedor.Compras.Add(ofertaTest);
            DateTime fechaTest = new DateTime(2021,11,16,15,57,34);
            ofertaTest.SoldDate = fechaTest;

            string expected = "Madera = 1000 unidades";
            Assert.AreEqual(expected,userTest.VerificarConsumo("11"));
        }

        /// <summary>
        /// Test para revisar si la clase es capaz de verificar el consumo de un Emprendedor correctamente. En este caso, quiero saber si es capaz de diferenciar entre los meses.
        /// </summary>
        [Test]
        public void VerificarConsumoFailTest()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            
            ofertaTest.Comprador = userTest;
            ofertaTest.IsVendido = true;
            DateTime fechaTest = new DateTime(2021,11,16,15,57,34);
            ofertaTest.SoldDate = fechaTest;

            string expected = String.Empty;
            Assert.AreEqual(expected,userTest.VerificarConsumo("09"));
        }

        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante una palabra clave ingresada que existe dentro de alguna oferta. Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test, por ende el m??todo funciona la clase buscador. <see cref="UserEmprendedor.VerOfertasPalabraClave"/>,<see cref="Buscador.VerOfertasPalabraClave"/>
        /// </summary>
        [Test]
        public void VerOfertasPalabraClave()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            ofertaTest.PalabrasClave.Add("Messi");
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);

            string expected = $"Esta oferta concuerda con la palabra clave que coloc??: \nID: {ofertaTest.Id} \nNombre: {ofertaTest.Product.Nombre} \nDescripci??n: {ofertaTest.Product.Descripcion} \nTipo: {ofertaTest.Product.Tipo.Nombre} \nUbicaci??n: {ofertaTest.Product.Ubicacion} \nValor: {ofertaTest.Product.MonetaryValue()}{ofertaTest.Product.Valor} \nCantidad: {ofertaTest.Product.Cantidad} {Singleton<Datos>.Instance.GetUnidadMedida(ofertaTest.Product.Tipo.Nombre)} \nHabilitaciones requeridas: {ofertaTest.HabilitacionesOferta.Habilitacion} \n\n";

            Assert.AreEqual(expected,userTest.VerOfertasPalabraClave("Messi"));
        }

        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante una palabra clave ingresada que no existe en ning??na oferta. Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test , por ende el m??todo funciona la clase buscador <see cref="UserEmprendedor.VerOfertasPalabraClave"/>,<see cref="Buscador.VerOfertasPalabraClave"/>.
        /// </summary>
        [Test]
        public void VerOfertasPalabraClaveFailTest()
        {
            Singleton<Datos>.Instance.ListaOfertas().Clear();
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            ofertaTest.PalabrasClave.Add("Messi");
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);

            string expected = "No se encontraron ofertas que concuerdan con esa palabra clave.";

            Assert.AreEqual(expected,userTest.VerOfertasPalabraClave("CR7"));
        }
        
        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante un tipo de producto ingresado que existe dentro de alguna oferta. Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test , por ende el m??todo funciona en la clase buscador. <see cref="UserEmprendedor.VerOfertasTipo"/>, <see cref="Buscador.VerOfertasTipo"/>
        /// </summary>
        [Test]
        public void VerOfertasTipoTest()
        {
            Singleton<Datos>.Instance.ListaOfertas().Clear();
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);
            
            string expected = $"Esta oferta concuerda con el tipo que describi??: \nID: {ofertaTest.Id} \nNombre: {ofertaTest.Product.Nombre} \nDescripci??n: {ofertaTest.Product.Descripcion} \nTipo: {ofertaTest.Product.Tipo.Nombre} \nUbicaci??n: {ofertaTest.Product.Ubicacion} \nValor: {ofertaTest.Product.MonetaryValue()}{ofertaTest.Product.Valor} \nCantidad: {ofertaTest.Product.Cantidad} {Singleton<Datos>.Instance.GetUnidadMedida(ofertaTest.Product.Tipo.Nombre)} \nHabilitaciones requeridas: {ofertaTest.HabilitacionesOferta.Habilitacion} \n\n";

            Assert.AreEqual(expected,userTest.VerOfertasTipo("Madera"));
        }

        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante un tipo de producto ingresado que existe dentro de alguna oferta. Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test; por ende el m??todo funciona en la clase buscador. <see cref="UserEmprendedor.VerOfertasTipo"/>,<see cref="Buscador.VerOfertasTipo"/>.
        /// </summary>
        [Test]
        public void VerOfertasTipoFailTest()
        {
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Ubicacion",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Pvc"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);
            
            string expected = "No se encontraron ofertas que concuerden con el tipo de producto deseado.";

            Assert.AreEqual(expected,userTest.VerOfertasTipo("Yeso"));
        }
        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante la ubicacion de 2 objetos, uno de ellos es el Emprendedor que llama la funci??n, y el otro objeto es la oferta que se encuentra almacenada en una lista de la clase "Datos". Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test, por ende el m??todo funciona en la clase buscador. <see cref="UserEmprendedor.VerOfertasUbicacion"/>,<see cref="Buscador.VerOfertasUbicacion"/>.
        /// </summary>
        [Test]
        public void VerOfertasUbicacionTest()
        {
            Singleton<Datos>.Instance.ListaOfertas().Clear();
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Gral. Urquiza 2784",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Bv. Gral. Artigas 1498",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);

            LocationApiClient clientTest = new LocationApiClient();
            Location locationEmprendedor = clientTest.GetLocation(userTest.Emprendedor.Ubicacion);
            Location locationOferta = clientTest.GetLocation(ofertaTest.Product.Ubicacion);
            Distance distanceTest = clientTest.GetDistance(locationEmprendedor,locationOferta);
            
            string expected = $"Esta oferta est?? a {distanceTest.TravelDistance}km de su ubicaci??n: \nID: {ofertaTest.Id} \nNombre: {ofertaTest.Product.Nombre} \nDescripci??n: {ofertaTest.Product.Descripcion} \n Tipo: {ofertaTest.Product.Tipo.Nombre} \n Ubicaci??n: {ofertaTest.Product.Ubicacion} \nValor: {ofertaTest.Product.MonetaryValue()}{ofertaTest.Product.Valor} \nCantidad: {ofertaTest.Product.Cantidad} {Singleton<Datos>.Instance.GetUnidadMedida(ofertaTest.Product.Tipo.Nombre)} \nHabilitaciones requeridas: {ofertaTest.HabilitacionesOferta.Habilitacion} \n\n";

            Assert.AreEqual(expected,userTest.VerOfertasUbicacion());
        }
        /// <summary>
        /// Test para revisar si la clase es capaz de buscar ofertas mediante la ubicacion de 2 objetos, uno de ellos es el Emprendedor que llama la funci??n, y el otro objeto es la oferta que se encuentra almacenada en una lista de la clase "Datos". En este caso particular, la oferta se encuentra a m??s de 10km de distancia, lo cual deber??a de hacer que no se muestre nada en la oferta, ya que el l??mite para designar ofertas como cercanas es 10km. Este m??todo es una delegaci??n del m??todo de la clase <see cref="Buscador"/>, por lo cual si funciona este test, por ende el m??todo funciona en la clase buscador. <see cref="UserEmprendedor.VerOfertasUbicacion"/>,  <see cref="Buscador.VerOfertasUbicacion"/>
        /// </summary>
        [Test]
        public void VerOfertasUbicacionFailTest()
        {
            Singleton<Datos>.Instance.ListaOfertas().Clear();
            UserEmprendedor userTest = new UserEmprendedor("TestID","Pepe Argento");
            Emprendedor emprendedorTest = new Emprendedor ("Gral. Urquiza 2784",new Rubro("RubroTest"),new Habilitaciones("HabTest"));
            userTest.Emprendedor = emprendedorTest;

            Producto productoTest = new Producto("Madera de Roble","Descripcion","Av. Don Pedro de Mendoza 8238",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            Singleton<Datos>.Instance.ListaOfertas().Add(ofertaTest);

            LocationApiClient clientTest = new LocationApiClient();
            Location locationEmprendedor = clientTest.GetLocation(userTest.Emprendedor.Ubicacion);
            Location locationOferta = clientTest.GetLocation(ofertaTest.Product.Ubicacion);
            Distance distanceTest = clientTest.GetDistance(locationEmprendedor,locationOferta);
            
            string expected = "No se encontraron ofertas que est??n en su cercan??a.";

            Assert.AreEqual(expected,userTest.VerOfertasUbicacion());
        }

    }
}