namespace ClinicaFRBA.ABMs.Roles
{
    partial class ListadoRoles
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
            this.grBoxFiltros = new System.Windows.Forms.GroupBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.dgRoles = new System.Windows.Forms.DataGridView();
            this.rolId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rolBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // grBoxFiltros
            // 
            this.grBoxFiltros.Controls.Add(this.lblNom);
            this.grBoxFiltros.Controls.Add(this.txtNom);
            this.grBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.grBoxFiltros.Name = "grBoxFiltros";
            this.grBoxFiltros.Size = new System.Drawing.Size(242, 65);
            this.grBoxFiltros.TabIndex = 25;
            this.grBoxFiltros.TabStop = false;
            this.grBoxFiltros.Text = "Filtros de búsqueda";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(18, 25);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(26, 13);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Rol:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(50, 22);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(162, 20);
            this.txtNom.TabIndex = 2;
            // 
            // dgRoles
            // 
            this.dgRoles.AllowUserToAddRows = false;
            this.dgRoles.AllowUserToDeleteRows = false;
            this.dgRoles.AllowUserToResizeColumns = false;
            this.dgRoles.AllowUserToResizeRows = false;
            this.dgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolId,
            this.rolNombre,
            this.rolModificar,
            this.rolBorrar});
            this.dgRoles.Location = new System.Drawing.Point(12, 95);
            this.dgRoles.MultiSelect = false;
            this.dgRoles.Name = "dgRoles";
            this.dgRoles.ReadOnly = true;
            this.dgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRoles.Size = new System.Drawing.Size(444, 150);
            this.dgRoles.TabIndex = 26;
            this.dgRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRoles_CellContentClick);
            // 
            // rolId
            // 
            this.rolId.HeaderText = "Rol Id";
            this.rolId.Name = "rolId";
            this.rolId.ReadOnly = true;
            this.rolId.Visible = false;
            // 
            // rolNombre
            // 
            this.rolNombre.HeaderText = "Rol";
            this.rolNombre.Name = "rolNombre";
            this.rolNombre.ReadOnly = true;
            this.rolNombre.Width = 200;
            // 
            // rolModificar
            // 
            this.rolModificar.HeaderText = "Modificar";
            this.rolModificar.Name = "rolModificar";
            this.rolModificar.ReadOnly = true;
            // 
            // rolBorrar
            // 
            this.rolBorrar.HeaderText = "Borrar";
            this.rolBorrar.Name = "rolBorrar";
            this.rolBorrar.ReadOnly = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(260, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 27;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(260, 37);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(260, 66);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 272);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgRoles);
            this.Controls.Add(this.grBoxFiltros);
            this.Name = "ListadoRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Listado de Roles";
            this.grBoxFiltros.ResumeLayout(false);
            this.grBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxFiltros;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DataGridView dgRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolId;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNombre;
        private System.Windows.Forms.DataGridViewButtonColumn rolModificar;
        private System.Windows.Forms.DataGridViewButtonColumn rolBorrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
    }
}