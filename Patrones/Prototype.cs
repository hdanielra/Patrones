using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PatronesCreacionales
{
    public class Prototype
    {

    }


    // CLONACIÓN:

    // - Superficial (Shallow): clona solamente los atributos que son básicos del objeto (int, float, double, string,...).
    //                Los objetos complejos que son hijos de animal, no se clonan 

    // - Profundidad (Deep): clona tanto atributos superficiales como atributos complejos o profundos (atributos tipo objetos...)


    //---------------------------------------------------------------------------------------------------------------------
    // Shallow Copy: copia superficial
    public class Animal : ICloneable
    {

        public int Patas { get; set; }
        public string Nombre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); // MemberwiseClone: crea una copia superficial
        }
    }
    //---------------------------------------------------------------------------------------------------------------------


    //---------------------------------------------------------------------------------------------------------------------
    // Deep Copy: copia profunda
    public class Animal2 : ICloneable
    {

        public int Patas { get; set; }
        public string Nombre { get; set; }

        public Detalles Rasgos { get; set; }

        //public object Clone()
        //{  
        //    return this.MemberwiseClone(); // MemberwiseClone: crea una copia superficial
        //}

        public object Clone()
        {
            // se puede hacer de manera recursiva (por cada objeto) el deep prototype, pero acá se hará fácilmente porque es solo 1

            // para poder hacer más profunda la clonación, debo hacerlo manualmente con el objeto profundo
            Animal2 clonado = this.MemberwiseClone() as Animal2;  // cree un clon superficial de este objeto (no enlazados)
            Detalles detalles = new Detalles(); // cree una referencia entre el objeto profundo de esta clase

            detalles.Color = this.Rasgos.Color;
            detalles.Raza = this.Rasgos.Raza;
            clonado.Rasgos = detalles;


            return clonado;
        }
    }

    public class Detalles
    {
        public string Color { get; set; }
        public string Raza { get; set; }
    }
    //---------------------------------------------------------------------------------------------------------------------


}
