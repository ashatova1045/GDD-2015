namespace PagoElectronico.Login
{
    partial class SeleccionarFuncionalidad
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
            this.btVolver = new System.Windows.Forms.Button();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.lbFuncionalidad = new System.Windows.Forms.Label();
            this.cbFuncionalidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(227, 50);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(92, 26);
            this.btVolver.TabIndex = 7;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Location = new System.Drawing.Point(80, 50);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(92, 26);
            this.btSeleccionar.TabIndex = 6;
            this.btSeleccionar.Text = "Seleccionar";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // lbFuncionalidad
            // 
            this.lbFuncionalidad.AutoSize = true;
            this.lbFuncionalidad.Location = new System.Drawing.Point(11, 15);
            this.lbFuncionalidad.Name = "lbFuncionalidad";
            this.lbFuncionalidad.Size = new System.Drawing.Size(76, 13);
            this.lbFuncionalidad.TabIndex = 5;
            this.lbFuncionalidad.Text = "Funcionalidad:";
            // 
            // cbFuncionalidad
            // 
            this.cbFuncionalidad.FormattingEnabled = true;
            this.cbFuncionalidad.Location = new System.Drawing.Point(93, 12);
            this.cbFuncionalidad.Name = "cbFuncionalidad";
            this.cbFuncionalidad.Size = new System.Drawing.Size(271, 21);
            this.cbFuncionalidad.TabIndex = 4;
            // 
            // SeleccionarFuncionalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 88);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.lbFuncionalidad);
            this.Controls.Add(this.cbFuncionalidad);
            this.Name = "SeleccionarFuncionalidad";
            this.Text = "SeleccionarFuncionalidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.Label lbFuncionalidad;
        private System.Windows.Forms.ComboBox cbFuncionalidad;
    }
}