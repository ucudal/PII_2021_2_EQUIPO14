using System;
using System.Collections;

namespace Proyecto_Final
{
    public class Habilitaciones
    {
        public ArrayList ListaHabilitaciones { get; private set;}

        public Habilitaciones(ArrayList listaHabilitaciones)
        {
            this.ListaHabilitaciones = listaHabilitaciones;
        }

        public void AgregarHabilitacion(string habilitacion)
        {
            this.ListaHabilitaciones.Add(habilitacion);
        }
        public void RemoverHabilitacion(string habilitacion)
        {
            this.ListaHabilitaciones.Remove(habilitacion);
        }

        public bool CheckHabilitaciones(ArrayList habilitacionesACheckear)
        {
            foreach(string habilitacionACheckear in habilitacionesACheckear)
            {
                foreach(string habilitacion in this.ListaHabilitaciones)
                {
                    if(habilitacion.ToLower() == habilitacionACheckear.ToLower())
                    {
                        Console.WriteLine($"El emprendedor contiene la habilitación {habilitacionACheckear}");
                        habilitacionesACheckear.Remove(habilitacionACheckear);
                    }
                }  
            }
            if (habilitacionesACheckear.Count == 0)
            {
                Console.WriteLine($"El emprendedor contiene todas las habilitaciones requeridas.");
                return true;
            }
            else
            {
                foreach(string habilitacionACheckear in habilitacionesACheckear)
                {
                    Console.WriteLine($"El emprendedor necesita tener {habilitacionesACheckear} para aceptar el contrato.");
                }
            }
            return false; 
        }
    }
}