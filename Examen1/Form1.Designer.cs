namespace Examen1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbEmpleado = new System.Windows.Forms.TextBox();
            this.treeViewJerarquia = new System.Windows.Forms.TreeView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnContar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmbInicio = new System.Windows.Forms.ComboBox();
            this.cmbFin = new System.Windows.Forms.ComboBox();
            this.btnCalcularRuta = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEmpleado
            // 
            this.tbEmpleado.Location = new System.Drawing.Point(36, 47);
            this.tbEmpleado.Name = "tbEmpleado";
            this.tbEmpleado.Size = new System.Drawing.Size(219, 22);
            this.tbEmpleado.TabIndex = 3;
            // 
            // treeViewJerarquia
            // 
            this.treeViewJerarquia.Location = new System.Drawing.Point(36, 98);
            this.treeViewJerarquia.Name = "treeViewJerarquia";
            this.treeViewJerarquia.Size = new System.Drawing.Size(219, 426);
            this.treeViewJerarquia.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(344, 47);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(174, 67);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(344, 142);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(174, 67);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnContar
            // 
            this.btnContar.Location = new System.Drawing.Point(344, 235);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(174, 67);
            this.btnContar.TabIndex = 7;
            this.btnContar.Text = "Contar";
            this.btnContar.UseVisualStyleBackColor = true;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(363, 355);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 16);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total:";
            // 
            // cmbInicio
            // 
            this.cmbInicio.FormattingEnabled = true;
            this.cmbInicio.Location = new System.Drawing.Point(672, 47);
            this.cmbInicio.Name = "cmbInicio";
            this.cmbInicio.Size = new System.Drawing.Size(121, 24);
            this.cmbInicio.TabIndex = 9;
            // 
            // cmbFin
            // 
            this.cmbFin.FormattingEnabled = true;
            this.cmbFin.Location = new System.Drawing.Point(854, 47);
            this.cmbFin.Name = "cmbFin";
            this.cmbFin.Size = new System.Drawing.Size(121, 24);
            this.cmbFin.TabIndex = 10;
            // 
            // btnCalcularRuta
            // 
            this.btnCalcularRuta.Location = new System.Drawing.Point(1027, 35);
            this.btnCalcularRuta.Name = "btnCalcularRuta";
            this.btnCalcularRuta.Size = new System.Drawing.Size(160, 46);
            this.btnCalcularRuta.TabIndex = 11;
            this.btnCalcularRuta.Text = "Ruta";
            this.btnCalcularRuta.UseVisualStyleBackColor = true;
            this.btnCalcularRuta.Click += new System.EventHandler(this.btnCalcularRuta_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(980, 167);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(35, 16);
            this.lblRuta.TabIndex = 12;
            this.lblRuta.Text = "Ruta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 719);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.btnCalcularRuta);
            this.Controls.Add(this.cmbFin);
            this.Controls.Add(this.cmbInicio);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnContar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.treeViewJerarquia);
            this.Controls.Add(this.tbEmpleado);
            this.Name = "Form1";
            this.Text = "Examen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmpleado;
        private System.Windows.Forms.TreeView treeViewJerarquia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnContar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbInicio;
        private System.Windows.Forms.ComboBox cmbFin;
        private System.Windows.Forms.Button btnCalcularRuta;
        private System.Windows.Forms.Label lblRuta;
    }
}

