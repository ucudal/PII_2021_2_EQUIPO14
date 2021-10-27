using NUnit.Framework;

namespace Proyecto_Final
{
    public class Tests
    {
        [Test]
        public void TestAceptarInvitacion()
        {
            UserEmpresa userE1 = new UserEmpresa("Panadero");

            userE1.AceptarInvitacion();

            Epresa expected = userE1.Empresa;
            Assert.AreEqual(expected, userE1.Empresa);
        }
    }
}