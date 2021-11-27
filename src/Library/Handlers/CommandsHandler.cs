using System.Linq;
using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/comandos".
    /// </summary>
    public class CommandsHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "/comandos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CommandsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/comandos"};  
        }

        /// <summary>
        /// Procesa el mensaje "/comandos" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessage message, out string response)
         {
            if (this.CanHandle(message))
            {
                response ="Los comandos disponibles son:\nPara saludar a EXIV ingrese: /hola\nPara despedirte ingrese: /chau o /adiós\nPara salir ingrese: /exit\nPara registrarte ingrese: /registro\n\nComo administrador:\nPara invitar a una empresa ingrese: /invitar\n\nComo empresa:\nPara publicar una oferta ingrese: /publicar\nPara agregarle una palabra clave a una oferta ingrese: /agregar_palabra\nPara ver tus ventas ingrese: /ventas\n\nComo emprendedor\nPara buscar una oferta por su categoría ingrese: /buscar_categoria\nPara buscar una oferta por su palabra clave ingrese: /buscar_palabra\nPara buscar una oferta por su zona ingrese: /buscar_zona\nPara buscar una oferta por su recurrencia ingrese: /buscar_recurrencia\nPara ver los materiales consumidos ingrese: /materiales_consumidos";

                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}