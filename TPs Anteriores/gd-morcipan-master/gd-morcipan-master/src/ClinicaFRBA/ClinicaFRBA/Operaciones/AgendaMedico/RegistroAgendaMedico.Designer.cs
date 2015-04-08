namespace ClinicaFRBA.Operaciones.AgendaMedico
{
    partial class RegistroAgendaMedico
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
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxHastaSabado = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeSabado = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBoxHastaViernes = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeViernes = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBoxHastaJueves = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeJueves = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxHastaMiercoles = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeMiercoles = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxHastaMartes = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeMartes = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxHastaLunes = new System.Windows.Forms.MaskedTextBox();
            this.tBoxDesdeLunes = new System.Windows.Forms.MaskedTextBox();
            this.checkSabado = new System.Windows.Forms.CheckBox();
            this.checkViernes = new System.Windows.Forms.CheckBox();
            this.checkJueves = new System.Windows.Forms.CheckBox();
            this.checkMiercoles = new System.Windows.Forms.CheckBox();
            this.checkMartes = new System.Windows.Forms.CheckBox();
            this.checkLunes = new System.Windows.Forms.CheckBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblIDProf = new System.Windows.Forms.Label();
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
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 72);
            this.groupBox1.TabIndex = 0;
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
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tBoxHastaSabado);
            this.groupBox2.Controls.Add(this.tBoxDesdeSabado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tBoxHastaViernes);
            this.groupBox2.Controls.Add(this.tBoxDesdeViernes);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tBoxHastaJueves);
            this.groupBox2.Controls.Add(this.tBoxDesdeJueves);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tBoxHastaMiercoles);
            this.groupBox2.Controls.Add(this.tBoxDesdeMiercoles);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tBoxHastaMartes);
            this.groupBox2.Controls.Add(this.tBoxDesdeMartes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tBoxHastaLunes);
            this.groupBox2.Controls.Add(this.tBoxDesdeLunes);
            this.groupBox2.Controls.Add(this.checkSabado);
            this.groupBox2.Controls.Add(this.checkViernes);
            this.groupBox2.Controls.Add(this.checkJueves);
            this.groupBox2.Controls.Add(this.checkMiercoles);
            this.groupBox2.Controls.Add(this.checkMartes);
            this.groupBox2.Controls.Add(this.checkLunes);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.lblHasta);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.lblDesde);
            this.groupBox2.Location = new System.Drawing.Point(13, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nueva Agenda";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "a";
            // 
            // tBoxHastaSabado
            // 
            this.tBoxHastaSabado.Enabled = false;
            this.tBoxHastaSabado.Location = new System.Drawing.Point(143, 149);
            this.tBoxHastaSabado.Mask = "00:00";
            this.tBoxHastaSabado.Name = "tBoxHastaSabado";
            this.tBoxHastaSabado.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaSabado.TabIndex = 26;
            this.tBoxHastaSabado.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeSabado
            // 
            this.tBoxDesdeSabado.Enabled = false;
            this.tBoxDesdeSabado.Location = new System.Drawing.Point(83, 149);
            this.tBoxDesdeSabado.Mask = "00:00";
            this.tBoxDesdeSabado.Name = "tBoxDesdeSabado";
            this.tBoxDesdeSabado.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeSabado.TabIndex = 25;
            this.tBoxDesdeSabado.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "a";
            // 
            // tBoxHastaViernes
            // 
            this.tBoxHastaViernes.Enabled = false;
            this.tBoxHastaViernes.Location = new System.Drawing.Point(143, 123);
            this.tBoxHastaViernes.Mask = "00:00";
            this.tBoxHastaViernes.Name = "tBoxHastaViernes";
            this.tBoxHastaViernes.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaViernes.TabIndex = 23;
            this.tBoxHastaViernes.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeViernes
            // 
            this.tBoxDesdeViernes.Enabled = false;
            this.tBoxDesdeViernes.Location = new System.Drawing.Point(83, 123);
            this.tBoxDesdeViernes.Mask = "00:00";
            this.tBoxDesdeViernes.Name = "tBoxDesdeViernes";
            this.tBoxDesdeViernes.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeViernes.TabIndex = 22;
            this.tBoxDesdeViernes.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "a";
            // 
            // tBoxHastaJueves
            // 
            this.tBoxHastaJueves.Enabled = false;
            this.tBoxHastaJueves.Location = new System.Drawing.Point(143, 97);
            this.tBoxHastaJueves.Mask = "00:00";
            this.tBoxHastaJueves.Name = "tBoxHastaJueves";
            this.tBoxHastaJueves.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaJueves.TabIndex = 20;
            this.tBoxHastaJueves.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeJueves
            // 
            this.tBoxDesdeJueves.Enabled = false;
            this.tBoxDesdeJueves.Location = new System.Drawing.Point(83, 97);
            this.tBoxDesdeJueves.Mask = "00:00";
            this.tBoxDesdeJueves.Name = "tBoxDesdeJueves";
            this.tBoxDesdeJueves.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeJueves.TabIndex = 19;
            this.tBoxDesdeJueves.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "a";
            // 
            // tBoxHastaMiercoles
            // 
            this.tBoxHastaMiercoles.Enabled = false;
            this.tBoxHastaMiercoles.Location = new System.Drawing.Point(143, 71);
            this.tBoxHastaMiercoles.Mask = "00:00";
            this.tBoxHastaMiercoles.Name = "tBoxHastaMiercoles";
            this.tBoxHastaMiercoles.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaMiercoles.TabIndex = 17;
            this.tBoxHastaMiercoles.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeMiercoles
            // 
            this.tBoxDesdeMiercoles.Enabled = false;
            this.tBoxDesdeMiercoles.Location = new System.Drawing.Point(83, 71);
            this.tBoxDesdeMiercoles.Mask = "00:00";
            this.tBoxDesdeMiercoles.Name = "tBoxDesdeMiercoles";
            this.tBoxDesdeMiercoles.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeMiercoles.TabIndex = 16;
            this.tBoxDesdeMiercoles.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "a";
            // 
            // tBoxHastaMartes
            // 
            this.tBoxHastaMartes.Enabled = false;
            this.tBoxHastaMartes.Location = new System.Drawing.Point(143, 45);
            this.tBoxHastaMartes.Mask = "00:00";
            this.tBoxHastaMartes.Name = "tBoxHastaMartes";
            this.tBoxHastaMartes.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaMartes.TabIndex = 14;
            this.tBoxHastaMartes.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeMartes
            // 
            this.tBoxDesdeMartes.Enabled = false;
            this.tBoxDesdeMartes.Location = new System.Drawing.Point(83, 45);
            this.tBoxDesdeMartes.Mask = "00:00";
            this.tBoxDesdeMartes.Name = "tBoxDesdeMartes";
            this.tBoxDesdeMartes.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeMartes.TabIndex = 13;
            this.tBoxDesdeMartes.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "a";
            // 
            // tBoxHastaLunes
            // 
            this.tBoxHastaLunes.Enabled = false;
            this.tBoxHastaLunes.Location = new System.Drawing.Point(143, 19);
            this.tBoxHastaLunes.Mask = "00:00";
            this.tBoxHastaLunes.Name = "tBoxHastaLunes";
            this.tBoxHastaLunes.Size = new System.Drawing.Size(35, 20);
            this.tBoxHastaLunes.TabIndex = 11;
            this.tBoxHastaLunes.ValidatingType = typeof(System.DateTime);
            // 
            // tBoxDesdeLunes
            // 
            this.tBoxDesdeLunes.Enabled = false;
            this.tBoxDesdeLunes.Location = new System.Drawing.Point(83, 19);
            this.tBoxDesdeLunes.Mask = "00:00";
            this.tBoxDesdeLunes.Name = "tBoxDesdeLunes";
            this.tBoxDesdeLunes.Size = new System.Drawing.Size(35, 20);
            this.tBoxDesdeLunes.TabIndex = 10;
            this.tBoxDesdeLunes.ValidatingType = typeof(System.DateTime);
            // 
            // checkSabado
            // 
            this.checkSabado.AutoSize = true;
            this.checkSabado.Location = new System.Drawing.Point(6, 151);
            this.checkSabado.Name = "checkSabado";
            this.checkSabado.Size = new System.Drawing.Size(63, 17);
            this.checkSabado.TabIndex = 9;
            this.checkSabado.Text = "Sabado";
            this.checkSabado.UseVisualStyleBackColor = true;
            this.checkSabado.CheckedChanged += new System.EventHandler(this.checkSabado_CheckedChanged);
            // 
            // checkViernes
            // 
            this.checkViernes.AutoSize = true;
            this.checkViernes.Location = new System.Drawing.Point(6, 125);
            this.checkViernes.Name = "checkViernes";
            this.checkViernes.Size = new System.Drawing.Size(61, 17);
            this.checkViernes.TabIndex = 8;
            this.checkViernes.Text = "Viernes";
            this.checkViernes.UseVisualStyleBackColor = true;
            this.checkViernes.CheckedChanged += new System.EventHandler(this.checkViernes_CheckedChanged);
            // 
            // checkJueves
            // 
            this.checkJueves.AutoSize = true;
            this.checkJueves.Location = new System.Drawing.Point(6, 99);
            this.checkJueves.Name = "checkJueves";
            this.checkJueves.Size = new System.Drawing.Size(60, 17);
            this.checkJueves.TabIndex = 7;
            this.checkJueves.Text = "Jueves";
            this.checkJueves.UseVisualStyleBackColor = true;
            this.checkJueves.CheckedChanged += new System.EventHandler(this.checkJueves_CheckedChanged);
            // 
            // checkMiercoles
            // 
            this.checkMiercoles.AutoSize = true;
            this.checkMiercoles.Location = new System.Drawing.Point(6, 73);
            this.checkMiercoles.Name = "checkMiercoles";
            this.checkMiercoles.Size = new System.Drawing.Size(71, 17);
            this.checkMiercoles.TabIndex = 6;
            this.checkMiercoles.Text = "Miercoles";
            this.checkMiercoles.UseVisualStyleBackColor = true;
            this.checkMiercoles.CheckedChanged += new System.EventHandler(this.checkMiercoles_CheckedChanged);
            // 
            // checkMartes
            // 
            this.checkMartes.AutoSize = true;
            this.checkMartes.Location = new System.Drawing.Point(6, 47);
            this.checkMartes.Name = "checkMartes";
            this.checkMartes.Size = new System.Drawing.Size(58, 17);
            this.checkMartes.TabIndex = 5;
            this.checkMartes.Text = "Martes";
            this.checkMartes.UseVisualStyleBackColor = true;
            this.checkMartes.CheckedChanged += new System.EventHandler(this.checkMartes_CheckedChanged);
            // 
            // checkLunes
            // 
            this.checkLunes.AutoSize = true;
            this.checkLunes.Location = new System.Drawing.Point(6, 21);
            this.checkLunes.Name = "checkLunes";
            this.checkLunes.Size = new System.Drawing.Size(55, 17);
            this.checkLunes.TabIndex = 4;
            this.checkLunes.Text = "Lunes";
            this.checkLunes.UseVisualStyleBackColor = true;
            this.checkLunes.CheckedChanged += new System.EventHandler(this.checkLunes_CheckedChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(219, 103);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(243, 87);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(219, 64);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(240, 48);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Horario de atencion del hospital ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lunes a Viernes de 07:00 a 20:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sabados de 10:00 a 15:00 ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(367, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(367, 42);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(367, 71);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblIDProf
            // 
            this.lblIDProf.AutoSize = true;
            this.lblIDProf.Location = new System.Drawing.Point(448, 18);
            this.lblIDProf.Name = "lblIDProf";
            this.lblIDProf.Size = new System.Drawing.Size(0, 13);
            this.lblIDProf.TabIndex = 5;
            this.lblIDProf.Visible = false;
            // 
            // RegistroAgendaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 277);
            this.Controls.Add(this.lblIDProf);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistroAgendaMedico";
            this.Text = "RegistroAgendaMedico";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNomYApe;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox tBoxDni;
        private System.Windows.Forms.TextBox tBoxNomYApe;
        private System.Windows.Forms.Button btnBuscarProf;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox checkSabado;
        private System.Windows.Forms.CheckBox checkViernes;
        private System.Windows.Forms.CheckBox checkJueves;
        private System.Windows.Forms.CheckBox checkMiercoles;
        private System.Windows.Forms.CheckBox checkMartes;
        private System.Windows.Forms.CheckBox checkLunes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tBoxHastaMiercoles;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeMiercoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tBoxHastaMartes;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeMartes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tBoxHastaLunes;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeLunes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tBoxHastaSabado;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeSabado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tBoxHastaViernes;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeViernes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tBoxHastaJueves;
        private System.Windows.Forms.MaskedTextBox tBoxDesdeJueves;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblIDProf;
    }
}