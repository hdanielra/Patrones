using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesComportamiento
{

    // STRATEGY

    // organiza el comportamiento que va a tener un objeto, puede cambiar dinámicamente en tiempo de ejecución
    // 1. Contexto: Clase por la cual se va a crear el objeto, tiene los métodos que ayudan a seleccionar el comportamiento 
    // 2. Estrategia: 
    // 3. Estrategia Concreta: 

    // A. que se transforme o mute en tiempo de ejecución
    // B. que reciba una opción para que internamente ejecuten una opción u otra

    // Por ejemplo tienes 2 web services (1 rest y el otro soap) la programación es distinta para c/u, pero almacenan en la misma BD
    // Para no meter todo en un solo método, usas 2 métodos con el mismo nombre con este patrón y si se cae un servicio se usa el otro
    

    class Strategy
    {
    }

    // este enum es para la 2da forma de hacer el comportamiento
    enum Comportamiento
    {
        ConquistaxCerveza,
        ConquistaxOjitos,
        ConquistaxGalan

    }


    interface IBorracho
    {
        void Conquistar();
    }

    class EstrategiaOjitos : IBorracho
    {
        public void Conquistar()
        {
            Console.WriteLine("Hacerle ojitos");
        }
    }


    class EstrategiaInvitarCerveza : IBorracho
    {
        public void Conquistar()
        {
            Console.WriteLine("Invitar una cerveza");
        }
    }

    class EstrategiaGalan : IBorracho
    {
        public void Conquistar()
        {
            Console.WriteLine("Hacer cara galán");
        }
    }

    class EstrategiasBorrachoContexto
    {
        private IBorracho oBorracho;


        public EstrategiasBorrachoContexto()
        {
            this.oBorracho = new EstrategiaOjitos(); // por defecto
        }

        // ------ ------ ------ ------ ------ ------ ------ ------
        // instancias por tipo de objeto
        public void EstablecerConquistaOjitos()
        {
            this.oBorracho = new EstrategiaOjitos();
        }
        public void EstablecerConquistaCerveza()
        {
            this.oBorracho = new EstrategiaInvitarCerveza();
        }
        public void EstablecerConquistaGalan()
        {
            this.oBorracho = new EstrategiaGalan();
        }
        // ------ ------ ------ ------ ------ ------ ------ ------


        // 1ra opción de implementar el comportamiento dinámico
        public void ConquistarContexto()
        {
            this.oBorracho.Conquistar();
        }



        // 2da opción de implementar el comportamiento dinámico
        public void ConquistarContexto2(Comportamiento opcion)
        {
            switch (opcion)
            {
                case Comportamiento.ConquistaxCerveza:
                    this.oBorracho = new EstrategiaInvitarCerveza();
                    break;
                case Comportamiento.ConquistaxOjitos:
                    this.oBorracho = new EstrategiaOjitos();
                    break;
                case Comportamiento.ConquistaxGalan:
                    this.oBorracho = new EstrategiaGalan();
                    break;
                    //default:
            }

            this.oBorracho.Conquistar();
        }



    }





}
