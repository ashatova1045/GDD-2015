namespace FrbaHotel.Facturar
{
    partial class Facturar
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
            this.label1 = new System.Windows.Forms.Label();
            this.reserva = new System.Windows.Forms.ComboBox();
            this.facturarb = new System.Windows.Forms.Button();
            this.lista = new System.Windows.Forms.DataGridView();
            this.consumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volver = new System.Windows.Forms.Button();
            this.ver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.totaltext = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reserva";
            // 
            // reserva
            // 
            this.reserva.FormattingEnabled = true;
            this.reserva.Location = new System.Drawing.Point(93, 19);
            this.reserva.Name = "reserva";
            this.reserva.Size = new System.Drawing.Size(137, 21);
            this.reserva.TabIndex = 1;
            // 
            // facturarb
            // 
            this.facturarb.Location = new System.Drawing.Point(193, 225);
            this.facturarb.Name = "facturarb";
            this.facturarb.Size = new System.Drawing.Size(214, 29);
            this.facturarb.TabIndex = 2;
            this.facturarb.Text = "Facturar";
            this.facturarb.UseVisualStyleBackColor = true;
            this.facturarb.Click += new System.EventHandler(this.facturarb_Click);
            // 
            // lista
            // 
            this.lista.AllowUserToAddRows = false;
            this.lista.AllowUserToDeleteRows = false;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consumible,
            this.cantidad,
            this.precio,
            this.hab,
            this.hotel});
            this.lista.Location = new System.Drawing.Point(31, 56);
            this.lista.Name = "lista";
            this.lista.ReadOnly = true;
            this.lista.Size = new System.Drawing.Size(415, 150);
            this.lista.TabIndex = 3;
            // 
            // consumible
            // 
            this.consumible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.consumible.DataPropertyName = "Consumible_Descripcion";
            this.consumible.HeaderText = "Consumible";
            this.consumible.Name = "consumible";
            this.consumible.ReadOnly = true;
            this.consumible.Width = 86;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cantidad.DataPropertyName = "Cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 74;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.precio.DataPropertyName = "Precio";
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 62;
            // 
            // hab
            // 
            this.hab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.hab.DataPropertyName = "Habitacion_Numero";
            this.hab.HeaderText = "Habitacion";
            this.hab.Name = "hab";
            this.hab.ReadOnly = true;
            this.hab.Width = 83;
            // 
            // hotel
            // 
            this.hotel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.hotel.DataPropertyName = "Hotel_Nombre";
            this.hotel.HeaderText = "Hotel";
            this.hotel.Name = "hotel";
            this.hotel.ReadOnly = true;
            this.hotel.Width = 57;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(498, 230);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 4;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // ver
            // 
            this.ver.Location = new System.Drawing.Point(253, 19);
            this.ver.Name = "ver";
            this.ver.Size = new System.Drawing.Size(89, 21);
            this.ver.TabIndex = 5;
            this.ver.Text = "Ver factura";
            this.ver.UseVisualStyleBackColor = true;
            this.ver.Click += new System.EventHandler(this.ver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total";
            // 
            // totaltext
            // 
            this.totaltext.Enabled = false;
            this.totaltext.Location = new System.Drawing.Point(525, 109);
            this.totaltext.Name = "totaltext";
            this.totaltext.Size = new System.Drawing.Size(57, 20);
            this.totaltext.TabIndex = 7;
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 266);
            this.Controls.Add(this.totaltext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ver);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.facturarb);
            this.Controls.Add(this.reserva);
            this.Controls.Add(this.label1);
            this.Name = "Facturar";
            this.Text = "Facturar";
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reserva;
        private System.Windows.Forms.Button facturarb;
        private System.Windows.Forms.DataGridView lista;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Button ver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totaltext;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn hab;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotel;
    }
}