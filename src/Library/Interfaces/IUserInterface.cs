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
        /// <returns>Si se acepta la invitacion, devuelve una tupla con los datos de la empresa, si no, devuelve una tupla con strings vacios.</returns>
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
        /// Interactua con el usuario Empresa para agregar una especializacion.
        /// </summary>
        /// <param name="empresa"></param>
        void AgregarEspecializacion(Empresa empresa);
        
        /// <summary>
        /// Interactua con el usuario y le envia un mensaje de aviso que la empresa ya fue invitada y aceptada.
        /// </summary>
        void AlreadyInvitedMsg();

        /// <summary>
        /// Interactua con el usuario para agregar palabras claves a una oferta.
        /// </summary>
        /// <param name="oferta"></param>
        (string, string) AgregarMsjClave();

        /// <summary>
        /// Interactua con el usuario para concretar una oferta.
        /// </summary>
        /// <returns>Retorna <c>true</c> si se concreta la oferta, de lo contrario retorna <c>false</c>.</returns>
        bool ConcretarOferta();
        
        /// <summary>
        /// Imprime en consola los materiales y la cantidad vendida a lo largo de la historia.
        /// </summary>
        /// <param name="item"></param>
        void ImprimirVendidos(KeyValuePair<string, int> item);

        /// <summary>
        /// Interactua con el usuario para registrarse como emprendedor.
        /// </summary>
        void RegistrarEmprendedor();
    }
}