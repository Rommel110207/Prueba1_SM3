using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jerarquia.ClasesGrafo
{
    public class Aristas
    {
        public string Destino { get; set; }
        public int Peso { get; set; }

        public Aristas(string destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }
}
