using System;

namespace Proyecto_Final
{
    public class Rubro
    {
        public string Nombre { get; }
        public Empresa Empresa { get; private set; }
        public Rubro(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}