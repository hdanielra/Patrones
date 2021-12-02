using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesCreacionales
{


    // Singleton
    // El patrón singleton se utiliza para limitar la creación de una clase a un solo objeto.
    // OJO: se usa la clase SEALED:SELLADA y el constructor PRIVADO
    // Una sealed class o clase sellada es aquella de la cual no podemos heredar.Lo que quiere decir que
    // no podemos implementara en otras clases para tener acceso a sus miembros.
    // Un constructor privado previene la creación de instancias a traves del constructor:New ___()
    //----------------------------------------------------------------------------------------



    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.

    // EN : The Singleton should always be a 'sealed' class to prevent class
    // inheritance through external classes and also through nested classes.

    // Una sealed class o clase sellada es aquella de la cual no podemos heredar.Lo que quiere decir que
    // no podemos implementara en otras clases para tener acceso a sus miembros.
    public sealed class Singleton2
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton2() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton2 _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Singleton2 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton2();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public static void someBusinessLogic()
        {
            // ...
        }
    }

    class ProgramSingleton
    {
        static void Main_(string[] args)
        {
            // The client code.
            Singleton2 s1 = Singleton2.GetInstance();
            Singleton2 s2 = Singleton2.GetInstance();
            //Singleton2 s = new Singleton2();              // como el constructor es privado, no se puede crear el objeto llamando al constructor

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
        }
    }

    // Output.txt: Resultado de la ejecución
    // Singleton works, both variables contain the same instance.
}
