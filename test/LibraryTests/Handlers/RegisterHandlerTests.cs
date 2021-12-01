using NUnit.Framework;
using Telegram.Bot.Types;

namespace Proyecto_Final
{
    /// <summary>
    /// Prueba de la clase <see cref="RegisterHandler"/>.
    /// </summary>
    [TestFixture]
    public class RegisterHandlerTests
    {   
        /// <summary>
        /// Para saber si un handler es capaz de procesar el mensaje; podemos ver el método de IHandle <see cref="IHandler.Handle"/>. Este nos indica que si un handler es capaz de procesar un mensaje nos retornará ese handler, en caso contrario retornará null. Siempre y cuando los handlers no retornen null al ejecutar el método "Handle", entonces podemos asegurar que el Handler es capaz de responder a su mensaje clave.
        /// </summary>
        [Test]
        public void RegisterHandlerTest()
        {
            Message mensaje = new Message();
            mensaje.From = new User();
            mensaje.Text = "/registro";
            mensaje.From.Id = 763281321;
            TelegramAdapter msj_adaptado = new TelegramAdapter(mensaje);

            Singleton<StatusManager>.Instance.AgregarEstadoUsuario(mensaje.From.Id.ToString(),"STATUS_IDLE");

            IHandler firstHandler = new RegisterHandler(null);

            string response = string.Empty;

            Assert.IsTrue(firstHandler.Handle(msj_adaptado,out response) != null);
        }
    }
}