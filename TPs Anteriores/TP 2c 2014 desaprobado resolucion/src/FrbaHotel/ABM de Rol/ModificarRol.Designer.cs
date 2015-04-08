namespace FrbaHotel.ABM_de_Rol
{
    partial class ModificarRol
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
            this.ModificarButton = new System.Windows.Forms.Button();
            this.VolverButton = new System.Windows.Forms.Button();
            this.NombreRolLabel = new System.Windows.Forms.Label();
            this.FuncionalidadesRolLabel = new System.Windows.Forms.Label();
            this.NombreDelRolAModificarLabel = new System.Windows.Forms.Label();
            this.rolHabilitadoCheckbox = new System.Windows.Forms.CheckBox();
            this.funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // ModificarButton
            // 
            this.ModificarButton.Location = new System.Drawing.Point(18, 294);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(75, 34);
            this.ModificarButton.TabIndex = 0;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = true;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(122, 294);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(75, 34);
            this.VolverButton.TabIndex = 1;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // NombreRolLabel
            // 
            this.NombreRolLabel.AutoSize = true;
            this.NombreRolLabel.Location = new System.Drawing.Point(9, 43);
            this.NombreRolLabel.Name = "NombreRolLabel";
            this.NombreRolLabel.Size = new System.Drawing.Size(44, 13);
            this.NombreRolLabel.TabIndex = 2;
            this.NombreRolLabel.Text = "Nombre";
            // 
            // FuncionalidadesRolLabel
            // 
            this.FuncionalidadesRolLabel.AutoSize = true;
            this.FuncionalidadesRolLabel.Location = new System.Drawing.Point(9, 78);
            this.FuncionalidadesRolLabel.Name = "FuncionalidadesRolLabel";
            this.FuncionalidadesRolLabel.Size = new System.Drawing.Size(162, 13);
            this.FuncionalidadesRolLabel.TabIndex = 6;
            this.FuncionalidadesRolLabel.Text = " Seleccione las Funcionalidades:";
            // 
            // NombreDelRolAModificarLabel
            // 
            this.NombreDelRolAModificarLabel.AutoSize = true;
            this.NombreDelRolAModificarLabel.Location = new System.Drawing.Point(84, 43);
            this.NombreDelRolAModificarLabel.Name = "NombreDelRolAModificarLabel";
            this.NombreDelRolAModificarLabel.Size = new System.Drawing.Size(149, 13);
            this.NombreDelRolAModificarLabel.TabIndex = 15;
            this.NombreDelRolAModificarLabel.Text = "aca se carga el nombre del rol";
            // 
            // rolHabilitadoCheckbox
            // 
            this.rolHabilitadoCheckbox.AutoSize = true;
            this.rolHabilitadoCheckbox.Location = new System.Drawing.Point(87, 234);
            this.rolHabilitadoCheckbox.Name = "rolHabilitadoCheckbox";
            this.rolHabilitadoCheckbox.Size = new System.Drawing.Size(75, 17);
            this.rolHabilitadoCheckbox.TabIndex = 4;
            this.rolHabilitadoCheckbox.Text = "Rol Activo";
            this.rolHabilitadoCheckbox.UseVisualStyleBackColor = true;
            
            // 
            // funcionalidades
            // 
            this.funcionalidades.FormattingEnabled = true;
            this.funcionalidades.Location = new System.Drawing.Point(77, 116);
            this.funcionalidades.Name = "funcionalidades";
            this.funcionalidades.Size = new System.Drawing.Size(120, 94);
            this.funcionalidades.TabIndex = 17;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 339);
            this.Controls.Add(this.funcionalidades);
            this.Controls.Add(this.NombreDelRolAModificarLabel);
            this.Controls.Add(this.FuncionalidadesRolLabel);
            this.Controls.Add(this.rolHabilitadoCheckbox);
            this.Controls.Add(this.NombreRolLabel);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.ModificarButton);
            this.Name = "ModificarRol";
            this.Text = "Modificar un Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.Label NombreRolLabel;
        private System.Windows.Forms.Label FuncionalidadesRolLabel;
        private System.Windows.Forms.Label NombreDelRolAModificarLabel;
        private System.Windows.Forms.CheckBox rolHabilitadoCheckbox;
        private System.Windows.Forms.CheckedListBox funcionalidades;
    }
}