namespace PagoElectronico.Login
{
    partial class SeleccionarRol
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
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(44, 12);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(271, 21);
            this.cbRoles.TabIndex = 0;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(12, 15);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(26, 13);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Rol:";
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Location = new System.Drawing.Point(57, 48);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(92, 26);
            this.btSeleccionar.TabIndex = 2;
            this.btSeleccionar.Text = "Seleccionar";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(204, 48);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(92, 26);
            this.btVolver.TabIndex = 3;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // SeleccionarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 80);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cbRoles);
            this.Name = "SeleccionarRol";
            this.Text = "SeleccionarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.Button btVolver;
    }
}