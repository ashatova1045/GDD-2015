namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    partial class RegistroResultado
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
            this.btnBuscarProf = new System.Windows.Forms.Button();
            this.tBoxDni = new System.Windows.Forms.TextBox();
            this.tBoxNomYApe = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblNomYApe = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tBoxPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.btnBuscarTurno = new System.Windows.Forms.Button();
            this.lblFechaTurno = new System.Windows.Forms.Label();
            this.dtpFechaConsulta = new System.Windows.Forms.DateTimePicker();
            this.lblSintomas = new System.Windows.Forms.Label();
            this.tBoxSintomas = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblIdProf = new System.Windows.Forms.Label();
            this.lblIdConsulta = new System.Windows.Forms.Label();
            this.cBoxConcretada = new System.Windows.Forms.CheckBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblEnfermedades = new System.Windows.Forms.Label();
            this.tBoxEnfermedades = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarProf);
            this.groupBox1.Controls.Add(this.tBoxDni);
            this.groupBox1.Controls.Add(this.tBoxNomYApe);
            this.groupBox1.Controls.Add(this.lblDni);
            this.groupBox1.Controls.Add(this.lblNomYApe);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion de Profesional";
            // 
            // btnBuscarProf
            // 
            this.btnBuscarProf.Location = new System.Drawing.Point(267, 15);
            this.btnBuscarProf.Name = "btnBuscarProf";
            this.btnBuscarProf.Size = new System.Drawing.Size(75, 48);
            this.btnBuscarProf.TabIndex = 4;
            this.btnBuscarProf.Text = "Buscar Profesional";
            this.btnBuscarProf.UseVisualStyleBackColor = true;
            this.btnBuscarProf.Click += new System.EventHandler(this.btnBuscarProf_Click);
            // 
            // tBoxDni
            // 
            this.tBoxDni.Enabled = false;
            this.tBoxDni.Location = new System.Drawing.Point(45, 43);
            this.tBoxDni.Name = "tBoxDni";
            this.tBoxDni.ReadOnly = true;
            this.tBoxDni.Size = new System.Drawing.Size(216, 20);
            this.tBoxDni.TabIndex = 3;
            // 
            // tBoxNomYApe
            // 
            this.tBoxNomYApe.Enabled = false;
            this.tBoxNomYApe.Location = new System.Drawing.Point(111, 17);
            this.tBoxNomYApe.Name = "tBoxNomYApe";
            this.tBoxNomYApe.ReadOnly = true;
            this.tBoxNomYApe.Size = new System.Drawing.Size(150, 20);
            this.tBoxNomYApe.TabIndex = 2;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(10, 46);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "DNI:";
            // 
            // lblNomYApe
            // 
            this.lblNomYApe.AutoSize = true;
            this.lblNomYApe.Location = new System.Drawing.Point(10, 20);
            this.lblNomYApe.Name = "lblNomYApe";
            this.lblNomYApe.Size = new System.Drawing.Size(95, 13);
            this.lblNomYApe.TabIndex = 0;
            this.lblNomYApe.Text = "Nombre y Apellido:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tBoxPaciente);
            this.groupBox2.Controls.Add(this.lblPaciente);
            this.groupBox2.Controls.Add(this.btnBuscarTurno);
            this.groupBox2.Controls.Add(this.lblFechaTurno);
            this.groupBox2.Controls.Add(this.dtpFechaConsulta);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 75);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccion de Paciente";
            // 
            // tBoxPaciente
            // 
            this.tBoxPaciente.Location = new System.Drawing.Point(64, 46);
            this.tBoxPaciente.Name = "tBoxPaciente";
            this.tBoxPaciente.ReadOnly = true;
            this.tBoxPaciente.Size = new System.Drawing.Size(278, 20);
            this.tBoxPaciente.TabIndex = 4;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(6, 49);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(52, 13);
            this.lblPaciente.TabIndex = 3;
            this.lblPaciente.Text = "Paciente:";
            // 
            // btnBuscarTurno
            // 
            this.btnBuscarTurno.Location = new System.Drawing.Point(169, 17);
            this.btnBuscarTurno.Name = "btnBuscarTurno";
            this.btnBuscarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTurno.TabIndex = 2;
            this.btnBuscarTurno.Text = "Buscar";
            this.btnBuscarTurno.UseVisualStyleBackColor = true;
            this.btnBuscarTurno.Click += new System.EventHandler(this.btnBuscarTurno_Click);
            // 
            // lblFechaTurno
            // 
            this.lblFechaTurno.AutoSize = true;
            this.lblFechaTurno.Location = new System.Drawing.Point(6, 22);
            this.lblFechaTurno.Name = "lblFechaTurno";
            this.lblFechaTurno.Size = new System.Drawing.Size(40, 13);
            this.lblFechaTurno.TabIndex = 1;
            this.lblFechaTurno.Text = "Fecha:";
            // 
            // dtpFechaConsulta
            // 
            this.dtpFechaConsulta.Enabled = false;
            this.dtpFechaConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaConsulta.Location = new System.Drawing.Point(64, 19);
            this.dtpFechaConsulta.Name = "dtpFechaConsulta";
            this.dtpFechaConsulta.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaConsulta.TabIndex = 0;
            // 
            // lblSintomas
            // 
            this.lblSintomas.AutoSize = true;
            this.lblSintomas.Location = new System.Drawing.Point(9, 222);
            this.lblSintomas.Name = "lblSintomas";
            this.lblSintomas.Size = new System.Drawing.Size(50, 13);
            this.lblSintomas.TabIndex = 3;
            this.lblSintomas.Text = "Sintomas";
            // 
            // tBoxSintomas
            // 
            this.tBoxSintomas.Enabled = false;
            this.tBoxSintomas.Location = new System.Drawing.Point(12, 238);
            this.tBoxSintomas.MaxLength = 255;
            this.tBoxSintomas.Multiline = true;
            this.tBoxSintomas.Name = "tBoxSintomas";
            this.tBoxSintomas.Size = new System.Drawing.Size(348, 52);
            this.tBoxSintomas.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(366, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Guardar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(366, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(366, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblIdProf
            // 
            this.lblIdProf.AutoSize = true;
            this.lblIdProf.Location = new System.Drawing.Point(367, 116);
            this.lblIdProf.Name = "lblIdProf";
            this.lblIdProf.Size = new System.Drawing.Size(45, 13);
            this.lblIdProf.TabIndex = 8;
            this.lblIdProf.Text = "lblIdProf";
            this.lblIdProf.Visible = false;
            // 
            // lblIdConsulta
            // 
            this.lblIdConsulta.AutoSize = true;
            this.lblIdConsulta.Location = new System.Drawing.Point(367, 129);
            this.lblIdConsulta.Name = "lblIdConsulta";
            this.lblIdConsulta.Size = new System.Drawing.Size(67, 13);
            this.lblIdConsulta.TabIndex = 9;
            this.lblIdConsulta.Text = "lblIdConsulta";
            this.lblIdConsulta.Visible = false;
            // 
            // cBoxConcretada
            // 
            this.cBoxConcretada.AutoSize = true;
            this.cBoxConcretada.Location = new System.Drawing.Point(12, 172);
            this.cBoxConcretada.Name = "cBoxConcretada";
            this.cBoxConcretada.Size = new System.Drawing.Size(164, 17);
            this.cBoxConcretada.TabIndex = 10;
            this.cBoxConcretada.Text = "Atencion Medica Concretada";
            this.cBoxConcretada.UseVisualStyleBackColor = true;
            this.cBoxConcretada.CheckedChanged += new System.EventHandler(this.cBoxConcretada_CheckedChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(9, 198);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(55, 195);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(156, 198);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 13;
            this.lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            this.dtpHora.Enabled = false;
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(195, 195);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(90, 20);
            this.dtpHora.TabIndex = 14;
            // 
            // lblEnfermedades
            // 
            this.lblEnfermedades.AutoSize = true;
            this.lblEnfermedades.Location = new System.Drawing.Point(12, 293);
            this.lblEnfermedades.Name = "lblEnfermedades";
            this.lblEnfermedades.Size = new System.Drawing.Size(75, 13);
            this.lblEnfermedades.TabIndex = 15;
            this.lblEnfermedades.Text = "Enfermedades";
            // 
            // tBoxEnfermedades
            // 
            this.tBoxEnfermedades.Enabled = false;
            this.tBoxEnfermedades.Location = new System.Drawing.Point(12, 309);
            this.tBoxEnfermedades.MaxLength = 255;
            this.tBoxEnfermedades.Multiline = true;
            this.tBoxEnfermedades.Name = "tBoxEnfermedades";
            this.tBoxEnfermedades.Size = new System.Drawing.Size(348, 52);
            this.tBoxEnfermedades.TabIndex = 16;
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 367);
            this.Controls.Add(this.tBoxEnfermedades);
            this.Controls.Add(this.lblEnfermedades);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cBoxConcretada);
            this.Controls.Add(this.lblIdConsulta);
            this.Controls.Add(this.lblIdProf);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tBoxSintomas);
            this.Controls.Add(this.lblSintomas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistroResultado";
            this.Text = "RegistroResultado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarProf;
        private System.Windows.Forms.TextBox tBoxDni;
        private System.Windows.Forms.TextBox tBoxNomYApe;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNomYApe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFechaTurno;
        private System.Windows.Forms.DateTimePicker dtpFechaConsulta;
        private System.Windows.Forms.TextBox tBoxPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Button btnBuscarTurno;
        private System.Windows.Forms.Label lblSintomas;
        private System.Windows.Forms.TextBox tBoxSintomas;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblIdProf;
        private System.Windows.Forms.Label lblIdConsulta;
        private System.Windows.Forms.CheckBox cBoxConcretada;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblEnfermedades;
        private System.Windows.Forms.TextBox tBoxEnfermedades;
    }
}