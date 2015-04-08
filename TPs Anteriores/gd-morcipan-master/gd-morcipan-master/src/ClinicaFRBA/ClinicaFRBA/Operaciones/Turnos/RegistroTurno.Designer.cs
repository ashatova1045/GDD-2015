namespace ClinicaFRBA.Operaciones.Turnos
{
    partial class RegistroTurno
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
            this.gbTurnos = new System.Windows.Forms.GroupBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.horaTurno = new System.Windows.Forms.ComboBox();
            this.fechaTurno = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbAfiliado = new System.Windows.Forms.GroupBox();
            this.lblDatosAfiliado = new System.Windows.Forms.Label();
            this.btnBuscarAfiliado = new System.Windows.Forms.Button();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.gbCompraBono.SuspendLayout();
            this.gbTurnos.SuspendLayout();
            this.gbAfiliado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompraBono
            // 
            this.gbCompraBono.Controls.Add(this.lblProfesionalDatos);
            this.gbCompraBono.Controls.Add(this.btnBuscarProfesional);
            this.gbCompraBono.Controls.Add(this.lblProfesional);
            this.gbCompraBono.Location = new System.Drawing.Point(12, 114);
            this.gbCompraBono.Name = "gbCompraBono";
            this.gbCompraBono.Size = new System.Drawing.Size(619, 68);
            this.gbCompraBono.TabIndex = 1;
            this.gbCompraBono.TabStop = false;
            this.gbCompraBono.Text = "Datos de Profesional";
            // 
            // lblProfesionalDatos
            // 
            this.lblProfesionalDatos.AutoSize = true;
            this.lblProfesionalDatos.Location = new System.Drawing.Point(151, 15);
            this.lblProfesionalDatos.Name = "lblProfesionalDatos";
            this.lblProfesionalDatos.Size = new System.Drawing.Size(0, 13);
            this.lblProfesionalDatos.TabIndex = 3;
            // 
            // btnBuscarProfesional
            // 
            this.btnBuscarProfesional.Location = new System.Drawing.Point(84, 21);
            this.btnBuscarProfesional.Name = "btnBuscarProfesional";
            this.btnBuscarProfesional.Size = new System.Drawing.Size(56, 23);
            this.btnBuscarProfesional.TabIndex = 4;
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
            this.lblProfesional.TabIndex = 3;
            this.lblProfesional.Text = "Profesional:";
            // 
            // gbTurnos
            // 
            this.gbTurnos.Controls.Add(this.lblHora);
            this.gbTurnos.Controls.Add(this.lblFecha);
            this.gbTurnos.Controls.Add(this.horaTurno);
            this.gbTurnos.Controls.Add(this.fechaTurno);
            this.gbTurnos.Location = new System.Drawing.Point(12, 191);
            this.gbTurnos.Name = "gbTurnos";
            this.gbTurnos.Size = new System.Drawing.Size(619, 79);
            this.gbTurnos.TabIndex = 2;
            this.gbTurnos.TabStop = false;
            this.gbTurnos.Text = "Fecha de Turno";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(223, 36);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "Hora:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 36);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            // 
            // horaTurno
            // 
            this.horaTurno.Enabled = false;
            this.horaTurno.FormattingEnabled = true;
            this.horaTurno.Location = new System.Drawing.Point(291, 33);
            this.horaTurno.Name = "horaTurno";
            this.horaTurno.Size = new System.Drawing.Size(121, 21);
            this.horaTurno.TabIndex = 8;
            // 
            // fechaTurno
            // 
            this.fechaTurno.CustomFormat = "dd/MM/yyyy";
            this.fechaTurno.Enabled = false;
            this.fechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaTurno.Location = new System.Drawing.Point(84, 32);
            this.fechaTurno.Name = "fechaTurno";
            this.fechaTurno.Size = new System.Drawing.Size(121, 20);
            this.fechaTurno.TabIndex = 6;
            this.fechaTurno.ValueChanged += new System.EventHandler(this.fechaTurno_ValueChanged);
            this.fechaTurno.DropDown += new System.EventHandler(this.fechaTurno_DropDown);
            this.fechaTurno.CloseUp += new System.EventHandler(this.fechaTurno_CloseUp);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(641, 49);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(641, 78);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbAfiliado
            // 
            this.gbAfiliado.Controls.Add(this.lblDatosAfiliado);
            this.gbAfiliado.Controls.Add(this.btnBuscarAfiliado);
            this.gbAfiliado.Controls.Add(this.lblAfiliado);
            this.gbAfiliado.Location = new System.Drawing.Point(12, 13);
            this.gbAfiliado.Name = "gbAfiliado";
            this.gbAfiliado.Size = new System.Drawing.Size(619, 88);
            this.gbAfiliado.TabIndex = 5;
            this.gbAfiliado.TabStop = false;
            this.gbAfiliado.Text = "Datos Afiliado";
            // 
            // lblDatosAfiliado
            // 
            this.lblDatosAfiliado.AutoSize = true;
            this.lblDatosAfiliado.Location = new System.Drawing.Point(150, 10);
            this.lblDatosAfiliado.Name = "lblDatosAfiliado";
            this.lblDatosAfiliado.Size = new System.Drawing.Size(0, 13);
            this.lblDatosAfiliado.TabIndex = 4;
            // 
            // btnBuscarAfiliado
            // 
            this.btnBuscarAfiliado.Location = new System.Drawing.Point(80, 21);
            this.btnBuscarAfiliado.Name = "btnBuscarAfiliado";
            this.btnBuscarAfiliado.Size = new System.Drawing.Size(56, 23);
            this.btnBuscarAfiliado.TabIndex = 2;
            this.btnBuscarAfiliado.Text = "Buscar";
            this.btnBuscarAfiliado.UseVisualStyleBackColor = true;
            this.btnBuscarAfiliado.Click += new System.EventHandler(this.btnBuscarAfiliado_Click);
            // 
            // lblAfiliado
            // 
            this.lblAfiliado.AutoSize = true;
            this.lblAfiliado.Location = new System.Drawing.Point(12, 26);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(44, 13);
            this.lblAfiliado.TabIndex = 1;
            this.lblAfiliado.Text = "Afiliado:";
            // 
            // RegistroTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 289);
            this.Controls.Add(this.gbAfiliado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbTurnos);
            this.Controls.Add(this.gbCompraBono);
            this.Name = "RegistroTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínico FRBA: Pedido de Turno";
            this.gbCompraBono.ResumeLayout(false);
            this.gbCompraBono.PerformLayout();
            this.gbTurnos.ResumeLayout(false);
            this.gbTurnos.PerformLayout();
            this.gbAfiliado.ResumeLayout(false);
            this.gbAfiliado.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbCompraBono;
        private System.Windows.Forms.Button btnBuscarProfesional;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.Label lblProfesionalDatos;
        private System.Windows.Forms.GroupBox gbTurnos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox gbAfiliado;
        private System.Windows.Forms.Button btnBuscarAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.Label lblDatosAfiliado;
        private System.Windows.Forms.DateTimePicker fechaTurno;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox horaTurno;
    }
}