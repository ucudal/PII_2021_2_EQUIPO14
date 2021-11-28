using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa al usuario de la Empresa.
    /// La función de esta clase es la de representar a un usuario que interactúa con el sistema que se identifica como empresa. 
    /// Debido a esto, la única responsabilidad de esta clase es la de proveer con un nexo entre las interacciones de usuario y los datos de este usuario, 
    /// los cuales se almacenan en la clase "Empresa" y los accede mediante el patrón de Delegación. Por lo cual también sigue con el patrón SRP.
    /// </summary>
    public class UserEmpresa : IUser
    {
        private bool isInvited = false;
        
        /// <summary>
        /// Otorga el id del usuario.
        /// </summary>
        /// <value>Id del usuario.</value>
        public string Id { get; set; }

        /// <summary>
        /// Obtiene un valor del nombre del usuario empresa.
        /// </summary>
        /// <value>Nombre de la empresa</value>
        public string Nombre { get; set; }
        
        /// <summary>
        /// Obtiene un valor del objeto Empresa.
        /// </summary>
        /// <value>Objeto del tipo Empresa</value>
        public Empresa Empresa { get; set; }

        /// <summary>
        /// Obtiene un valor booleano dependiendo de si la empresa fue invitada o no.
        /// </summary>
        /// <value><c>true/false</c></value>
        public bool IsInvited { get { return isInvited; }  set { this.isInvited = value;} }

        /// <summary>
        /// Constructor vacio utilizado para la serializacion.
        /// </summary>
        [JsonConstructor]
        public UserEmpresa () {}

        /// <summary>
        /// Inicializa la clase UserEmpresa.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public UserEmpresa(string id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        /// <summary>
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro)
        {
            this.Empresa.AgregarRubro(rubro); //(Delegacion)
        }

        /// <summary>
        /// El usuario puede crear la empresa.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        public void CrearEmpresa(string nombre, string ubicacion, string rubro) // (Creator)
        {
            Rubro newRubro = new Rubro(rubro);
            Empresa newEmpresa = new Empresa(nombre, ubicacion, newRubro);

            this.Empresa = newEmpresa;
        }

        /// <summary>
        /// Como empresa, quiero indicar un conjunto de palabras claves asociadas a la publicación de los materiales, para que de esa forma sea más fácil de encontrarlos en las búsquedas que hacen los emprendedores.
        /// </summary>
        /// <param name="oferId"></param>
        /// <param name="palabra"></param>
        public void CrearMsjClave(string oferId, string palabra) 
        {
            this.Empresa.AgregarMsjClave(oferId, palabra); // (Delegacion)
        }

        /// <summary>
        /// Como empresa, quiero publicar una oferta de materiales reciclables o residuos, para que de esa forma los emprendedores que lo necesiten puedan reutilizarlos.
        /// </summary>
        /// <param name="nombreOferta"></param>
        /// <param name="datosHabilitacion"></param>
        /// <param name="isRecurrente"></param>
        /// <param name="nombreProducto"></param>
        /// <param name="descripcionProducto"></param>
        /// <param name="ubicacionProducto"></param>
        /// <param name="valorProducto"></param>
        /// <param name="valorMoneda"></param>
        /// <param name="cantidadProducto"></param>
        /// <param name="datosTipoProducto"></param>
        public void CrearOferta(string nombreOferta, string datosHabilitacion, string isRecurrente, string nombreProducto, string descripcionProducto, string ubicacionProducto, int valorProducto, string valorMoneda, int cantidadProducto, string datosTipoProducto) // (Creator)
        {
            bool recurrencia = false;
            bool isPesos = false;

            if(valorMoneda == "1")
            {
                isPesos = false;
            }
            else
            {
                isPesos = true;
            }

            if(isRecurrente == "1")
            {
                recurrencia = false;
            }
            else
            {
                recurrencia = true;
            }

            Producto producto = this.CrearProducto(nombreProducto, descripcionProducto, ubicacionProducto, valorProducto, isPesos, cantidadProducto, datosTipoProducto);
            Habilitaciones habilitacion = new Habilitaciones(datosHabilitacion);
            Oferta newOferta = new Oferta(nombreOferta, producto, recurrencia, habilitacion);

            this.Empresa.Ofertas.Add(newOferta);
            Singleton<Datos>.Instance.UpdateOfersData();

            this.CrearMsjClave(newOferta.Id,nombreOferta);
            this.CrearMsjClave(newOferta.Id,datosTipoProducto);
            this.CrearMsjClave(newOferta.Id,nombreProducto);
            this.CrearMsjClave(newOferta.Id,Id);

            Console.WriteLine($"Oferta creada:\nNombre: {newOferta.Nombre} \nRecurrencia: {newOferta.IsRecurrente} \n\nProducto:\nNombre: {newOferta.Product.Nombre} \nDescripción: {newOferta.Product.Descripcion} \nTipo: {newOferta.Product.Tipo.Nombre} \nUbicación: {newOferta.Product.Ubicacion} \nValor: {newOferta.Product.MonetaryValue()}{newOferta.Product.Valor} \nCantidad: {newOferta.Product.Cantidad} \nHabilitaciones requeridas: {newOferta.HabilitacionesOferta.Habilitacion}\n");
        }

        /// <summary>
        /// Como empresa, quiero clasificar los materiales o residuos, indicar su cantidad y unidad, el valor (en $ o U$S) de los mismos y el lugar donde se ubican, para que de esa forma los emprendedores tengan información de materiales o residuos disponibles.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="ubicacion"></param>
        /// <param name="valor"></param>
        /// <param name="isPesos"></param>
        /// <param name="cantidad"></param>
        /// <param name="datosTipoProducto"></param>
        /// <returns></returns>
        public Producto CrearProducto(string nombre, string descripcion, string ubicacion, int valor, bool isPesos, int cantidad, string datosTipoProducto) // (Creator)
        {
            TipoProducto newTipoProducto = new TipoProducto(datosTipoProducto);
            Producto newProducto = new Producto(nombre, descripcion, ubicacion, valor, isPesos, cantidad, newTipoProducto);

            return newProducto;
        }

        /// <summary>
        /// Cambia el estado de la oferta especifica a vendido.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="nombreOferta"></param>
        public void ConcretarOferta(string input, string nombreOferta) //(Expert)
        {
            if (input == "Y")
            {
                foreach (Oferta oferta in this.Empresa.Ofertas)
                {
                    if (oferta.Nombre == nombreOferta)
                    {
                        if (oferta.Comprador != null)
                        {
                            oferta.IsVendido = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Como empresa, quiero saber todos los materiales o residuos entregados en un período de tiempo, para de esa forma tener un seguimiento de su reutilización.
        /// </summary>
        /// <returns>Retorna un diccionario con los datos de las ventas</returns>
        public Dictionary<string, int> VerificarVentas()
        {
            return this.Empresa.VerificarVentas(); // (Delegacion)
        }
    }
}