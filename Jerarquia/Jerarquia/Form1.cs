using Jerarquia.ClasesGrafo;
using Jerarquia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jerarquia
{
    public partial class Form1 : Form
    {
        //Crea los objetos "cerebro"
        private Arbol miJerarquia;
        private ClasesGrafo.Grafo miGrafo;
        public Form1()
        {
            InitializeComponent();
            NodoArbolito ceo = new NodoArbolito("Presidente ");
            miJerarquia = new Arbol(ceo);

            miJerarquia.Insertar("Presidente ", "Gerente de Ventas");

            //Incializa el grafo
            miGrafo = new ClasesGrafo.Grafo();

            //Agregar los edificios como nodos

            miGrafo.AgregarNodo("Edificio A ");
            miGrafo.AgregarNodo("Edificio B ");
            miGrafo.AgregarNodo("Edificio C ");

            //Agregar las conexiones entre los edificios como aristas

            miGrafo.AgregarArista("Edificio A ", "Edificio B ", 100);
            miGrafo.AgregarArista("Edificio B ", "Edificio C ", 150);
            miGrafo.AgregarArista("Edificio A ", "Edificio C ", 300);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
