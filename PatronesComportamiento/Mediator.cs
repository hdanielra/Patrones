using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesComportamiento
{

    // en sistemas grandes hay comunicaciones entre objetos y se va haciendo más compleja
    // y necesitas refactorizar el código (optimizarlo), le vas a dar cambios al código y
    // es posible que colapse.
    // cuando se usa mediator, se puede agregar facilidad de modificar los objetos, sin
    // tener problématica (no planeada) con lo que se afecta

    // es un mediador de comunicación entre objetos
    // básicamente es una INTERFACE que contiene un método para tener todos los objetos de
    // tipo COLLEGUE. La comunicación no es directa entre objetos
    // contiene 4 entidades:
    // Mediator, Colleague, ConcreteMediator1...n

    // la interfaz es un medio para comunicar los objetos


    public interface IMediator
    {
        void Send(string message, IColleague colleague);
    }



    //------------------------------------------------------------------------

    public abstract class IColleague
    {
        private IMediator _mediator;

        public IColleague(IMediator mediator)
        {
            this._mediator = mediator;
        }

        //public IMediator Mediator { get => mediator; set => mediator = value; }
        //public IMediator Mediator { get; }
        public IMediator Mediator { get => _mediator; }

        public void Communicate(string message)
        {
            // aca le va a enviar un mensaje a los demás objetos de la lista que está en MEDIATOR
            // y envía como parámetro this, para que ese objeto sea el emisor y los demás los receptores
            this._mediator.Send(message, this);
        }

        public abstract void Recive(string message);

    }

    //------------------------------------------------------------------------

    class Mediator : IMediator
    {
        private List<IColleague> colleagues;

        public Mediator()
        {
            colleagues = new List<IColleague>();
        }

        public void Add(IColleague colleague)
        {
            this.colleagues.Add(colleague);
        }

        public void Send(string message, IColleague colleague)
        {
            foreach (var c in this.colleagues)
            {
                if (colleague != c)
                {
                    c.Recive(message);
                }
            }
        }
    }
    //------------------------------------------------------------------------


    public class UserAdmin : IColleague
    {

        public UserAdmin(IMediator mediator) : base(mediator)
        {

        }
        public override void Recive(string message)
        {
            Console.WriteLine("Al administrador recibe : " + message);
            Console.WriteLine("Se notifica por email");
        }
    }

    //------------------------------------------------------------------------

    public class User : IColleague
    {

        public User(IMediator mediator) : base(mediator)
        {

        }
        public override void Recive(string message)
        {
            Console.WriteLine("Al usuario recibe : " + message);
        }
    }

    //------------------------------------------------------------------------

}
