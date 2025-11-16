using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jerarquia.ClasesGrafo
{
    public class Grafo
    {

        public Dictionary<string, List<Aristas>> Adyacencias { get; set; }

        public Grafo()
        {
            Adyacencias = new Dictionary<string, List<Aristas>>();
        }

        public void AgregarNodo(string nombre)
        {
            if (!Adyacencias.ContainsKey(nombre))
            {
                Adyacencias[nombre] = new List<Aristas>();
            }
        }
        public void AgregarArista(string origen, string destino, int peso)
        {
            AgregarNodo(origen);
            AgregarNodo(destino);

            //Origen > Destino
            Adyacencias[origen].Add(new Aristas(destino, peso));

            //Destino > Origen
            Adyacencias[destino].Add(new Aristas(origen, peso));

        }
        //BFS
        public bool ExisteCaminoBFS(string inicio, string fin)
        {
            Queue<string> cola = new Queue<string>();
            HashSet<string> visitados = new HashSet<string>();

            cola.Enqueue(inicio);
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                string actual = cola.Dequeue();
                if (actual == fin)
                {
                    return true;
                }
                foreach (var arista in Adyacencias[actual])
                {
                    if (!visitados.Contains(arista.Destino))
                    {
                        visitados.Add(arista.Destino);
                        cola.Enqueue(arista.Destino);
                    }
                }
            }
            return false;
        }
    }
}
