namespace PagoElectronico.Transferencias
{
    partial class Transferencias
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
            this.cbOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nImporte = new System.Windows.Forms.NumericUpDown();
            this.btTransferir = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.cbImporteMoneda = new System.Windows.Forms.ComboBox();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoneda2 = new System.Windows.Forms.TextBox();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.txtImporteConvertido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtMonedaATransferir = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOrigen
            // 
            this.cbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(142, 12);
            this.cbOrigen.MaxLength = 18;
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(133, 21);
            this.cbOrigen.TabIndex = 0;
            this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cbOrigen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuenta Destino:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(279, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(322, 15);
            this.txtSaldo.MaxLength = 99999;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(117, 20);
            this.txtSaldo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Importe a transferir:";
            // 
            // nImporte
            // 
            this.nImporte.DecimalPlaces = 2;
            this.nImporte.Location = new System.Drawing.Point(143, 84);
            this.nImporte.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.nImporte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nImporte.Name = "nImporte";
            this.nImporte.Size = new System.Drawing.Size(133, 20);
            this.nImporte.TabIndex = 8;
            this.nImporte.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // btTransferir
            // 
            this.btTransferir.BackColor = System.Drawing.Color.Moccasin;
            this.btTransferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTransferir.Location = new System.Drawing.Point(107, 141);
            this.btTransferir.Name = "btTransferir";
            this.btTransferir.Size = new System.Drawing.Size(103, 28);
            this.btTransferir.TabIndex = 9;
            this.btTransferir.Text = "Transferir";
            this.btTransferir.UseVisualStyleBackColor = false;
            this.btTransferir.Click += new System.EventHandler(this.btTransferir_Click);
            // 
            // btVolver
            // 
            this.btVolver.BackColor = System.Drawing.Color.Moccasin;
            this.btVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolver.Location = new System.Drawing.Point(227, 140);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(90, 28);
            this.btVolver.TabIndex = 10;
            this.btVolver.Text = "<< Volver";
            this.btVolver.UseVisualStyleBackColor = false;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // cbImporteMoneda
            // 
            this.cbImporteMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImporteMoneda.FormattingEnabled = true;
            this.cbImporteMoneda.Location = new System.Drawing.Point(281, 84);
            this.cbImporteMoneda.Name = "cbImporteMoneda";
            this.cbImporteMoneda.Size = new System.Drawing.Size(91, 21);
            this.cbImporteMoneda.TabIndex = 11;
            this.cbImporteMoneda.SelectedIndexChanged += new System.EventHandler(this.cbImporteMoneda_SelectedIndexChanged);
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(442, 15);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(76, 20);
            this.txtMoneda.TabIndex = 12;
            // 
            // txtCosto
            // 
            this.txtCosto.Enabled = false;
            this.txtCosto.Location = new System.Drawing.Point(322, 41);
            this.txtCosto.MaxLength = 99999;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(117, 20);
            this.txtCosto.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(281, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Costo:";
            // 
            // txtMoneda2
            // 
            this.txtMoneda2.Enabled = false;
            this.txtMoneda2.Location = new System.Drawing.Point(442, 40);
            this.txtMoneda2.Name = "txtMoneda2";
            this.txtMoneda2.Size = new System.Drawing.Size(76, 20);
            this.txtMoneda2.TabIndex = 15;
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(142, 46);
            this.cbDestino.MaxLength = 18;
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(133, 21);
            this.cbDestino.TabIndex = 16;
            this.cbDestino.SelectedIndexChanged += new System.EventHandler(this.cbDestino_SelectedIndexChanged);
            // 
            // txtImporteConvertido
            // 
            this.txtImporteConvertido.Enabled = false;
            this.txtImporteConvertido.Location = new System.Drawing.Point(397, 84);
            this.txtImporteConvertido.Name = "txtImporteConvertido";
            this.txtImporteConvertido.Size = new System.Drawing.Size(63, 20);
            this.txtImporteConvertido.TabIndex = 17;
            this.txtImporteConvertido.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "=";
            // 
            // btnCalc
            // 
            this.btnCalc.BackColor = System.Drawing.Color.Moccasin;
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Location = new System.Drawing.Point(397, 110);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(106, 21);
            this.btnCalc.TabIndex = 19;
            this.btnCalc.Text = "Calcular cambio";
            this.btnCalc.UseVisualStyleBackColor = false;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtMonedaATransferir
            // 
            this.txtMonedaATransferir.Enabled = false;
            this.txtMonedaATransferir.Location = new System.Drawing.Point(445, 84);
            this.txtMonedaATransferir.Name = "txtMonedaATransferir";
            this.txtMonedaATransferir.Size = new System.Drawing.Size(49, 20);
            this.txtMonedaATransferir.TabIndex = 20;
            // 
            // Transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(539, 182);
            this.Controls.Add(this.txtMonedaATransferir);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImporteConvertido);
            this.Controls.Add(this.cbDestino);
            this.Controls.Add(this.txtMoneda2);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.cbImporteMoneda);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btTransferir);
            this.Controls.Add(this.nImporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOrigen);
            this.Name = "Transferencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencias";
            this.Load += new System.EventHandler(this.Transferencias_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Transferencias_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nImporte;
        private System.Windows.Forms.Button btTransferir;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.ComboBox cbImporteMoneda;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMoneda2;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.TextBox txtImporteConvertido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtMonedaATransferir;
    }
}