using System.Collections.Generic;
using System;

namespace Proyecto_Final
{
    /// <summary>
    /// Clase encargada de crear un producto al almacenar los datos en diccionarios cuyos Key son el ID del usuario y el contenido correspondiente al atributo de la clase producto correspondiente.
    /// </summary>
    public class CreadorProducto //(SRP)
    {
        private Dictionary<string,string> diccionarioNombre = new Dictionary<string,string>();

        /// <summary>
        /// Retorna la instancia del diccionario "diccionarioNombre"
        /// </summary>
        /// <returns>instancia de objeto "diccionarioNombre"</returns>
        public Dictionary<string,string> DiccionarioNombre() //(Singleton)
        {
            return this.diccionarioNombre;
        }

        /// <summary>
        /// Agrega el nombre que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public void AgregarDiccionarioNombre(string id, string nombre)
        {
            this.diccionarioNombre.Add(id,nombre);
        }
        private Dictionary<string,string> diccionarioDescripcion = new Dictionary<string,string>();

        /// <summary>
        /// Retorna la instancia del diccionario "diccionarioDescripcion"
        /// </summary>
        /// <returns>instancia de objeto "diccionarioDescripcion"</returns>
        public Dictionary<string,string> DiccionarioDescrpicion() //(Singleton)
        {
            return this.diccionarioDescripcion;
        }

        /// <summary>
        /// Agrega la descripción que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        public void AgregarDiccionarioDescripcion(string id, string descripcion) //(Expert)
        {
            this.diccionarioDescripcion.Add(id,descripcion);
        }

        private Dictionary<string,string> diccionarioUbicacion = new Dictionary<string,string>();

        /// <summary>
        /// Retorna la instancia del diccionario "diccionarioUbicacion"
        /// </summary>
        /// <returns>instancia de objeto "diccionarioUbicacion"</returns>
        public Dictionary<string,string> DiccionarioUbicacion() //(Singleton)
        {
            return this.diccionarioUbicacion;
        }

        /// <summary>
        /// Agrega la ubicación que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
        public void AgregarDiccionarioUbicacion(string id, string ubicacion) //(Expert)
        {
            this.diccionarioUbicacion.Add(id,ubicacion);
        }

        private Dictionary<string,int> diccionarioValor = new Dictionary<string,int>();

        /// <summary>
        /// Retorna la instancia del diccionario "diccionarioValor"
        /// </summary>
        /// <returns>instancia de objeto "diccionarioValor"</returns>
        public Dictionary<string,int> DiccionarioValor() //(Singleton)
        {
            return this.diccionarioValor;
        }

        /// <summary>
        /// Agrega el valor que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        public void AgregarDiccionarioValor(string id, string valor) //(Expert)
        {
            int valorInt = Convert.ToInt16(valor);
            this.diccionarioValor.Add(id,valorInt);
        }
        
        private Dictionary<string,string> diccionarioMoneda = new Dictionary<string,string>();

        /// <summary>
        /// Agrega la cantidad que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <returns>Instancia de objeto "diccionarioCantidad"</returns>
        public Dictionary<string,string> DiccionarioMoneda() //(Singleton)
        {
            return this.diccionarioMoneda;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moneda"></param>
        public void AgregarDiccionarioMoneda(string id, string moneda) //(Expert)
        {
            this.diccionarioMoneda.Add(id,moneda);
        }

        private Dictionary<string,int> diccionarioCantidad = new Dictionary<string,int>();

        /// <summary>
        /// Agrega la cantidad que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <returns>Instancia de objeto "diccionarioCantidad"</returns>
        public Dictionary<string,int> DiccionarioCantidad() //(Singleton)
        {
            return this.diccionarioCantidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        public void AgregarDiccionarioCantidad(string id, string cantidad) //(Expert)
        {
            int cantidadInt = Convert.ToInt32(cantidad);
            this.diccionarioCantidad.Add(id,cantidadInt);
        }

        private Dictionary<string,string> diccionarioTipo = new Dictionary<string,string>();

        /// <summary>
        /// Retorna la instancia del diccionario "diccionarioTipo"
        /// </summary>
        /// <returns>instancia de objeto "diccionarioTipo"</returns>
        public Dictionary<string,string> DiccionarioTipo() //(Singleton)
        {
            return this.diccionarioTipo;
        }
        
        /// <summary>
        /// Agrega el tipo que le designo un Emprendedor identificado por ID a un diccionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        public void AgregarDiccionarioTipo(string id, string tipo) //(Expert)
        {
            this.diccionarioTipo.Add(id,tipo);
        }
        /// <summary>
        /// Crea el producto en base a los datos almacenados por una ID en c/u de los diccionarios.
        /// </summary>
        /// <returns></returns>
        public Producto CrearProducto(string id) //(Expert)
        {
            string nombre = "";
            TipoProducto tipo = new TipoProducto("");
            string descripcion = "";
            string ubicacion = "";
            bool valorMoneda = true;
            int valor = 0;
            int cantidad = 0;

            foreach (KeyValuePair<string,string> item in Singleton<CreadorProducto>.Instance.DiccionarioNombre())
            {
                if (item.Key == id)
                {
                    nombre = item.Value;
                }
            }
            foreach (KeyValuePair<string,string> item in Singleton<CreadorProducto>.Instance.DiccionarioTipo())
            {
                if (item.Key == id)
                {
                    string tipoString = item.Value;
                    tipo.Nombre = tipoString;
                }
            }
            foreach (KeyValuePair<string,string> item in Singleton<CreadorProducto>.Instance.DiccionarioDescrpicion())
            {
                if (item.Key == id)
                {
                    descripcion = item.Value;
                }
            }
            foreach (KeyValuePair<string,string> item in Singleton<CreadorProducto>.Instance.DiccionarioUbicacion())
            {
                if (item.Key == id)
                {
                    ubicacion = item.Value;
                }
            }
            foreach (KeyValuePair<string,string> item in Singleton<CreadorProducto>.Instance.DiccionarioMoneda())
            {
                if (item.Key == id)
                {
                    string Moneda = item.Value;
                    if (Moneda == "1")
                    {
                        valorMoneda = false;
                    }
                    else
                    {
                        valorMoneda = true;
                    }
                }
            }
            foreach (KeyValuePair<string,int> item in Singleton<CreadorProducto>.Instance.DiccionarioValor())
            {
                if (item.Key == id)
                {
                    valor = item.Value;
                }
            }
            foreach (KeyValuePair<string,int> item in Singleton<CreadorProducto>.Instance.DiccionarioCantidad())
            {
                if (item.Key == id)
                {
                    cantidad = item.Value;
                }
            }
            Producto newProducto = new Producto(nombre,descripcion,ubicacion,valor,cantidad,tipo);
            newProducto.IsPesos = valorMoneda;
            Console.WriteLine($"Nombre: {newProducto.Nombre}\nDescripción: {newProducto.Descripcion}\nTipo: {newProducto.Tipo.Nombre}\nUbicación: {newProducto.Ubicacion}\nValor: {newProducto.MonetaryValue()}{newProducto.Valor}\nCantidad: {newProducto.Cantidad}");
            return newProducto;
        }
    }
}