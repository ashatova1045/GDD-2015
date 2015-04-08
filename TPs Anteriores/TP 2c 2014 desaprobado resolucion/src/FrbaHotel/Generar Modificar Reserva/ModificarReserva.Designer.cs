namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ModificarReserva
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
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbHotel = new System.Windows.Forms.ComboBox();
            this.Hotel = new System.Windows.Forms.Label();
            this.modificarb = new System.Windows.Forms.Button();
            this.HabitacionesDisponibles = new System.Windows.Forms.Label();
            this.ResultGridHabitacionesBuscadas = new System.Windows.Forms.DataGridView();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.Regimen = new System.Windows.Forms.Label();
            this.cmbTipoHab = new System.Windows.Forms.ComboBox();
            this.tipoHabitacion = new System.Windows.Forms.Label();
            this.calendarioHasta = new System.Windows.Forms.MonthCalendar();
            this.Hasta = new System.Windows.Forms.Label();
            this.calendarioDesde = new System.Windows.Forms.MonthCalendar();
            this.Desde = new System.Windows.Forms.Label();
            this.labelNReserva = new System.Windows.Forms.Label();
            this.txtNReserva = new System.Windows.Forms.TextBox();
            this.btnBuscarReserva = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridHabitacionesBuscadas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(275, 255);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(139, 96);
            this.btnConsultar.TabIndex = 34;
            this.btnConsultar.Text = "Consultar disponibilidad:";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(367, 661);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 32;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbHotel
            // 
            this.cmbHotel.FormattingEnabled = true;
            this.cmbHotel.Location = new System.Drawing.Point(125, 235);
            this.cmbHotel.Name = "cmbHotel";
            this.cmbHotel.Size = new System.Drawing.Size(121, 21);
            this.cmbHotel.TabIndex = 31;
            // 
            // Hotel
            // 
            this.Hotel.AutoSize = true;
            this.Hotel.Location = new System.Drawing.Point(6, 238);
            this.Hotel.Name = "Hotel";
            this.Hotel.Size = new System.Drawing.Size(35, 13);
            this.Hotel.TabIndex = 30;
            this.Hotel.Text = "Hotel:";
            // 
            // modificarb
            // 
            this.modificarb.Location = new System.Drawing.Point(472, 385);
            this.modificarb.Name = "modificarb";
            this.modificarb.Size = new System.Drawing.Size(131, 29);
            this.modificarb.TabIndex = 44;
            this.modificarb.Text = "Modificar Reserva";
            this.modificarb.UseVisualStyleBackColor = true;
            this.modificarb.Visible = false;
            this.modificarb.Click += new System.EventHandler(this.modificarb_Click);
            // 
            // HabitacionesDisponibles
            // 
            this.HabitacionesDisponibles.AutoSize = true;
            this.HabitacionesDisponibles.Location = new System.Drawing.Point(6, 332);
            this.HabitacionesDisponibles.Name = "HabitacionesDisponibles";
            this.HabitacionesDisponibles.Size = new System.Drawing.Size(127, 13);
            this.HabitacionesDisponibles.TabIndex = 28;
            this.HabitacionesDisponibles.Text = "Habitaciones disponibles:";
            // 
            // ResultGridHabitacionesBuscadas
            // 
            this.ResultGridHabitacionesBuscadas.AllowUserToAddRows = false;
            this.ResultGridHabitacionesBuscadas.AllowUserToDeleteRows = false;
            this.ResultGridHabitacionesBuscadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridHabitacionesBuscadas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ResultGridHabitacionesBuscadas.Location = new System.Drawing.Point(9, 357);
            this.ResultGridHabitacionesBuscadas.Name = "ResultGridHabitacionesBuscadas";
            this.ResultGridHabitacionesBuscadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultGridHabitacionesBuscadas.Size = new System.Drawing.Size(402, 176);
            this.ResultGridHabitacionesBuscadas.TabIndex = 27;
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Location = new System.Drawing.Point(125, 262);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(121, 21);
            this.cmbRegimen.TabIndex = 26;
            // 
            // Regimen
            // 
            this.Regimen.AutoSize = true;
            this.Regimen.Location = new System.Drawing.Point(6, 265);
            this.Regimen.Name = "Regimen";
            this.Regimen.Size = new System.Drawing.Size(52, 13);
            this.Regimen.TabIndex = 25;
            this.Regimen.Text = "Regimen:";
            // 
            // cmbTipoHab
            // 
            this.cmbTipoHab.FormattingEnabled = true;
            this.cmbTipoHab.Location = new System.Drawing.Point(124, 299);
            this.cmbTipoHab.Name = "cmbTipoHab";
            this.cmbTipoHab.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoHab.TabIndex = 23;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.AutoSize = true;
            this.tipoHabitacion.Location = new System.Drawing.Point(6, 302);
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.Size = new System.Drawing.Size(98, 13);
            this.tipoHabitacion.TabIndex = 22;
            this.tipoHabitacion.Text = "Tipo de habitacion:";
            // 
            // calendarioHasta
            // 
            this.calendarioHasta.Location = new System.Drawing.Point(243, 68);
            this.calendarioHasta.MaxSelectionCount = 1;
            this.calendarioHasta.Name = "calendarioHasta";
            this.calendarioHasta.TabIndex = 21;
            // 
            // Hasta
            // 
            this.Hasta.AutoSize = true;
            this.Hasta.Location = new System.Drawing.Point(240, 46);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(38, 13);
            this.Hasta.TabIndex = 20;
            this.Hasta.Text = "Hasta:";
            // 
            // calendarioDesde
            // 
            this.calendarioDesde.Location = new System.Drawing.Point(12, 68);
            this.calendarioDesde.MaxSelectionCount = 1;
            this.calendarioDesde.Name = "calendarioDesde";
            this.calendarioDesde.TabIndex = 19;
            // 
            // Desde
            // 
            this.Desde.AutoSize = true;
            this.Desde.Location = new System.Drawing.Point(6, 46);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(41, 13);
            this.Desde.TabIndex = 18;
            this.Desde.Text = "Desde:";
            // 
            // labelNReserva
            // 
            this.labelNReserva.AutoSize = true;
            this.labelNReserva.Location = new System.Drawing.Point(9, 13);
            this.labelNReserva.Name = "labelNReserva";
            this.labelNReserva.Size = new System.Drawing.Size(147, 13);
            this.labelNReserva.TabIndex = 40;
            this.labelNReserva.Text = "Ingrese el numero de reserva:";
            // 
            // txtNReserva
            // 
            this.txtNReserva.Location = new System.Drawing.Point(210, 13);
            this.txtNReserva.Name = "txtNReserva";
            this.txtNReserva.Size = new System.Drawing.Size(204, 20);
            this.txtNReserva.TabIndex = 41;
            // 
            // btnBuscarReserva
            // 
            this.btnBuscarReserva.Location = new System.Drawing.Point(452, 13);
            this.btnBuscarReserva.Name = "btnBuscarReserva";
            this.btnBuscarReserva.Size = new System.Drawing.Size(171, 23);
            this.btnBuscarReserva.TabIndex = 42;
            this.btnBuscarReserva.Text = "Consultar Reserva";
            this.btnBuscarReserva.UseVisualStyleBackColor = true;
            this.btnBuscarReserva.Click += new System.EventHandler(this.btnBuscarReserva_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(472, 463);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(131, 31);
            this.volver.TabIndex = 43;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 540);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.btnBuscarReserva);
            this.Controls.Add(this.txtNReserva);
            this.Controls.Add(this.labelNReserva);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbHotel);
            this.Controls.Add(this.Hotel);
            this.Controls.Add(this.modificarb);
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
            this.Name = "ModificarReserva";
            this.Text = "ModificarReserva";
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridHabitacionesBuscadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbHotel;
        private System.Windows.Forms.Label Hotel;
        private System.Windows.Forms.Button modificarb;
        private System.Windows.Forms.Label HabitacionesDisponibles;
        private System.Windows.Forms.DataGridView ResultGridHabitacionesBuscadas;
        private System.Windows.Forms.ComboBox cmbRegimen;
        private System.Windows.Forms.Label Regimen;
        private System.Windows.Forms.ComboBox cmbTipoHab;
        private System.Windows.Forms.Label tipoHabitacion;
        private System.Windows.Forms.MonthCalendar calendarioHasta;
        private System.Windows.Forms.Label Hasta;
        private System.Windows.Forms.MonthCalendar calendarioDesde;
        private System.Windows.Forms.Label Desde;
        private System.Windows.Forms.Label labelNReserva;
        private System.Windows.Forms.TextBox txtNReserva;
        private System.Windows.Forms.Button btnBuscarReserva;
        private System.Windows.Forms.Button volver;
        
    }
}