namespace FrbaHotel.Registrar_Consumible
{
    partial class RegistrarConsumible
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
            this.habitacion = new System.Windows.Forms.ComboBox();
            this.reserva = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.consumible = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.NumericUpDown();
            this.registrar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // habitacion
            // 
            this.habitacion.FormattingEnabled = true;
            this.habitacion.Location = new System.Drawing.Point(136, 46);
            this.habitacion.Name = "habitacion";
            this.habitacion.Size = new System.Drawing.Size(134, 21);
            this.habitacion.TabIndex = 0;
            // 
            // reserva
            // 
            this.reserva.FormattingEnabled = true;
            this.reserva.Location = new System.Drawing.Point(136, 12);
            this.reserva.Name = "reserva";
            this.reserva.Size = new System.Drawing.Size(135, 21);
            this.reserva.TabIndex = 1;
            this.reserva.SelectedIndexChanged += new System.EventHandler(this.reserva_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Habitacion";
            // 
            // consumible
            // 
            this.consumible.FormattingEnabled = true;
            this.consumible.Location = new System.Drawing.Point(136, 88);
            this.consumible.Name = "consumible";
            this.consumible.Size = new System.Drawing.Size(134, 21);
            this.consumible.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Consumible";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad";
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(136, 127);
            this.cantidad.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(82, 20);
            this.cantidad.TabIndex = 7;
            // 
            // registrar
            // 
            this.registrar.Location = new System.Drawing.Point(42, 196);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(122, 31);
            this.registrar.TabIndex = 8;
            this.registrar.Text = "Registrar Consumible";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(216, 222);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(67, 32);
            this.volver.TabIndex = 9;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // RegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 266);
            this.Controls.Add(this.registrar);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consumible);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reserva);
            this.Controls.Add(this.habitacion);
            this.Name = "RegistrarConsumible";
            this.Text = "Registrar consumible";
            ((System.ComponentModel.ISupportInitialize)(this.cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox habitacion;
        private System.Windows.Forms.ComboBox reserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox consumible;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantidad;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.Button volver;
    }
}