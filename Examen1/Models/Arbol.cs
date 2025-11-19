using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Models
{
    public class Arbol
    {
        public NodoArbol Raiz { get; set; }

        public Arbol(NodoArbol raiz)
        {
            Raiz = raiz;
        }

        // --- Funciones Requeridas ---

        // Método para buscar un nodo en todo el árbol
        // (Usa recursividad)
        public NodoArbol Buscar(string valor)
        {
            return BuscarRecursivo(Raiz, valor);
        }

        private NodoArbol BuscarRecursivo(NodoArbol nodoActual, string valor)
        {
            if (nodoActual == null)
                return null; // No se encontró

            if (nodoActual.Valor == valor)
                return nodoActual; 

            
            foreach (NodoArbol hijo in nodoActual.Hijos)
            {
                NodoArbol encontrado = BuscarRecursivo(hijo, valor);
                if (encontrado != null)
                    return encontrado; 
            }

            return null; // No se encontró en esta rama
        }

       
        public bool Insertar(string valorPadre, string valorNuevo)
        {
            // 1. Encontrar al jefe (nodo padre)
            NodoArbol padre = Buscar(valorPadre);

            if (padre != null)
            {
                
                NodoArbol nuevoNodo = new NodoArbol(valorNuevo);

                
                padre.Hijos.Add(nuevoNodo);
                return true; // Éxito
            }

            return false; 
        }

        // Método para contar todos los nodos (empleados)
        public int Contar()
        {
            return ContarRecursivo(Raiz);
        }

        private int ContarRecursivo(NodoArbol nodoActual)
        {
            if (nodoActual == null)
                return 0;

            int total = 1; // Contarse a sí mismo
            foreach (NodoArbol hijo in nodoActual.Hijos)
            {
                total += ContarRecursivo(hijo); // Sumar los de sus hijos
            }
            return total;
        }
    }
}
