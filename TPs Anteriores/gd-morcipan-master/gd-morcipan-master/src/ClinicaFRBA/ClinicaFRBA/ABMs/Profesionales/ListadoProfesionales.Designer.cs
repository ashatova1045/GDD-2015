namespace ClinicaFRBA.ABMs.Profesionales
{
    partial class ListadoProfesionales
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tBoxMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.cBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkFechaNac = new System.Windows.Forms.CheckBox();
            this.cBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.tBoxMatricula = new System.Windows.Forms.TextBox();
            this.tBoxTelefono = new System.Windows.Forms.TextBox();
            this.tBoxDireccion = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cBoxSexo = new System.Windows.Forms.ComboBox();
            this.tBoxDni = new System.Windows.Forms.TextBox();
            this.tBoxApellido = new System.Windows.Forms.TextBox();
            this.tBoxNombre = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.dtResultado = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxMail);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.cBoxTipoDoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkFechaNac);
            this.groupBox1.Controls.Add(this.cBoxEspecialidad);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Controls.Add(this.tBoxMatricula);
            this.groupBox1.Controls.Add(this.tBoxTelefono);
            this.groupBox1.Controls.Add(this.tBoxDireccion);
            this.groupBox1.Controls.Add(this.dtpFechaNac);
            this.groupBox1.Controls.Add(this.cBoxSexo);
            this.groupBox1.Controls.Add(this.tBoxDni);
            this.groupBox1.Controls.Add(this.tBoxApellido);
            this.groupBox1.Controls.Add(this.tBoxNombre);
            this.groupBox1.Controls.Add(this.lblMatricula);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.lblFechaNac);
            this.groupBox1.Controls.Add(this.lblSexo);
            this.groupBox1.Controls.Add(this.lblDni);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda de profesionales";
            // 
            // tBoxMail
            // 
            this.tBoxMail.Location = new System.Drawing.Point(61, 125);
            this.tBoxMail.Name = "tBoxMail";
            this.tBoxMail.Size = new System.Drawing.Size(120, 20);
            this.tBoxMail.TabIndex = 9;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(7, 128);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 21;
            this.lblMail.Text = "Mail:";
            // 
            // cBoxTipoDoc
            // 
            this.cBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoDoc.FormattingEnabled = true;
            this.cBoxTipoDoc.Location = new System.Drawing.Point(102, 71);
            this.cBoxTipoDoc.Name = "cBoxTipoDoc";
            this.cBoxTipoDoc.Size = new System.Drawing.Size(79, 21);
            this.cBoxTipoDoc.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tipo Documento;";
            // 
            // checkFechaNac
            // 
            this.checkFechaNac.AutoSize = true;
            this.checkFechaNac.Location = new System.Drawing.Point(451, 22);
            this.checkFechaNac.Name = "checkFechaNac";
            this.checkFechaNac.Size = new System.Drawing.Size(15, 14);
            this.checkFechaNac.TabIndex = 18;
            this.checkFechaNac.UseVisualStyleBackColor = true;
            this.checkFechaNac.CheckedChanged += new System.EventHandler(this.checkFechaNac_CheckedChanged);
            // 
            // cBoxEspecialidad
            // 
            this.cBoxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEspecialidad.FormattingEnabled = true;
            this.cBoxEspecialidad.Location = new System.Drawing.Point(83, 151);
            this.cBoxEspecialidad.Name = "cBoxEspecialidad";
            this.cBoxEspecialidad.Size = new System.Drawing.Size(98, 21);
            this.cBoxEspecialidad.TabIndex = 11;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(7, 154);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 16;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // tBoxMatricula
            // 
            this.tBoxMatricula.Location = new System.Drawing.Point(66, 99);
            this.tBoxMatricula.Name = "tBoxMatricula";
            this.tBoxMatricula.Size = new System.Drawing.Size(115, 20);
            this.tBoxMatricula.TabIndex = 7;
            // 
            // tBoxTelefono
            // 
            this.tBoxTelefono.Location = new System.Drawing.Point(325, 125);
            this.tBoxTelefono.Name = "tBoxTelefono";
            this.tBoxTelefono.Size = new System.Drawing.Size(231, 20);
            this.tBoxTelefono.TabIndex = 10;
            this.tBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxTelefono_KeyPress);
            // 
            // tBoxDireccion
            // 
            this.tBoxDireccion.Location = new System.Drawing.Point(325, 99);
            this.tBoxDireccion.Name = "tBoxDireccion";
            this.tBoxDireccion.Size = new System.Drawing.Size(231, 20);
            this.tBoxDireccion.TabIndex = 8;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Enabled = false;
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(325, 20);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaNac.TabIndex = 2;
            // 
            // cBoxSexo
            // 
            this.cBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSexo.FormattingEnabled = true;
            this.cBoxSexo.Location = new System.Drawing.Point(325, 46);
            this.cBoxSexo.Name = "cBoxSexo";
            this.cBoxSexo.Size = new System.Drawing.Size(120, 21);
            this.cBoxSexo.TabIndex = 4;
            // 
            // tBoxDni
            // 
            this.tBoxDni.Location = new System.Drawing.Point(325, 73);
            this.tBoxDni.Name = "tBoxDni";
            this.tBoxDni.Size = new System.Drawing.Size(120, 20);
            this.tBoxDni.TabIndex = 6;
            this.tBoxDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxDni_KeyPress);
            // 
            // tBoxApellido
            // 
            this.tBoxApellido.Location = new System.Drawing.Point(61, 45);
            this.tBoxApellido.Name = "tBoxApellido";
            this.tBoxApellido.Size = new System.Drawing.Size(120, 20);
            this.tBoxApellido.TabIndex = 3;
            // 
            // tBoxNombre
            // 
            this.tBoxNombre.Location = new System.Drawing.Point(61, 19);
            this.tBoxNombre.Name = "tBoxNombre";
            this.tBoxNombre.Size = new System.Drawing.Size(120, 20);
            this.tBoxNombre.TabIndex = 1;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(7, 102);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(53, 13);
            this.lblMatricula.TabIndex = 7;
            this.lblMatricula.Text = "Matricula:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(209, 128);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(209, 103);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(208, 23);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(111, 13);
            this.lblFechaNac.TabIndex = 4;
            this.lblFechaNac.Text = "Fecha de Nacimiento:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(209, 49);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 3;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(209, 76);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(105, 13);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "Numero Documento:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(7, 48);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(581, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(581, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(581, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(581, 298);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 15;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // dtResultado
            // 
            this.dtResultado.AllowUserToAddRows = false;
            this.dtResultado.AllowUserToDeleteRows = false;
            this.dtResultado.AllowUserToOrderColumns = true;
            this.dtResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtResultado.Location = new System.Drawing.Point(13, 199);
            this.dtResultado.MultiSelect = false;
            this.dtResultado.Name = "dtResultado";
            this.dtResultado.ReadOnly = true;
            this.dtResultado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtResultado.Size = new System.Drawing.Size(562, 329);
            this.dtResultado.TabIndex = 5;
            this.dtResultado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtResultado_CellClick);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(581, 327);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // ListadoProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 537);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtResultado);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoProfesionales";
            this.Text = "Listado de Profesionales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox tBoxDireccion;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.ComboBox cBoxSexo;
        private System.Windows.Forms.TextBox tBoxDni;
        private System.Windows.Forms.TextBox tBoxApellido;
        private System.Windows.Forms.TextBox tBoxNombre;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.ComboBox cBoxEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox tBoxMatricula;
        private System.Windows.Forms.TextBox tBoxTelefono;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.DataGridView dtResultado;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox checkFechaNac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxTipoDoc;
        private System.Windows.Forms.TextBox tBoxMail;
        private System.Windows.Forms.Label lblMail;
    }
}