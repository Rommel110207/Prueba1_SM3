using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Models
{
    public class Grafo
    {
        // El cerebro del grafo: La Lista de Adyacencia
        // (Un diccionario que mapea un nodo a su lista de aristas/conexiones)
        public Dictionary<string, List<Arista>> Adyacencias { get; set; }

        public Grafo()
        {
            Adyacencias = new Dictionary<string, List<Arista>>();
        }

        // --- Funciones de Construcción ---

        public void AgregarNodo(string nombre)
        {
            if (!Adyacencias.ContainsKey(nombre))
            {
                // Agrega el edificio al diccionario con una lista vacía de conexiones
                Adyacencias[nombre] = new List<Arista>();
            }
        }

        public void AgregarArista(string origen, string destino, int peso)
        {
            // Como es NO DIRIGIDO, la conexión va en ambos sentidos

            // Asegurarse de que ambos nodos existen
            AgregarNodo(origen);
            AgregarNodo(destino);

            // Conexión Origen -> Destino
            Adyacencias[origen].Add(new Arista(destino, peso));

            // Conexión Destino -> Origen
            Adyacencias[destino].Add(new Arista(origen, peso));
        }

        // --- Funciones Requeridas (Algoritmos) ---

        // Rúbrica: "Validar conexidad" -> Se usa BFS
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
                    return true; // ¡Llegamos!

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
            var colaPrioridad = new List<string>(); // Nodos por visitar

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
                // Encontrar el nodo con la menor distancia en la cola
                // (Una cola de prioridad real es más eficiente, pero esto funciona)
                colaPrioridad.Sort((a, b) => distancias[a].CompareTo(distancias[b]));
                string actual = colaPrioridad[0];
                colaPrioridad.RemoveAt(0);

                // Si es el destino, terminamos
                if (actual == fin)
                    break;

                // Si la distancia es infinita, no hay camino
                if (distancias[actual] == int.MaxValue)
                    break;

                // 3. Revisar vecinos
                foreach (var arista in Adyacencias[actual])
                {
                    int nuevaDistancia = distancias[actual] + arista.Peso;

                    if (nuevaDistancia < distancias[arista.Destino])
                    {
                        // Encontramos un camino más corto
                        distancias[arista.Destino] = nuevaDistancia;
                        anteriores[arista.Destino] = actual;
                    }
                }
            }

            // 4. Reconstrucción del Camino
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

