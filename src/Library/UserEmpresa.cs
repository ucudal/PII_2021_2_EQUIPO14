using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa al usuario de la Empresa.
    /// </summary>
    public class UserEmpresa
    {
        private bool isInvited = false;

        /// <summary>
        /// Obtiene un valor del nombre del usuario empresa.
        /// </summary>
        /// <value>Nombre de la empresa</value>
        public string Nombre { get; }
        /// <summary>
        /// Obtiene un valor del objeto Empresa.
        /// </summary>
        /// <value>Objeto del tipo Empresa</value>
        public Empresa Empresa { get; private set; }

        /// <summary>
        /// Obtiene un valor booleano dependiendo de si la empresa fue invitada o no.
        /// </summary>
        /// <value><c>true/false</c></value>
        public bool IsInvited { get { return isInvited; } private set { this.isInvited = value;} }

        /// <summary>
        /// Inicializa la clase UserEmpresa.
        /// </summary>
        /// <param name="nombre"></param>
        public UserEmpresa(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Como empresa, quiero aceptar una invitación a unirme en la plataforma y registrar mi nombre, ubicación y rubro, para que de esa forma pueda comenzar a publicar ofertas.
        /// </summary>
        /// <param name="isAccepted"></param>
        /// <param name="userInterface"></param>
        public void AceptarInvitacion(bool isAccepted, IUserInterface userInterface) // (Creator)
        {
            if (isAccepted == true)
            {
                this.IsInvited = true; // La empresa cambia su estado a invitada/aceptada.
                // Crea la empresa en base a los datos obtenidos de la interface.
                (string, string, string) datos = userInterface.CrearDatosEmpresa(); // (Delegacion)
                Rubro newRubro = new Rubro(datos.Item3);
                this.Empresa = new Empresa(datos.Item1, datos.Item2, newRubro);
            }
        }

        /// <summary>
        /// Como empresa, quiero indicar un conjunto de palabras claves asociadas a la publicación de los materiales, para que de esa forma sea más fácil de encontrarlos en las búsquedas que hacen los emprendedores.
        /// </summary>
        /// <param name="oferta"></param>
        /// <param name="userInterface"></param>
        public void CrearMsjClave(Oferta oferta, IUserInterface userInterface)
        {
            userInterface.AgregarMsjClave(oferta); // (Delegacion) 
        }

        /// <summary>
        /// Como empresa, quiero publicar una oferta de materiales reciclables o residuos, para que de esa forma los emprendedores que lo necesiten puedan reutilizarlos.
        /// </summary>
        /// <param name="userInterface"></param>
        public void CrearOferta(IUserInterface userInterface) // (Creator)
        {
            string datosOferta = userInterface.CrearDatosOferta(); // (Delegacion y SRP)
            string datosHabilitacion = userInterface.CrearDatosHabilitacion(); // (Delegacion y SRP) 
            (string, string, string, int, int) datosProducto = userInterface.CrearDatosProducto(); // (Delegacion y SRP)
            string datosTipoProducto = userInterface.CrearDatosTipoProducto();

            TipoProducto tipoProducto = new TipoProducto(datosTipoProducto);
            Habilitaciones habilitacion = new Habilitaciones(datosHabilitacion);
            Producto producto = new Producto(datosProducto.Item1, datosProducto.Item2, datosProducto.Item3, datosProducto.Item4, datosProducto.Item5, tipoProducto);
            Oferta newOferta = new Oferta(datosOferta, producto, habilitacion);

            this.Empresa.Ofertas.Add(newOferta);
            // TODO: Agregar publicacion a BD.
        }

        /// <summary>
        /// Cambia el estado de la oferta a vendido.
        /// </summary>
        /// <param name="oferta"></param>
        /// <param name="userInterface"></param>
        public void ConcretarOferta(Oferta oferta, IUserInterface userInterface)
        {
            bool isVendido = userInterface.ConcretarOferta(); // (Delegacion y SRP)
            oferta.IsVendido = isVendido;
        }

        /// <summary>
        /// Como empresa, quiero saber todos los materiales o residuos entregados en un período de tiempo, para de esa forma tener un seguimiento de su reutilización.
        /// </summary>
        public void VerificarVentas(IUserInterface userInterface)
        {
            this.Empresa.VerificarVentas(userInterface); // (Delegacion)
        }

        /// <summary>
        /// DEBUG: Setea una empresa al usuario.
        /// </summary>
        /// <param name="empresa"></param>
        public void SetEmpresa(Empresa empresa)
        {
            this.Empresa = empresa;
        }
    }
}