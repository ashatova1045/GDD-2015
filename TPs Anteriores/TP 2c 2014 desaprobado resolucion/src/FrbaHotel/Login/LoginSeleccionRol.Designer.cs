namespace FrbaHotel.Login
{
    partial class LoginSeleccionRol
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
            this.Hoteles = new System.Windows.Forms.ComboBox();
            this.seleccionarHotel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roles = new System.Windows.Forms.ComboBox();
            this.seleccionarRol = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Hoteles
            // 
            this.Hoteles.FormattingEnabled = true;
            this.Hoteles.Location = new System.Drawing.Point(64, 22);
            this.Hoteles.Name = "Hoteles";
            this.Hoteles.Size = new System.Drawing.Size(149, 21);
            this.Hoteles.TabIndex = 0;
            this.Hoteles.SelectedIndexChanged += new System.EventHandler(this.Hoteles_SelectedIndexChanged);
            // 
            // seleccionarHotel
            // 
            this.seleccionarHotel.Location = new System.Drawing.Point(250, 22);
            this.seleccionarHotel.Name = "seleccionarHotel";
            this.seleccionarHotel.Size = new System.Drawing.Size(75, 19);
            this.seleccionarHotel.TabIndex = 1;
            this.seleccionarHotel.Text = "Seleccionar";
            this.seleccionarHotel.UseVisualStyleBackColor = true;
            this.seleccionarHotel.Click += new System.EventHandler(this.seleccionarHotel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rol:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hotel:";
            // 
            // roles
            // 
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(64, 61);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(149, 21);
            this.roles.TabIndex = 4;
            this.roles.Visible = false;
            // 
            // seleccionarRol
            // 
            this.seleccionarRol.Location = new System.Drawing.Point(250, 61);
            this.seleccionarRol.Name = "seleccionarRol";
            this.seleccionarRol.Size = new System.Drawing.Size(75, 19);
            this.seleccionarRol.TabIndex = 5;
            this.seleccionarRol.Text = "Seleccionar";
            this.seleccionarRol.UseVisualStyleBackColor = true;
            this.seleccionarRol.Visible = false;
            this.seleccionarRol.Click += new System.EventHandler(this.seleccionarRol_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(12, 125);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(144, 27);
            this.login.TabIndex = 6;
            this.login.Text = "Volver a Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // LoginSeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 164);
            this.Controls.Add(this.login);
            this.Controls.Add(this.seleccionarRol);
            this.Controls.Add(this.roles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seleccionarHotel);
            this.Controls.Add(this.Hoteles);
            this.Name = "LoginSeleccionRol";
            this.Text = "Selección de Rol";
            this.Load += new System.EventHandler(this.LoginSeleccionRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Hoteles;
        private System.Windows.Forms.Button seleccionarHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox roles;
        private System.Windows.Forms.Button seleccionarRol;
        private System.Windows.Forms.Button login;
    }
}