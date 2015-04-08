namespace FrbaHotel.ABM_de_Habitacion
{
    partial class ABMHabitacionVentanaPrincipal
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
            this.NuevaHabitacionBoton = new System.Windows.Forms.Button();
            this.ModificarHabitacionBoton = new System.Windows.Forms.Button();
            this.DarBajaHabitacionBoton = new System.Windows.Forms.Button();
            this.BuscarHabitacionBoton = new System.Windows.Forms.Button();
            this.LimpiarBusquedaBoton = new System.Windows.Forms.Button();
            this.dgvHabitacion = new System.Windows.Forms.DataGridView();
            this.VentanaPrincipalHabitacionVolverBoton = new System.Windows.Forms.Button();
            this.codigoHabitacionlabel = new System.Windows.Forms.Label();
            this.PisoHabitacionlabel = new System.Windows.Forms.Label();
            this.TipoHabitacionLabel = new System.Windows.Forms.Label();
            this.CodHabitacionTextBox = new System.Windows.Forms.TextBox();
            this.PisoHabitacionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HotelNombreTextBox = new System.Windows.Forms.TextBox();
            this.TipoNuevaHabitacioncomboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.habilitadach = new System.Windows.Forms.CheckBox();
            this.nroHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pisoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NuevaHabitacionBoton
            // 
            this.NuevaHabitacionBoton.Location = new System.Drawing.Point(609, 30);
            this.NuevaHabitacionBoton.Name = "NuevaHabitacionBoton";
            this.NuevaHabitacionBoton.Size = new System.Drawing.Size(131, 85);
            this.NuevaHabitacionBoton.TabIndex = 0;
            this.NuevaHabitacionBoton.Text = "Nueva Habitacion";
            this.NuevaHabitacionBoton.UseVisualStyleBackColor = true;
            this.NuevaHabitacionBoton.Click += new System.EventHandler(this.NuevaHabitacionBoton_Click);
            // 
            // ModificarHabitacionBoton
            // 
            this.ModificarHabitacionBoton.Location = new System.Drawing.Point(619, 216);
            this.ModificarHabitacionBoton.Name = "ModificarHabitacionBoton";
            this.ModificarHabitacionBoton.Size = new System.Drawing.Size(108, 39);
            this.ModificarHabitacionBoton.TabIndex = 1;
            this.ModificarHabitacionBoton.Text = "Modificar Habitacion";
            this.ModificarHabitacionBoton.UseVisualStyleBackColor = true;
            this.ModificarHabitacionBoton.Click += new System.EventHandler(this.ModificarHabitacionBoton_Click);
            // 
            // DarBajaHabitacionBoton
            // 
            this.DarBajaHabitacionBoton.Location = new System.Drawing.Point(619, 261);
            this.DarBajaHabitacionBoton.Name = "DarBajaHabitacionBoton";
            this.DarBajaHabitacionBoton.Size = new System.Drawing.Size(108, 38);
            this.DarBajaHabitacionBoton.TabIndex = 2;
            this.DarBajaHabitacionBoton.Text = "Dar de Baja Habitacion";
            this.DarBajaHabitacionBoton.UseVisualStyleBackColor = true;
            this.DarBajaHabitacionBoton.Click += new System.EventHandler(this.DarBajaHabitacionBoton_Click);
            // 
            // BuscarHabitacionBoton
            // 
            this.BuscarHabitacionBoton.Location = new System.Drawing.Point(26, 113);
            this.BuscarHabitacionBoton.Name = "BuscarHabitacionBoton";
            this.BuscarHabitacionBoton.Size = new System.Drawing.Size(135, 30);
            this.BuscarHabitacionBoton.TabIndex = 3;
            this.BuscarHabitacionBoton.Text = "Buscar";
            this.BuscarHabitacionBoton.UseVisualStyleBackColor = true;
            this.BuscarHabitacionBoton.Click += new System.EventHandler(this.BuscarHabitacionBoton_Click);
            // 
            // LimpiarBusquedaBoton
            // 
            this.LimpiarBusquedaBoton.Location = new System.Drawing.Point(213, 113);
            this.LimpiarBusquedaBoton.Name = "LimpiarBusquedaBoton";
            this.LimpiarBusquedaBoton.Size = new System.Drawing.Size(123, 30);
            this.LimpiarBusquedaBoton.TabIndex = 4;
            this.LimpiarBusquedaBoton.Text = "Limpiar";
            this.LimpiarBusquedaBoton.UseVisualStyleBackColor = true;
            this.LimpiarBusquedaBoton.Click += new System.EventHandler(this.LimpiarBusquedaBoton_Click);
            // 
            // dgvHabitacion
            // 
            this.dgvHabitacion.AllowUserToAddRows = false;
            this.dgvHabitacion.AllowUserToDeleteRows = false;
            this.dgvHabitacion.AllowUserToResizeRows = false;
            this.dgvHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nroHabitacion,
            this.pisoHabitacion,
            this.habilitado,
            this.frente,
            this.tipoHabitacion});
            this.dgvHabitacion.Location = new System.Drawing.Point(15, 149);
            this.dgvHabitacion.MultiSelect = false;
            this.dgvHabitacion.Name = "dgvHabitacion";
            this.dgvHabitacion.ReadOnly = true;
            this.dgvHabitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHabitacion.Size = new System.Drawing.Size(552, 219);
            this.dgvHabitacion.TabIndex = 5;
            // 
            // VentanaPrincipalHabitacionVolverBoton
            // 
            this.VentanaPrincipalHabitacionVolverBoton.Location = new System.Drawing.Point(619, 337);
            this.VentanaPrincipalHabitacionVolverBoton.Name = "VentanaPrincipalHabitacionVolverBoton";
            this.VentanaPrincipalHabitacionVolverBoton.Size = new System.Drawing.Size(84, 31);
            this.VentanaPrincipalHabitacionVolverBoton.TabIndex = 6;
            this.VentanaPrincipalHabitacionVolverBoton.Text = "Volver";
            this.VentanaPrincipalHabitacionVolverBoton.UseVisualStyleBackColor = true;
            this.VentanaPrincipalHabitacionVolverBoton.Click += new System.EventHandler(this.VentanaPrincipalHabitacionVolverBoton_Click);
            // 
            // codigoHabitacionlabel
            // 
            this.codigoHabitacionlabel.AutoSize = true;
            this.codigoHabitacionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoHabitacionlabel.Location = new System.Drawing.Point(8, 20);
            this.codigoHabitacionlabel.Name = "codigoHabitacionlabel";
            this.codigoHabitacionlabel.Size = new System.Drawing.Size(149, 17);
            this.codigoHabitacionlabel.TabIndex = 8;
            this.codigoHabitacionlabel.Text = "Numero de Habitacion";
            // 
            // PisoHabitacionlabel
            // 
            this.PisoHabitacionlabel.AutoSize = true;
            this.PisoHabitacionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PisoHabitacionlabel.Location = new System.Drawing.Point(8, 50);
            this.PisoHabitacionlabel.Name = "PisoHabitacionlabel";
            this.PisoHabitacionlabel.Size = new System.Drawing.Size(39, 17);
            this.PisoHabitacionlabel.TabIndex = 9;
            this.PisoHabitacionlabel.Text = "Piso ";
            // 
            // TipoHabitacionLabel
            // 
            this.TipoHabitacionLabel.AutoSize = true;
            this.TipoHabitacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipoHabitacionLabel.Location = new System.Drawing.Point(328, 50);
            this.TipoHabitacionLabel.Name = "TipoHabitacionLabel";
            this.TipoHabitacionLabel.Size = new System.Drawing.Size(36, 17);
            this.TipoHabitacionLabel.TabIndex = 10;
            this.TipoHabitacionLabel.Text = "Tipo";
            // 
            // CodHabitacionTextBox
            // 
            this.CodHabitacionTextBox.Location = new System.Drawing.Point(166, 19);
            this.CodHabitacionTextBox.MaxLength = 18;
            this.CodHabitacionTextBox.Name = "CodHabitacionTextBox";
            this.CodHabitacionTextBox.Size = new System.Drawing.Size(100, 20);
            this.CodHabitacionTextBox.TabIndex = 12;
            // 
            // PisoHabitacionTextBox
            // 
            this.PisoHabitacionTextBox.Location = new System.Drawing.Point(166, 50);
            this.PisoHabitacionTextBox.MaxLength = 18;
            this.PisoHabitacionTextBox.Name = "PisoHabitacionTextBox";
            this.PisoHabitacionTextBox.Size = new System.Drawing.Size(100, 20);
            this.PisoHabitacionTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hotel";
            // 
            // HotelNombreTextBox
            // 
            this.HotelNombreTextBox.Enabled = false;
            this.HotelNombreTextBox.Location = new System.Drawing.Point(419, 19);
            this.HotelNombreTextBox.Name = "HotelNombreTextBox";
            this.HotelNombreTextBox.Size = new System.Drawing.Size(121, 20);
            this.HotelNombreTextBox.TabIndex = 20;
            // 
            // TipoNuevaHabitacioncomboBox1
            // 
            this.TipoNuevaHabitacioncomboBox1.FormattingEnabled = true;
            this.TipoNuevaHabitacioncomboBox1.Location = new System.Drawing.Point(419, 49);
            this.TipoNuevaHabitacioncomboBox1.Name = "TipoNuevaHabitacioncomboBox1";
            this.TipoNuevaHabitacioncomboBox1.Size = new System.Drawing.Size(121, 21);
            this.TipoNuevaHabitacioncomboBox1.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.habilitadach);
            this.groupBox1.Controls.Add(this.TipoNuevaHabitacioncomboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.HotelNombreTextBox);
            this.groupBox1.Controls.Add(this.PisoHabitacionTextBox);
            this.groupBox1.Controls.Add(this.CodHabitacionTextBox);
            this.groupBox1.Controls.Add(this.TipoHabitacionLabel);
            this.groupBox1.Controls.Add(this.PisoHabitacionlabel);
            this.groupBox1.Controls.Add(this.codigoHabitacionlabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 99);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Búsqueda";
            // 
            // habilitadach
            // 
            this.habilitadach.AutoSize = true;
            this.habilitadach.Checked = true;
            this.habilitadach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitadach.Location = new System.Drawing.Point(11, 76);
            this.habilitadach.Name = "habilitadach";
            this.habilitadach.Size = new System.Drawing.Size(73, 17);
            this.habilitadach.TabIndex = 24;
            this.habilitadach.Text = "Habilitada";
            this.habilitadach.UseVisualStyleBackColor = true;
            // 
            // nroHabitacion
            // 
            this.nroHabitacion.DataPropertyName = "Habitacion_Numero";
            this.nroHabitacion.HeaderText = "Nro. Habitación";
            this.nroHabitacion.Name = "nroHabitacion";
            this.nroHabitacion.ReadOnly = true;
            // 
            // pisoHabitacion
            // 
            this.pisoHabitacion.DataPropertyName = "Habitacion_Piso";
            this.pisoHabitacion.HeaderText = "Piso";
            this.pisoHabitacion.Name = "pisoHabitacion";
            this.pisoHabitacion.ReadOnly = true;
            // 
            // habilitado
            // 
            this.habilitado.DataPropertyName = "Habitacion_Habilitada";
            this.habilitado.HeaderText = "Habitación Habilitada";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            this.habilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.habilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frente
            // 
            this.frente.DataPropertyName = "Habitacion_Frente";
            this.frente.HeaderText = "Habitación al Frente";
            this.frente.Name = "frente";
            this.frente.ReadOnly = true;
            // 
            // tipoHabitacion
            // 
            this.tipoHabitacion.DataPropertyName = "Habitacion_Tipo_Descripcion";
            this.tipoHabitacion.HeaderText = "Tipo de Habitación";
            this.tipoHabitacion.Name = "tipoHabitacion";
            this.tipoHabitacion.ReadOnly = true;
            // 
            // ABMHabitacionVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.VentanaPrincipalHabitacionVolverBoton);
            this.Controls.Add(this.dgvHabitacion);
            this.Controls.Add(this.LimpiarBusquedaBoton);
            this.Controls.Add(this.BuscarHabitacionBoton);
            this.Controls.Add(this.DarBajaHabitacionBoton);
            this.Controls.Add(this.ModificarHabitacionBoton);
            this.Controls.Add(this.NuevaHabitacionBoton);
            this.Name = "ABMHabitacionVentanaPrincipal";
            this.Text = "Habitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NuevaHabitacionBoton;
        private System.Windows.Forms.Button ModificarHabitacionBoton;
        private System.Windows.Forms.Button DarBajaHabitacionBoton;
        private System.Windows.Forms.Button BuscarHabitacionBoton;
        private System.Windows.Forms.Button LimpiarBusquedaBoton;
        private System.Windows.Forms.DataGridView dgvHabitacion;
        private System.Windows.Forms.Button VentanaPrincipalHabitacionVolverBoton;
        private System.Windows.Forms.Label codigoHabitacionlabel;
        private System.Windows.Forms.Label PisoHabitacionlabel;
        private System.Windows.Forms.Label TipoHabitacionLabel;
        private System.Windows.Forms.TextBox CodHabitacionTextBox;
        private System.Windows.Forms.TextBox PisoHabitacionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HotelNombreTextBox;
        private System.Windows.Forms.ComboBox TipoNuevaHabitacioncomboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox habilitadach;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pisoHabitacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoHabitacion;
    }
}