using System.Collections;
using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    public class StatusManager
    {
        private  Dictionary<int, string> userData = new Dictionary<int, string>();

        public Dictionary<int, string> ListaEstadoUsuario()
        {
            return this.userData;
        }

       public void AgregarEstadoUsuario(int id, string estado)
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
            foreach (KeyValuePair<int, string> kvp in this.ListaEstadoUsuario())
            {
                Console.WriteLine("Usuario = {0} || Status = {1}", kvp.Key, kvp.Value);
            }
        }
        public string CheckStatus(int id)
        {
            foreach( KeyValuePair<int, string> kvp in this.ListaEstadoUsuario() )
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