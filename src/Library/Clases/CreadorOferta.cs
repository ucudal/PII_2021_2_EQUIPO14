using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase encargada de crear un producto al almacenar los datos en diccionarios cuyos Key son el ID del usuario y el contenido correspondiente al atributo de la clase producto correspondiente.
    /// </summary>
    public class CreadorOferta //(SRP)
    {
        private Dictionary<string,Dictionary<string,string>> datosOferta = new Dictionary<string,Dictionary<string,string>>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,Dictionary<string,string>> DatosOferta() //(Singleton)
        {
            return this.datosOferta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void WipeDataById(string id) //(Expert)
        {
            this.datosOferta.Remove(id);
        }

        /// <summary>
        /// Agrega los datos a los diccionarios temporales.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>

        public void AddDataById(string id, string key, string data) //(Expert)
        {
            if (this.datosOferta.ContainsKey(id))
            {
                Dictionary<string,string> value;
                if(this.datosOferta.TryGetValue(id, out value))
                {
                    if(value.ContainsKey(key))
                    {
                        value[key] = data;
                    }
                    else
                    {
                    value.Add(key,data);
                    }
                }
            }
            else
            {
                Dictionary<string,string> auxDict = new Dictionary<string, string>();
                auxDict.Add(key,data);
                this.datosOferta.Add(id, auxDict);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void EntregarDatosOferta(string id)
        {
            foreach (KeyValuePair<string, Dictionary<string,string>> item in Singleton<CreadorOferta>.Instance.DatosOferta())
            {
                if (item.Key == id)
                {
                    Dictionary<string,string> auxDict = item.Value;
                    UserEmpresa user = (UserEmpresa) Singleton<Datos>.Instance.GetUserById(id);

                    Console.WriteLine(auxDict["habilitacionProducto"]);

                    user.CrearOferta(auxDict["nombreOferta"],auxDict["habilitacionProducto"],auxDict["recurrenciaOferta"],auxDict["nombreProducto"],auxDict["descripcionProducto"],auxDict["ubicacionProducto"],Convert.ToInt32(auxDict["valorUnitarioProducto"]),auxDict["valorMonedaProducto"],Convert.ToInt32(auxDict["cantidadProducto"]),auxDict["tipoProducto"]);
                }
            }
        }
    }
}