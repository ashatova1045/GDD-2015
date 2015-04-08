namespace FrbaHotel.ABM_de_Usuario
{
    partial class DarAltaUsuario
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
            this.TipoDocTextBox = new System.Windows.Forms.TextBox();
            this.NumeroDoc = new System.Windows.Forms.Label();
            this.nrodoc = new System.Windows.Forms.TextBox();
            this.Apellido = new System.Windows.Forms.Label();
            this.FechaNacimiento = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.Nacionalidad = new System.Windows.Forms.Label();
            this.DarAltaClienteBoton = new System.Windows.Forms.Button();
            this.VolverBoton = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roles = new System.Windows.Forms.ComboBox();
            this.tiposdoc = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nombret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apellidot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telefonot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mailt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TipoDocTextBox
            // 
            this.TipoDocTextBox.Enabled = false;
            this.TipoDocTextBox.Location = new System.Drawing.Point(111, 43);
            this.TipoDocTextBox.MaxLength = 10;
            this.TipoDocTextBox.Name = "TipoDocTextBox";
            this.TipoDocTextBox.Size = new System.Drawing.Size(100, 20);
            this.TipoDocTextBox.TabIndex = 1;
            // 
            // NumeroDoc
            // 
            this.NumeroDoc.AutoSize = true;
            this.NumeroDoc.Location = new System.Drawing.Point(12, 81);
            this.NumeroDoc.Name = "NumeroDoc";
            this.NumeroDoc.Size = new System.Drawing.Size(67, 13);
            this.NumeroDoc.TabIndex = 2;
            this.NumeroDoc.Text = "Numero Doc";
            // 
            // nrodoc
            // 
            this.nrodoc.Location = new System.Drawing.Point(111, 78);
            this.nrodoc.MaxLength = 18;
            this.nrodoc.Name = "nrodoc";
            this.nrodoc.Size = new System.Drawing.Size(100, 20);
            this.nrodoc.TabIndex = 3;
            // 
            // Apellido
            // 
            this.Apellido.AutoSize = true;
            this.Apellido.Location = new System.Drawing.Point(12, 115);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(43, 13);
            this.Apellido.TabIndex = 6;
            this.Apellido.Text = "Usuario";
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.AutoSize = true;
            this.FechaNacimiento.Location = new System.Drawing.Point(257, 78);
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Size = new System.Drawing.Size(52, 13);
            this.FechaNacimiento.TabIndex = 10;
            this.FechaNacimiento.Text = "Direccion";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(364, 75);
            this.direccion.MaxLength = 60;
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 20);
            this.direccion.TabIndex = 11;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.AutoSize = true;
            this.Nacionalidad.Location = new System.Drawing.Point(247, 43);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.Size = new System.Drawing.Size(106, 13);
            this.Nacionalidad.TabIndex = 20;
            this.Nacionalidad.Text = "Fecha de nacimiento";
            // 
            // DarAltaClienteBoton
            // 
            this.DarAltaClienteBoton.Location = new System.Drawing.Point(79, 298);
            this.DarAltaClienteBoton.Name = "DarAltaClienteBoton";
            this.DarAltaClienteBoton.Size = new System.Drawing.Size(118, 74);
            this.DarAltaClienteBoton.TabIndex = 28;
            this.DarAltaClienteBoton.Text = "Dar de Alta";
            this.DarAltaClienteBoton.UseVisualStyleBackColor = true;
            this.DarAltaClienteBoton.Click += new System.EventHandler(this.DarAltaClienteBoton_Click);
            // 
            // VolverBoton
            // 
            this.VolverBoton.Location = new System.Drawing.Point(261, 298);
            this.VolverBoton.Name = "VolverBoton";
            this.VolverBoton.Size = new System.Drawing.Size(124, 74);
            this.VolverBoton.TabIndex = 29;
            this.VolverBoton.Text = "Volver";
            this.VolverBoton.UseVisualStyleBackColor = true;
            this.VolverBoton.Click += new System.EventHandler(this.VolverBoton_Click);
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(111, 112);
            this.user.MaxLength = 30;
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(100, 20);
            this.user.TabIndex = 7;
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(111, 158);
            this.pass.MaxLength = 44;
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(100, 20);
            this.pass.TabIndex = 9;
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(12, 161);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(61, 13);
            this.Nombre.TabIndex = 8;
            this.Nombre.Text = "Contrasena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Rol";
            // 
            // roles
            // 
            this.roles.FormattingEnabled = true;
            this.roles.Location = new System.Drawing.Point(364, 119);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(121, 21);
            this.roles.TabIndex = 33;
            // 
            // tiposdoc
            // 
            this.tiposdoc.FormattingEnabled = true;
            this.tiposdoc.Location = new System.Drawing.Point(159, 12);
            this.tiposdoc.Name = "tiposdoc";
            this.tiposdoc.Size = new System.Drawing.Size(100, 21);
            this.tiposdoc.TabIndex = 34;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 35;
            this.radioButton1.Text = "Otro";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(141, 17);
            this.radioButton2.TabIndex = 36;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Elegir Tipo de Pasaporte";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(364, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // nombret
            // 
            this.nombret.Location = new System.Drawing.Point(364, 154);
            this.nombret.MaxLength = 30;
            this.nombret.Name = "nombret";
            this.nombret.Size = new System.Drawing.Size(100, 20);
            this.nombret.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Nombre";
            // 
            // apellidot
            // 
            this.apellidot.Location = new System.Drawing.Point(364, 180);
            this.apellidot.MaxLength = 30;
            this.apellidot.Name = "apellidot";
            this.apellidot.Size = new System.Drawing.Size(100, 20);
            this.apellidot.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Apellido";
            // 
            // telefonot
            // 
            this.telefonot.Location = new System.Drawing.Point(111, 210);
            this.telefonot.MaxLength = 30;
            this.telefonot.Name = "telefonot";
            this.telefonot.Size = new System.Drawing.Size(100, 20);
            this.telefonot.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Telefono";
            // 
            // mailt
            // 
            this.mailt.Location = new System.Drawing.Point(111, 184);
            this.mailt.MaxLength = 30;
            this.mailt.Name = "mailt";
            this.mailt.Size = new System.Drawing.Size(100, 20);
            this.mailt.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Mail";
            // 
            // DarAltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 394);
            this.Controls.Add(this.telefonot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mailt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.apellidot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.tiposdoc);
            this.Controls.Add(this.roles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VolverBoton);
            this.Controls.Add(this.DarAltaClienteBoton);
            this.Controls.Add(this.Nacionalidad);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.FechaNacimiento);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.user);
            this.Controls.Add(this.Apellido);
            this.Controls.Add(this.nrodoc);
            this.Controls.Add(this.NumeroDoc);
            this.Controls.Add(this.TipoDocTextBox);
            this.Name = "DarAltaUsuario";
            this.Text = "Dar de Alta un Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TipoDocTextBox;
        private System.Windows.Forms.Label NumeroDoc;
        private System.Windows.Forms.TextBox nrodoc;
        private System.Windows.Forms.Label Apellido;
        private System.Windows.Forms.Label FechaNacimiento;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label Nacionalidad;
        private System.Windows.Forms.Button DarAltaClienteBoton;
        private System.Windows.Forms.Button VolverBoton;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roles;
        private System.Windows.Forms.ComboBox tiposdoc;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox nombret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apellidot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telefonot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mailt;
        private System.Windows.Forms.Label label5;
    }
}