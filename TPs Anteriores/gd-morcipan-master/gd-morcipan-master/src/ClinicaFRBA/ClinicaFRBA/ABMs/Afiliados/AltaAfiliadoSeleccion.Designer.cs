namespace ClinicaFRBA.ABMs.Afiliados
{
    partial class AltaAfiliadoSeleccion
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
            this.btnAgregarAfiliado = new System.Windows.Forms.Button();
            this.btnNuevoAfiliado = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarAfiliado
            // 
            this.btnAgregarAfiliado.Location = new System.Drawing.Point(12, 41);
            this.btnAgregarAfiliado.Name = "btnAgregarAfiliado";
            this.btnAgregarAfiliado.Size = new System.Drawing.Size(184, 23);
            this.btnAgregarAfiliado.TabIndex = 1;
            this.btnAgregarAfiliado.Text = "AGREGAR A GRUPO FAMILIAR";
            this.btnAgregarAfiliado.UseVisualStyleBackColor = true;
            this.btnAgregarAfiliado.Click += new System.EventHandler(this.btnAgregarAfiliado_Click);
            // 
            // btnNuevoAfiliado
            // 
            this.btnNuevoAfiliado.Location = new System.Drawing.Point(12, 12);
            this.btnNuevoAfiliado.Name = "btnNuevoAfiliado";
            this.btnNuevoAfiliado.Size = new System.Drawing.Size(184, 23);
            this.btnNuevoAfiliado.TabIndex = 0;
            this.btnNuevoAfiliado.Text = "NUEVO AFILIADO";
            this.btnNuevoAfiliado.UseVisualStyleBackColor = true;
            this.btnNuevoAfiliado.Click += new System.EventHandler(this.btnNuevoAfiliado_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(12, 71);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(184, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "CANCELAR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // AltaAfiliadoSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 104);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevoAfiliado);
            this.Controls.Add(this.btnAgregarAfiliado);
            this.Name = "AltaAfiliadoSeleccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Alta de Afiliado (Selección)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarAfiliado;
        private System.Windows.Forms.Button btnNuevoAfiliado;
        private System.Windows.Forms.Button btnSalir;
    }
}