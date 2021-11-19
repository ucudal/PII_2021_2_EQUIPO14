namespace Proyecto_Final
{
    /// <summary>
    /// Esta clase tiene como función funcionar como base para crear una sola instancia de clases almacenadoras de datos en el programa.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Singleton<T> where T : new()
    {
    
        private static T instance;
        /// <summary>
        /// Otorga una instancia de la clase que sea Singleton.
        /// </summary>
        /// <value><c>true</c>Crea una instancia de la clase Singleton y la retorna,<c>false</c> solo retorna la instancia de clase ya existente.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}