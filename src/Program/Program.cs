using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            /* Habilitaciones */
            Habilitaciones hab1 = new Habilitaciones("Hab-1");
            Habilitaciones hab2 = new Habilitaciones("Hab-2");
            Habilitaciones hab3 = new Habilitaciones("Hab-3");
            Habilitaciones hab4 = new Habilitaciones("Hab-4");
            Singleton<Datos>.Instance.AgregarHabilitacion(hab1);
            Singleton<Datos>.Instance.AgregarHabilitacion(hab2);
            Singleton<Datos>.Instance.AgregarHabilitacion(hab3);
            Singleton<Datos>.Instance.AgregarHabilitacion(hab4);
            /**/

            /* Rubros */
            Rubro rb1 = new Rubro("Rub-1");
            Rubro rb2 = new Rubro("Rub-2");
            Rubro rb3 = new Rubro("Rub-3");
            Rubro rb4 = new Rubro("Rub-4");
            Singleton<Datos>.Instance.AgregarRubro(rb1);
            Singleton<Datos>.Instance.AgregarRubro(rb2);
            Singleton<Datos>.Instance.AgregarRubro(rb3);
            Singleton<Datos>.Instance.AgregarRubro(rb4);
            /**/

            /* Tipos */
            TipoProducto tipo1 = new TipoProducto("Tipo-1");
            TipoProducto tipo2 = new TipoProducto("Tipo-2");
            TipoProducto tipo3 = new TipoProducto("Tipo-3");
            TipoProducto tipo4 = new TipoProducto("Tipo-4");
            Singleton<Datos>.Instance.AgregarTipo(tipo1);
            Singleton<Datos>.Instance.AgregarTipo(tipo2);
            Singleton<Datos>.Instance.AgregarTipo(tipo3);
            Singleton<Datos>.Instance.AgregarTipo(tipo4);
            /**/

            UserEmprendedor userEE1 = new UserEmprendedor("Juan");
            UserEmpresa userE1 = new UserEmpresa("Pepito");
            UserAdmin userA1 = new UserAdmin("Admin-1");
            Singleton<Datos>.Instance.AgregarUsuarioEmprendedor(userEE1);
            ConsoleInteraction consoleInteraction = new ConsoleInteraction();

            Empresa empresa1 = new Empresa("Empresa", "Ubi", rb1);
            Emprendedor emprendedor1 = new Emprendedor("Av. 8 de Octubre 2738",rb1,hab1);

            userE1.Empresa = empresa1;
            userEE1.Emprendedor = emprendedor1;
            
            Producto newProducto = new Producto("Plastico de Botellas", "Plastico reciclable", "Av3221", 10, 100, tipo1);   
            Oferta newOferta = new Oferta("Plastico de Botellas", newProducto, hab1);
            userE1.Empresa.Ofertas.Add(newOferta);

            userE1.VerificarVentas();

            //userEE1.VerOfertasUbicacion()
            Console.WriteLine(userEE1.VerOfertasUbicacion());

            //userEE1.VerOfertasPalabraClave(string palabraClave)
            userE1.CrearMsjClave(("Plastico de Botellas","TeamSeas"));
            Console.WriteLine(userEE1.VerOfertasPalabraClave("TeamSeas"));

            //userEE1.VerOfertasTipo(string nombreTipo)
            Console.WriteLine(userEE1.VerOfertasTipo("Tipo-1"));

            Producto newProducto1 = new Producto("Plastico de Botellas", "Plastico reciclable", "Av3221", 10, 130, tipo1);   
            Oferta newOferta1 = new Oferta("Plastico de Botellas", newProducto1, hab1);
            userE1.Empresa.Ofertas.Add(newOferta1);

            Producto newProducto2 = new Producto("Meta;", "Plastico reciclable", "Av3221", 10, 400, tipo2);   
            Oferta newOferta2 = new Oferta("Metal", newProducto2, hab1);
            userE1.Empresa.Ofertas.Add(newOferta2);

            Producto newProducto3 = new Producto("Vidrio", "Plastico reciclable", "Av3221", 10, 2, tipo3);   
            Oferta newOferta3 = new Oferta("Vidrio", newProducto3, hab1);
            userE1.Empresa.Ofertas.Add(newOferta3);

            userE1.ConcretarOferta(consoleInteraction.ConcretarOferta(), "Plastico de Botellas", "Juan");
            userE1.ConcretarOferta(consoleInteraction.ConcretarOferta(), "Metal", "Juan");
            userE1.ConcretarOferta(consoleInteraction.ConcretarOferta(), "Vidrio", "Juan");


            Dictionary<string, int> dict = userE1.Empresa.VerificarVentas();
            consoleInteraction.ImprimirVendidos(dict);

            //userEE1.ConsumoXTiempo()
            //Console.WriteLine(userEE1.ConsumoXTiempo());
        }
    }
}