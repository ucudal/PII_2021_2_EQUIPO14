using System.Collections;
using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    public class StatusManager
    {
        private  Dictionary<string, string> userData = new Dictionary<string, string>();

        public Dictionary<string, string> ListaEstadoUsuario()
        {
            return this.userData;
        }

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

        public void PrintUserStatus()
        {
            foreach (KeyValuePair<string, string> kvp in this.ListaEstadoUsuario())
            {
                Console.WriteLine("StatusManager: Usuario = {0} || Status = {1}", kvp.Key, kvp.Value);
            }
        }
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