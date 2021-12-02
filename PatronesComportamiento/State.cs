using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesComportamiento
{

    // STATE

    // sirve para solucionar algún comportamiento
    // es una abstracción del estado de un objeto (recuerda el enum) pero cuando
    // el estado afecta el comportamiento del mismo objeto, se pone más commplejo el tema

    // CONTEXTO: objeto que va a cambiar de estado
    // STATE: interfaz o clase abstracta, manejará el comportamiento dependiento del estado
    // CONCRETESTATE: una clase que implementa o hereda de la interfaz o la clase abstracta

   public abstract class IServerState 
    {
        public abstract void Respuesta();

    }


    public class ServerContext
    {
        // este será el objeto de tipo interfaz que variará dependiento de la clase
        // que herede de la interfaz/clase abstracta: IServerState 
        private IServerState state;

        public IServerState State { get => state; set => state = value; }

        public void AtenderSolicitud()
        {
            state.Respuesta();
        }
    }

    public class AvailableServerState : IServerState
    {
        public override void Respuesta()
        {
            Console.WriteLine("Respuesta 200(éxito)");
        }
    }
    public class SaturatedServerState : IServerState
    {
        public override void Respuesta()
        {
            Task.Delay(500);
            Console.WriteLine("Respuesta 200(éxito)");
        }
    }
    public class SuperSaturatedServerState : IServerState
    {
        public override void Respuesta()
        {
            Task.Delay(1000);
            Console.WriteLine("Respuesta 200(éxito)");
        }
    }

    public class FallenServerState : IServerState
    {
        public override void Respuesta()
        {
            Console.WriteLine("Respuesta 503(Temporalmente no disponible)");
        }
    }

}
