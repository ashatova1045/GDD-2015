namespace FrbaHotel.ABM_de_Rol
{
    partial class ABMRolVentanaPrincipal
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
            this.RolCodLabel = new System.Windows.Forms.Label();
            this.ConsignaAbmRolLabel = new System.Windows.Forms.Label();
            this.RolCodTextBox = new System.Windows.Forms.TextBox();
            this.BuscarRolesButton = new System.Windows.Forms.Button();
            this.LimpiarBusquedaButton = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.CrearRolButton = new System.Windows.Forms.Button();
            this.VolverButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreRolTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Rol_Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol_Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RolCodLabel
            // 
            this.RolCodLabel.AutoSize = true;
            this.RolCodLabel.Location = new System.Drawing.Point(13, 18);
            this.RolCodLabel.Name = "RolCodLabel";
            this.RolCodLabel.Size = new System.Drawing.Size(74, 13);
            this.RolCodLabel.TabIndex = 0;
            this.RolCodLabel.Text = "Código de Rol";
            // 
            // ConsignaAbmRolLabel
            // 
            this.ConsignaAbmRolLabel.AutoSize = true;
            this.ConsignaAbmRolLabel.Location = new System.Drawing.Point(9, 18);
            this.ConsignaAbmRolLabel.Name = "ConsignaAbmRolLabel";
            this.ConsignaAbmRolLabel.Size = new System.Drawing.Size(249, 13);
            this.ConsignaAbmRolLabel.TabIndex = 1;
            this.ConsignaAbmRolLabel.Text = "Utilice los filtros para realizar la búsqueda de un Rol";
            // 
            // RolCodTextBox
            // 
            this.RolCodTextBox.Location = new System.Drawing.Point(111, 15);
            this.RolCodTextBox.Name = "RolCodTextBox";
            this.RolCodTextBox.Size = new System.Drawing.Size(118, 20);
            this.RolCodTextBox.TabIndex = 2;
            // 
            // BuscarRolesButton
            // 
            this.BuscarRolesButton.Location = new System.Drawing.Point(111, 76);
            this.BuscarRolesButton.Name = "BuscarRolesButton";
            this.BuscarRolesButton.Size = new System.Drawing.Size(93, 23);
            this.BuscarRolesButton.TabIndex = 3;
            this.BuscarRolesButton.Text = "Buscar ";
            this.BuscarRolesButton.UseVisualStyleBackColor = true;
            this.BuscarRolesButton.Click += new System.EventHandler(this.BuscarRolesButton_Click);
            // 
            // LimpiarBusquedaButton
            // 
            this.LimpiarBusquedaButton.Location = new System.Drawing.Point(224, 76);
            this.LimpiarBusquedaButton.Name = "LimpiarBusquedaButton";
            this.LimpiarBusquedaButton.Size = new System.Drawing.Size(99, 23);
            this.LimpiarBusquedaButton.TabIndex = 4;
            this.LimpiarBusquedaButton.Text = "Limpiar Busqueda";
            this.LimpiarBusquedaButton.UseVisualStyleBackColor = true;
            this.LimpiarBusquedaButton.Click += new System.EventHandler(this.LimpiarBusquedaButton_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AllowUserToResizeColumns = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rol_Cod,
            this.Rol_Nombre,
            this.Rol_Habilitado,
            this.Modificar,
            this.Eliminar});
            this.dgvRoles.Location = new System.Drawing.Point(12, 180);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(544, 160);
            this.dgvRoles.TabIndex = 5;
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);
            // 
            // CrearRolButton
            // 
            this.CrearRolButton.Location = new System.Drawing.Point(436, 54);
            this.CrearRolButton.Name = "CrearRolButton";
            this.CrearRolButton.Size = new System.Drawing.Size(197, 86);
            this.CrearRolButton.TabIndex = 6;
            this.CrearRolButton.Text = "Crear un Nuevo Rol";
            this.CrearRolButton.UseVisualStyleBackColor = true;
            this.CrearRolButton.Click += new System.EventHandler(this.CrearRolButton_Click);
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(546, 358);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(129, 39);
            this.VolverButton.TabIndex = 9;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre del Rol";
            // 
            // nombreRolTextBox
            // 
            this.nombreRolTextBox.Location = new System.Drawing.Point(111, 43);
            this.nombreRolTextBox.Name = "nombreRolTextBox";
            this.nombreRolTextBox.Size = new System.Drawing.Size(119, 20);
            this.nombreRolTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nombreRolTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RolCodTextBox);
            this.panel1.Controls.Add(this.BuscarRolesButton);
            this.panel1.Controls.Add(this.LimpiarBusquedaButton);
            this.panel1.Controls.Add(this.RolCodLabel);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 115);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Para añadir un Rol nuevo, use el botón \"Crear un Nuevo Rol\"";
            // 
            // Rol_Cod
            // 
            this.Rol_Cod.HeaderText = "Código";
            this.Rol_Cod.Name = "Rol_Cod";
            this.Rol_Cod.ReadOnly = true;
            // 
            // Rol_Nombre
            // 
            this.Rol_Nombre.HeaderText = "Nombre";
            this.Rol_Nombre.Name = "Rol_Nombre";
            this.Rol_Nombre.ReadOnly = true;
            // 
            // Rol_Habilitado
            // 
            this.Rol_Habilitado.HeaderText = "Habilitado";
            this.Rol_Habilitado.Name = "Rol_Habilitado";
            this.Rol_Habilitado.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.Text = "M";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "E";
            // 
            // ABMRolVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.CrearRolButton);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.ConsignaAbmRolLabel);
            this.Controls.Add(this.panel1);
            this.Name = "ABMRolVentanaPrincipal";
            this.Text = "Roles";
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RolCodLabel;
        private System.Windows.Forms.Label ConsignaAbmRolLabel;
        private System.Windows.Forms.TextBox RolCodTextBox;
        private System.Windows.Forms.Button BuscarRolesButton;
        private System.Windows.Forms.Button LimpiarBusquedaButton;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button CrearRolButton;
        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreRolTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol_Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol_Habilitado;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;

    }
}