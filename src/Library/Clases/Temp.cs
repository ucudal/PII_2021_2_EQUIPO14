using System;
using System.Collections.Generic;

namespace Proyecto_Final
{

    /// <summary>
    /// Clase encargada de almacenar y actualizar los datos temporales.
    /// </summary>
    public sealed class  Temp
    {   
        private Dictionary<string, Dictionary<string, string>> tempData = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// Otorga el diccionario de datos temporales.
        /// </summary>
        /// <value>Retorna un diccionario con datos temporales.</value>
        public Dictionary<string, Dictionary<string, string>> TempData { get; }

        /// <summary>
        /// Agrega datos a la lista que contiene el id del usuario en el diccionario.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void AddDataById(string id, string key, string data)
        {
            if (this.tempData.ContainsKey(id))
            {
                Dictionary<string, string> value;
                if(this.tempData.TryGetValue(id, out value))
                {
                    if (value.ContainsKey(key))
                    {
                        value[key] = data;
                    }
                    else
                    {
                        value.Add(key, data);
                    }
                }
            }
            else
            {
                Dictionary<string, string> auxDict = new Dictionary<string, string>();
                auxDict.Add(key, data);
                this.tempData.Add(id, auxDict);
            }
        }

        /// <summary>
        /// Devuelve el dato almacenado en una key especifica.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns>Devuelve un dato si lo encuentra.</returns>
        public string GetDataByKey(string id, string key)
        {
            if (this.tempData.ContainsKey(id))
            {
                Dictionary<string, string> value;
                if(this.tempData.TryGetValue(id, out value))
                {
                    if (value.ContainsKey(key))
                    {
                        return value[key];
                    }
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Elimina completamente el item del diccionario.
        /// </summary>
        /// <param name="id"></param>
        public void WipeDataById(string id)
        {
            this.tempData.Remove(id);
        }
    }
}