using System.Collections;
using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase es la responsable en gestionar y agregar los distintos status a cada usuario.
    /// Esta clase fue creada en base al patron SRP ya que sus responsabilidades son especificas y unicas.
    /// A su vez esta clase es una clase Singleton ya que unicamente necesitamos una instancia unica de la misma.
    /// </summary>
    public sealed class StatusManager
    {
        private  Dictionary<string, string> userData = new Dictionary<string, string>();

        /// <summary>
        /// Otorga un diccionario con los id de usuario como key y su estado como value.
        /// </summary>
        /// <returns>Diccionario de usuarios con sus estados.</returns>
        public Dictionary<string, string> ListaEstadoUsuario()
        {
            return this.userData;
        }

        /// <summary>
        /// Modifica el estado del usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        public void AgregarEstadoUsuario(string id, string estado)
        {
            if (this.userData.ContainsKey(id))
            {
                this.userData[id] = estado;
                //Console.WriteLine($"Estado {estado} agregado a usuario {id}");
            }
            else
            {
                this.userData.Add(id, "STATUS_IDLE");
                //Console.WriteLine($"Estado del usuario {id} creado.");
            }
        }

        /// <summary>
        /// Metodo que imprime en consola una lista con los usuarios y su estado actual.
        /// </summary>
        public void PrintUserStatus()
        {
            foreach (KeyValuePair<string, string> kvp in this.ListaEstadoUsuario())
            {
                Console.WriteLine("StatusManager: Usuario = {0} || Status = {1}", kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Verifica el status actual de un usuario y lo devuelve.
        /// Si no tiene estado devuelve el status por defecto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el estado actual.</returns>
        public string CheckStatus(string id)
        {
            foreach( KeyValuePair<string, string> kvp in this.ListaEstadoUsuario() )
            {
                if (id == kvp.Key)
                {
                    return kvp.Value;
                }
            }
            return "STATUS_IDLE";
        }
    }
}