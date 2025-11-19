using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Models
{
    public class Grafo
    {
        
        public Dictionary<string, List<Arista>> Adyacencias { get; set; }

        public Grafo()
        {
            Adyacencias = new Dictionary<string, List<Arista>>();
        }

        

        public void AgregarNodo(string nombre)
        {
            if (!Adyacencias.ContainsKey(nombre))
            {
                
                Adyacencias[nombre] = new List<Arista>();
            }
        }

        public void AgregarArista(string origen, string destino, int peso)
        {
            
            AgregarNodo(origen);
            AgregarNodo(destino);

            
            Adyacencias[origen].Add(new Arista(destino, peso));

            
            Adyacencias[destino].Add(new Arista(origen, peso));
        }

        
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
                    return true; 

                foreach (Arista vecino in Adyacencias[actual])
                {
                    if (!visitados.Contains(vecino.Destino))
                    {
                        visitados.Add(vecino.Destino);
                        cola.Enqueue(vecino.Destino);
                    }
                }
            }
            return false; // No se encontró camino
        }
        
        public string CalcularRutaDijkstra(string inicio, string fin)
        {
            // 1. Inicialización
            var distancias = new Dictionary<string, int>(); // Distancia desde el inicio
            var anteriores = new Dictionary<string, string>(); // Camino para reconstruir
            var colaPrioridad = new List<string>(); 

            foreach (var nodo in Adyacencias.Keys)
            {
                if (nodo == inicio)
                {
                    distancias[nodo] = 0; // Distancia a sí mismo es 0
                }
                else
                {
                    distancias[nodo] = int.MaxValue; // Infinito
                }
                anteriores[nodo] = null;
                colaPrioridad.Add(nodo);
            }

            // 2. Bucle principal del algoritmo
            while (colaPrioridad.Count > 0)
            {
                
                colaPrioridad.Sort((a, b) => distancias[a].CompareTo(distancias[b]));
                string actual = colaPrioridad[0];
                colaPrioridad.RemoveAt(0);

                
                if (actual == fin)
                    break;

                // Si la distancia es infinita, no hay camino
                if (distancias[actual] == int.MaxValue)
                    break;

                
                foreach (var arista in Adyacencias[actual])
                {
                    int nuevaDistancia = distancias[actual] + arista.Peso;

                    if (nuevaDistancia < distancias[arista.Destino])
                    {
                        
                        distancias[arista.Destino] = nuevaDistancia;
                        anteriores[arista.Destino] = actual;
                    }
                }
            }

            
            if (distancias[fin] == int.MaxValue)
            {
                return $"No existe ruta de {inicio} a {fin}.";
            }

            var camino = new Stack<string>();
            string nodoActual = fin;
            while (nodoActual != null)
            {
                camino.Push(nodoActual);
                nodoActual = anteriores[nodoActual];
            }

            // 5. Formatear Salida
            string rutaStr = string.Join(" -> ", camino);
            return $"Ruta más corta: {rutaStr}\nDistancia Total: {distancias[fin]} metros";
        }

    }
}

