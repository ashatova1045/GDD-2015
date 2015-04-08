namespace FrbaHotel.Registrar_Estadia
{
    partial class checkin
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
            this.reserva = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Checking = new System.Windows.Forms.Button();
            this.habitaciones = new System.Windows.Forms.CheckedListBox();
            this.volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reserva
            // 
            this.reserva.FormattingEnabled = true;
            this.reserva.Location = new System.Drawing.Point(130, 23);
            this.reserva.Name = "reserva";
            this.reserva.Size = new System.Drawing.Size(110, 21);
            this.reserva.TabIndex = 0;
            this.reserva.SelectedIndexChanged += new System.EventHandler(this.reserva_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reserva";
            // 
            // Checking
            // 
            this.Checking.Location = new System.Drawing.Point(281, 68);
            this.Checking.Name = "Checking";
            this.Checking.Size = new System.Drawing.Size(101, 36);
            this.Checking.TabIndex = 3;
            this.Checking.Text = "Check in";
            this.Checking.UseVisualStyleBackColor = true;
            this.Checking.Click += new System.EventHandler(this.Checking_Click);
            // 
            // habitaciones
            // 
            this.habitaciones.FormattingEnabled = true;
            this.habitaciones.Location = new System.Drawing.Point(120, 68);
            this.habitaciones.Name = "habitaciones";
            this.habitaciones.Size = new System.Drawing.Size(120, 124);
            this.habitaciones.TabIndex = 4;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(291, 158);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(90, 22);
            this.volver.TabIndex = 5;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // checkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 214);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.habitaciones);
            this.Controls.Add(this.Checking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reserva);
            this.Name = "checkin";
            this.Text = "Check In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox reserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Checking;
        private System.Windows.Forms.CheckedListBox habitaciones;
        private System.Windows.Forms.Button volver;
    }
}