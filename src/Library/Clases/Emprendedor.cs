using System;
using System.Collections;
using System.Text;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase representa los datos adicionales del emprendedor.
    /// </summary>
    public class Emprendedor
    {
        private ArrayList compras = new ArrayList();

        private ArrayList especializaciones = new ArrayList();

        /// <summary>
        /// Otorga la ubicación del Emprendedor
        /// </summary>
        /// <value>Ubicación del Emprendedor</value>
        public string Ubicacion {get; set;}

        /// <summary>
        /// Otorga una instancia de objeto "Rubro" del Emprendedor
        /// </summary>
        /// <value>Objeto de tipo "Rubro".</value>
        public Rubro Rubro {get; set;}

        /// <summary>
        /// Otorga una instancia de objeto "Habilitaciones" del Emprendedor
        /// </summary>
        /// <value>Objeto de tipo "Habilitaciones".</value>
        public Habilitaciones Habilitacion {get; set;}

        /// <summary>
        /// Otorga una lista de strings que representan las especializaciones del Emprendedor.
        /// </summary>
        /// <value></value>
        public ArrayList Especializaciones {get{return this.especializaciones;}}

        /// <summary>
        /// Otorga una lista de strings que representan las compras del Emprendedor.
        /// </summary>
        /// <value></value>
        public ArrayList Compras {get{return this.compras;}}

        /// <summary>
        /// Inicializa la clase Emprendedor
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        /// <param name="habilitacion"></param>
        public Emprendedor(string ubicacion, Rubro rubro, Habilitaciones habilitacion)
        {
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
            this.Habilitacion = habilitacion;
        }

        /// <summary>
        /// Agrega una habilitacion.
        /// </summary>
        /// <param name="habilitacion"></param>
        public void AgregarHabilitacion(string habilitacion)
        {
            Habilitaciones newHab = new Habilitaciones(habilitacion);
            this.Habilitacion = newHab;
        }

        /// <summary>
        /// Agrega un rubro.
        /// </summary>
        /// <param name="rubro"></param>
        public void AgregarRubro(string rubro)
        {
            Rubro newRubro = new Rubro(rubro);
            this.Rubro = newRubro;
        }

        /// <summary>
        /// Agrega una Especialización al Emprendedor.
        /// </summary>
        public void AgregarEspecializacion(string especializacion)
        {
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Add(especializacion);
        }
        /// <summary>
        /// Elimina una Especialización al Emprendedor.
        /// </summary>
        public void EliminarEspecializacion(string especializacion)
        {
            ArrayList especializaciones = this.Especializaciones;
            especializaciones.Remove(especializacion);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Como emprendedor, quiero saber cuántos materiales o residuos consumí en un período de tiempo, para de esa forma tener un control de mis insumos.
        /// </summary>
        public string ConsumoXTiempo(UserEmprendedor userEmprendedor)
        {
            StringBuilder result = new StringBuilder();
            foreach(Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                if(oferta.IsVendido==true)
                {
                    if(userEmprendedor.Nombre == oferta.Comprador.Nombre)
                    {
                        result.Append($"Compró esta oferta: \n Nombre: {oferta.Product.Nombre} \n Descripción: {oferta.Product.Descripcion} \n Tipo: {oferta.Product.Tipo.Nombre} \n Ubicación: {oferta.Product.Ubicacion} \n Valor: ${oferta.Product.Valor} \n Cantidad: {oferta.Product.Cantidad} \n Habilitaciones requeridas: {oferta.HabilitacionesOferta.Habilitacion} \n");
                    }
                }
            }
            if(result.ToString() == "")
            {
                result.Append("Aún no se ha comprado ningún producto.");
            }
            return result.ToString();
        }
    }
}
