using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    public class UserEmpresa
    {
        public string Nombre { get; }
        public Empresa Empresa { get; private set; }

        public UserEmpresa(string nombre)
        {
            this.Nombre = nombre;
        }

        /* Como empresa, quiero aceptar una invitación a unirme en la plataforma y registrar mi nombre, 
        ubicación y rubro, para que de esa forma pueda comenzar a publicar ofertas. */
        public void AceptarInvitacion((string, string, string) datos)
        {
            // Deberia UserEmpresa ser la encargada de crear la empresa y el rubro? (Creator)
            Rubro newRubro = new Rubro(datos.Item3);
            this.Empresa = new Empresa(datos.Item1, datos.Item2, newRubro);
        }

        public void AgregarRubro()
        {
            this.Empresa.AgregarRubro(); // (Delegacion)
        }

        public void EliminarRubro()
        {
            this.Empresa.EliminarRubro(); // (Delegacion)
        }

        public void AgregarEspecializacion()
        {
            this.Empresa.AgregarEspecializacion(); // (Delegacion)
        }

        public void EliminarEspecializacion()
        {
            this.Empresa.EliminarEspecializacion(); // (Delegacion)
        }

        /* Como empresa, quiero indicar un conjunto de palabras claves asociadas a la publicación de los materiales, 
        para que de esa forma sea más fácil de encontrarlos en las búsquedas que hacen los emprendedores. */
        public void CrearMsjClave(Oferta oferta)
        {
            this.Empresa.AgregarMsjClave(oferta); // (Delegacion)
        }

        /* Como empresa, quiero publicar una oferta de materiales reciclables o residuos, 
        para que de esa forma los emprendedores que lo necesiten puedan reutilizarlos. */
        public void CrearOferta(string nombre)
        {
            Oferta newOferta = new Oferta(nombre);

            this.Empresa.Ofertas.Add(newOferta);
            // Oferta creada
        }
    }
}