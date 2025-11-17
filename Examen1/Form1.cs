using Examen1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen1
{
    public partial class Form1 : Form
    {
        private Arbol miJerarquia;
        private Grafo miMapa;
        public Form1()
        {
            InitializeComponent();

            // Asigna el evento AfterSelect para tu "extra" de colores
            treeViewJerarquia.AfterSelect += treeViewJerarquia_AfterSelect;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //  Cargar Árbol Inicial
            NodoArbol ceo = new NodoArbol("Rommel Muñoz");
            miJerarquia = new Arbol(ceo);

            // Insertamos datos de ejemplo
            miJerarquia.Insertar("Rommel Muñoz", "Ana Pérez");
            miJerarquia.Insertar("Rommel Muñoz", "Luis Gómez");
            miJerarquia.Insertar("Ana Pérez", "Carlos Sánchez");
            miJerarquia.Insertar("Ana Pérez", "María Rodríguez");
            miJerarquia.Insertar("Luis Gómez", "Sofía Fernández");

            // Actualizamos el TreeView visualmente
            CargarTreeView();
            treeViewJerarquia.ExpandAll(); // Expandir todos los nodos

            //  Grafo Inicial
            miMapa = new Grafo();
            miMapa.AgregarArista("Edificio A", "Edificio B", 100);
            miMapa.AgregarArista("Edificio B", "Edificio C", 150);
            miMapa.AgregarArista("Edificio A", "Edificio C", 300); // Ruta larga
            miMapa.AgregarArista("Edificio C", "Edificio D", 50);

            // Llenamos los ComboBox
            foreach (string edificio in miMapa.Adyacencias.Keys)
            {
                cmbInicio.Items.Add(edificio);
                cmbFin.Items.Add(edificio);
            }
        }

        // --- MÉTODO AYUDANTE para (re)cargar el TreeView ---
        // Lo usaremos para refrescar el árbol visual
        private void CargarTreeView()
        {
            treeViewJerarquia.Nodes.Clear(); // Limpiamos el árbol visual
                                             // Creamos el nodo raíz visual
            TreeNode nodoRaizUI = new TreeNode(miJerarquia.Raiz.Valor);
            nodoRaizUI.BackColor = Color.DarkBlue; // Color original (azul)
            nodoRaizUI.ForeColor = Color.White;

            treeViewJerarquia.Nodes.Add(nodoRaizUI);

            // Llamada recursiva para agregar todos los demás nodos
            AgregarNodosHijosUI(miJerarquia.Raiz, nodoRaizUI);
        }

        private void AgregarNodosHijosUI(NodoArbol nodoLogico, TreeNode nodoVisual)
        {
            foreach (NodoArbol hijoLogico in nodoLogico.Hijos)
            {
                TreeNode hijoVisual = new TreeNode(hijoLogico.Valor);
                hijoVisual.BackColor = Color.Green; // Color original (verde)
                hijoVisual.ForeColor = Color.White;

                nodoVisual.Nodes.Add(hijoVisual);

                
                AgregarNodosHijosUI(hijoLogico, hijoVisual);
            }
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            int total = miJerarquia.Contar();
            lblTotal.Text = $"Total de Empleados: {total}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TreeNode nodoJefeUI = treeViewJerarquia.SelectedNode;
            if (nodoJefeUI == null)
            {
                MessageBox.Show("Por favor, seleccione un jefe en el árbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que hay un nombre de empleado
            string nombreNuevo = tbEmpleado.Text;
            if (string.IsNullOrWhiteSpace(nombreNuevo))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el nuevo empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Lógica del Modelo (Añadir al árbol lógico)
            bool exito = miJerarquia.Insertar(nodoJefeUI.Text, nombreNuevo);

            if (exito)
            {
                
                TreeNode nuevoNodoUI = new TreeNode(nombreNuevo);
                nuevoNodoUI.BackColor = Color.Green; // Color por defecto (verde)
                nuevoNodoUI.ForeColor = Color.White;

                nodoJefeUI.Nodes.Add(nuevoNodoUI);
                nodoJefeUI.Expand(); // Expandir el jefe para ver al nuevo
                tbEmpleado.Clear();
            }
            else
            {
                MessageBox.Show("Error: No se pudo encontrar el nodo jefe en la lógica.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreABuscar = tbEmpleado.Text; 

            NodoArbol encontrado = miJerarquia.Buscar(nombreABuscar);

            if (encontrado != null)
            {
                MessageBox.Show($"¡{nombreABuscar} ha sido encontrado!", "Búsqueda exitosa");
                // (Extra) Aquí podrías llamar a un método que expanda y seleccione el nodo en el TreeView
            }
            else
            {
                MessageBox.Show($"'{nombreABuscar}' no se encuentra en la jerarquía.", "Búsqueda fallida");
            }
        }
        private void ResetearColoresDefecto(TreeNodeCollection nodos)
        {
            foreach (TreeNode nodo in nodos)
            {
                // Raíz (Nivel 0)
                if (nodo.Level == 0)
                {
                    nodo.BackColor = Color.DarkBlue;
                    nodo.ForeColor = Color.White;
                }
                // Hijos (Nivel 1+)
                else
                {
                    nodo.BackColor = Color.Green;
                    nodo.ForeColor = Color.White;
                }

                // Llamada recursiva para los hijos de este nodo
                if (nodo.Nodes.Count > 0)
                {
                    ResetearColoresDefecto(nodo.Nodes);
                }
            }
        }
        private void treeViewJerarquia_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 1. Primero, reseteamos TODOS los nodos a sus colores por defecto
            ResetearColoresDefecto(treeViewJerarquia.Nodes);

            // 2. Obtenemos el nodo que acabas de seleccionar
            TreeNode nodoSeleccionado = e.Node;
            if (nodoSeleccionado == null) return;

            // 3. Aplicamos tu nueva lógica de colores SOLO al seleccionado

            // Si es "padre" (tiene hijos) -> Color Rojo
            if (nodoSeleccionado.Nodes.Count > 0)
            {
                nodoSeleccionado.BackColor = Color.Red;
                nodoSeleccionado.ForeColor = Color.White;
            }
            // Si es "hijo" (es un nodo hoja, no tiene hijos) -> Color Azul
            else
            {
                // (Ojo: Azul ya era tu raíz, usemos un azul diferente como 'RoyalBlue')
                nodoSeleccionado.BackColor = Color.RoyalBlue;
                nodoSeleccionado.ForeColor = Color.White;
            }
        }

        private void btnCalcularRuta_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (cmbInicio.SelectedItem == null || cmbFin.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un inicio y un fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string inicio = cmbInicio.SelectedItem.ToString();
            string fin = cmbFin.SelectedItem.ToString();

            if (inicio == fin)
            {
                MessageBox.Show("El inicio y el fin no pueden ser el mismo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Llamar a la Lógica (¡Aquí ocurre la magia!)
            string resultado = miMapa.CalcularRutaDijkstra(inicio, fin);

            // 3. Mostrar resultado en la Vista
            lblRuta.Text = resultado;
        }
    }
    }

