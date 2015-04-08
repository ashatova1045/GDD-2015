namespace FrbaHotel.ABM_de_Habitacion
{
    partial class CrearHabitacion
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
            this.PisoHabitacionNuevaLabel = new System.Windows.Forms.Label();
            this.TipoHabitacionNuevaLabel = new System.Windows.Forms.Label();
            this.TipoNuevaHabitacioncomboBox1 = new System.Windows.Forms.ComboBox();
            this.CrearHabitacionBoton = new System.Windows.Forms.Button();
            this.HabitacionNuevaVolverBoton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Frente = new System.Windows.Forms.CheckBox();
            this.habilitada = new System.Windows.Forms.CheckBox();
            this.hotelnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numerotb = new System.Windows.Forms.TextBox();
            this.pisotb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PisoHabitacionNuevaLabel
            // 
            this.PisoHabitacionNuevaLabel.AutoSize = true;
            this.PisoHabitacionNuevaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PisoHabitacionNuevaLabel.Location = new System.Drawing.Point(43, 77);
            this.PisoHabitacionNuevaLabel.Name = "PisoHabitacionNuevaLabel";
            this.PisoHabitacionNuevaLabel.Size = new System.Drawing.Size(35, 17);
            this.PisoHabitacionNuevaLabel.TabIndex = 2;
            this.PisoHabitacionNuevaLabel.Text = "Piso";
            // 
            // TipoHabitacionNuevaLabel
            // 
            this.TipoHabitacionNuevaLabel.AutoSize = true;
            this.TipoHabitacionNuevaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoHabitacionNuevaLabel.Location = new System.Drawing.Point(44, 119);
            this.TipoHabitacionNuevaLabel.Name = "TipoHabitacionNuevaLabel";
            this.TipoHabitacionNuevaLabel.Size = new System.Drawing.Size(36, 17);
            this.TipoHabitacionNuevaLabel.TabIndex = 3;
            this.TipoHabitacionNuevaLabel.Text = "Tipo";
            // 
            // TipoNuevaHabitacioncomboBox1
            // 
            this.TipoNuevaHabitacioncomboBox1.FormattingEnabled = true;
            this.TipoNuevaHabitacioncomboBox1.Location = new System.Drawing.Point(146, 116);
            this.TipoNuevaHabitacioncomboBox1.Name = "TipoNuevaHabitacioncomboBox1";
            this.TipoNuevaHabitacioncomboBox1.Size = new System.Drawing.Size(100, 21);
            this.TipoNuevaHabitacioncomboBox1.TabIndex = 9;
            // 
            // CrearHabitacionBoton
            // 
            this.CrearHabitacionBoton.Location = new System.Drawing.Point(300, 17);
            this.CrearHabitacionBoton.Name = "CrearHabitacionBoton";
            this.CrearHabitacionBoton.Size = new System.Drawing.Size(125, 60);
            this.CrearHabitacionBoton.TabIndex = 10;
            this.CrearHabitacionBoton.Text = "Crear Habitacion";
            this.CrearHabitacionBoton.UseVisualStyleBackColor = true;
            this.CrearHabitacionBoton.Click += new System.EventHandler(this.CrearHabitacionBoton_Click);
            // 
            // HabitacionNuevaVolverBoton
            // 
            this.HabitacionNuevaVolverBoton.Location = new System.Drawing.Point(300, 81);
            this.HabitacionNuevaVolverBoton.Name = "HabitacionNuevaVolverBoton";
            this.HabitacionNuevaVolverBoton.Size = new System.Drawing.Size(125, 60);
            this.HabitacionNuevaVolverBoton.TabIndex = 11;
            this.HabitacionNuevaVolverBoton.Text = "Volver";
            this.HabitacionNuevaVolverBoton.UseVisualStyleBackColor = true;
            this.HabitacionNuevaVolverBoton.Click += new System.EventHandler(this.HabitacionNuevaVolverBoton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Numero";
            // 
            // Frente
            // 
            this.Frente.AutoSize = true;
            this.Frente.Location = new System.Drawing.Point(99, 159);
            this.Frente.Name = "Frente";
            this.Frente.Size = new System.Drawing.Size(56, 17);
            this.Frente.TabIndex = 14;
            this.Frente.Text = "Frente";
            this.Frente.UseVisualStyleBackColor = true;
            // 
            // habilitada
            // 
            this.habilitada.AutoSize = true;
            this.habilitada.Location = new System.Drawing.Point(173, 159);
            this.habilitada.Name = "habilitada";
            this.habilitada.Size = new System.Drawing.Size(73, 17);
            this.habilitada.TabIndex = 15;
            this.habilitada.Text = "Habilitada";
            this.habilitada.UseVisualStyleBackColor = true;
            // 
            // hotelnombre
            // 
            this.hotelnombre.Enabled = false;
            this.hotelnombre.Location = new System.Drawing.Point(146, 12);
            this.hotelnombre.Name = "hotelnombre";
            this.hotelnombre.Size = new System.Drawing.Size(100, 20);
            this.hotelnombre.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hotel";
            // 
            // numerotb
            // 
            this.numerotb.Location = new System.Drawing.Point(146, 39);
            this.numerotb.MaxLength = 18;
            this.numerotb.Name = "numerotb";
            this.numerotb.Size = new System.Drawing.Size(100, 20);
            this.numerotb.TabIndex = 20;
            // 
            // pisotb
            // 
            this.pisotb.Location = new System.Drawing.Point(146, 77);
            this.pisotb.MaxLength = 18;
            this.pisotb.Name = "pisotb";
            this.pisotb.Size = new System.Drawing.Size(100, 20);
            this.pisotb.TabIndex = 21;
            // 
            // CrearHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 214);
            this.Controls.Add(this.pisotb);
            this.Controls.Add(this.numerotb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hotelnombre);
            this.Controls.Add(this.habilitada);
            this.Controls.Add(this.Frente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HabitacionNuevaVolverBoton);
            this.Controls.Add(this.CrearHabitacionBoton);
            this.Controls.Add(this.TipoNuevaHabitacioncomboBox1);
            this.Controls.Add(this.TipoHabitacionNuevaLabel);
            this.Controls.Add(this.PisoHabitacionNuevaLabel);
            this.Name = "CrearHabitacion";
            this.Text = "Crear Una Habitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PisoHabitacionNuevaLabel;
        private System.Windows.Forms.Label TipoHabitacionNuevaLabel;
        private System.Windows.Forms.ComboBox TipoNuevaHabitacioncomboBox1;
        private System.Windows.Forms.Button CrearHabitacionBoton;
        private System.Windows.Forms.Button HabitacionNuevaVolverBoton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Frente;
        private System.Windows.Forms.CheckBox habilitada;
        private System.Windows.Forms.TextBox hotelnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numerotb;
        private System.Windows.Forms.TextBox pisotb;
    }
}