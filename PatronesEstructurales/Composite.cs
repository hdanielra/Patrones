using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesEstructurales
{
    // COMPOSITE

    // en español COMPUESTO, sirve para resolver problemas que se parecen
    // pero esos problemas a su vez construyen cosas más grandes que son
    // compuestas que también se parecen 

    // Ej: venta productos (precio marca nombre), pero se venden KITs
    // o paquetes compuestos por varios productos (precio marca nombre)
    // o en manufactura, que un producto final está compuesto de produtos o
    // materiales 


    // COMPONENT
    // LEAF: hereda de COMPONENT. Contiene los elementos mínimas 
    // COMPOSITE: hereda de COMPONENT. Tiene también lo mismo que contiene LEAF
    // pero además contiene una lista de LEAF

    class Composite
    {
    }

    public abstract class Component
    {
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        public Component(string pNombre, decimal pCosto)
        {
            this.Nombre = pNombre;
            this.Costo = pCosto;
        }
    }




    class Ingrediente : Component
    {
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public Ingrediente(string pNombre, decimal pCosto, int pCantidad, string pUnidad) :
            base(pNombre, pCosto)
        {
            this.Cantidad = pCantidad;
            this.Unidad = pUnidad;
        }
    }


    class PastelComposite : Component
    {

        private List<Component> ingredientes = new List<Component>();

        public void Add(Component pElemento)
        {
            ingredientes.Add(pElemento);
        }
        public void Remove(Component pElemento)
        {
            ingredientes.Remove(pElemento);
        }

        public decimal CostoTotal
        {
            get
            {
                decimal costo = 0;
                foreach (var oElemento in ingredientes)
                {
                    //if (oElemento.GetType().Name == "PastelComposite")
                    if (oElemento.GetType().Name == this.GetType().Name)
                        costo += ((PastelComposite)oElemento).CostoTotal;
                    else
                        costo += oElemento.Costo;
                }
                return costo;
            }
        }

        public PastelComposite(string pNombre, decimal pCosto = 0) : base(pNombre, pCosto)
        {

        }
    }

}
