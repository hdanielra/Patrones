using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesCreacionales
{
    class FactoryMethod
    {
        // cuando tienes varios objetos y los cuales heredarán de la misma clase y quieres relevar 
        // la creación de estos para que una clase externa los cree y lleve esa logística
        // un uso serían conexiones a 3 BD, de tal manera que para los programadores sea 
        // invisible esa lógica con la que trabajarán


    }


    // las clases abstractas no pueden crear objetos

    public abstract class BebidaEmbriagante
    {
        public abstract int CuantoMeEmbriagaxHora();
    }

    public class VinoTinto : BebidaEmbriagante
    {
        public override int CuantoMeEmbriagaxHora()
        {
            return 20;
        }
    }

    public class Cerveza : BebidaEmbriagante
    {
        public override int CuantoMeEmbriagaxHora()
        {
            return 5;
        }
    }

    //------------------------------------------------------------------------------------
    public class Creador
    {
        public const int VINO_TINTO = 1;
        public const int CERVEZA = 2;

        public static BebidaEmbriagante CreadorBebida(int pTipo)
        {
            switch (pTipo)
            {
                case VINO_TINTO:
                    return new VinoTinto();

                case CERVEZA:
                    return new Cerveza();

                default:
                    return null;
            }
        }
    }
    //------------------------------------------------------------------------------------


}
