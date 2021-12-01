using NUnit.Framework;
using Telegram.Bot.Types;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="ExitHandler"/>.
    /// </summary>
    [TestFixture]
    public class ExitHandlerTests
    {   
        /// <summary>
        /// Para saber si un handler es capaz de procesar el mensaje; podemos ver el método de IHandle <see cref="IHandler.Handle"/>. Este nos indica que si un handler es capaz de procesar un mensaje nos retornará ese handler, en caso contrario retornará null. Siempre y cuando los handlers no retornen null al ejecutar el método "Handle", entonces podemos asegurar que el Handler es capaz de responder a su mensaje clave. Para 
        /// </summary>
        [Test]
        public void ExitHandlerTest()
        {
            Message mensaje = new Message();
            mensaje.From = new User();
            mensaje.Text = "/salir";
            mensaje.From.Id = 52469236;
            TelegramAdapter msj_adaptado = new TelegramAdapter(mensaje);

            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(mensaje.From.Id.ToString(),"STATUS_IDLE");

            IHandler firstHandler = new ExitHandler(null);

            string response = string.Empty;

            Assert.IsTrue(firstHandler.Handle(msj_adaptado,out response) == null);
        }
    }
}