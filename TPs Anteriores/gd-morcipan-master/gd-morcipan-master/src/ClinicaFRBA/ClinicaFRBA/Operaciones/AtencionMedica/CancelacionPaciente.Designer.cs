namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    partial class CancelacionPaciente
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
            this.gdDatosCancelacion = new System.Windows.Forms.GroupBox();
            this.cmbTurnosAfiliado = new System.Windows.Forms.ComboBox();
            this.lblTurnoCancelar = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblDatosAfiliado = new System.Windows.Forms.Label();
            this.lblNroAfiliado = new System.Windows.Forms.Label();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.cmbTipoCancelacion = new System.Windows.Forms.ComboBox();
            this.btnValidarAfiliado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gdDatosCancelacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdDatosCancelacion
            // 
            this.gdDatosCancelacion.Controls.Add(this.cmbTurnosAfiliado);
            this.gdDatosCancelacion.Controls.Add(this.lblTurnoCancelar);
            this.gdDatosCancelacion.Controls.Add(this.lblMotivo);
            this.gdDatosCancelacion.Controls.Add(this.richTextBox1);
            this.gdDatosCancelacion.Controls.Add(this.lblDatosAfiliado);
            this.gdDatosCancelacion.Controls.Add(this.lblNroAfiliado);
            this.gdDatosCancelacion.Controls.Add(this.txtNroAfiliado);
            this.gdDatosCancelacion.Controls.Add(this.cmbTipoCancelacion);
            this.gdDatosCancelacion.Controls.Add(this.btnValidarAfiliado);
            this.gdDatosCancelacion.Controls.Add(this.label1);
            this.gdDatosCancelacion.Location = new System.Drawing.Point(12, 12);
            this.gdDatosCancelacion.Name = "gdDatosCancelacion";
            this.gdDatosCancelacion.Size = new System.Drawing.Size(476, 351);
            this.gdDatosCancelacion.TabIndex = 0;
            this.gdDatosCancelacion.TabStop = false;
            this.gdDatosCancelacion.Text = "Datos de Cancelación";
            // 
            // cmbTurnosAfiliado
            // 
            this.cmbTurnosAfiliado.FormattingEnabled = true;
            this.cmbTurnosAfiliado.Location = new System.Drawing.Point(139, 103);
            this.cmbTurnosAfiliado.Name = "cmbTurnosAfiliado";
            this.cmbTurnosAfiliado.Size = new System.Drawing.Size(171, 21);
            this.cmbTurnosAfiliado.TabIndex = 8;
            // 
            // lblTurnoCancelar
            // 
            this.lblTurnoCancelar.AutoSize = true;
            this.lblTurnoCancelar.Location = new System.Drawing.Point(28, 106);
            this.lblTurnoCancelar.Name = "lblTurnoCancelar";
            this.lblTurnoCancelar.Size = new System.Drawing.Size(92, 13);
            this.lblTurnoCancelar.TabIndex = 7;
            this.lblTurnoCancelar.Text = "Turno a Cancelar:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(28, 143);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(104, 13);
            this.lblMotivo.TabIndex = 9;
            this.lblMotivo.Text = "Motivo Cancelación:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(139, 140);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 198);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // lblDatosAfiliado
            // 
            this.lblDatosAfiliado.AutoSize = true;
            this.lblDatosAfiliado.Location = new System.Drawing.Point(316, 19);
            this.lblDatosAfiliado.Name = "lblDatosAfiliado";
            this.lblDatosAfiliado.Size = new System.Drawing.Size(85, 13);
            this.lblDatosAfiliado.TabIndex = 4;
            this.lblDatosAfiliado.Text = "[lblDatosAfiliado]";
            // 
            // lblNroAfiliado
            // 
            this.lblNroAfiliado.AutoSize = true;
            this.lblNroAfiliado.Location = new System.Drawing.Point(28, 34);
            this.lblNroAfiliado.Name = "lblNroAfiliado";
            this.lblNroAfiliado.Size = new System.Drawing.Size(67, 13);
            this.lblNroAfiliado.TabIndex = 1;
            this.lblNroAfiliado.Text = "Nro. Afiliado:";
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Location = new System.Drawing.Point(139, 31);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(108, 20);
            this.txtNroAfiliado.TabIndex = 2;
            this.txtNroAfiliado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroAfiliado_KeyPress);
            // 
            // cmbTipoCancelacion
            // 
            this.cmbTipoCancelacion.FormattingEnabled = true;
            this.cmbTipoCancelacion.Items.AddRange(new object[] {
            "VACACIONES",
            "PARTICULAR",
            "OTRO"});
            this.cmbTipoCancelacion.Location = new System.Drawing.Point(139, 65);
            this.cmbTipoCancelacion.Name = "cmbTipoCancelacion";
            this.cmbTipoCancelacion.Size = new System.Drawing.Size(171, 21);
            this.cmbTipoCancelacion.TabIndex = 6;
            // 
            // btnValidarAfiliado
            // 
            this.btnValidarAfiliado.Location = new System.Drawing.Point(253, 28);
            this.btnValidarAfiliado.Name = "btnValidarAfiliado";
            this.btnValidarAfiliado.Size = new System.Drawing.Size(56, 23);
            this.btnValidarAfiliado.TabIndex = 3;
            this.btnValidarAfiliado.Text = "Validar";
            this.btnValidarAfiliado.UseVisualStyleBackColor = true;
            this.btnValidarAfiliado.Click += new System.EventHandler(this.btnValidarAfiliado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo Cancelación:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(503, 55);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(503, 26);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CancelacionPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 375);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gdDatosCancelacion);
            this.Name = "CancelacionPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clínica FRBA: Cancelación de Atención Médica (Paciente)";
            this.Load += new System.EventHandler(this.CancelacionPaciente_Load);
            this.gdDatosCancelacion.ResumeLayout(false);
            this.gdDatosCancelacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gdDatosCancelacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoCancelacion;
        private System.Windows.Forms.Label lblDatosAfiliado;
        private System.Windows.Forms.Label lblNroAfiliado;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private System.Windows.Forms.Button btnValidarAfiliado;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbTurnosAfiliado;
        private System.Windows.Forms.Label lblTurnoCancelar;
    }
}