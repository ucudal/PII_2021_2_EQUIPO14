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
        public Rubro Rubro { get; }
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
        public Empresa(string nombre, string ubicacion, Rubro rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }

        public void AgregarEspecializacion(string especializacion)
        {
            this.Especializaciones.Add(especializacion);
        }
        public void EliminarEspecializacion(string especializacion)
        {
            ArrayList arrayEmpresa = this.Especializaciones;

            for (int i = 0; i < arrayEmpresa.Count - 1; i++)
            {
                if ((string)arrayEmpresa[i] == especializacion)
                {
                    arrayEmpresa.RemoveAt(i);
                }
            }
        }

        public void AgregarMsjClave(Oferta oferta)
        {
            Console.WriteLine("Ingrese palabra clave a agregar: ");
            string palabra = Console.ReadLine();

            for (int i = 0; i < this.Ofertas.Count - 1; i++)
            {
                if (this.Ofertas[i] == oferta)
                {
                    this.Ofertas[i].PalabraClave.Add(palabra);
                    Console.WriteLine($"Palabra clave: {palabra} agregada.");
                }
            }
        }
    }
}