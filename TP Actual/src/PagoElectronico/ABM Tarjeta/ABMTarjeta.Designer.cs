namespace PagoElectronico.ABM_Tarjeta
{
    partial class ABMTarjeta
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
            this.btAso = new System.Windows.Forms.Button();
            this.btMod = new System.Windows.Forms.Button();
            this.btDes = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAso
            // 
            this.btAso.Location = new System.Drawing.Point(12, 12);
            this.btAso.Name = "btAso";
            this.btAso.Size = new System.Drawing.Size(148, 35);
            this.btAso.TabIndex = 0;
            this.btAso.Text = "Asociar tarjeta";
            this.btAso.UseVisualStyleBackColor = true;
            this.btAso.Click += new System.EventHandler(this.button1_Click);
            // 
            // btMod
            // 
            this.btMod.Location = new System.Drawing.Point(12, 53);
            this.btMod.Name = "btMod";
            this.btMod.Size = new System.Drawing.Size(148, 35);
            this.btMod.TabIndex = 1;
            this.btMod.Text = "Modificar tarjeta";
            this.btMod.UseVisualStyleBackColor = true;
            // 
            // btDes
            // 
            this.btDes.Location = new System.Drawing.Point(12, 94);
            this.btDes.Name = "btDes";
            this.btDes.Size = new System.Drawing.Size(148, 35);
            this.btDes.TabIndex = 2;
            this.btDes.Text = "Desasociar tarjeta";
            this.btDes.UseVisualStyleBackColor = true;
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(12, 135);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(148, 35);
            this.btVolver.TabIndex = 3;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // ABMTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 176);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btDes);
            this.Controls.Add(this.btMod);
            this.Controls.Add(this.btAso);
            this.Name = "ABMTarjeta";
            this.Text = "Tarjetas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAso;
        private System.Windows.Forms.Button btMod;
        private System.Windows.Forms.Button btDes;
        private System.Windows.Forms.Button btVolver;
    }
}