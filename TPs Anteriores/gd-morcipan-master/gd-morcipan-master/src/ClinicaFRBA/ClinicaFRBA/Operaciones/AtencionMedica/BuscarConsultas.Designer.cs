namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    partial class BuscarConsultas
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
            this.dtResultado = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtResultado
            // 
            this.dtResultado.AllowUserToAddRows = false;
            this.dtResultado.AllowUserToDeleteRows = false;
            this.dtResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtResultado.Location = new System.Drawing.Point(13, 13);
            this.dtResultado.Name = "dtResultado";
            this.dtResultado.ReadOnly = true;
            this.dtResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtResultado.Size = new System.Drawing.Size(416, 362);
            this.dtResultado.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(435, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Seleccionar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(435, 184);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BuscarConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 387);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtResultado);
            this.Name = "BuscarConsultas";
            this.Text = "BuscarConsultas";
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtResultado;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSalir;
    }
}