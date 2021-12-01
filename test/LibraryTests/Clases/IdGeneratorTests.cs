using NUnit.Framework;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="IdGenerator"/>. En base a una generación correcta de los valores, esto implica que el método "generador" funciona correctamente.
    /// </summary>
    [TestFixture]
    
    public class IdGeneratorTests
    {
        /// <summary>
        /// Test para ver si la ID generada entrega un valor numérico.
        /// </summary>
        [Test]
        public void GenerateNumericIdTest()
        {
            string expected = IdGenerator.GenerateNumericId();
            Console.WriteLine(expected);
            Assert.IsTrue(long.TryParse(expected, out long result)); 
        }

        /// <summary>
        /// Ver si genera correctamente un Token de 10 caracteres de largo.
        /// </summary>
        [Test]
        public void GenerateTokenTest()
        {
            string expected = IdGenerator.GenerateToken();
            Assert.IsTrue(expected.Length == 10); 
        }
    }
}