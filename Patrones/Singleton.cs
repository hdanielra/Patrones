using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesCreacionales
{


    // Singleton
    // El patrón singleton se utiliza para limitar la creación de una clase a un solo objeto.

    
    
    public class Singleton
    {
        private static Singleton instance = null;
        public string mensaje = "";

        protected Singleton()
        {
            mensaje = "Hola Mundo";
        }


        //Esta es la propiedad que me permite instanciar solo 1 objeto
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }
    }
}
