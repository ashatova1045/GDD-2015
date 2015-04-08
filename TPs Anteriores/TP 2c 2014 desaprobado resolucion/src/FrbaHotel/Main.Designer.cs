namespace FrbaHotel
{
    partial class Main
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
            this.funcionalidades = new System.Windows.Forms.ComboBox();
            this.ir = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // funcionalidades
            // 
            this.funcionalidades.FormattingEnabled = true;
            this.funcionalidades.Location = new System.Drawing.Point(12, 22);
            this.funcionalidades.Name = "funcionalidades";
            this.funcionalidades.Size = new System.Drawing.Size(370, 21);
            this.funcionalidades.TabIndex = 0;
            this.funcionalidades.SelectedIndexChanged += new System.EventHandler(this.funcionalidades_SelectedIndexChanged);
            // 
            // ir
            // 
            this.ir.Location = new System.Drawing.Point(406, 22);
            this.ir.Name = "ir";
            this.ir.Size = new System.Drawing.Size(56, 21);
            this.ir.TabIndex = 1;
            this.ir.Text = "Ir";
            this.ir.UseVisualStyleBackColor = true;
            this.ir.Click += new System.EventHandler(this.ir_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(12, 64);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(144, 27);
            this.login.TabIndex = 2;
            this.login.Text = "Volver a Seleccion de Rol";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 103);
            this.Controls.Add(this.login);
            this.Controls.Add(this.ir);
            this.Controls.Add(this.funcionalidades);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox funcionalidades;
        private System.Windows.Forms.Button ir;
        private System.Windows.Forms.Button login;

    }
}

