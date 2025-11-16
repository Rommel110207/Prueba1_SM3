using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jerarquia.Models
{
    public class Arbol
    {
        // Propiedad que representa la raíz del árbol
        public NodoArbolito Raiz { get; set; }



        public Arbol(NodoArbolito raiz)
        {
            Raiz = raiz;
        }

        

        public NodoArbolito Buscar(string valor)
        {
            return BuscarRecursivo(Raiz, valor);

        }
        private NodoArbolito BuscarRecursivo(NodoArbolito nodoActual, string valor)
        {

            if (nodoActual == null) return null;

            if (nodoActual.Valor == valor) return nodoActual;

            foreach (NodoArbolito hijo in nodoActual.Hijos)
            {
                NodoArbolito resultado = BuscarRecursivo(hijo, valor);
                if (resultado != null) return resultado;
            }
            return null; // No se encontró el nodo
        }
        public bool Insertar(string valorPadre, string valorNuevo)
        {
            NodoArbolito nodoPadre = Buscar(valorPadre);
            if (nodoPadre != null)
            {
                NodoArbolito nuevoNodo = new NodoArbolito(valorNuevo);
                nodoPadre.Hijos.Add(nuevoNodo);
                return true; // Inserción exitosa
            }
            return false; // Nodo padre no encontrado

        }
        public int Contar()
        {
           return ContarRecusivo(Raiz);

        }
        private int ContarRecusivo(NodoArbolito nodoActual)
        {
            if (nodoActual == null) return 0;

            int total = 1;
            foreach (NodoArbolito hijo in nodoActual.Hijos)
            {
                total += ContarRecusivo(hijo);
            }
            return total;

        }


        }
}
