using NUnit.Framework;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="Oferta"/>.
    /// </summary>
    [TestFixture]
    public class OfertaTest
    {
        /// <summary>
        /// Testea si el método agrega una palabra clave a la oferta.
        /// </summary>
        [Test]
        public void AgregarMsjClaveTest()
        {
            Producto productoTest = new Producto("Madera de Roble","Descripcion","Ubicacion",100,true,1000,new TipoProducto("Madera"));
            Oferta ofertaTest = new Oferta("NombreOferta",productoTest,true,new Habilitaciones("HabilitacionTest"));
            ofertaTest.AgregarMsjClave("MsjClave");
            Assert.Contains("MsjClave",ofertaTest.PalabrasClave);
        }
    }
}