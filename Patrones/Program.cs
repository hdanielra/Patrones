using System;

namespace PatronesCreacionales
{
    class Program
    {
        static void Main(string[] args)
        {
            //EjemploSingleton();
            //EjemploPrototipo("SUPERFICIAL");
            //EjemploPrototipo("PROFUNDIDAD");
            //EjemploFactory();
            new Client().Main();

        }

        private static void EjemploFactory()
        {
            // acá se usa el patrón, simplemente uso una clase creadora que internamente sabe qué debe hacer y para mi es invisible
            BebidaEmbriagante oBebida = Creador.CreadorBebida(Creador.VINO_TINTO);
            Console.WriteLine(oBebida.CuantoMeEmbriagaxHora());
        }

        private static void EjemploPrototipo(string pTipo)
        {
            switch (pTipo)
            {
                case "SUPERFICIAL":
                    //----------------------------------------------------------------------------
                    // Shallow prototype 

                    Animal oAnimal = new Animal() { Nombre = "Oveja", Patas = 4 };
                    Animal oAnimalClonado = oAnimal;  // crea una referencia/enlace entre los 2 objetos, si se modifica 1 el otro también se modifica del mismo modo
                    oAnimalClonado.Patas = 5;
                    Console.WriteLine(oAnimal.Patas);         // imprime 5
                    Console.WriteLine(oAnimalClonado.Patas);  // imprime 5 

                    //---

                    oAnimal.Patas = 4;
                    //Animal oAnimalClonado2 = (Animal)oAnimal.Clone(); // conversión explicita 
                    Animal oAnimalClonado2 = oAnimal.Clone() as Animal; // conversión explicita. se crea una copia superficial. si se modifica un objeto el otro no, porque no están enlazados
                    oAnimalClonado2.Patas = 5;
                    Console.WriteLine(oAnimal.Patas);         // imprime 4
                    Console.WriteLine(oAnimalClonado2.Patas);  // imprime 5 

                    //----------------------------------------------------------------------------
                    break;


                default: // PROFUNDIDAD

                    //----------------------------------------------------------------------------
                    // Deep prototype 

                    Animal2 oAnimal2 = new Animal2() { Nombre = "Oveja Dolly", Patas = 4 };
                    oAnimal2.Rasgos = new Detalles();
                    oAnimal2.Rasgos.Color = "Blanca";
                    oAnimal2.Rasgos.Raza = "Oveja B";

                    Animal2 oAnimal2Clonado = (Animal2)oAnimal2.Clone();
                    oAnimal2Clonado.Rasgos.Color = "Negra";
                    oAnimal2Clonado.Rasgos.Raza = "Oveja N";
                    oAnimal2Clonado.Nombre = "Oveja Lara";

                    //// los atributos profundos no se clonaron, sino que se referenciaron... por eso si cambia uno el otro también
                    //Console.WriteLine("oAnimal2.Rasgos.Color: " + oAnimal2.Rasgos.Color);               // imprime "Negra"
                    //Console.WriteLine("oAnimal2Clonado.Rasgos.Color: " + oAnimal2Clonado.Rasgos.Color); // imprime "Negra" 

                    //// los atributos superficiales sí cambian
                    //Console.WriteLine("oAnimal2.Nombre: " + oAnimal2.Nombre);                           // imprime "Oveja Dolly"
                    //Console.WriteLine("oAnimal2Clonado.Nombre: " + oAnimal2Clonado.Nombre);             // imprime "Oveja Lara" 


                    // el atributo profundo se clonó directamente en la clase y luego se modificó el método de
                    // clonar para que retornara un clon con el atributo clonado también 
                    Console.WriteLine("oAnimal2.Rasgos.Color: " + oAnimal2.Rasgos.Color);               // imprime "Blanca"
                    Console.WriteLine("oAnimal2Clonado.Rasgos.Color: " + oAnimal2Clonado.Rasgos.Color); // imprime "Negra" 

                    // los atributos superficiales sí cambian
                    Console.WriteLine("oAnimal2.Nombre: " + oAnimal2.Nombre);                           // imprime "Oveja Dolly"
                    Console.WriteLine("oAnimal2Clonado.Nombre: " + oAnimal2Clonado.Nombre);             // imprime "Oveja Lara" 

                    //----------------------------------------------------------------------------

                    break;
            }
        }





        private static void EjemploSingleton()
        {
            //----------------------------------------------------------------------------
            // singleton

            Console.WriteLine(Singleton.Instance.mensaje);
            Singleton.Instance.mensaje = "Modificado";
            Console.WriteLine(Singleton.Instance.mensaje);

            //----------------------------------------------------------------------------

        }
    }
}
