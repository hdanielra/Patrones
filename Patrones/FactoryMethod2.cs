using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesCreacionales
{
    class FactoryMethod2
    {
        // cuando tienes varios objetos y los cuales heredarán de la misma clase y quieres relevar 
        // la creación de estos para que una clase externa los cree y lleve esa logística
        // un uso serían conexiones a 3 BD, de tal manera que para los programadores sea 
        // invisible esa lógica con la que trabajarán


    }



    // The Creator class declares the factory method that is supposed to return
    // an object of a Product class. The Creator's subclasses usually provide
    // the implementation of this method.


    // OJO: el tipo de instancia/objeto/clase que se debe retornar es: PRODUCTO
    // en este caso se usa en lugar de una clase, un contrato/interfaz: IProducto
    // esa creación del tipo Producto va estar escondida, para lo cual se usa
    // una clase abstracta llamada Creator, que es parecida a un contrato, solo
    // que permite sobreescribir/implementar métodos abstractos en los hijos, y 
    // hay otros métodos que no son abstractos y que los heredan los hijos... pero también es como un contrato
    // dadas estas premisas, hay que crear un método (o dos) que herede de la clase abstract CREATOR
    // e implemente(sobreescriba) explícitamente el método que creará la instancia de tipo PRODUCTO: FactoryMethod()
    // pero como no es una clase PRODUCTO sino una interfaz IPRODUCTO, entonces lo que retorna
    // es otra clase que hereda de la interfaz IPRODUCTO y por lo tanto equivale a un objeto de tipo PRODUCTO
    // esa clase es: ConcreteCreator1... y también ConcreteCreator2,  porque son dos clases que heredan de PRODUCTO
    // en el método MAIN() del programa, puedo crear un método ClientCode(Creator creator), que cuando le pase
    // uno de los dos objetos (new ConcreteCreator1() o new ConcreteCreator2()) los castee automáticamente y use
    // sus respectivas propiedades y métodos 



    // está es una clase abstracta que no se puede instanciar(=new())
    abstract class Creator
    {
        // Note that the Creator may also provide some default implementation of
        // the factory method.


        // está es una clase abstracta que no se puede instanciar(=new() X no) 
        // pero que sí se puede definir un objeto de esta clase que se instancie
        // con una clase que herede de creator:   Creator c = new ConcreteCreator1(); 
        // crean un método abstracto sin implementar usando una interfaz
        // lo que indica que cuando se instancie en una clase que la herede, esa 
        // clase sí tendrá implementado ese método. Pero al final este método
        // lo que hace es simplemente crear una instancia de ConcreteProduct1 o de ConcreteProduct2

        // en resumen: este método retorna un objeto del tipo Producto (que ahora se implemento es con contratos:interfaces)
        public abstract IProduct FactoryMethod();

        // Also note that, despite its name, the Creator's primary
        // responsibility is not creating products. Usually, it contains some
        // core business logic that relies on Product objects, returned by the
        // factory method. Subclasses can indirectly change that business logic
        // by overriding the factory method and returning a different type of
        // product from it.
        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            var product = FactoryMethod();
            // Now, use the product.
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }


    // The Product interface declares the operations that all concrete products
    // must implement.
    public interface IProduct
    {
        string Operation();
    }


    // Concrete Creators override the factory method in order to change the
    // resulting product's type.
    class ConcreteCreator1 : Creator
    {
        // Note that the signature of the method still uses the abstract product
        // type, even though the concrete product is actually returned from the
        // method. This way the Creator can stay independent of concrete product
        // classes.


        // acá está la implementación del método definido en la interfaz
        // este método lo único que hace es crear una instancia de ConcreteProduct1
        // en ConcreteProduct1 se tienen disponibles los métodos implementados del
        // contrato con la interfaz IProduct
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }


    // Concrete Products provide various implementations of the Product
    // interface.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    class Client
    {
        public void Main()
        {


            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }

        // The client code works with an instance of a concrete creator, albeit
        // through its base interface. As long as the client keeps working with
        // the creator via the base interface, you can pass it any creator's
        // subclass.
        public void ClientCode(Creator creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
            // ...
        }
    }

    class ProgramFactory
    {
        static void Main_(string[] args)
        {
            new Client().Main();
        }
    }


    // Output.txt: Resultado de la ejecución
    //App: Launched with the ConcreteCreator1.
    //Client: I'm not aware of the creator's class, but it still works.
    //Creator: The same creator's code has just worked with {Result of ConcreteProduct1}

    //App: Launched with the ConcreteCreator2.
    //Client: I'm not aware of the creator's class, but it still works.
    //Creator: The same creator's code has just worked with {Result of ConcreteProduct2}
}