# 🚀 Proyecto de Examen: Innovatec Park (Organigrama y Rutas)

Aplicación de escritorio en C# (Windows Forms) que resuelve un caso de estudio para un parque tecnológico. El proyecto implementa estructuras de datos de **Árboles Generales** y **Grafos Ponderados** para gestionar su jerarquía organizativa y sus rutas internas.

## 📋 Caso de Estudio (Problema)

El proyecto aborda dos requerimientos principales del parque "Innovatec Park":

1.  **Gestión de Jerarquía (Árbol):** Modelar la estructura organizativa (jefes, vicepresidentes, gerentes, etc.) mediante una estructura de **Árbol General**, permitiendo agregar, buscar y contar empleados.
2.  **Sistema de Rutas (Grafo):** Calcular la ruta más corta entre los diferentes edificios del parque. Esto se modela como un **Grafo Ponderado**, donde los edificios son los nodos y los caminos (con distancias en metros) son las aristas.

---

## ✨ Características Principales

### 🌳 Pestaña 1: Jerarquía Organizativa (Árbol)

* **Visualización Jerárquica:** Muestra el organigrama completo usando un control `TreeView`.
* **Inserción de Nodos:** Permite agregar nuevos empleados (nodos hijos) bajo un jefe seleccionado (nodo padre).
* **Búsqueda:** Permite buscar a cualquier empleado por nombre en toda la organización.
* **Conteo:** Muestra el número total de empleados en la estructura.
* **Coloreado Dinámico:**
    * **Raíz (CEO):** Color Azul Oscuro (por defecto).
    * **Nodos Hijos:** Color Verde (por defecto).
    * **Nodo Padre Seleccionado:** Color Rojo (al hacer clic).
    * **Nodo Hoja Seleccionado:** Color Azul Real (al hacer clic).

### 🗺️ Pestaña 2: Rutas entre Edificios (Grafo)

* **Selección de Ruta:** Permite al usuario elegir un edificio de **inicio** y **fin** desde menús desplegables.
* **Cálculo de Ruta Más Corta:** Implementa el **algoritmo de Dijkstra** para encontrar el camino con la menor distancia total (en metros).
* **Visualización de Resultados:** Muestra la ruta paso a paso (ej. "Edificio A -> Edificio C -> Edificio D") y la distancia total acumulada.

---

## 🛠️ Stack de Tecnologías

* **Lenguaje:** C# (.NET)
* **Interfaz:** Windows Forms
* **Estructuras de Datos:** Clases personalizadas de Árbol y Grafo (OOP).
* **IDE:** Visual Studio

---

## 📂 Estructura del Proyecto (OOP)

El proyecto está diseñado siguiendo principios de Programación Orientada a Objetos (OOP), separando la lógica de negocio (el "Modelo") de la interfaz de usuario (la "Vista").

* **Clases del Modelo (Lógica):**
    * `NodoArbol.cs`: Representa a un solo empleado (un nodo) con su `Valor` (nombre) y una `List<NodoArbol>` de `Hijos`.
    * `Arbol.cs`: Gestiona toda la jerarquía. Contiene la `Raiz` y los métodos principales: `Insertar()`, `Buscar()` y `Contar()`.
    * `Arista.cs`: Representa una conexión ponderada (un camino). Almacena un `Destino` y un `Peso` (distancia).
    * `Grafo.cs`: Gestiona el mapa de edificios. Usa un `Dictionary<string, List<Arista>>` (Lista de Adyacencia) y contiene los métodos `AgregarArista()` y `CalcularRutaDijkstra()`.
* **Clases de la Vista (UI):**
    * `Form1.cs`: Es el "controlador" que maneja los eventos de los botones y la interacción del usuario. Llama a los métodos de las clases `Arbol` y `Grafo` para realizar el trabajo pesado y luego actualiza la UI.

---

## 🧠 Algoritmos Implementados

### Árbol (Recorridos Recursivos)

* **Inserción y Búsqueda:** Se implementan usando **recorridos recursivos (tipo DFS - Búsqueda en Profundidad)**. Para buscar, se comprueba el nodo actual y luego se llama recursivamente a la función de búsqueda para cada uno de sus hijos hasta encontrar el valor.

### Grafo (Dijkstra vs. BFS)

* **Algoritmo de Dijkstra:** Se eligió este algoritmo para la función principal de "Calcular Ruta" (`btnCalcularRuta_Click`).
    * **Justificación:** El caso de estudio especifica un **grafo ponderado** (con distancias en metros). El algoritmo **BFS** (Búsqueda en Amplitud), aunque solicitado en el *prompt* inicial del usuario, solo encuentra la ruta con menos *paradas* (aristas), ignorando las distancias. **Dijkstra** es el algoritmo correcto y óptimo para garantizar la ruta con la **menor distancia total acumulada**, cumpliendo así con el requisito del problema.
* **BFS (Búsqueda en Amplitud):** El algoritmo BFS es la base para la función "Validar Conectividad" (un requerimiento de la rúbrica), ya que es la forma más rápida de determinar si *existe* un camino entre dos nodos, sin importar el peso.

---

## 🚀 Cómo Usar

1.  Clonar o descargar el repositorio.
2.  Abrir el archivo de solución (`.sln`) con Visual Studio.
3.  Presionar `F5` o el botón "Start" para compilar y ejecutar la aplicación.
4.  **Para el Árbol:**
    * Seleccione un nodo (jefe) en el panel izquierdo.
    * Escriba el nombre del nuevo empleado en el `TextBox`.
    * Haga clic en **"Agregar"**.
5.  **Para el Grafo:**
    * Seleccione un edificio de inicio en el `ComboBox` "Desde".
    * Seleccione un edificio de destino en el `ComboBox` "Hasta".
    * Haga clic en **"Calcular Ruta"**. El resultado aparecerá en el cuadro de texto.




---

## 👨‍💻 Autor

* **Rommel Muñoz**
