namespace ClinicaFRBA.ABMs.Profesionales
{
    partial class AltaProfesionales
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
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.tBoxTelefono = new System.Windows.Forms.TextBox();
            this.tBoxNumeroDoc = new System.Windows.Forms.TextBox();
            this.cListEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.tBoxMatricula = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.cBoxSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.tBoxDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.tBoxApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.tBoxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.tBoxMail = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tBoxMail);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.cBoxTipoDoc);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.lblEspecialidades);
            this.groupBox1.Controls.Add(this.tBoxTelefono);
            this.groupBox1.Controls.Add(this.tBoxNumeroDoc);
            this.groupBox1.Controls.Add(this.cListEspecialidades);
            this.groupBox1.Controls.Add(this.tBoxMatricula);
            this.groupBox1.Controls.Add(this.lblMatricula);
            this.groupBox1.Controls.Add(this.cBoxSexo);
            this.groupBox1.Controls.Add(this.lblSexo);
            this.groupBox1.Controls.Add(this.dtpFechaNac);
            this.groupBox1.Controls.Add(this.lblFechaNac);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.tBoxDireccion);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.tBoxApellido);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.tBoxNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 355);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Profesional";
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Location = new System.Drawing.Point(6, 176);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(81, 13);
            this.lblEspecialidades.TabIndex = 17;
            this.lblEspecialidades.Text = "Especialidades:";
            // 
            // tBoxTelefono
            // 
            this.tBoxTelefono.Location = new System.Drawing.Point(67, 124);
            this.tBoxTelefono.Name = "tBoxTelefono";
            this.tBoxTelefono.Size = new System.Drawing.Size(129, 20);
            this.tBoxTelefono.TabIndex = 9;
            this.tBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxTelefono_KeyPress);
            // 
            // tBoxNumeroDoc
            // 
            this.tBoxNumeroDoc.Location = new System.Drawing.Point(301, 45);
            this.tBoxNumeroDoc.Name = "tBoxNumeroDoc";
            this.tBoxNumeroDoc.Size = new System.Drawing.Size(119, 20);
            this.tBoxNumeroDoc.TabIndex = 5;
            this.tBoxNumeroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxNumeroDoc_KeyPress);
            // 
            // cListEspecialidades
            // 
            this.cListEspecialidades.FormattingEnabled = true;
            this.cListEspecialidades.Location = new System.Drawing.Point(6, 192);
            this.cListEspecialidades.Name = "cListEspecialidades";
            this.cListEspecialidades.Size = new System.Drawing.Size(414, 154);
            this.cListEspecialidades.TabIndex = 12;
            // 
            // tBoxMatricula
            // 
            this.tBoxMatricula.Location = new System.Drawing.Point(67, 150);
            this.tBoxMatricula.Name = "tBoxMatricula";
            this.tBoxMatricula.Size = new System.Drawing.Size(129, 20);
            this.tBoxMatricula.TabIndex = 11;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(6, 153);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(53, 13);
            this.lblMatricula.TabIndex = 16;
            this.lblMatricula.Text = "Matricula:";
            // 
            // cBoxSexo
            // 
            this.cBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSexo.FormattingEnabled = true;
            this.cBoxSexo.Location = new System.Drawing.Point(301, 71);
            this.cBoxSexo.Name = "cBoxSexo";
            this.cBoxSexo.Size = new System.Drawing.Size(33, 21);
            this.cBoxSexo.TabIndex = 7;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(245, 74);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 14;
            this.lblSexo.Text = "Sexo:";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(123, 71);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaNac.TabIndex = 6;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(6, 74);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(111, 13);
            this.lblFechaNac.TabIndex = 12;
            this.lblFechaNac.Text = "Fecha de Nacimiento:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(6, 127);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Telefono:";
            // 
            // tBoxDireccion
            // 
            this.tBoxDireccion.Location = new System.Drawing.Point(67, 98);
            this.tBoxDireccion.Name = "tBoxDireccion";
            this.tBoxDireccion.Size = new System.Drawing.Size(353, 20);
            this.tBoxDireccion.TabIndex = 8;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 101);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(190, 48);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(105, 13);
            this.lblDocumento.TabIndex = 6;
            this.lblDocumento.Text = "Numero Documento:";
            // 
            // tBoxApellido
            // 
            this.tBoxApellido.Location = new System.Drawing.Point(301, 19);
            this.tBoxApellido.Name = "tBoxApellido";
            this.tBoxApellido.Size = new System.Drawing.Size(119, 20);
            this.tBoxApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(190, 22);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // tBoxNombre
            // 
            this.tBoxNombre.Location = new System.Drawing.Point(81, 19);
            this.tBoxNombre.Name = "tBoxNombre";
            this.tBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.tBoxNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(448, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(448, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(448, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(6, 48);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDoc.TabIndex = 18;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // cBoxTipoDoc
            // 
            this.cBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTipoDoc.FormattingEnabled = true;
            this.cBoxTipoDoc.Location = new System.Drawing.Point(99, 45);
            this.cBoxTipoDoc.Name = "cBoxTipoDoc";
            this.cBoxTipoDoc.Size = new System.Drawing.Size(82, 21);
            this.cBoxTipoDoc.TabIndex = 4;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(203, 127);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 20;
            this.lblMail.Text = "Mail:";
            // 
            // tBoxMail
            // 
            this.tBoxMail.Location = new System.Drawing.Point(238, 124);
            this.tBoxMail.Name = "tBoxMail";
            this.tBoxMail.Size = new System.Drawing.Size(182, 20);
            this.tBoxMail.TabIndex = 10;
            // 
            // AltaProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 372);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaProfesionales";
            this.Text = "AltaProfesionales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox tBoxDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox tBoxApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox tBoxNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.CheckedListBox cListEspecialidades;
        private System.Windows.Forms.TextBox tBoxMatricula;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.ComboBox cBoxSexo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox tBoxTelefono;
        private System.Windows.Forms.TextBox tBoxNumeroDoc;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.TextBox tBoxMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.ComboBox cBoxTipoDoc;
        private System.Windows.Forms.Label lblTipoDoc;
    }
}