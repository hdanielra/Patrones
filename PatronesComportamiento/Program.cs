using System;
using static PatronesComportamiento.Mediator;

namespace PatronesComportamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            //EjemploStrategy();
            //EjemploMediator();
            EjemploState();

        }

        private static void EjemploState()
        {
            ServerContext oServer = new ServerContext();
            oServer.State = new AvailableServerState();
            oServer.AtenderSolicitud();

            //Respuesta 200(éxito)


            oServer.State = new FallenServerState();
            oServer.AtenderSolicitud();

            //Respuesta 503(Temporalmente no disponible)
        }

        private static void EjemploMediator()
        {
            // cuando se crea una instancia MEDIATOR se crea un objeto lista de ICOLLEAGUES
            // OJO que este objeto mediator enlazará todos los objetos ICOLLEAGUE
            Mediator mediator = new();

            // IColleague (clase ABSTRACTA, no tanto una interfaz) tiene el método
            // COMMUNICATE (implementado) que a su ves invoca al método
            // _MEDIATOR.SEND(MESSAGE, THIS)
            // para nuestro caso THIS será el objeto particular que haya creado (USER O USERADMIN)

            // mediator (instancia de la clase MEDIATOR) tiene el método SEND, y como cada objeto
            // (USER O USERADMIN) tiene su propio objeto mediator,
            // el objeto es el mismo para los dos objetos porque acá abajo
            // en las siguientes líneas se definió así

            // así como cada objeto diferente (pero con la misma interfaz) se enlaza por el mismo MEDIATOR
            // el MEDIATOR a su vez puede guardar cada uno de los objetos en una lista
            // con el fin de usarlos a través de mediator para enviarles mensajes... 
            // como mediator es el mismo para todos y mediator conoce y almacena a su vez 
            // cada objeto, pues les puede enviar mensajes desde el objeto invocado a los demás
            // que es precisamente lo que hace en MEDIATOR.SEND(string message, IColleague colleague)
            // donde recorre su lista de objetos y los compara con collaegue, para que los demás 
            // reciban el mensaje desde el invocado

            IColleague oPepe = new User(mediator);
            IColleague oAdmin1 = new UserAdmin(mediator);
            IColleague oAdmin2 = new UserAdmin(mediator);


            // acá cuando agrego cada obj a la lista, serán utilizados por mediator de manera 
            // que cada objeto (USER O USERADMIN) pueda comunicarse con los otros a
            // través del mismo mediator
            mediator.Add(oPepe);
            mediator.Add(oAdmin1);
            mediator.Add(oAdmin2);

            // ahora haremos que se envíen mensajes entre ellos ... de pepe --> admin
            oPepe.Communicate("Oye admin, te envío un mensaje... desde Pepe");


            //Al administrador recibe: Oye admin, te envío un mensaje... desde Pepe
            //Se notifica por email
            //Al administrador recibe: Oye admin, te envío un mensaje... desde Pepe
            //Se notifica por email

        }

        private static void EjemploStrategy()
        {
            EstrategiasBorrachoContexto oBorracho = new(); // por defecto Ojitos

            // 1a forma
            oBorracho.ConquistarContexto();
            oBorracho.EstablecerConquistaCerveza();
            oBorracho.ConquistarContexto();

            //Hacerle ojitos
            //Invitar una cerveza




            // 2da forma
            oBorracho.ConquistarContexto2(Comportamiento.ConquistaxCerveza);
            oBorracho.EstablecerConquistaCerveza();
            oBorracho.ConquistarContexto2(Comportamiento.ConquistaxOjitos);


            //Invitar una cerveza
            //Hacerle ojitos
        }

    }
}
