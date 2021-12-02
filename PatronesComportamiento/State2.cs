using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesComportamiento
{
    

    // The Context defines the interface of interest to clients. It also
    // maintains a reference to an instance of a State subclass, which
    // represents the current state of the Context.
    class ContextState2
    {
        // A reference to the current state of the Context.
        private State2 _state = null;

        public ContextState2(State2 state)
        {
            this.TransitionTo(state);
        }

        // The Context allows changing the State object at runtime.
        public void TransitionTo(State2 state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }

        // The Context delegates part of its behavior to the current State
        // object.
        public void Request1()
        {
            this._state.Handle1();
        }

        public void Request2()
        {
            this._state.Handle2();
        }
    }

    // The base State class declares methods that all Concrete State should
    // implement and also provides a backreference to the Context object,
    // associated with the State. This backreference can be used by States to
    // transition the Context to another State.
    abstract class State2
    {
        protected ContextState2 _context;

        public void SetContext(ContextState2 context)
        {
            this._context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class ConcreteStateA : State2
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class ConcreteStateB : State2
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStateA());
        }
    }

    class ProgramState
    {
        static void Main_(string[] args)
        {
            // The client code.
            // acá está creando el contexto(objeto) y a su vez está creando el estado (objeto de uno de los estados)
            // 1. en el OBJETO CONTEXTO le asigna el OBJETO ESTADO a través de una propiedad
            // 2. en el OBJETO ESTADO  le asigna el OBJETO CONTEXTO a través de una propiedad
            var context = new ContextState2(new ConcreteStateA());

            // acá internamente envía mensajes usando el OBJETO ESTADO A, y crea un OBJETO ESTADO B, quee es 
            // asociado al contexto y por lo tanto le cambia la propiedad de ESTADO al contexto y ahora es ESTADO B
            // diferente al anterior patrón(mediator) que mantenia asociados todos los objetos en una lista
            // en este caso solo asocia un objeto y lo reemplada cada vez 

            context.Request1();

            // acá ya internamete está usando OBJETO ESTADO B, y envía un mensaje desde B
            context.Request2();
        }
    }


    //Output.txt: Resultado de la ejecución

    //Context: Transition to ConcreteStateA.
    //ConcreteStateA handles request1.
    //ConcreteStateA wants to change the state of the context.
    
    //Context: Transition to ConcreteStateB.

    //ConcreteStateB handles request2.
    //ConcreteStateB wants to change the state of the context.
    //Context: Transition to ConcreteStateA.
}
