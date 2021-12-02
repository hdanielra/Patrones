using System;

namespace PatronesEstructurales
{
    class Program
    {
        static void Main(string[] args)
        {
            EjemploComposite();
        }

        private static void EjemploComposite()
        {
            Ingrediente oIngrediente1 = new Ingrediente("Harina", 100, 200, "gramos");
            Ingrediente oIngrediente2 = new Ingrediente("Leche", 20, 1, "kilo");
            Ingrediente oIngrediente3 = new Ingrediente("Huevo", 30, 1, "kilo");

            PastelComposite oPastel = new PastelComposite("Pastel de Leche");
            oPastel.Add(oIngrediente1);
            oPastel.Add(oIngrediente2);
            oPastel.Add(oIngrediente3);


            Ingrediente oIngrediente4 = new Ingrediente("Chocolate", 200, 1, "litro");
            PastelComposite oPastel2 = new PastelComposite("Pastel de Chocolate y Leche");
            // agregué 1 ingrediente
            oPastel2.Add(oIngrediente4);
            // agregué 1 compuesto
            oPastel2.Add(oPastel);


            Console.WriteLine(oPastel2.CostoTotal);

            // 350

        }

    }
}
