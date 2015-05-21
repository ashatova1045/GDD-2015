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
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nImporte = new System.Windows.Forms.NumericUpDown();
            this.btTransferir = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.cbImporteMoneda = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOrigen
            // 
            this.cbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigen.FormattingEnabled = true;
            this.cbOrigen.Location = new System.Drawing.Point(146, 12);
            this.cbOrigen.MaxLength = 18;
            this.cbOrigen.Name = "cbOrigen";
            this.cbOrigen.Size = new System.Drawing.Size(133, 21);
            this.cbOrigen.TabIndex = 0;
            this.cbOrigen.SelectedIndexChanged += new System.EventHandler(this.cbOrigen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuenta Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuenta Destino";
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(146, 49);
            this.cbDestino.MaxLength = 18;
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(133, 21);
            this.cbDestino.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(335, 12);
            this.txtSaldo.MaxLength = 99999;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(179, 20);
            this.txtSaldo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Importe a transferir:";
            // 
            // nImporte
            // 
            this.nImporte.DecimalPlaces = 2;
            this.nImporte.Location = new System.Drawing.Point(146, 84);
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
            this.btTransferir.Location = new System.Drawing.Point(90, 121);
            this.btTransferir.Name = "btTransferir";
            this.btTransferir.Size = new System.Drawing.Size(103, 26);
            this.btTransferir.TabIndex = 9;
            this.btTransferir.Text = "Transferir";
            this.btTransferir.UseVisualStyleBackColor = true;
            this.btTransferir.Click += new System.EventHandler(this.btTransferir_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(316, 121);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(90, 26);
            this.btVolver.TabIndex = 10;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // cbImporteMoneda
            // 
            this.cbImporteMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImporteMoneda.FormattingEnabled = true;
            this.cbImporteMoneda.Location = new System.Drawing.Point(285, 84);
            this.cbImporteMoneda.Name = "cbImporteMoneda";
            this.cbImporteMoneda.Size = new System.Drawing.Size(91, 21);
            this.cbImporteMoneda.TabIndex = 11;
            // 
            // Transferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 158);
            this.Controls.Add(this.cbImporteMoneda);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btTransferir);
            this.Controls.Add(this.nImporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDestino);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOrigen);
            this.Name = "Transferencias";
            this.Text = "Transferencias";
            ((System.ComponentModel.ISupportInitialize)(this.nImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nImporte;
        private System.Windows.Forms.Button btTransferir;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.ComboBox cbImporteMoneda;
    }
}