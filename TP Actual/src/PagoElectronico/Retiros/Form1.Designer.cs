namespace PagoElectronico.Retiros
{
    partial class RetiroEfectivo_FRM
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
		
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 302);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetiroEfectivo_FRM));
            this.Cuenta_CB = new System.Windows.Forms.ComboBox();
            this.Cuenta_LB = new System.Windows.Forms.Label();
            this.Importe_LB = new System.Windows.Forms.Label();
            this.Importe_NUD = new System.Windows.Forms.NumericUpDown();
            this.Moneda_LB = new System.Windows.Forms.Label();
            this.Moneda_CB = new System.Windows.Forms.ComboBox();
            this.RealizarCheque_BTN = new System.Windows.Forms.Button();
            this.Cancelar_BTN = new System.Windows.Forms.Button();
            this.NoDoc_LB = new System.Windows.Forms.Label();
            this.NoDoc_TXT = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Banco_LB = new System.Windows.Forms.Label();
            this.Banco_CB = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Importe_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cuenta_CB
            // 
            this.Cuenta_CB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cuenta_CB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cuenta_CB.FormattingEnabled = true;
            this.Cuenta_CB.Location = new System.Drawing.Point(143, 23);
            this.Cuenta_CB.Name = "Cuenta_CB";
            this.Cuenta_CB.Size = new System.Drawing.Size(121, 21);
            this.Cuenta_CB.TabIndex = 0;
            this.Cuenta_CB.Click += new System.EventHandler(this.Cuenta_CB_Click);
            // 
            // Cuenta_LB
            // 
            this.Cuenta_LB.AutoSize = true;
            this.Cuenta_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cuenta_LB.ForeColor = System.Drawing.Color.Black;
            this.Cuenta_LB.Location = new System.Drawing.Point(30, 22);
            this.Cuenta_LB.Name = "Cuenta_LB";
            this.Cuenta_LB.Size = new System.Drawing.Size(61, 18);
            this.Cuenta_LB.TabIndex = 1;
            this.Cuenta_LB.Text = "Cuenta";
            this.Cuenta_LB.Click += new System.EventHandler(this.label1_Click);
            // 
            // Importe_LB
            // 
            this.Importe_LB.AutoSize = true;
            this.Importe_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Importe_LB.Location = new System.Drawing.Point(30, 115);
            this.Importe_LB.Name = "Importe_LB";
            this.Importe_LB.Size = new System.Drawing.Size(65, 18);
            this.Importe_LB.TabIndex = 3;
            this.Importe_LB.Text = "Importe";
            this.Importe_LB.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Importe_NUD
            // 
            this.Importe_NUD.DecimalPlaces = 2;
            this.Importe_NUD.Location = new System.Drawing.Point(144, 117);
            this.Importe_NUD.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.Importe_NUD.Name = "Importe_NUD";
            this.Importe_NUD.Size = new System.Drawing.Size(120, 20);
            this.Importe_NUD.TabIndex = 4;
            this.Importe_NUD.ValueChanged += new System.EventHandler(this.Importe_NUD_ValueChanged);
            // 
            // Moneda_LB
            // 
            this.Moneda_LB.AutoSize = true;
            this.Moneda_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Moneda_LB.Location = new System.Drawing.Point(30, 163);
            this.Moneda_LB.Name = "Moneda_LB";
            this.Moneda_LB.Size = new System.Drawing.Size(68, 18);
            this.Moneda_LB.TabIndex = 5;
            this.Moneda_LB.Text = "Moneda";
            // 
            // Moneda_CB
            // 
            this.Moneda_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Moneda_CB.FormattingEnabled = true;
            this.Moneda_CB.Location = new System.Drawing.Point(142, 164);
            this.Moneda_CB.Name = "Moneda_CB";
            this.Moneda_CB.Size = new System.Drawing.Size(121, 21);
            this.Moneda_CB.TabIndex = 6;
            this.Moneda_CB.SelectedIndexChanged += new System.EventHandler(this.Moneda_CB_SelectedIndexChanged);
            this.Moneda_CB.Click += new System.EventHandler(this.Moneda_CB_Click);
            // 
            // RealizarCheque_BTN
            // 
            this.RealizarCheque_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RealizarCheque_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealizarCheque_BTN.Location = new System.Drawing.Point(89, 263);
            this.RealizarCheque_BTN.Name = "RealizarCheque_BTN";
            this.RealizarCheque_BTN.Size = new System.Drawing.Size(161, 32);
            this.RealizarCheque_BTN.TabIndex = 9;
            this.RealizarCheque_BTN.Text = "Realizar Cheque";
            this.RealizarCheque_BTN.UseVisualStyleBackColor = false;
            this.RealizarCheque_BTN.Click += new System.EventHandler(this.RealizarCheque_BTN_Click);
            // 
            // Cancelar_BTN
            // 
            this.Cancelar_BTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Cancelar_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelar_BTN.Location = new System.Drawing.Point(356, 263);
            this.Cancelar_BTN.Name = "Cancelar_BTN";
            this.Cancelar_BTN.Size = new System.Drawing.Size(117, 32);
            this.Cancelar_BTN.TabIndex = 10;
            this.Cancelar_BTN.Text = "Cancelar";
            this.Cancelar_BTN.UseVisualStyleBackColor = false;
            this.Cancelar_BTN.Click += new System.EventHandler(this.Cancelar_BTN_Click);
            // 
            // NoDoc_LB
            // 
            this.NoDoc_LB.AutoSize = true;
            this.NoDoc_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoDoc_LB.Location = new System.Drawing.Point(30, 72);
            this.NoDoc_LB.Name = "NoDoc_LB";
            this.NoDoc_LB.Size = new System.Drawing.Size(57, 16);
            this.NoDoc_LB.TabIndex = 11;
            this.NoDoc_LB.Text = "Nº Doc";
            // 
            // NoDoc_TXT
            // 
            this.NoDoc_TXT.Location = new System.Drawing.Point(142, 71);
            this.NoDoc_TXT.Name = "NoDoc_TXT";
            this.NoDoc_TXT.Size = new System.Drawing.Size(121, 20);
            this.NoDoc_TXT.TabIndex = 12;
            this.NoDoc_TXT.TextChanged += new System.EventHandler(this.NoDoc_TXT_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(341, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 140);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Banco_LB
            // 
            this.Banco_LB.AutoSize = true;
            this.Banco_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Banco_LB.Location = new System.Drawing.Point(30, 214);
            this.Banco_LB.Name = "Banco_LB";
            this.Banco_LB.Size = new System.Drawing.Size(52, 16);
            this.Banco_LB.TabIndex = 14;
            this.Banco_LB.Text = "Banco";
            // 
            // Banco_CB
            // 
            this.Banco_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Banco_CB.FormattingEnabled = true;
            this.Banco_CB.Location = new System.Drawing.Point(142, 209);
            this.Banco_CB.Name = "Banco_CB";
            this.Banco_CB.Size = new System.Drawing.Size(121, 21);
            this.Banco_CB.TabIndex = 15;
            this.Banco_CB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.Banco_CB.Click += new System.EventHandler(this.Banco_CB_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RetiroEfectivo_FRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(543, 316);
            this.Controls.Add(this.Banco_CB);
            this.Controls.Add(this.Banco_LB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NoDoc_TXT);
            this.Controls.Add(this.NoDoc_LB);
            this.Controls.Add(this.Cancelar_BTN);
            this.Controls.Add(this.RealizarCheque_BTN);
            this.Controls.Add(this.Moneda_CB);
            this.Controls.Add(this.Moneda_LB);
            this.Controls.Add(this.Importe_NUD);
            this.Controls.Add(this.Importe_LB);
            this.Controls.Add(this.Cuenta_LB);
            this.Controls.Add(this.Cuenta_CB);
            this.Name = "RetiroEfectivo_FRM";
            this.Text = "Retiro de Efectivo";
            ((System.ComponentModel.ISupportInitialize)(this.Importe_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cuenta_CB;
        private System.Windows.Forms.Label Cuenta_LB;
        private System.Windows.Forms.Label Importe_LB;
        private System.Windows.Forms.NumericUpDown Importe_NUD;
        private System.Windows.Forms.Label Moneda_LB;
        private System.Windows.Forms.ComboBox Moneda_CB;
        private System.Windows.Forms.Button RealizarCheque_BTN;
        private System.Windows.Forms.Button Cancelar_BTN;
        private System.Windows.Forms.Label NoDoc_LB;
        private System.Windows.Forms.TextBox NoDoc_TXT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Banco_LB;
        private System.Windows.Forms.ComboBox Banco_CB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}