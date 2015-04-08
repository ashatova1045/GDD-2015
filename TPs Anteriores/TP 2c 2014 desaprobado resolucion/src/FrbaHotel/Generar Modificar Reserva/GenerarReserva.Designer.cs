namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class GenerarReserva
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
            this.Desde = new System.Windows.Forms.Label();
            this.calendarioDesde = new System.Windows.Forms.MonthCalendar();
            this.calendarioHasta = new System.Windows.Forms.MonthCalendar();
            this.Hasta = new System.Windows.Forms.Label();
            this.tipoHabitacion = new System.Windows.Forms.Label();
            this.cmbTipoHab = new System.Windows.Forms.ComboBox();
            this.Regimen = new System.Windows.Forms.Label();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.ResultGridHabitacionesBuscadas = new System.Windows.Forms.DataGridView();
            this.habum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HabitacionesDisponibles = new System.Windows.Forms.Label();
            this.btnConfirmarReserva = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.hotelcmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridHabitacionesBuscadas)).BeginInit();
            this.SuspendLayout();
            // 
            // Desde
            // 
            this.Desde.AutoSize = true;
            this.Desde.Location = new System.Drawing.Point(12, 1);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(41, 13);
            this.Desde.TabIndex = 0;
            this.Desde.Text = "Desde:";
            // 
            // calendarioDesde
            // 
            this.calendarioDesde.Location = new System.Drawing.Point(18, 23);
            this.calendarioDesde.MaxSelectionCount = 1;
            this.calendarioDesde.Name = "calendarioDesde";
            this.calendarioDesde.TabIndex = 1;
            // 
            // calendarioHasta
            // 
            this.calendarioHasta.Location = new System.Drawing.Point(249, 23);
            this.calendarioHasta.MaxSelectionCount = 1;
            this.calendarioHasta.Name = "calendarioHasta";
            this.calendarioHasta.TabIndex = 3;
            // 
            // Hasta
            // 
            this.Hasta.AutoSize = true;
            this.Hasta.Location = new System.Drawing.Point(246, 1);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(38, 13);
            this.Hasta.TabIndex = 2;
            this.Hasta.Text = "Hasta:";
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.AutoSize = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(12, 288);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(98, 13);
            this.tipoHabitacion.TabIndex = 4;
            this.tipoHabitacion.Text = "Tipo de habitacion:";
            // 
            // cmbTipoHab
            // 
            this.cmbTipoHab.FormattingEnabled = true;
            this.cmbTipoHab.Location = new System.Drawing.Point(130, 285);
            this.cmbTipoHab.Name = "cmbTipoHab";
            this.cmbTipoHab.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoHab.TabIndex = 5;
            // 
            // Regimen
            // 
            this.Regimen.AutoSize = true;
            this.Regimen.Location = new System.Drawing.Point(12, 220);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(52, 13);
            this.Regimen.TabIndex = 8;
            this.Regimen.Text = "Regimen:";
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Location = new System.Drawing.Point(131, 217);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(121, 21);
            this.cmbRegimen.TabIndex = 9;
            // 
            // ResultGridHabitacionesBuscadas
            // 
            this.ResultGridHabitacionesBuscadas.AllowUserToAddRows = false;
            this.ResultGridHabitacionesBuscadas.AllowUserToDeleteRows = false;
            this.ResultGridHabitacionesBuscadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridHabitacionesBuscadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.habum});
            this.ResultGridHabitacionesBuscadas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ResultGridHabitacionesBuscadas.Location = new System.Drawing.Point(18, 345);
            this.ResultGridHabitacionesBuscadas.Name = "ResultGridHabitacionesBuscadas";
            this.ResultGridHabitacionesBuscadas.ReadOnly = true;
            this.ResultGridHabitacionesBuscadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultGridHabitacionesBuscadas.Size = new System.Drawing.Size(146, 156);
            this.ResultGridHabitacionesBuscadas.TabIndex = 10;
            // 
            // habum
            // 
            this.habum.DataPropertyName = "Habitacion_Numero";
            this.habum.HeaderText = "Numero";
            this.habum.Name = "habum";
            this.habum.ReadOnly = true;
            // 
            // HabitacionesDisponibles
            // 
            this.HabitacionesDisponibles.AutoSize = true;
            this.HabitacionesDisponibles.Location = new System.Drawing.Point(12, 318);
            this.HabitacionesDisponibles.Name = "HabitacionesDisponibles";
            this.HabitacionesDisponibles.Size = new System.Drawing.Size(127, 13);
            this.HabitacionesDisponibles.TabIndex = 11;
            this.HabitacionesDisponibles.Text = "Habitaciones disponibles:";
            // 
            // btnConfirmarReserva
            // 
            this.btnConfirmarReserva.Location = new System.Drawing.Point(210, 454);
            this.btnConfirmarReserva.Name = "btnConfirmarReserva";
            this.btnConfirmarReserva.Size = new System.Drawing.Size(108, 23);
            this.btnConfirmarReserva.TabIndex = 12;
            this.btnConfirmarReserva.Text = "Confirmar Reserva";
            this.btnConfirmarReserva.UseVisualStyleBackColor = true;
            this.btnConfirmarReserva.Click += new System.EventHandler(this.btnConfirmarReserva_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(345, 454);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(281, 210);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(139, 96);
            this.btnConsultar.TabIndex = 17;
            this.btnConsultar.Text = "Consultar:";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // hotelcmb
            // 
            this.hotelcmb.FormattingEnabled = true;
            this.hotelcmb.Location = new System.Drawing.Point(130, 190);
            this.hotelcmb.Name = "hotelcmb";
            this.hotelcmb.Size = new System.Drawing.Size(121, 21);
            this.hotelcmb.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hotel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Valor de cada habitacion por noche";
            // 
            // valor
            // 
            this.valor.Enabled = false;
            this.valor.Location = new System.Drawing.Point(333, 427);
            this.valor.Name = "valor";
            this.valor.Size = new System.Drawing.Size(80, 20);
            this.valor.TabIndex = 21;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 512);
            this.Controls.Add(this.valor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hotelcmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmarReserva);
            this.Controls.Add(this.HabitacionesDisponibles);
            this.Controls.Add(this.ResultGridHabitacionesBuscadas);
            this.Controls.Add(this.cmbRegimen);
            this.Controls.Add(this.Regimen);
            this.Controls.Add(this.cmbTipoHab);
            this.Controls.Add(this.tipoHabitacion);
            this.Controls.Add(this.calendarioHasta);
            this.Controls.Add(this.Hasta);
            this.Controls.Add(this.calendarioDesde);
            this.Controls.Add(this.Desde);
            this.Name = "GenerarReserva";
            this.Text = "Nueva Reserva";
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridHabitacionesBuscadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.MonthCalendar calendarioDesde;
        private System.Windows.Forms.MonthCalendar calendarioHasta;
        private System.Windows.Forms.Label Hasta;
        private System.Windows.Forms.Label tipoHabitacion;
        private System.Windows.Forms.ComboBox cmbTipoHab;
        private System.Windows.Forms.Label Regimen;
        private System.Windows.Forms.ComboBox cmbRegimen;
        private System.Windows.Forms.DataGridView ResultGridHabitacionesBuscadas;
        private System.Windows.Forms.Label HabitacionesDisponibles;
        private System.Windows.Forms.Button btnConfirmarReserva;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox hotelcmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn habum;
    }
}