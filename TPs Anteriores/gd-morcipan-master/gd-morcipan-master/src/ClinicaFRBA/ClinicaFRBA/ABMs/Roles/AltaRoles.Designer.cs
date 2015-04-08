namespace ClinicaFRBA.ABMs.Roles
{
    partial class AltaRoles
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
            this.gbDatosRol = new System.Windows.Forms.GroupBox();
            this.chkListFunc = new System.Windows.Forms.CheckedListBox();
            this.lblFunciones = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosRol
            // 
            this.gbDatosRol.Controls.Add(this.chkListFunc);
            this.gbDatosRol.Controls.Add(this.lblFunciones);
            this.gbDatosRol.Controls.Add(this.txtNombre);
            this.gbDatosRol.Controls.Add(this.lblNombre);
            this.gbDatosRol.Location = new System.Drawing.Point(12, 12);
            this.gbDatosRol.Name = "gbDatosRol";
            this.gbDatosRol.Size = new System.Drawing.Size(344, 260);
            this.gbDatosRol.TabIndex = 0;
            this.gbDatosRol.TabStop = false;
            this.gbDatosRol.Text = "Datos del Rol";
            // 
            // chkListFunc
            // 
            this.chkListFunc.FormattingEnabled = true;
            this.chkListFunc.Location = new System.Drawing.Point(22, 75);
            this.chkListFunc.Name = "chkListFunc";
            this.chkListFunc.Size = new System.Drawing.Size(305, 169);
            this.chkListFunc.TabIndex = 22;
            // 
            // lblFunciones
            // 
            this.lblFunciones.AutoSize = true;
            this.lblFunciones.Location = new System.Drawing.Point(19, 58);
            this.lblFunciones.Name = "lblFunciones";
            this.lblFunciones.Size = new System.Drawing.Size(59, 13);
            this.lblFunciones.TabIndex = 21;
            this.lblFunciones.Text = "Funciones:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(72, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(255, 20);
            this.txtNombre.TabIndex = 20;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(19, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 19;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(362, 60);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(362, 31);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AltaRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 293);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbDatosRol);
            this.Name = "AltaRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Alta de Rol";
            this.Load += new System.EventHandler(this.AltaRoles_Load);
            this.gbDatosRol.ResumeLayout(false);
            this.gbDatosRol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosRol;
        private System.Windows.Forms.CheckedListBox chkListFunc;
        private System.Windows.Forms.Label lblFunciones;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;

    }
}