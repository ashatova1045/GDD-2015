namespace FrbaHotel.Cancelar_Reserva
{
    partial class CancelarReserva
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNReserva = new System.Windows.Forms.Label();
            this.txtNReserva = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.comboopciones = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(271, 164);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 33;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNReserva
            // 
            this.lblNReserva.AutoSize = true;
            this.lblNReserva.Location = new System.Drawing.Point(13, 22);
            this.lblNReserva.Name = "lblNReserva";
            this.lblNReserva.Size = new System.Drawing.Size(105, 13);
            this.lblNReserva.TabIndex = 34;
            this.lblNReserva.Text = "Numero de Reserva:";
            // 
            // txtNReserva
            // 
            this.txtNReserva.Location = new System.Drawing.Point(124, 19);
            this.txtNReserva.Name = "txtNReserva";
            this.txtNReserva.Size = new System.Drawing.Size(126, 20);
            this.txtNReserva.TabIndex = 35;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(273, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(13, 77);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(118, 13);
            this.lblMotivo.TabIndex = 37;
            this.lblMotivo.Text = "Motivo de cancelacion:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(137, 74);
            this.txtMotivo.MaxLength = 100;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(211, 20);
            this.txtMotivo.TabIndex = 38;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 164);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar Reserva";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboopciones
            // 
            this.comboopciones.FormattingEnabled = true;
            this.comboopciones.Items.AddRange(new object[] {
            "Reserva cancelada por Recepción",
            "Reserva cancelada por Cliente",
            "Reserva cancelada por No-Show"});
            this.comboopciones.Location = new System.Drawing.Point(12, 101);
            this.comboopciones.Name = "comboopciones";
            this.comboopciones.Size = new System.Drawing.Size(334, 21);
            this.comboopciones.TabIndex = 44;
            this.comboopciones.Visible = false;
            // 
            // CancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 199);
            this.Controls.Add(this.comboopciones);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNReserva);
            this.Controls.Add(this.lblNReserva);
            this.Controls.Add(this.btnVolver);
            this.Name = "CancelarReserva";
            this.Text = "Cancelar Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNReserva;
        private System.Windows.Forms.TextBox txtNReserva;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboopciones;
    }
}