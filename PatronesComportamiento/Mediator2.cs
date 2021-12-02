using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesComportamiento
{
    class Mediator2
    {
    }

    // The Mediator interface declares a method used by components to notify the
    // mediator about various events. The Mediator may react to these events and
    // pass the execution to other components.
    public interface IMediator2
    {
        void Notify(object sender, string ev);
    }

    // Concrete Mediators implement cooperative behavior by coordinating several
    // components.
    class ConcreteMediator : IMediator2
    {
        private Component1 _component1;

        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this._component1 = component1;
            this._component1.SetMediator(this);
            this._component2 = component2;
            this._component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                this._component2.DoC();
            }
            if (ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                this._component1.DoB();
                this._component2.DoC();
            }
        }
    }

    // The Base Component provides the basic functionality of storing a
    // mediator's instance inside component objects.
    class BaseComponent
    {
        protected IMediator2 _mediator;

        public BaseComponent(IMediator2 mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator2 mediator)
        {
            this._mediator = mediator;
        }
    }

    // Concrete Components implement various functionality. They don't depend on
    // other components. They also don't depend on any concrete mediator
    // classes.
    class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");

            this._mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            this._mediator.Notify(this, "B");
        }
    }

    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this._mediator.Notify(this, "D");
        }
    }

    class ProgramMediator
    {
        static void Main_(string[] args)
        {
            // The client code.
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();

            // acá usan esta clase ConcreteMediator para enlazar los 2 componentes
            // a su vez funciona como el intermediario (mediator), porque en su constructor
            // usa los dos objetos para autoasociarse a estos
            _ = new ConcreteMediator(component1, component2);

            // cuando el componente hace el llamado a la función, esta usa el objeto
            // mediator para Enviar un mensaje... este mediator conoce los dos objetos
            // simplemente lo que hace es detectar cual objeto ejecuta la función
            // y entonces usa el otro para recibir ese mensaje
            Console.WriteLine("Client triggets operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
    }

    //Output.txt: Resultado de la ejecución
    //Client triggers operation A.
    //Component 1 does A.
    //Mediator reacts on A and triggers following operations:
    //Component 2 does C.

    //Client triggers operation D.
    //Component 2 does D.
    //Mediator reacts on D and triggers following operations:
    //Component 1 does B.
    //Component 2 does C.
}
