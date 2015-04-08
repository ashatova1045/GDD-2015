namespace ClinicaFRBA.ABMs.Afiliados
{
    partial class ModificacionAfiliados
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
            this.gbDatosAfiliados = new System.Windows.Forms.GroupBox();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.lblNroAfiliado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtCantHijos = new System.Windows.Forms.TextBox();
            this.cmbPlanMedico = new System.Windows.Forms.ComboBox();
            this.lblCantHijos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDirecion = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosAfiliados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosAfiliados
            // 
            this.gbDatosAfiliados.Controls.Add(this.txtNroAfiliado);
            this.gbDatosAfiliados.Controls.Add(this.lblNroAfiliado);
            this.gbDatosAfiliados.Controls.Add(this.label1);
            this.gbDatosAfiliados.Controls.Add(this.dtFechaNacimiento);
            this.gbDatosAfiliados.Controls.Add(this.txtCantHijos);
            this.gbDatosAfiliados.Controls.Add(this.cmbPlanMedico);
            this.gbDatosAfiliados.Controls.Add(this.lblCantHijos);
            this.gbDatosAfiliados.Controls.Add(this.label2);
            this.gbDatosAfiliados.Controls.Add(this.cmbEstadoCivil);
            this.gbDatosAfiliados.Controls.Add(this.lblEstadoCivil);
            this.gbDatosAfiliados.Controls.Add(this.cmbSexo);
            this.gbDatosAfiliados.Controls.Add(this.lblSexo);
            this.gbDatosAfiliados.Controls.Add(this.txtTelefono);
            this.gbDatosAfiliados.Controls.Add(this.txtEmail);
            this.gbDatosAfiliados.Controls.Add(this.lblEmail);
            this.gbDatosAfiliados.Controls.Add(this.lblTelefono);
            this.gbDatosAfiliados.Controls.Add(this.txtDireccion);
            this.gbDatosAfiliados.Controls.Add(this.lblDirecion);
            this.gbDatosAfiliados.Controls.Add(this.txtNroDoc);
            this.gbDatosAfiliados.Controls.Add(this.cmbTipoDoc);
            this.gbDatosAfiliados.Controls.Add(this.txtApellido);
            this.gbDatosAfiliados.Controls.Add(this.txtNombre);
            this.gbDatosAfiliados.Controls.Add(this.lblNroDoc);
            this.gbDatosAfiliados.Controls.Add(this.lblTipoDoc);
            this.gbDatosAfiliados.Controls.Add(this.lblApellido);
            this.gbDatosAfiliados.Controls.Add(this.lblNombre);
            this.gbDatosAfiliados.Location = new System.Drawing.Point(12, 12);
            this.gbDatosAfiliados.Name = "gbDatosAfiliados";
            this.gbDatosAfiliados.Size = new System.Drawing.Size(604, 233);
            this.gbDatosAfiliados.TabIndex = 14;
            this.gbDatosAfiliados.TabStop = false;
            this.gbDatosAfiliados.Text = "Datos de Afiliado";
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroAfiliado.Location = new System.Drawing.Point(116, 18);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.ReadOnly = true;
            this.txtNroAfiliado.Size = new System.Drawing.Size(175, 20);
            this.txtNroAfiliado.TabIndex = 27;
            // 
            // lblNroAfiliado
            // 
            this.lblNroAfiliado.AutoSize = true;
            this.lblNroAfiliado.Location = new System.Drawing.Point(23, 22);
            this.lblNroAfiliado.Name = "lblNroAfiliado";
            this.lblNroAfiliado.Size = new System.Drawing.Size(67, 13);
            this.lblNroAfiliado.TabIndex = 26;
            this.lblNroAfiliado.Text = "Nro. Afiliado:";
            this.lblNroAfiliado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fec. Nac.:";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtFechaNacimiento.Enabled = false;
            this.dtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaNacimiento.Location = new System.Drawing.Point(116, 136);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(117, 20);
            this.dtFechaNacimiento.TabIndex = 7;
            // 
            // txtCantHijos
            // 
            this.txtCantHijos.Enabled = false;
            this.txtCantHijos.Location = new System.Drawing.Point(366, 199);
            this.txtCantHijos.Name = "txtCantHijos";
            this.txtCantHijos.Size = new System.Drawing.Size(59, 20);
            this.txtCantHijos.TabIndex = 11;
            // 
            // cmbPlanMedico
            // 
            this.cmbPlanMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanMedico.FormattingEnabled = true;
            this.cmbPlanMedico.Location = new System.Drawing.Point(116, 199);
            this.cmbPlanMedico.Name = "cmbPlanMedico";
            this.cmbPlanMedico.Size = new System.Drawing.Size(175, 21);
            this.cmbPlanMedico.TabIndex = 10;
            // 
            // lblCantHijos
            // 
            this.lblCantHijos.AutoSize = true;
            this.lblCantHijos.Location = new System.Drawing.Point(297, 202);
            this.lblCantHijos.Name = "lblCantHijos";
            this.lblCantHijos.Size = new System.Drawing.Size(61, 13);
            this.lblCantHijos.TabIndex = 23;
            this.lblCantHijos.Text = "Cant. Hijos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Plan Médico:";
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.Location = new System.Drawing.Point(366, 107);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(210, 21);
            this.cmbEstadoCivil.TabIndex = 6;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Location = new System.Drawing.Point(297, 110);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(65, 13);
            this.lblEstadoCivil.TabIndex = 20;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(116, 107);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(175, 21);
            this.cmbSexo.TabIndex = 5;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(23, 110);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 18;
            this.lblSexo.Text = "Sexo:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(116, 168);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(175, 20);
            this.txtTelefono.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(366, 168);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(297, 171);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "E-mail:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(23, 171);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(300, 137);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(276, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // lblDirecion
            // 
            this.lblDirecion.AutoSize = true;
            this.lblDirecion.Location = new System.Drawing.Point(239, 140);
            this.lblDirecion.Name = "lblDirecion";
            this.lblDirecion.Size = new System.Drawing.Size(55, 13);
            this.lblDirecion.TabIndex = 9;
            this.lblDirecion.Text = "Dirección:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(366, 77);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(210, 20);
            this.txtNroDoc.TabIndex = 4;
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.Enabled = false;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(116, 72);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(175, 21);
            this.cmbTipoDoc.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(366, 44);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(210, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(116, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(175, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(297, 80);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(56, 13);
            this.lblNroDoc.TabIndex = 3;
            this.lblNroDoc.Text = "Nro. Doc.:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(23, 80);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(72, 13);
            this.lblTipoDoc.TabIndex = 2;
            this.lblTipoDoc.Text = "Tipo de Doc.:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(297, 47);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 47);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(622, 74);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(622, 41);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ModificacionAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 257);
            this.Controls.Add(this.gbDatosAfiliados);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "ModificacionAfiliados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Modificación de Afiliados";
            this.Load += new System.EventHandler(this.ModificacionAfiliados_Load);
            this.gbDatosAfiliados.ResumeLayout(false);
            this.gbDatosAfiliados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosAfiliados;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private System.Windows.Forms.Label lblNroAfiliado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.TextBox txtCantHijos;
        private System.Windows.Forms.ComboBox cmbPlanMedico;
        private System.Windows.Forms.Label lblCantHijos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstadoCivil;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDirecion;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}