using System;

namespace Proyecto_Final
{
    public class TipoProducto
    {
        public string Nombre { get; }
        public TipoProducto(string tipo)
        {
            this.Nombre = tipo;
        }
    }
}