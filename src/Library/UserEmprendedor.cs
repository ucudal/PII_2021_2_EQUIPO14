using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    public class UserEmprendedor
    {
        public string Nombre { get; }
        public Emprendedor Emprendedor { get; private set; }

        public UserEmprendedor(string nombre)
        {
            this.Nombre = nombre;
        }

        public void AgregarEspecializacion()
        {
            this.Emprendedor.AgregarEspecializacion();
        }
        
        public void EliminarEspecializacion()
        {
            this.Emprendedor.EliminarEspecializacion();
        }
        public void EnviarMsj()
        {

        }
        public void VerOfertasPalabraClave()
        {

        }
        public void VerOfertasUbicacion()
        {

        }
        public void CargarInfo()
        {

        }
        public void GuardarInfo()
        {

        }
        
    }
}