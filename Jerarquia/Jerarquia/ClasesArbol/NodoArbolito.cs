using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jerarquia.Models
{
    public class NodoArbolito
    {
        public string Valor { get; set; }

        public List<NodoArbolito> Hijos { get; set; }
        public NodoArbolito(string valor)
        {
            Valor = valor;
            Hijos = new List<NodoArbolito>();
        }
    }
}
