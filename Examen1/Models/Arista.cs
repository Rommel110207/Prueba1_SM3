using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Models
{
    public class Arista
    {
        public string Destino { get; set; } // El nodo al que se conecta
        public int Peso { get; set; }      // La distancia (ponderación)

        public Arista(string destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}

