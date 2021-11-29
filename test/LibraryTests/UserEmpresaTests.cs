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
        /// Test para revisar si se genera correctamente un código de 10 letras.
        /// </summary>
        
        [Test]
        public void InvitarEmpresaTest()
        {
            string token = UserAdmin.InvitarEmpresa();
            Assert.IsTrue(token.Length == 10, "No genera bien tokens"); 
        }
    }
}