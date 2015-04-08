namespace FrbaHotel.ABM_de_Hotel
{
    partial class ABMSeleccionH
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
            this.VolverButton = new System.Windows.Forms.Button();
            this.DarBajaRolButton = new System.Windows.Forms.Button();
            this.ModificarRolButton = new System.Windows.Forms.Button();
            this.CrearRolButton = new System.Windows.Forms.Button();
            this.hoteles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ciudadt = new System.Windows.Forms.TextBox();
            this.callet = new System.Windows.Forms.TextBox();
            this.ncallet = new System.Windows.Forms.TextBox();
            this.cantes = new System.Windows.Forms.TextBox();
            this.reccantes = new System.Windows.Forms.TextBox();
            this.mailt = new System.Windows.Forms.TextBox();
            this.paist = new System.Windows.Forms.TextBox();
            this.nombret = new System.Windows.Forms.TextBox();
            this.fechacreacion = new System.Windows.Forms.DateTimePicker();
            this.motivo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.telefonot = new System.Windows.Forms.TextBox();
            this.fechacheck = new System.Windows.Forms.CheckBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.habilitadoch = new System.Windows.Forms.CheckBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrocalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(238, 405);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(120, 23);
            this.VolverButton.TabIndex = 23;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // DarBajaRolButton
            // 
            this.DarBajaRolButton.Location = new System.Drawing.Point(26, 295);
            this.DarBajaRolButton.Name = "DarBajaRolButton";
            this.DarBajaRolButton.Size = new System.Drawing.Size(120, 39);
            this.DarBajaRolButton.TabIndex = 22;
            this.DarBajaRolButton.Text = "Dar de Baja un Hotel";
            this.DarBajaRolButton.UseVisualStyleBackColor = true;
            this.DarBajaRolButton.Click += new System.EventHandler(this.DarBajaRolButton_Click);
            // 
            // ModificarRolButton
            // 
            this.ModificarRolButton.Location = new System.Drawing.Point(26, 237);
            this.ModificarRolButton.Name = "ModificarRolButton";
            this.ModificarRolButton.Size = new System.Drawing.Size(120, 52);
            this.ModificarRolButton.TabIndex = 21;
            this.ModificarRolButton.Text = "Modificar un Hotel";
            this.ModificarRolButton.UseVisualStyleBackColor = true;
            this.ModificarRolButton.Click += new System.EventHandler(this.ModificarRolButton_Click);
            // 
            // CrearRolButton
            // 
            this.CrearRolButton.Location = new System.Drawing.Point(26, 181);
            this.CrearRolButton.Name = "CrearRolButton";
            this.CrearRolButton.Size = new System.Drawing.Size(120, 50);
            this.CrearRolButton.TabIndex = 20;
            this.CrearRolButton.Text = "Crear un Nuevo Hotel";
            this.CrearRolButton.UseVisualStyleBackColor = true;
            this.CrearRolButton.Click += new System.EventHandler(this.CrearRolButton_Click);
            // 
            // hoteles
            // 
            this.hoteles.AllowUserToAddRows = false;
            this.hoteles.AllowUserToDeleteRows = false;
            this.hoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hoteles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.habilitado,
            this.ciudad,
            this.calle,
            this.nrocalle,
            this.cante,
            this.recarga,
            this.creacion,
            this.pais,
            this.nombre,
            this.telefono,
            this.mail});
            this.hoteles.Location = new System.Drawing.Point(8, 9);
            this.hoteles.Name = "hoteles";
            this.hoteles.ReadOnly = true;
            this.hoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hoteles.Size = new System.Drawing.Size(908, 166);
            this.hoteles.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Calle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Numero de calle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cant Estrellas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Recarga por estrellas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fecha de creacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(644, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Pais";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(627, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(645, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Mail";
            // 
            // ciudadt
            // 
            this.ciudadt.Location = new System.Drawing.Point(389, 210);
            this.ciudadt.MaxLength = 255;
            this.ciudadt.Name = "ciudadt";
            this.ciudadt.Size = new System.Drawing.Size(100, 20);
            this.ciudadt.TabIndex = 34;
            // 
            // callet
            // 
            this.callet.Location = new System.Drawing.Point(389, 236);
            this.callet.MaxLength = 255;
            this.callet.Name = "callet";
            this.callet.Size = new System.Drawing.Size(100, 20);
            this.callet.TabIndex = 35;
            // 
            // ncallet
            // 
            this.ncallet.Location = new System.Drawing.Point(389, 262);
            this.ncallet.MaxLength = 18;
            this.ncallet.Name = "ncallet";
            this.ncallet.Size = new System.Drawing.Size(100, 20);
            this.ncallet.TabIndex = 36;
            // 
            // cantes
            // 
            this.cantes.Location = new System.Drawing.Point(389, 288);
            this.cantes.MaxLength = 18;
            this.cantes.Name = "cantes";
            this.cantes.Size = new System.Drawing.Size(100, 20);
            this.cantes.TabIndex = 37;
            // 
            // reccantes
            // 
            this.reccantes.Location = new System.Drawing.Point(389, 314);
            this.reccantes.MaxLength = 18;
            this.reccantes.Name = "reccantes";
            this.reccantes.Size = new System.Drawing.Size(100, 20);
            this.reccantes.TabIndex = 38;
            // 
            // mailt
            // 
            this.mailt.Location = new System.Drawing.Point(692, 210);
            this.mailt.MaxLength = 60;
            this.mailt.Name = "mailt";
            this.mailt.Size = new System.Drawing.Size(100, 20);
            this.mailt.TabIndex = 40;
            // 
            // paist
            // 
            this.paist.Location = new System.Drawing.Point(692, 236);
            this.paist.MaxLength = 60;
            this.paist.Name = "paist";
            this.paist.Size = new System.Drawing.Size(100, 20);
            this.paist.TabIndex = 41;
            // 
            // nombret
            // 
            this.nombret.Location = new System.Drawing.Point(692, 262);
            this.nombret.MaxLength = 60;
            this.nombret.Name = "nombret";
            this.nombret.Size = new System.Drawing.Size(100, 20);
            this.nombret.TabIndex = 42;
            // 
            // fechacreacion
            // 
            this.fechacreacion.Location = new System.Drawing.Point(389, 340);
            this.fechacreacion.Name = "fechacreacion";
            this.fechacreacion.Size = new System.Drawing.Size(208, 20);
            this.fechacreacion.TabIndex = 45;
            // 
            // motivo
            // 
            this.motivo.Location = new System.Drawing.Point(26, 366);
            this.motivo.Multiline = true;
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(187, 62);
            this.motivo.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 346);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Motivo de la baja";
            // 
            // telefonot
            // 
            this.telefonot.Location = new System.Drawing.Point(692, 295);
            this.telefonot.MaxLength = 18;
            this.telefonot.Name = "telefonot";
            this.telefonot.Size = new System.Drawing.Size(100, 20);
            this.telefonot.TabIndex = 53;
            // 
            // fechacheck
            // 
            this.fechacheck.AutoSize = true;
            this.fechacheck.Location = new System.Drawing.Point(386, 368);
            this.fechacheck.Name = "fechacheck";
            this.fechacheck.Size = new System.Drawing.Size(107, 17);
            this.fechacheck.TabIndex = 54;
            this.fechacheck.Text = "Buscar por fecha";
            this.fechacheck.UseVisualStyleBackColor = true;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(630, 346);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(184, 26);
            this.Buscar.TabIndex = 52;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(635, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Telefono";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(632, 326);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 80;
            this.label12.Text = "Habilitado";
            // 
            // habilitadoch
            // 
            this.habilitadoch.AutoSize = true;
            this.habilitadoch.Checked = true;
            this.habilitadoch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitadoch.Location = new System.Drawing.Point(692, 323);
            this.habilitadoch.Name = "habilitadoch";
            this.habilitadoch.Size = new System.Drawing.Size(73, 17);
            this.habilitadoch.TabIndex = 79;
            this.habilitadoch.Text = "Habilitado";
            this.habilitadoch.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id.DataPropertyName = "Hotel_ID";
            this.id.HeaderText = "Id Hotel";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 69;
            // 
            // habilitado
            // 
            this.habilitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.habilitado.DataPropertyName = "Hotel_Habilitado";
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            this.habilitado.Width = 60;
            // 
            // ciudad
            // 
            this.ciudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ciudad.DataPropertyName = "Hotel_Ciudad";
            this.ciudad.HeaderText = "Ciudad";
            this.ciudad.Name = "ciudad";
            this.ciudad.ReadOnly = true;
            this.ciudad.Width = 70;
            // 
            // calle
            // 
            this.calle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calle.DataPropertyName = "Hotel_Calle";
            this.calle.HeaderText = "Calle";
            this.calle.Name = "calle";
            this.calle.ReadOnly = true;
            this.calle.Width = 70;
            // 
            // nrocalle
            // 
            this.nrocalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nrocalle.DataPropertyName = "Hotel_Nro_Calle";
            this.nrocalle.HeaderText = "Numero de calle";
            this.nrocalle.Name = "nrocalle";
            this.nrocalle.ReadOnly = true;
            this.nrocalle.Width = 60;
            // 
            // cante
            // 
            this.cante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cante.DataPropertyName = "Hotel_CantEstrella";
            this.cante.HeaderText = "Cantidad de estrellas";
            this.cante.Name = "cante";
            this.cante.ReadOnly = true;
            this.cante.Width = 60;
            // 
            // recarga
            // 
            this.recarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.recarga.DataPropertyName = "Hotel_Recarga_Estrella";
            this.recarga.HeaderText = "Recarga por estrellas";
            this.recarga.Name = "recarga";
            this.recarga.ReadOnly = true;
            this.recarga.Width = 60;
            // 
            // creacion
            // 
            this.creacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.creacion.DataPropertyName = "Hotel_Fecha_Creacion";
            this.creacion.HeaderText = "Fecha de creacion";
            this.creacion.Name = "creacion";
            this.creacion.ReadOnly = true;
            this.creacion.Width = 70;
            // 
            // pais
            // 
            this.pais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pais.DataPropertyName = "Hotel_Pais";
            this.pais.HeaderText = "Pais";
            this.pais.Name = "pais";
            this.pais.ReadOnly = true;
            this.pais.Width = 70;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nombre.DataPropertyName = "Hotel_Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 70;
            // 
            // telefono
            // 
            this.telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.telefono.DataPropertyName = "Hotel_Telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 70;
            // 
            // mail
            // 
            this.mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.mail.DataPropertyName = "Hotel_Mail";
            this.mail.HeaderText = "Mail";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            this.mail.Width = 70;
            // 
            // ABMSeleccionH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 432);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.habilitadoch);
            this.Controls.Add(this.telefonot);
            this.Controls.Add(this.fechacheck);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.motivo);
            this.Controls.Add(this.fechacreacion);
            this.Controls.Add(this.nombret);
            this.Controls.Add(this.paist);
            this.Controls.Add(this.mailt);
            this.Controls.Add(this.reccantes);
            this.Controls.Add(this.cantes);
            this.Controls.Add(this.ncallet);
            this.Controls.Add(this.callet);
            this.Controls.Add(this.ciudadt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hoteles);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.DarBajaRolButton);
            this.Controls.Add(this.ModificarRolButton);
            this.Controls.Add(this.CrearRolButton);
            this.Name = "ABMSeleccionH";
            this.Text = "Hoteles";
            ((System.ComponentModel.ISupportInitialize)(this.hoteles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.Button DarBajaRolButton;
        private System.Windows.Forms.Button ModificarRolButton;
        private System.Windows.Forms.Button CrearRolButton;
        private System.Windows.Forms.DataGridView hoteles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ciudadt;
        private System.Windows.Forms.TextBox callet;
        private System.Windows.Forms.TextBox ncallet;
        private System.Windows.Forms.TextBox cantes;
        private System.Windows.Forms.TextBox reccantes;
        private System.Windows.Forms.TextBox mailt;
        private System.Windows.Forms.TextBox paist;
        private System.Windows.Forms.TextBox nombret;
        private System.Windows.Forms.DateTimePicker fechacreacion;
        private System.Windows.Forms.TextBox motivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox telefonot;
        private System.Windows.Forms.CheckBox fechacheck;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox habilitadoch;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cante;
        private System.Windows.Forms.DataGridViewTextBoxColumn recarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
    }
}