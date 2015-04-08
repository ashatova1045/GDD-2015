namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class ConfirmarReserva
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
            this.opcionSi = new System.Windows.Forms.RadioButton();
            this.opcionNo = new System.Windows.Forms.RadioButton();
            this.cmbTDoc = new System.Windows.Forms.ComboBox();
            this.lblTDoc = new System.Windows.Forms.Label();
            this.lblNDoc = new System.Windows.Forms.Label();
            this.txtNDoc = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblComplete = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Ya se alojo alguna vez en la cadena hotelera?";
            // 
            // opcionSi
            // 
            this.opcionSi.AutoSize = true;
            this.opcionSi.Location = new System.Drawing.Point(15, 39);
            this.opcionSi.Name = "opcionSi";
            this.opcionSi.Size = new System.Drawing.Size(34, 17);
            this.opcionSi.TabIndex = 1;
            this.opcionSi.TabStop = true;
            this.opcionSi.Text = "Si";
            this.opcionSi.UseVisualStyleBackColor = true;
            this.opcionSi.CheckedChanged += new System.EventHandler(this.opcionSi_CheckedChanged);
            // 
            // opcionNo
            // 
            this.opcionNo.AutoSize = true;
            this.opcionNo.Location = new System.Drawing.Point(93, 39);
            this.opcionNo.Name = "opcionNo";
            this.opcionNo.Size = new System.Drawing.Size(39, 17);
            this.opcionNo.TabIndex = 2;
            this.opcionNo.TabStop = true;
            this.opcionNo.Text = "No";
            this.opcionNo.UseVisualStyleBackColor = true;
            this.opcionNo.CheckedChanged += new System.EventHandler(this.opcionNo_CheckedChanged);
            // 
            // cmbTDoc
            // 
            this.cmbTDoc.FormattingEnabled = true;
            this.cmbTDoc.Location = new System.Drawing.Point(136, 95);
            this.cmbTDoc.Name = "cmbTDoc";
            this.cmbTDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbTDoc.TabIndex = 3;
            // 
            // lblTDoc
            // 
            this.lblTDoc.AutoSize = true;
            this.lblTDoc.Location = new System.Drawing.Point(12, 98);
            this.lblTDoc.Name = "lblTDoc";
            this.lblTDoc.Size = new System.Drawing.Size(104, 13);
            this.lblTDoc.TabIndex = 4;
            this.lblTDoc.Text = "Tipo de Documento:";
            // 
            // lblNDoc
            // 
            this.lblNDoc.AutoSize = true;
            this.lblNDoc.Location = new System.Drawing.Point(11, 133);
            this.lblNDoc.Name = "lblNDoc";
            this.lblNDoc.Size = new System.Drawing.Size(120, 13);
            this.lblNDoc.TabIndex = 5;
            this.lblNDoc.Text = "Numero de Documento:";
            // 
            // txtNDoc
            // 
            this.txtNDoc.Location = new System.Drawing.Point(137, 130);
            this.txtNDoc.Name = "txtNDoc";
            this.txtNDoc.Size = new System.Drawing.Size(120, 20);
            this.txtNDoc.TabIndex = 6;
            this.txtNDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNDoc_KeyPress);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(12, 168);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 7;
            this.lblMail.Text = "Mail:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(136, 165);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(120, 20);
            this.txtMail.TabIndex = 8;
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMail_KeyPress);
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.Location = new System.Drawing.Point(12, 68);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(157, 13);
            this.lblComplete.TabIndex = 9;
            this.lblComplete.Text = "Complete alguno de los campos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(15, 231);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Location = new System.Drawing.Point(157, 36);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarse.TabIndex = 11;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = true;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(225, 231);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ConfirmarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 273);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblComplete);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtNDoc);
            this.Controls.Add(this.lblNDoc);
            this.Controls.Add(this.lblTDoc);
            this.Controls.Add(this.cmbTDoc);
            this.Controls.Add(this.opcionNo);
            this.Controls.Add(this.opcionSi);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmarReserva";
            this.Text = "Confirmar Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton opcionSi;
        private System.Windows.Forms.RadioButton opcionNo;
        private System.Windows.Forms.ComboBox cmbTDoc;
        private System.Windows.Forms.Label lblTDoc;
        private System.Windows.Forms.Label lblNDoc;
        private System.Windows.Forms.TextBox txtNDoc;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Button btnVolver;
    }
}