using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class InyeccionDependencias
    {
    }
    // se busca quitar dependencias entre clases


    public class Cantinero
    {
        //public PinaColada pinaColada;
        //public Coctel coctel;

        public IBebida bebida;



        // agregamos al constructor el parámetro interfaz que sería la inyección
        public Cantinero(IBebida pBebida)
        {
            // acá debería usar una interfaz en lugar de una clase para que de desacopple
            //this.pinaColada = new PinaColada();
            //this.coctel = new Coctel();

            // solución: usar interface para abstraer el cógido y que no tengan que modificar Cantinero
            this.bebida = pBebida;
        }

        public void Preparar()
        {
            //this.pinaColada.Preparar();
            this.bebida.Preparar();
        }

    }



    // usando la interfaz como un contrato hacemos que la responsabilidad no sea del cantinero
    // por lo tanto no se modificaría cantinero
    // imagínese si se tratara de 2 conexiones (MySQL y SQL Server) y luego me dicen que habrá 
    // una tercera, simplemente creo una clase para esa conexión que implemente la interfaz y modifico
    // la funcionalidad donde se hace el llamado, en este caso en el método main

    public interface IBebida
    {
        public void Preparar();
    }

    public class PinaColada : IBebida
    {
        public void Preparar()
        {
            Console.WriteLine("Se prepara una piña colada");
        }

    }

    public class Coctel : IBebida
    {
        public string tipo { get; set; }
        public Coctel(string pTipo)
        {
            this.tipo = pTipo;
        }

        public void Preparar()
        {
            Console.WriteLine("Se prepara un coctel  " + tipo);
        }

    }
}
