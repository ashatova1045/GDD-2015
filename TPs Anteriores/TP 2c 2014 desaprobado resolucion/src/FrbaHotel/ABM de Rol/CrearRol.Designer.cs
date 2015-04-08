namespace FrbaHotel.ABM_de_Rol
{
    partial class CrearRol
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
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.FuncionalidadesLabel = new System.Windows.Forms.Label();
            this.RolActivoCheckBox = new System.Windows.Forms.CheckBox();
            this.CrearButton = new System.Windows.Forms.Button();
            this.VolverButton = new System.Windows.Forms.Button();
            this.funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Enabled = false;
            this.NombreTextBox.Location = new System.Drawing.Point(116, 13);
            this.NombreTextBox.MaxLength = 50;
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(114, 20);
            this.NombreTextBox.TabIndex = 1;
            // 
            // FuncionalidadesLabel
            // 
            this.FuncionalidadesLabel.AutoSize = true;
            this.FuncionalidadesLabel.Location = new System.Drawing.Point(9, 51);
            this.FuncionalidadesLabel.Name = "FuncionalidadesLabel";
            this.FuncionalidadesLabel.Size = new System.Drawing.Size(197, 13);
            this.FuncionalidadesLabel.TabIndex = 2;
            this.FuncionalidadesLabel.Text = "Seleccione Las Funcionalidades de Rol:";
            // 
            // RolActivoCheckBox
            // 
            this.RolActivoCheckBox.AutoSize = true;
            this.RolActivoCheckBox.Checked = true;
            this.RolActivoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RolActivoCheckBox.Location = new System.Drawing.Point(83, 178);
            this.RolActivoCheckBox.Name = "RolActivoCheckBox";
            this.RolActivoCheckBox.Size = new System.Drawing.Size(73, 17);
            this.RolActivoCheckBox.TabIndex = 7;
            this.RolActivoCheckBox.Text = "Habilitado";
            this.RolActivoCheckBox.UseVisualStyleBackColor = true;
            // 
            // CrearButton
            // 
            this.CrearButton.Location = new System.Drawing.Point(12, 201);
            this.CrearButton.Name = "CrearButton";
            this.CrearButton.Size = new System.Drawing.Size(83, 40);
            this.CrearButton.TabIndex = 8;
            this.CrearButton.Text = "Crear Rol";
            this.CrearButton.UseVisualStyleBackColor = true;
            this.CrearButton.Click += new System.EventHandler(this.CrearButton_Click);
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(142, 201);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(76, 40);
            this.VolverButton.TabIndex = 9;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // funcionalidades
            // 
            this.funcionalidades.FormattingEnabled = true;
            this.funcionalidades.Location = new System.Drawing.Point(30, 78);
            this.funcionalidades.Name = "funcionalidades";
            this.funcionalidades.Size = new System.Drawing.Size(188, 94);
            this.funcionalidades.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre del rol";
            // 
            // CrearRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 258);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.funcionalidades);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.CrearButton);
            this.Controls.Add(this.RolActivoCheckBox);
            this.Controls.Add(this.FuncionalidadesLabel);
            this.Controls.Add(this.NombreTextBox);
            this.Name = "CrearRol";
            this.Text = "Crear Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label FuncionalidadesLabel;
        private System.Windows.Forms.CheckBox RolActivoCheckBox;
        private System.Windows.Forms.Button CrearButton;
        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.CheckedListBox funcionalidades;
        private System.Windows.Forms.Label label1;
    }
}