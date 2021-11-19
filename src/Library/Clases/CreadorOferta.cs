using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase encargada de crear un producto al almacenar los datos en diccionarios cuyos Key son el ID del usuario y el contenido correspondiente al atributo de la clase producto correspondiente.
    /// </summary>
    public class CreadorOferta //(SRP)
    {
        private Dictionary<string,List<string>> datosOferta = new Dictionary<string,List<string>>();

        public Dictionary<string,List<string>> DatosOferta()
        {
            return this.datosOferta;
        }

        public void DeleteData(string id)
        {
            foreach (KeyValuePair<string,List<string>> item in this.datosOferta)
            {
                if (id == item.Key)
                {
                    item.Value.Clear();
                }
            }
        }

        public void AddDataById(string id, string data)
        {
            foreach (KeyValuePair<string,List<string>> item in this.datosOferta)
            {
                if (id == item.Key)
                {
                    item.Value.Add(data);
                }
                else
                {
                    this.datosOferta.Add(id, new List<string>()  {data});
                }
            }
        }
    }
}