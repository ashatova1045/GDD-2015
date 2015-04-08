namespace FrbaHotel.ABM_de_Cliente
{
    partial class ABMSeleccionC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMSeleccionC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.ApellidoLabel = new System.Windows.Forms.Label();
            this.TipoPasaporteLabel = new System.Windows.Forms.Label();
            this.NroDocLabel = new System.Windows.Forms.Label();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.ApellidoTextBox = new System.Windows.Forms.TextBox();
            this.NroDocTextBox = new System.Windows.Forms.TextBox();
            this.DarAltaClienteBoton = new System.Windows.Forms.Button();
            this.DarBajaClienteBoton = new System.Windows.Forms.Button();
            this.ModificarClienteBoton = new System.Windows.Forms.Button();
            this.BuscarClientesBoton = new System.Windows.Forms.Button();
            this.LimpiarBusquedaBoton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TipoPasaporteComboBox = new System.Windows.Forms.ComboBox();
            this.MailLabel = new System.Windows.Forms.Label();
            this.MailtextBox = new System.Windows.Forms.TextBox();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 360);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Clientes";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(15, 62);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(44, 13);
            this.NombreLabel.TabIndex = 4;
            this.NombreLabel.Text = "Nombre";
            // 
            // ApellidoLabel
            // 
            this.ApellidoLabel.AutoSize = true;
            this.ApellidoLabel.Location = new System.Drawing.Point(15, 97);
            this.ApellidoLabel.Name = "ApellidoLabel";
            this.ApellidoLabel.Size = new System.Drawing.Size(44, 13);
            this.ApellidoLabel.TabIndex = 5;
            this.ApellidoLabel.Text = "Apellido";
            this.ApellidoLabel.Click += new System.EventHandler(this.ApellidoLabel_Click);
            // 
            // TipoPasaporteLabel
            // 
            this.TipoPasaporteLabel.AutoSize = true;
            this.TipoPasaporteLabel.Location = new System.Drawing.Point(9, 171);
            this.TipoPasaporteLabel.Name = "TipoPasaporteLabel";
            this.TipoPasaporteLabel.Size = new System.Drawing.Size(79, 13);
            this.TipoPasaporteLabel.TabIndex = 6;
            this.TipoPasaporteLabel.Text = "Tipo Pasaporte";
            // 
            // NroDocLabel
            // 
            this.NroDocLabel.AutoSize = true;
            this.NroDocLabel.Location = new System.Drawing.Point(247, 171);
            this.NroDocLabel.Name = "NroDocLabel";
            this.NroDocLabel.Size = new System.Drawing.Size(47, 13);
            this.NroDocLabel.TabIndex = 7;
            this.NroDocLabel.Text = "Nro Doc";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(94, 59);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(100, 20);
            this.NombreTextBox.TabIndex = 8;
            // 
            // ApellidoTextBox
            // 
            this.ApellidoTextBox.Location = new System.Drawing.Point(94, 94);
            this.ApellidoTextBox.Name = "ApellidoTextBox";
            this.ApellidoTextBox.Size = new System.Drawing.Size(100, 20);
            this.ApellidoTextBox.TabIndex = 9;
            // 
            // NroDocTextBox
            // 
            this.NroDocTextBox.Location = new System.Drawing.Point(310, 168);
            this.NroDocTextBox.Name = "NroDocTextBox";
            this.NroDocTextBox.Size = new System.Drawing.Size(100, 20);
            this.NroDocTextBox.TabIndex = 11;
            // 
            // DarAltaClienteBoton
            // 
            this.DarAltaClienteBoton.Location = new System.Drawing.Point(12, 256);
            this.DarAltaClienteBoton.Name = "DarAltaClienteBoton";
            this.DarAltaClienteBoton.Size = new System.Drawing.Size(152, 78);
            this.DarAltaClienteBoton.TabIndex = 12;
            this.DarAltaClienteBoton.Text = "Dar de Alta a un Cliente";
            this.DarAltaClienteBoton.UseVisualStyleBackColor = true;
            this.DarAltaClienteBoton.Click += new System.EventHandler(this.DarAltaClienteBoton_Click);
            // 
            // DarBajaClienteBoton
            // 
            this.DarBajaClienteBoton.Location = new System.Drawing.Point(209, 256);
            this.DarBajaClienteBoton.Name = "DarBajaClienteBoton";
            this.DarBajaClienteBoton.Size = new System.Drawing.Size(160, 80);
            this.DarBajaClienteBoton.TabIndex = 13;
            this.DarBajaClienteBoton.Text = "Dar de Baja a un Cliente";
            this.DarBajaClienteBoton.UseVisualStyleBackColor = true;
            this.DarBajaClienteBoton.Click += new System.EventHandler(this.DarBajaClienteBoton_Click_1);
            // 
            // ModificarClienteBoton
            // 
            this.ModificarClienteBoton.Location = new System.Drawing.Point(410, 256);
            this.ModificarClienteBoton.Name = "ModificarClienteBoton";
            this.ModificarClienteBoton.Size = new System.Drawing.Size(157, 80);
            this.ModificarClienteBoton.TabIndex = 14;
            this.ModificarClienteBoton.Text = "Modificar un Cliente";
            this.ModificarClienteBoton.UseVisualStyleBackColor = true;
            this.ModificarClienteBoton.Click += new System.EventHandler(this.ModificarClienteBoton_Click_1);
            // 
            // BuscarClientesBoton
            // 
            this.BuscarClientesBoton.Location = new System.Drawing.Point(100, 197);
            this.BuscarClientesBoton.Name = "BuscarClientesBoton";
            this.BuscarClientesBoton.Size = new System.Drawing.Size(135, 23);
            this.BuscarClientesBoton.TabIndex = 15;
            this.BuscarClientesBoton.Text = "Buscar";
            this.BuscarClientesBoton.UseVisualStyleBackColor = true;
            this.BuscarClientesBoton.Click += new System.EventHandler(this.BuscarClientesBoton_Click);
            // 
            // LimpiarBusquedaBoton
            // 
            this.LimpiarBusquedaBoton.Location = new System.Drawing.Point(250, 197);
            this.LimpiarBusquedaBoton.Name = "LimpiarBusquedaBoton";
            this.LimpiarBusquedaBoton.Size = new System.Drawing.Size(160, 23);
            this.LimpiarBusquedaBoton.TabIndex = 16;
            this.LimpiarBusquedaBoton.Text = "Limpiar Busqueda";
            this.LimpiarBusquedaBoton.UseVisualStyleBackColor = true;
            this.LimpiarBusquedaBoton.Click += new System.EventHandler(this.LimpiarBusquedaBoton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 365);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(599, 190);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // TipoPasaporteComboBox
            // 
            this.TipoPasaporteComboBox.FormattingEnabled = true;
            this.TipoPasaporteComboBox.Location = new System.Drawing.Point(94, 168);
            this.TipoPasaporteComboBox.Name = "TipoPasaporteComboBox";
            this.TipoPasaporteComboBox.Size = new System.Drawing.Size(121, 21);
            this.TipoPasaporteComboBox.TabIndex = 18;
            this.TipoPasaporteComboBox.SelectedIndexChanged += new System.EventHandler(this.TipoPasaporteComboBox_SelectedIndexChanged);
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Location = new System.Drawing.Point(12, 141);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(26, 13);
            this.MailLabel.TabIndex = 19;
            this.MailLabel.Text = "Mail";
            // 
            // MailtextBox
            // 
            this.MailtextBox.Location = new System.Drawing.Point(94, 138);
            this.MailtextBox.Name = "MailtextBox";
            this.MailtextBox.Size = new System.Drawing.Size(100, 20);
            this.MailtextBox.TabIndex = 20;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(479, 197);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(88, 32);
            this.volver.TabIndex = 21;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // ABMSeleccionC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 552);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.MailtextBox);
            this.Controls.Add(this.MailLabel);
            this.Controls.Add(this.TipoPasaporteComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LimpiarBusquedaBoton);
            this.Controls.Add(this.BuscarClientesBoton);
            this.Controls.Add(this.ModificarClienteBoton);
            this.Controls.Add(this.DarBajaClienteBoton);
            this.Controls.Add(this.DarAltaClienteBoton);
            this.Controls.Add(this.NroDocTextBox);
            this.Controls.Add(this.ApellidoTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.NroDocLabel);
            this.Controls.Add(this.TipoPasaporteLabel);
            this.Controls.Add(this.ApellidoLabel);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ABMSeleccionC";
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.Label ApellidoLabel;
        private System.Windows.Forms.Label TipoPasaporteLabel;
        private System.Windows.Forms.Label NroDocLabel;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.TextBox ApellidoTextBox;
        private System.Windows.Forms.TextBox NroDocTextBox;
        private System.Windows.Forms.Button DarAltaClienteBoton;
        private System.Windows.Forms.Button DarBajaClienteBoton;
        private System.Windows.Forms.Button ModificarClienteBoton;
        private System.Windows.Forms.Button BuscarClientesBoton;
        private System.Windows.Forms.Button LimpiarBusquedaBoton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox TipoPasaporteComboBox;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.TextBox MailtextBox;
        private System.Windows.Forms.Button volver;
    }
}