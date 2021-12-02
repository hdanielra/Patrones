using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            EjemploInyeccionD();
        }

        private static void EjemploInyeccionD()
        {
            IBebida oPinaColada = new PinaColada();
            Cantinero oCantinero = new Cantinero(oPinaColada);
            oCantinero.Preparar();

            IBebida oCoctel = new Coctel("con Sal");
            oCantinero = new Cantinero(oCoctel);
            oCantinero.Preparar();


            //Se prepara una piña colada
            //Se prepara un coctel con Sal
        }
    }
}
