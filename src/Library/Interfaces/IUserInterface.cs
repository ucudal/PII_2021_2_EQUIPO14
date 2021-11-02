using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta interface permite implementar distintas formas de que el usuario interactue con el bot.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Interactua con el usuario para crear una oferta.
        /// </summary>
        /// <returns><c>string</c></returns>
        string CrearOferta();

        /// <summary>
        /// Interactua con el usuario para aceptar la invitacion.
        /// </summary>
        /// <returns>Si se acepta la invitacion, devuelve una "Y", si no, devuelve una "N".</returns>
        string AceptarInvitacion();
        
        /// <summary>
        /// Interactua con el usuario para crear los datos respectivos de la empresa.
        /// </summary>
        /// <returns>Tupla de strings con los datos de la empresa.</returns>
        (string, string, string) CrearDatosEmpresa();

        /// <summary>
        /// Interactua con el usuario para poder crear los datos de la habilitacion.
        /// </summary>
        /// <returns>Habilitacion.</returns>
        string CrearDatosHabilitacion();

        /// <summary>
        /// Interactua con el usuario para poder crear los datos del producto.
        /// </summary>
        /// <returns>Nombre, descripcion, ubicacion, valor y cantidad del producto.</returns>
        (string, string, string, int, int) CrearDatosProducto();

        /// <summary>
        /// Interactua con el usuario para crear los datos de la publicacion.
        /// </summary>
        /// <returns>Nombre de la publicacion</returns>
        string CrearDatosOferta();

        /// <summary>
        /// Interactua con el usuario para crear los datos del tipo de producto.
        /// </summary>
        /// <returns>Tipo de producto</returns>
        string CrearDatosTipoProducto();
        
        /// <summary>
        /// Interactua con el usuario para agregar palabras claves a una oferta.
        /// </summary>
        /// <returns></returns>
        (string, string) AgregarMsjClave();

        /// <summary>
        /// Interactua con el usuario para concretar una oferta.
        /// </summary>
        /// <returns>Retorna <c>true</c> si se concreta la oferta, de lo contrario retorna <c>false</c>.</returns>
        string ConcretarOferta();
        
        /// <summary>
        /// Imprime en consola los materiales y la cantidad vendida a lo largo de la historia.
        /// </summary>
        /// <param name="item"></param>
        void ImprimirVendidos(Dictionary<string, int> item);
    }
}