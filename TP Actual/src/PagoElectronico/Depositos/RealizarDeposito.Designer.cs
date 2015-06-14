namespace PagoElectronico.Depositos
{
    partial class RealizarDeposito
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
            this.seleccionCuenta = new System.Windows.Forms.ComboBox();
            this.seleccionImporte = new System.Windows.Forms.NumericUpDown();
            this.seleccionMoneda = new System.Windows.Forms.ComboBox();
            this.seleccionTarjeta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.volverFuncionalidades = new System.Windows.Forms.Button();
            this.botonConfirmar = new System.Windows.Forms.Button();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.bEquivalente = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.seleccionImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // seleccionCuenta
            // 
            this.seleccionCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seleccionCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionCuenta.FormattingEnabled = true;
            this.seleccionCuenta.Location = new System.Drawing.Point(98, 32);
            this.seleccionCuenta.Name = "seleccionCuenta";
            this.seleccionCuenta.Size = new System.Drawing.Size(249, 21);
            this.seleccionCuenta.TabIndex = 0;
            this.seleccionCuenta.SelectionChangeCommitted += new System.EventHandler(this.seleccionCuenta_SelectedIndexChange);
            // 
            // seleccionImporte
            // 
            this.seleccionImporte.DecimalPlaces = 2;
            this.seleccionImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionImporte.Location = new System.Drawing.Point(98, 76);
            this.seleccionImporte.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.seleccionImporte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.seleccionImporte.Name = "seleccionImporte";
            this.seleccionImporte.Size = new System.Drawing.Size(140, 20);
            this.seleccionImporte.TabIndex = 1;
            this.seleccionImporte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // seleccionMoneda
            // 
            this.seleccionMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seleccionMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionMoneda.FormattingEnabled = true;
            this.seleccionMoneda.Location = new System.Drawing.Point(98, 116);
            this.seleccionMoneda.Name = "seleccionMoneda";
            this.seleccionMoneda.Size = new System.Drawing.Size(140, 21);
            this.seleccionMoneda.TabIndex = 2;
            // 
            // seleccionTarjeta
            // 
            this.seleccionTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seleccionTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionTarjeta.FormattingEnabled = true;
            this.seleccionTarjeta.Location = new System.Drawing.Point(98, 160);
            this.seleccionTarjeta.Name = "seleccionTarjeta";
            this.seleccionTarjeta.Size = new System.Drawing.Size(249, 21);
            this.seleccionTarjeta.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Moneda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tarjeta";
            // 
            // volverFuncionalidades
            // 
            this.volverFuncionalidades.BackColor = System.Drawing.Color.NavajoWhite;
            this.volverFuncionalidades.Location = new System.Drawing.Point(40, 281);
            this.volverFuncionalidades.Name = "volverFuncionalidades";
            this.volverFuncionalidades.Size = new System.Drawing.Size(93, 36);
            this.volverFuncionalidades.TabIndex = 12;
            this.volverFuncionalidades.Text = "<<Volver";
            this.volverFuncionalidades.UseVisualStyleBackColor = false;
            this.volverFuncionalidades.Click += new System.EventHandler(this.volverFuncionalidades_Click_1);
            // 
            // botonConfirmar
            // 
            this.botonConfirmar.BackColor = System.Drawing.Color.Moccasin;
            this.botonConfirmar.Enabled = false;
            this.botonConfirmar.Location = new System.Drawing.Point(225, 280);
            this.botonConfirmar.Name = "botonConfirmar";
            this.botonConfirmar.Size = new System.Drawing.Size(204, 37);
            this.botonConfirmar.TabIndex = 13;
            this.botonConfirmar.Text = "Realizar el Deposito";
            this.botonConfirmar.UseVisualStyleBackColor = false;
            this.botonConfirmar.Click += new System.EventHandler(this.botonConfirmar_Click_1);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(406, 114);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(71, 20);
            this.txtCosto.TabIndex = 14;
            // 
            // bEquivalente
            // 
            this.bEquivalente.BackColor = System.Drawing.Color.Moccasin;
            this.bEquivalente.Location = new System.Drawing.Point(425, 67);
            this.bEquivalente.Name = "bEquivalente";
            this.bEquivalente.Size = new System.Drawing.Size(139, 34);
            this.bEquivalente.TabIndex = 15;
            this.bEquivalente.Text = "Ver Equivalente";
            this.bEquivalente.UseVisualStyleBackColor = false;
            this.bEquivalente.Click += new System.EventHandler(this.bEquivalente_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(503, 114);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(71, 20);
            this.txtDesc.TabIndex = 16;
            // 
            // RealizarDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(599, 345);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.bEquivalente);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.botonConfirmar);
            this.Controls.Add(this.volverFuncionalidades);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seleccionTarjeta);
            this.Controls.Add(this.seleccionMoneda);
            this.Controls.Add(this.seleccionImporte);
            this.Controls.Add(this.seleccionCuenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RealizarDeposito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realizar Deposito";
            this.Load += new System.EventHandler(this.RealizarDeposito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seleccionImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox seleccionCuenta;
        private System.Windows.Forms.NumericUpDown seleccionImporte;
        private System.Windows.Forms.ComboBox seleccionMoneda;
        private System.Windows.Forms.ComboBox seleccionTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button volverFuncionalidades;
        private System.Windows.Forms.Button botonConfirmar;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Button bEquivalente;
        private System.Windows.Forms.TextBox txtDesc;

    }
}