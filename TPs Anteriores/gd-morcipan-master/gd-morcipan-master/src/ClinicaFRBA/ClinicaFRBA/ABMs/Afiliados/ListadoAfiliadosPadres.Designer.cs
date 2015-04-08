namespace ClinicaFRBA.ABMs.Afiliados
{
    partial class ListadoAfiliadosPadres
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
            this.cNroAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPlanMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPlanMedico = new System.Windows.Forms.ComboBox();
            this.lblPlanMedico = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtResultado
            // 
            this.dtResultado.AllowUserToAddRows = false;
            this.dtResultado.AllowUserToDeleteRows = false;
            this.dtResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNroAfiliado,
            this.cAfiliado,
            this.cTipoNroDoc,
            this.cEstadoCivil,
            this.cPlanMedico,
            this.cSeleccionar});
            this.dtResultado.Location = new System.Drawing.Point(12, 136);
            this.dtResultado.Name = "dtResultado";
            this.dtResultado.ReadOnly = true;
            this.dtResultado.Size = new System.Drawing.Size(597, 248);
            this.dtResultado.TabIndex = 17;
            this.dtResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtResultado_CellContentClick);
            // 
            // cNroAfiliado
            // 
            this.cNroAfiliado.HeaderText = "Nro. Afiliado";
            this.cNroAfiliado.Name = "cNroAfiliado";
            this.cNroAfiliado.ReadOnly = true;
            this.cNroAfiliado.Visible = false;
            // 
            // cAfiliado
            // 
            this.cAfiliado.HeaderText = "Afiliado";
            this.cAfiliado.Name = "cAfiliado";
            this.cAfiliado.ReadOnly = true;
            this.cAfiliado.Width = 150;
            // 
            // cTipoNroDoc
            // 
            this.cTipoNroDoc.HeaderText = "Tipo y Nro Doc.";
            this.cTipoNroDoc.Name = "cTipoNroDoc";
            this.cTipoNroDoc.ReadOnly = true;
            // 
            // cEstadoCivil
            // 
            this.cEstadoCivil.HeaderText = "Estado Civil";
            this.cEstadoCivil.Name = "cEstadoCivil";
            this.cEstadoCivil.ReadOnly = true;
            // 
            // cPlanMedico
            // 
            this.cPlanMedico.HeaderText = "Plan";
            this.cPlanMedico.Name = "cPlanMedico";
            this.cPlanMedico.ReadOnly = true;
            // 
            // cSeleccionar
            // 
            this.cSeleccionar.HeaderText = "Seleccionar";
            this.cSeleccionar.Name = "cSeleccionar";
            this.cSeleccionar.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(580, 89);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(580, 60);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(580, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPlanMedico);
            this.groupBox1.Controls.Add(this.lblPlanMedico);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblFechaNac);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 108);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de búsqueda de Afiliados";
            // 
            // cmbPlanMedico
            // 
            this.cmbPlanMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanMedico.FormattingEnabled = true;
            this.cmbPlanMedico.Location = new System.Drawing.Point(87, 74);
            this.cmbPlanMedico.Name = "cmbPlanMedico";
            this.cmbPlanMedico.Size = new System.Drawing.Size(169, 21);
            this.cmbPlanMedico.TabIndex = 2;
            // 
            // lblPlanMedico
            // 
            this.lblPlanMedico.AutoSize = true;
            this.lblPlanMedico.Location = new System.Drawing.Point(21, 77);
            this.lblPlanMedico.Name = "lblPlanMedico";
            this.lblPlanMedico.Size = new System.Drawing.Size(31, 13);
            this.lblPlanMedico.TabIndex = 2;
            this.lblPlanMedico.Text = "Plan:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(335, 49);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(195, 20);
            this.txtNroDoc.TabIndex = 4;
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(87, 49);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(169, 21);
            this.cmbTipoDoc.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(335, 23);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(195, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(268, 52);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(56, 13);
            this.lblFechaNac.TabIndex = 4;
            this.lblFechaNac.Text = "Nro. Doc.:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(21, 52);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(57, 13);
            this.lblTipoDoc.TabIndex = 2;
            this.lblTipoDoc.Text = "Tipo Doc.:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(268, 26);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // ListadoAfiliadosPadres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 399);
            this.Controls.Add(this.dtResultado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoAfiliadosPadres";
            this.Text = "Clínica FRBA: Listado de Afiliados";
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtResultado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPlanMedico;
        private System.Windows.Forms.Label lblPlanMedico;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoNroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPlanMedico;
        private System.Windows.Forms.DataGridViewButtonColumn cSeleccionar;
    }
}