namespace ClinicaFRBA.Operaciones.Turnos
{
    partial class BuscarProfesional
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.tBoxNombre = new System.Windows.Forms.TextBox();
            this.tBoxApellido = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgProfesionales = new System.Windows.Forms.DataGridView();
            this.cIdProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccionProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(17, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(287, 28);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // tBoxNombre
            // 
            this.tBoxNombre.Location = new System.Drawing.Point(86, 25);
            this.tBoxNombre.Name = "tBoxNombre";
            this.tBoxNombre.Size = new System.Drawing.Size(191, 20);
            this.tBoxNombre.TabIndex = 8;
            // 
            // tBoxApellido
            // 
            this.tBoxApellido.Location = new System.Drawing.Point(340, 25);
            this.tBoxApellido.Name = "tBoxApellido";
            this.tBoxApellido.Size = new System.Drawing.Size(203, 20);
            this.tBoxApellido.TabIndex = 9;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(17, 60);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 16;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // cBoxEspecialidad
            // 
            this.cBoxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEspecialidad.FormattingEnabled = true;
            this.cBoxEspecialidad.Location = new System.Drawing.Point(86, 57);
            this.cBoxEspecialidad.Name = "cBoxEspecialidad";
            this.cBoxEspecialidad.Size = new System.Drawing.Size(191, 21);
            this.cBoxEspecialidad.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxEspecialidad);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Controls.Add(this.tBoxApellido);
            this.groupBox1.Controls.Add(this.tBoxNombre);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(592, 79);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(592, 50);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(592, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgProfesionales
            // 
            this.dgProfesionales.AllowUserToAddRows = false;
            this.dgProfesionales.AllowUserToDeleteRows = false;
            this.dgProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIdProfesional,
            this.cNombreProfesional,
            this.cDireccionProfesional});
            this.dgProfesionales.Location = new System.Drawing.Point(41, 120);
            this.dgProfesionales.Name = "dgProfesionales";
            this.dgProfesionales.ReadOnly = true;
            this.dgProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfesionales.Size = new System.Drawing.Size(514, 191);
            this.dgProfesionales.TabIndex = 7;
            this.dgProfesionales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProfesionales_CellDoubleClick);
            this.dgProfesionales.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProfesionales_CellContentDoubleClick);
            this.dgProfesionales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgProfesionales_KeyPress);
            // 
            // cIdProfesional
            // 
            this.cIdProfesional.HeaderText = "Profesional";
            this.cIdProfesional.Name = "cIdProfesional";
            this.cIdProfesional.ReadOnly = true;
            this.cIdProfesional.Visible = false;
            // 
            // cNombreProfesional
            // 
            this.cNombreProfesional.HeaderText = "Profesional";
            this.cNombreProfesional.Name = "cNombreProfesional";
            this.cNombreProfesional.ReadOnly = true;
            // 
            // cDireccionProfesional
            // 
            this.cDireccionProfesional.HeaderText = "Dirección";
            this.cDireccionProfesional.Name = "cDireccionProfesional";
            this.cDireccionProfesional.ReadOnly = true;
            this.cDireccionProfesional.Width = 270;
            // 
            // BuscarProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 323);
            this.Controls.Add(this.dgProfesionales);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "BuscarProfesional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Buscar Profesional";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesionales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox tBoxNombre;
        private System.Windows.Forms.TextBox tBoxApellido;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cBoxEspecialidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIdProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccionProfesional;
    }
}