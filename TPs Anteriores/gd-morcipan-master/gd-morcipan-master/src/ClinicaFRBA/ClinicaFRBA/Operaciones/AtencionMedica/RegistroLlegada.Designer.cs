namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    partial class RegistroLlegada
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
            this.gbCompraBono = new System.Windows.Forms.GroupBox();
            this.lblProfesionalDatos = new System.Windows.Forms.Label();
            this.btnBuscarProfesional = new System.Windows.Forms.Button();
            this.lblProfesional = new System.Windows.Forms.Label();
            this.gbTurnosDelDia = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBonosConsulta = new System.Windows.Forms.Label();
            this.cmbBonosConsulta = new System.Windows.Forms.ComboBox();
            this.lblDatosAfiliado = new System.Windows.Forms.Label();
            this.lblNroAfiliado = new System.Windows.Forms.Label();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.btnValidarAfiliado = new System.Windows.Forms.Button();
            this.dgTurnos = new System.Windows.Forms.DataGridView();
            this.idTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCompraBono.SuspendLayout();
            this.gbTurnosDelDia.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCompraBono
            // 
            this.gbCompraBono.Controls.Add(this.lblProfesionalDatos);
            this.gbCompraBono.Controls.Add(this.btnBuscarProfesional);
            this.gbCompraBono.Controls.Add(this.lblProfesional);
            this.gbCompraBono.Location = new System.Drawing.Point(13, 12);
            this.gbCompraBono.Name = "gbCompraBono";
            this.gbCompraBono.Size = new System.Drawing.Size(619, 58);
            this.gbCompraBono.TabIndex = 2;
            this.gbCompraBono.TabStop = false;
            this.gbCompraBono.Text = "Datos de Profesional";
            // 
            // lblProfesionalDatos
            // 
            this.lblProfesionalDatos.AutoSize = true;
            this.lblProfesionalDatos.Location = new System.Drawing.Point(155, 11);
            this.lblProfesionalDatos.Name = "lblProfesionalDatos";
            this.lblProfesionalDatos.Size = new System.Drawing.Size(0, 13);
            this.lblProfesionalDatos.TabIndex = 3;
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(84, 21);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(56, 23);
            this.btnBuscarProfesional.TabIndex = 2;
            this.btnBuscarProfesional.Text = "Buscar";
            this.btnBuscarProfesional.UseVisualStyleBackColor = true;
            this.btnBuscarProfesional.Click += new System.EventHandler(this.btnBuscarProfesional_Click);
            // 
            // lblProfesional
            // 
            this.lblProfesional.AutoSize = true;
            this.lblProfesional.Location = new System.Drawing.Point(16, 26);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(62, 13);
            this.lblProfesional.TabIndex = 2;
            this.lblProfesional.Text = "Profesional:";
            // 
            // gbTurnosDelDia
            // 
            this.gbTurnosDelDia.Controls.Add(this.groupBox1);
            this.gbTurnosDelDia.Controls.Add(this.dgTurnos);
            this.gbTurnosDelDia.Location = new System.Drawing.Point(14, 76);
            this.gbTurnosDelDia.Name = "gbTurnosDelDia";
            this.gbTurnosDelDia.Size = new System.Drawing.Size(618, 215);
            this.gbTurnosDelDia.TabIndex = 3;
            this.gbTurnosDelDia.TabStop = false;
            this.gbTurnosDelDia.Text = "Turnos del día";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBonosConsulta);
            this.groupBox1.Controls.Add(this.cmbBonosConsulta);
            this.groupBox1.Controls.Add(this.lblDatosAfiliado);
            this.groupBox1.Controls.Add(this.lblNroAfiliado);
            this.groupBox1.Controls.Add(this.txtNroAfiliado);
            this.groupBox1.Controls.Add(this.btnValidarAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(18, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 97);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Afiliado";
            // 
            // lblBonosConsulta
            // 
            this.lblBonosConsulta.AutoSize = true;
            this.lblBonosConsulta.Location = new System.Drawing.Point(15, 67);
            this.lblBonosConsulta.Name = "lblBonosConsulta";
            this.lblBonosConsulta.Size = new System.Drawing.Size(79, 13);
            this.lblBonosConsulta.TabIndex = 5;
            this.lblBonosConsulta.Text = "Bono Consulta:";
            // 
            // cmbBonosConsulta
            // 
            this.cmbBonosConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBonosConsulta.Enabled = false;
            this.cmbBonosConsulta.FormattingEnabled = true;
            this.cmbBonosConsulta.Location = new System.Drawing.Point(98, 64);
            this.cmbBonosConsulta.Name = "cmbBonosConsulta";
            this.cmbBonosConsulta.Size = new System.Drawing.Size(121, 21);
            this.cmbBonosConsulta.TabIndex = 4;
            // 
            // lblDatosAfiliado
            // 
            this.lblDatosAfiliado.AutoSize = true;
            this.lblDatosAfiliado.Location = new System.Drawing.Point(229, 16);
            this.lblDatosAfiliado.Name = "lblDatosAfiliado";
            this.lblDatosAfiliado.Size = new System.Drawing.Size(85, 13);
            this.lblDatosAfiliado.TabIndex = 3;
            this.lblDatosAfiliado.Text = "[lblDatosAfiliado]";
            // 
            // lblNroAfiliado
            // 
            this.lblNroAfiliado.AutoSize = true;
            this.lblNroAfiliado.Location = new System.Drawing.Point(15, 31);
            this.lblNroAfiliado.Name = "lblNroAfiliado";
            this.lblNroAfiliado.Size = new System.Drawing.Size(67, 13);
            this.lblNroAfiliado.TabIndex = 0;
            this.lblNroAfiliado.Text = "Nro. Afiliado:";
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Enabled = false;
            this.txtNroAfiliado.Location = new System.Drawing.Point(98, 28);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(62, 20);
            this.txtNroAfiliado.TabIndex = 1;
            this.txtNroAfiliado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroAfiliado_KeyPress);
            // 
            // btnValidarAfiliado
            // 
            this.btnValidarAfiliado.Enabled = false;
            this.btnValidarAfiliado.Location = new System.Drawing.Point(166, 25);
            this.btnValidarAfiliado.Name = "btnValidarAfiliado";
            this.btnValidarAfiliado.Size = new System.Drawing.Size(56, 23);
            this.btnValidarAfiliado.TabIndex = 2;
            this.btnValidarAfiliado.Text = "Validar";
            this.btnValidarAfiliado.UseVisualStyleBackColor = true;
            this.btnValidarAfiliado.Click += new System.EventHandler(this.btnValidarAfiliado_Click);
            // 
            // dgTurnos
            // 
            this.dgTurnos.AllowUserToAddRows = false;
            this.dgTurnos.AllowUserToDeleteRows = false;
            this.dgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTurno,
            this.idAfiliado,
            this.hsTurno});
            this.dgTurnos.Location = new System.Drawing.Point(448, 19);
            this.dgTurnos.MultiSelect = false;
            this.dgTurnos.Name = "dgTurnos";
            this.dgTurnos.ReadOnly = true;
            this.dgTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTurnos.Size = new System.Drawing.Size(150, 190);
            this.dgTurnos.TabIndex = 10;
            // 
            // idTurno
            // 
            this.idTurno.HeaderText = "IdTurno";
            this.idTurno.Name = "idTurno";
            this.idTurno.ReadOnly = true;
            this.idTurno.Visible = false;
            // 
            // idAfiliado
            // 
            this.idAfiliado.HeaderText = "IdAfiliado";
            this.idAfiliado.Name = "idAfiliado";
            this.idAfiliado.ReadOnly = true;
            this.idAfiliado.Visible = false;
            // 
            // hsTurno
            // 
            this.hsTurno.HeaderText = "Turno";
            this.hsTurno.Name = "hsTurno";
            this.hsTurno.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(640, 47);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(640, 18);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 304);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbTurnosDelDia);
            this.Controls.Add(this.gbCompraBono);
            this.Name = "RegistroLlegada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Registro de Llegada (Turnos)";
            this.gbCompraBono.ResumeLayout(false);
            this.gbCompraBono.PerformLayout();
            this.gbTurnosDelDia.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompraBono;
        private System.Windows.Forms.Label lblProfesionalDatos;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.GroupBox gbTurnosDelDia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDatosAfiliado;
        private System.Windows.Forms.Button btnValidarAfiliado;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private System.Windows.Forms.Label lblNroAfiliado;
        private System.Windows.Forms.DataGridView dgTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsTurno;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbBonosConsulta;
        private System.Windows.Forms.Label lblBonosConsulta;
    }
}