namespace FrbaHotel.Listado_Estadistico
{
    partial class SeleccionDeListado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ano = new System.Windows.Forms.NumericUpDown();
            this.volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trimestre = new System.Windows.Forms.NumericUpDown();
            this.listado = new System.Windows.Forms.DataGridView();
            this.eleccion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mostrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ano)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // ano
            // 
            this.ano.Location = new System.Drawing.Point(44, 12);
            this.ano.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ano.Minimum = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.ano.Name = "ano";
            this.ano.Size = new System.Drawing.Size(48, 20);
            this.ano.TabIndex = 0;
            this.ano.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(474, 2);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(69, 25);
            this.volver.TabIndex = 1;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trimestre";
            // 
            // trimestre
            // 
            this.trimestre.Location = new System.Drawing.Point(196, 12);
            this.trimestre.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.trimestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(30, 20);
            this.trimestre.TabIndex = 4;
            this.trimestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Location = new System.Drawing.Point(15, 90);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.Size = new System.Drawing.Size(528, 108);
            this.listado.TabIndex = 5;
            // 
            // eleccion
            // 
            this.eleccion.FormattingEnabled = true;
            this.eleccion.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas",
            "Hoteles con mayor cantidad de consumibles facturados",
            "Hoteles con mayor cantidad de días fuera de servicio",
            "Habitaciones con mayor cantidad de días y veces que fueron ocupadas",
            "Cliente con mayor cantidad de puntos"});
            this.eleccion.Location = new System.Drawing.Point(93, 54);
            this.eleccion.Name = "eleccion";
            this.eleccion.Size = new System.Drawing.Size(318, 21);
            this.eleccion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lista a mostrar";
            // 
            // mostrar
            // 
            this.mostrar.Location = new System.Drawing.Point(432, 54);
            this.mostrar.Name = "mostrar";
            this.mostrar.Size = new System.Drawing.Size(93, 21);
            this.mostrar.TabIndex = 8;
            this.mostrar.Text = "Mostrar";
            this.mostrar.UseVisualStyleBackColor = true;
            this.mostrar.Click += new System.EventHandler(this.mostrar_Click);
            // 
            // SeleccionDeListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 206);
            this.Controls.Add(this.mostrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eleccion);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.ano);
            this.Name = "SeleccionDeListado";
            this.Text = "Seleccion de listados estadisticos";
            ((System.ComponentModel.ISupportInitialize)(this.ano)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ano;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown trimestre;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.ComboBox eleccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button mostrar;
    }
}