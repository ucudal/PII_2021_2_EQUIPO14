using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    public class Empresa
    {
        private ArrayList especializaciones = new ArrayList();
        private ArrayList ofertas = new ArrayList();
        public string Nombre { get; }
        public string Ubicacion { get; }
        public string Rubro { get; }
        public ArrayList Especializaciones 
        { 
            get 
            {
                return this.especializaciones;
            } 
        }
        public ArrayList Ofertas 
        { 
            get 
            {
                return this.ofertas;
            } 
        }
        public Empresa(string nombre, string ubicacion, string rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }
    }
}