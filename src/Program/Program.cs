using System;

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

            UserEmpresa userE1 = new UserEmpresa("Pepito");
            UserAdmin userA1 = new UserAdmin("Admin-1");
            ConsoleInteraction consoleInteraction = new ConsoleInteraction();

            //userA1.InvitarEmpresa(userE1, consoleInteraction);
            Empresa empresa = new Empresa("E1", "AsAs", rb4);
            userE1.SetEmpresa(empresa);

            userE1.CrearOferta(consoleInteraction);

            userE1.VerificarVentas(consoleInteraction);

            //userEm1.VerOfertasUbicacion()
            UserEmprendedor userEm1 = new UserEmprendedor("Messi");
            
            Emprendedor emprendedor = new Emprendedor("Gral Urquiza 2784",rb4);
            
            userEm1.SetEmprendedor(emprendedor);

            Console.WriteLine(userEm1.VerOfertasUbicacion());

            foreach (Oferta oferta in Singleton<Datos>.Instance.ListaOfertas())
            {
                userE1.CrearMsjClave(oferta, consoleInteraction);
            }
            Console.WriteLine(userEm1.VerOfertasPalabraClave("Quiero"));
        }
    }
}