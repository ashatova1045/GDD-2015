namespace PagoElectronico.ABM_Tarjeta
{
    partial class mtar
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
            this.btModificar = new System.Windows.Forms.Button();
            this.btDesasociar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.btAsociar = new System.Windows.Forms.Button();
            this.cbTarjeta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btModificar
            // 
            this.btModificar.Enabled = false;
            this.btModificar.Location = new System.Drawing.Point(141, 39);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(117, 22);
            this.btModificar.TabIndex = 2;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btDesasociar
            // 
            this.btDesasociar.Enabled = false;
            this.btDesasociar.Location = new System.Drawing.Point(264, 39);
            this.btDesasociar.Name = "btDesasociar";
            this.btDesasociar.Size = new System.Drawing.Size(117, 22);
            this.btDesasociar.TabIndex = 3;
            this.btDesasociar.Text = "Desasociar";
            this.btDesasociar.UseVisualStyleBackColor = true;
            this.btDesasociar.Click += new System.EventHandler(this.btDesasociar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(387, 39);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(117, 22);
            this.btVolver.TabIndex = 4;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // btAsociar
            // 
            this.btAsociar.Location = new System.Drawing.Point(18, 39);
            this.btAsociar.Name = "btAsociar";
            this.btAsociar.Size = new System.Drawing.Size(117, 22);
            this.btAsociar.TabIndex = 5;
            this.btAsociar.Text = "Asociar nueva";
            this.btAsociar.UseVisualStyleBackColor = true;
            this.btAsociar.Click += new System.EventHandler(this.btAsociar_Click);
            // 
            // cbTarjeta
            // 
            this.cbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTarjeta.FormattingEnabled = true;
            this.cbTarjeta.Location = new System.Drawing.Point(188, 6);
            this.cbTarjeta.Name = "cbTarjeta";
            this.cbTarjeta.Size = new System.Drawing.Size(256, 21);
            this.cbTarjeta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de tarjeta:";
            // 
            // mtar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 63);
            this.Controls.Add(this.btAsociar);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btDesasociar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTarjeta);
            this.Name = "mtar";
            this.Text = "Tarjetas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btDesasociar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Button btAsociar;
        private System.Windows.Forms.ComboBox cbTarjeta;
        private System.Windows.Forms.Label label1;


    }
}