using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/comandos".
    /// </summary>
    public class CommandsHandler : BaseHandler
    {
        Dictionary<string, string> GeneralCommands;
        Dictionary<string, string> AdminCommands;
        Dictionary<string, string> EmpresaCommands;
        Dictionary<string, string> EmprendedorCommands;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PublishHandler"/>. Esta clase procesa el mensaje "/comandos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CommandsHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/comandos"};  
            this.GeneralCommands = new Dictionary<string, string> () {
                // Comandos Generales.
                {"/comandos", "Para desplegar la lista de comandos."},
                {"/hola", "Para saludar a EXIV."},
                {"/exit", "Para salir."},
                {"/registro", "Para registrarte."},
            };
            this.AdminCommands = new Dictionary<string, string> () {
                // Comandos Admin.
                {"/invitar", "Para generar un token de invitacion."},
            };
            this.EmpresaCommands = new Dictionary<string, string> () {
                // Comandos Empresa.
                {"/publicar", "Para publicar una oferta."},
                {"/agergar_palabra", "Para agregar una palabra clave a una oferta."},
                {"/ventas", "Para ver tus ventas."},
            };
            this.EmprendedorCommands = new Dictionary<string, string> () {
                 // Comandos Emprendedor.
                {"/buscar_categoria", "Para buscar una oferta por su categoria."},
                {"/buscar_palabra", "Para buscar una oferta por su palabra clave."},
                {"/buscar_zona", "Para buscar una oferta por su zona."},
                {"/materiales_consumidos", "Para ver los materiales consumididos."}
            };
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
                StringBuilder str = new StringBuilder();
                str.Append("Los comandos disponibles son:\n");
                str.Append(this.generateList(this.GeneralCommands));
                str.Append("\nComo Administrador:\n");
                str.Append(this.generateList(this.AdminCommands));
                str.Append("\nComo Empresa:\n");
                str.Append(this.generateList(this.EmpresaCommands));
                str.Append("\nComo Emprendedor:\n");
                str.Append(this.generateList(this.EmprendedorCommands));
                response = str.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }

        private StringBuilder generateList(Dictionary<string, string> dict)
        {
            StringBuilder aux = new StringBuilder();
            foreach (KeyValuePair<string, string> command in dict)
            {
                aux.Append($"{command.Key} : { command.Value }\n");
            }
            return aux;
        }
    }
}