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

/* Lo que queremos realizar con este método es una manera de checkear si los emprendedores contienen las
habilitaciones que se requieren. Estas estarían publicadas en la oferta, por lo cual la manera en la que
envisonamos la ejecución del comando sería "oferta.Habilitaciones.CheckHabilitaciones(empredor.Habilitaciones)" 
*/
        public bool CheckHabilitaciones(Habilitaciones habilitacionesACheckear)
        {
            ArrayList checker = habilitacionesACheckear.ListaHabilitaciones;
            foreach(string habilitacionACheckear in checker)
            {
                foreach(string habilitacion in this.ListaHabilitaciones)
                {
                    if(habilitacion.ToLower() == habilitacionACheckear.ToLower())
                    {
                        Console.WriteLine($"El emprendedor contiene la habilitación {habilitacionACheckear}");
                        checker.Remove(habilitacionACheckear);
                    }
                }  
            }
            if (checker.Count == 0)
            {
                Console.WriteLine($"El emprendedor contiene todas las habilitaciones requeridas.");
                return true;
            }
            else
            {
                foreach(string habilitacionACheckear in checker)
                {
                    Console.WriteLine($"El emprendedor necesita tener {habilitacionesACheckear} para aceptar el contrato.");
                }
            }
            return false; 
        }
    }
}

