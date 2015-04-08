namespace FrbaHotel.ABM_de_Usuario
{
    partial class ABMSeleccionU
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
            this.CrearUsuarioButton = new System.Windows.Forms.Button();
            this.ConsignaAbmRolLabel = new System.Windows.Forms.Label();
            this.datagridViewUsuario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nombretextBox = new System.Windows.Forms.TextBox();
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nroDocTextBox = new System.Windows.Forms.TextBox();
            this.buscarBoton = new System.Windows.Forms.Button();
            this.LimpiarBoton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.direcciont = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombreHotelLabel = new System.Windows.Forms.Label();
            this.HotelLabel = new System.Windows.Forms.Label();
            this.TipoDocLabel = new System.Windows.Forms.Label();
            this.TipoDoccomboBox = new System.Windows.Forms.ComboBox();
            this.UsuarioIDTextBox = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpasdes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cndoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechanac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chabilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewUsuario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(662, 366);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(136, 34);
            this.VolverButton.TabIndex = 19;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // DarBajaRolButton
            // 
            this.DarBajaRolButton.Location = new System.Drawing.Point(652, 173);
            this.DarBajaRolButton.Name = "DarBajaRolButton";
            this.DarBajaRolButton.Size = new System.Drawing.Size(146, 62);
            this.DarBajaRolButton.TabIndex = 18;
            this.DarBajaRolButton.Text = "Dar de Baja un Usuario";
            this.DarBajaRolButton.UseVisualStyleBackColor = true;
            this.DarBajaRolButton.Click += new System.EventHandler(this.DarBajaRolButton_Click);
            // 
            // ModificarRolButton
            // 
            this.ModificarRolButton.Location = new System.Drawing.Point(652, 94);
            this.ModificarRolButton.Name = "ModificarRolButton";
            this.ModificarRolButton.Size = new System.Drawing.Size(146, 58);
            this.ModificarRolButton.TabIndex = 17;
            this.ModificarRolButton.Text = "Modificar un Usuario";
            this.ModificarRolButton.UseVisualStyleBackColor = true;
            this.ModificarRolButton.Click += new System.EventHandler(this.ModificarRolButton_Click);
            // 
            // CrearUsuarioButton
            // 
            this.CrearUsuarioButton.Location = new System.Drawing.Point(652, 12);
            this.CrearUsuarioButton.Name = "CrearUsuarioButton";
            this.CrearUsuarioButton.Size = new System.Drawing.Size(146, 62);
            this.CrearUsuarioButton.TabIndex = 16;
            this.CrearUsuarioButton.Text = "Crear un Nuevo Usuario";
            this.CrearUsuarioButton.UseVisualStyleBackColor = true;
            this.CrearUsuarioButton.Click += new System.EventHandler(this.CrearRolButton_Click);
            // 
            // ConsignaAbmRolLabel
            // 
            this.ConsignaAbmRolLabel.AutoSize = true;
            this.ConsignaAbmRolLabel.Location = new System.Drawing.Point(-43, -49);
            this.ConsignaAbmRolLabel.Name = "ConsignaAbmRolLabel";
            this.ConsignaAbmRolLabel.Size = new System.Drawing.Size(231, 13);
            this.ConsignaAbmRolLabel.TabIndex = 11;
            this.ConsignaAbmRolLabel.Text = "Para buscar un Rol ingrese el Codigo del mismo";
            // 
            // datagridViewUsuario
            // 
            this.datagridViewUsuario.AllowUserToAddRows = false;
            this.datagridViewUsuario.AllowUserToDeleteRows = false;
            this.datagridViewUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridViewUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cid,
            this.cusername,
            this.cpasdes,
            this.cndoc,
            this.cdireccion,
            this.cfechanac,
            this.cnombre,
            this.capellido,
            this.cmail,
            this.ctelefono,
            this.chabilitado});
            this.datagridViewUsuario.Location = new System.Drawing.Point(23, 189);
            this.datagridViewUsuario.Name = "datagridViewUsuario";
            this.datagridViewUsuario.ReadOnly = true;
            this.datagridViewUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridViewUsuario.Size = new System.Drawing.Size(604, 211);
            this.datagridViewUsuario.TabIndex = 20;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(91, 14);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Apellido:";
            // 
            // nombretextBox
            // 
            this.nombretextBox.Location = new System.Drawing.Point(91, 47);
            this.nombretextBox.Name = "nombretextBox";
            this.nombretextBox.Size = new System.Drawing.Size(100, 20);
            this.nombretextBox.TabIndex = 27;
            this.nombretextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // apellidoTextBox
            // 
            this.apellidoTextBox.Location = new System.Drawing.Point(326, 72);
            this.apellidoTextBox.Name = "apellidoTextBox";
            this.apellidoTextBox.Size = new System.Drawing.Size(122, 20);
            this.apellidoTextBox.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Mail:";
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(326, 46);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(122, 20);
            this.mailTextBox.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Nro.Doc:";
            // 
            // nroDocTextBox
            // 
            this.nroDocTextBox.Location = new System.Drawing.Point(326, 103);
            this.nroDocTextBox.Name = "nroDocTextBox";
            this.nroDocTextBox.Size = new System.Drawing.Size(124, 20);
            this.nroDocTextBox.TabIndex = 32;
            // 
            // buscarBoton
            // 
            this.buscarBoton.Location = new System.Drawing.Point(77, 143);
            this.buscarBoton.Name = "buscarBoton";
            this.buscarBoton.Size = new System.Drawing.Size(144, 32);
            this.buscarBoton.TabIndex = 33;
            this.buscarBoton.Text = "Buscar";
            this.buscarBoton.UseVisualStyleBackColor = true;
            this.buscarBoton.Click += new System.EventHandler(this.buscarBoton_Click);
            // 
            // LimpiarBoton
            // 
            this.LimpiarBoton.Location = new System.Drawing.Point(315, 143);
            this.LimpiarBoton.Name = "LimpiarBoton";
            this.LimpiarBoton.Size = new System.Drawing.Size(144, 31);
            this.LimpiarBoton.TabIndex = 34;
            this.LimpiarBoton.Text = "Limpiar";
            this.LimpiarBoton.UseVisualStyleBackColor = true;
            this.LimpiarBoton.Click += new System.EventHandler(this.LimpiarBoton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.direcciont);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nombreHotelLabel);
            this.groupBox1.Controls.Add(this.HotelLabel);
            this.groupBox1.Controls.Add(this.TipoDocLabel);
            this.groupBox1.Controls.Add(this.TipoDoccomboBox);
            this.groupBox1.Controls.Add(this.UsuarioIDTextBox);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.nroDocTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.mailTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.apellidoTextBox);
            this.groupBox1.Controls.Add(this.nombretextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.usernameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 130);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // direcciont
            // 
            this.direcciont.Location = new System.Drawing.Point(326, 14);
            this.direcciont.Name = "direcciont";
            this.direcciont.Size = new System.Drawing.Size(122, 20);
            this.direcciont.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Direccion";
            // 
            // nombreHotelLabel
            // 
            this.nombreHotelLabel.AutoSize = true;
            this.nombreHotelLabel.Location = new System.Drawing.Point(513, 21);
            this.nombreHotelLabel.Name = "nombreHotelLabel";
            this.nombreHotelLabel.Size = new System.Drawing.Size(85, 13);
            this.nombreHotelLabel.TabIndex = 39;
            this.nombreHotelLabel.Text = "nombre del hotel";
            // 
            // HotelLabel
            // 
            this.HotelLabel.AutoSize = true;
            this.HotelLabel.Location = new System.Drawing.Point(456, 21);
            this.HotelLabel.Name = "HotelLabel";
            this.HotelLabel.Size = new System.Drawing.Size(35, 13);
            this.HotelLabel.TabIndex = 38;
            this.HotelLabel.Text = "Hotel:";
            // 
            // TipoDocLabel
            // 
            this.TipoDocLabel.AutoSize = true;
            this.TipoDocLabel.Location = new System.Drawing.Point(11, 79);
            this.TipoDocLabel.Name = "TipoDocLabel";
            this.TipoDocLabel.Size = new System.Drawing.Size(48, 13);
            this.TipoDocLabel.TabIndex = 37;
            this.TipoDocLabel.Text = "TipoDoc";
            // 
            // TipoDoccomboBox
            // 
            this.TipoDoccomboBox.FormattingEnabled = true;
            this.TipoDoccomboBox.Location = new System.Drawing.Point(91, 76);
            this.TipoDoccomboBox.Name = "TipoDoccomboBox";
            this.TipoDoccomboBox.Size = new System.Drawing.Size(100, 21);
            this.TipoDoccomboBox.TabIndex = 36;
            // 
            // UsuarioIDTextBox
            // 
            this.UsuarioIDTextBox.Location = new System.Drawing.Point(90, 104);
            this.UsuarioIDTextBox.Name = "UsuarioIDTextBox";
            this.UsuarioIDTextBox.Size = new System.Drawing.Size(122, 20);
            this.UsuarioIDTextBox.TabIndex = 35;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(11, 110);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(60, 13);
            this.ID.TabIndex = 34;
            this.ID.Text = "Usuario ID:";
            // 
            // cid
            // 
            this.cid.DataPropertyName = "Usuario_ID";
            this.cid.HeaderText = "ID";
            this.cid.Name = "cid";
            this.cid.ReadOnly = true;
            // 
            // cusername
            // 
            this.cusername.DataPropertyName = "Usuario_Username";
            this.cusername.HeaderText = "Username";
            this.cusername.Name = "cusername";
            this.cusername.ReadOnly = true;
            // 
            // cpasdes
            // 
            this.cpasdes.DataPropertyName = "Pasaporte_Tipo";
            this.cpasdes.HeaderText = "Tipo de Pasaporte";
            this.cpasdes.Name = "cpasdes";
            this.cpasdes.ReadOnly = true;
            // 
            // cndoc
            // 
            this.cndoc.DataPropertyName = "Usuario_Numero_Doc";
            this.cndoc.HeaderText = "Numero de pasaporte";
            this.cndoc.Name = "cndoc";
            this.cndoc.ReadOnly = true;
            // 
            // cdireccion
            // 
            this.cdireccion.DataPropertyName = "Usuario_Direccion";
            this.cdireccion.HeaderText = "Direccion";
            this.cdireccion.Name = "cdireccion";
            this.cdireccion.ReadOnly = true;
            // 
            // cfechanac
            // 
            this.cfechanac.DataPropertyName = "Usuario_Fecha_Nacimiento";
            this.cfechanac.HeaderText = "Fecha de Nacimiento";
            this.cfechanac.Name = "cfechanac";
            this.cfechanac.ReadOnly = true;
            // 
            // cnombre
            // 
            this.cnombre.DataPropertyName = "Usuario_Nombre";
            this.cnombre.HeaderText = "Nombre";
            this.cnombre.Name = "cnombre";
            this.cnombre.ReadOnly = true;
            // 
            // capellido
            // 
            this.capellido.DataPropertyName = "Usuario_Apellido";
            this.capellido.HeaderText = "Apellido";
            this.capellido.Name = "capellido";
            this.capellido.ReadOnly = true;
            // 
            // cmail
            // 
            this.cmail.DataPropertyName = "Usuario_mail";
            this.cmail.HeaderText = "Mail";
            this.cmail.Name = "cmail";
            this.cmail.ReadOnly = true;
            // 
            // ctelefono
            // 
            this.ctelefono.DataPropertyName = "Usuario_Telefono";
            this.ctelefono.HeaderText = "Telefono";
            this.ctelefono.Name = "ctelefono";
            this.ctelefono.ReadOnly = true;
            // 
            // chabilitado
            // 
            this.chabilitado.DataPropertyName = "Usuario_Habilitado";
            this.chabilitado.HeaderText = "Habilitado";
            this.chabilitado.Name = "chabilitado";
            this.chabilitado.ReadOnly = true;
            // 
            // ABMSeleccionU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LimpiarBoton);
            this.Controls.Add(this.buscarBoton);
            this.Controls.Add(this.datagridViewUsuario);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.DarBajaRolButton);
            this.Controls.Add(this.ModificarRolButton);
            this.Controls.Add(this.CrearUsuarioButton);
            this.Controls.Add(this.ConsignaAbmRolLabel);
            this.Name = "ABMSeleccionU";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.ABMSeleccionU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewUsuario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.Button DarBajaRolButton;
        private System.Windows.Forms.Button ModificarRolButton;
        private System.Windows.Forms.Button CrearUsuarioButton;
        private System.Windows.Forms.Label ConsignaAbmRolLabel;
        private System.Windows.Forms.DataGridView datagridViewUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombretextBox;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nroDocTextBox;
        private System.Windows.Forms.Button buscarBoton;
        private System.Windows.Forms.Button LimpiarBoton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label TipoDocLabel;
        private System.Windows.Forms.ComboBox TipoDoccomboBox;
        private System.Windows.Forms.TextBox UsuarioIDTextBox;
        private System.Windows.Forms.Label nombreHotelLabel;
        private System.Windows.Forms.Label HotelLabel;
        private System.Windows.Forms.TextBox direcciont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusername;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpasdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cndoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfechanac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn capellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctelefono;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chabilitado;


    }
}