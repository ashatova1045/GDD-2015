namespace ClinicaFRBA.Operaciones.AgendaMedico
{
    partial class horarioInicial
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
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxDia = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxMinutos = new System.Windows.Forms.ComboBox();
            this.lblDosPuntos = new System.Windows.Forms.Label();
            this.cBoxHora = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Horario inicial para el dia ";
            // 
            // tBoxDia
            // 
            this.tBoxDia.Enabled = false;
            this.tBoxDia.Location = new System.Drawing.Point(143, 12);
            this.tBoxDia.Name = "tBoxDia";
            this.tBoxDia.ReadOnly = true;
            this.tBoxDia.Size = new System.Drawing.Size(63, 20);
            this.tBoxDia.TabIndex = 13;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(69, 61);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Indique el Horario";
            // 
            // cBoxMinutos
            // 
            this.cBoxMinutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMinutos.FormattingEnabled = true;
            this.cBoxMinutos.Location = new System.Drawing.Point(166, 38);
            this.cBoxMinutos.Name = "cBoxMinutos";
            this.cBoxMinutos.Size = new System.Drawing.Size(38, 21);
            this.cBoxMinutos.TabIndex = 27;
            // 
            // lblDosPuntos
            // 
            this.lblDosPuntos.AutoSize = true;
            this.lblDosPuntos.Location = new System.Drawing.Point(150, 42);
            this.lblDosPuntos.Name = "lblDosPuntos";
            this.lblDosPuntos.Size = new System.Drawing.Size(10, 13);
            this.lblDosPuntos.TabIndex = 26;
            this.lblDosPuntos.Text = ":";
            // 
            // cBoxHora
            // 
            this.cBoxHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxHora.FormattingEnabled = true;
            this.cBoxHora.Location = new System.Drawing.Point(106, 38);
            this.cBoxHora.Name = "cBoxHora";
            this.cBoxHora.Size = new System.Drawing.Size(38, 21);
            this.cBoxHora.TabIndex = 25;
            // 
            // horarioInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 96);
            this.Controls.Add(this.cBoxMinutos);
            this.Controls.Add(this.lblDosPuntos);
            this.Controls.Add(this.cBoxHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tBoxDia);
            this.Controls.Add(this.label1);
            this.Name = "horarioInicial";
            this.Text = "horarioInicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxDia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxMinutos;
        private System.Windows.Forms.Label lblDosPuntos;
        private System.Windows.Forms.ComboBox cBoxHora;

    }
}