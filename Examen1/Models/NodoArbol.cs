using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Models
{
    public class NodoArbol
    {
        // El dato que guarda, ej: "Gerente de Finanzas"
        public string Valor { get; set; }

        // La lista de nodos que dependen de él
        public List<NodoArbol> Hijos { get; set; }

        // Constructor: Se llama cuando creas un nuevo nodo
        public NodoArbol(string valor)
        {
            Valor = valor;
            Hijos = new List<NodoArbol>(); // Inicia la lista de hijos vacía
        }
    }
}
