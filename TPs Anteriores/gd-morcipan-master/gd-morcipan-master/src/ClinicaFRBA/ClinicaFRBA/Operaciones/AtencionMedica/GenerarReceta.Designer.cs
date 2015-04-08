namespace ClinicaFRBA.Operaciones.AtencionMedica
{
    partial class GenerarReceta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarBono = new System.Windows.Forms.Button();
            this.tBoxNbono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregarMedicamento = new System.Windows.Forms.Button();
            this.cBoxCantidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxMedicamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBonos = new System.Windows.Forms.DataGridView();
            this.dtMedicamentos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblIdMed = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMedicamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregarBono);
            this.groupBox1.Controls.Add(this.tBoxNbono);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bono Farmacia";
            // 
            // btnAgregarBono
            // 
            this.btnAgregarBono.Location = new System.Drawing.Point(193, 17);
            this.btnAgregarBono.Name = "btnAgregarBono";
            this.btnAgregarBono.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarBono.TabIndex = 2;
            this.btnAgregarBono.Text = "Agregar";
            this.btnAgregarBono.UseVisualStyleBackColor = true;
            this.btnAgregarBono.Click += new System.EventHandler(this.btnAgregarBono_Click);
            // 
            // tBoxNbono
            // 
            this.tBoxNbono.Location = new System.Drawing.Point(87, 19);
            this.tBoxNbono.Name = "tBoxNbono";
            this.tBoxNbono.Size = new System.Drawing.Size(100, 20);
            this.tBoxNbono.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bono Numero:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.btnAgregarMedicamento);
            this.groupBox2.Controls.Add(this.cBoxCantidad);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tBoxMedicamento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Medicamentos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(193, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregarMedicamento
            // 
            this.btnAgregarMedicamento.Location = new System.Drawing.Point(193, 46);
            this.btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            this.btnAgregarMedicamento.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarMedicamento.TabIndex = 4;
            this.btnAgregarMedicamento.Text = "Agregar";
            this.btnAgregarMedicamento.UseVisualStyleBackColor = true;
            this.btnAgregarMedicamento.Click += new System.EventHandler(this.btnAgregarMedicamento_Click);
            // 
            // cBoxCantidad
            // 
            this.cBoxCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCantidad.FormattingEnabled = true;
            this.cBoxCantidad.Location = new System.Drawing.Point(86, 45);
            this.cBoxCantidad.Name = "cBoxCantidad";
            this.cBoxCantidad.Size = new System.Drawing.Size(99, 21);
            this.cBoxCantidad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad:";
            // 
            // tBoxMedicamento
            // 
            this.tBoxMedicamento.Enabled = false;
            this.tBoxMedicamento.Location = new System.Drawing.Point(86, 19);
            this.tBoxMedicamento.Name = "tBoxMedicamento";
            this.tBoxMedicamento.Size = new System.Drawing.Size(100, 20);
            this.tBoxMedicamento.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Medicamento:";
            // 
            // dtBonos
            // 
            this.dtBonos.AllowUserToAddRows = false;
            this.dtBonos.AllowUserToDeleteRows = false;
            this.dtBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtBonos.Location = new System.Drawing.Point(12, 165);
            this.dtBonos.Name = "dtBonos";
            this.dtBonos.ReadOnly = true;
            this.dtBonos.Size = new System.Drawing.Size(148, 150);
            this.dtBonos.TabIndex = 2;
            // 
            // dtMedicamentos
            // 
            this.dtMedicamentos.AllowUserToAddRows = false;
            this.dtMedicamentos.AllowUserToDeleteRows = false;
            this.dtMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMedicamentos.Location = new System.Drawing.Point(166, 165);
            this.dtMedicamentos.Name = "dtMedicamentos";
            this.dtMedicamentos.ReadOnly = true;
            this.dtMedicamentos.Size = new System.Drawing.Size(240, 150);
            this.dtMedicamentos.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bonos Ingresados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Medicamentos Ingresados";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(293, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblIdMed
            // 
            this.lblIdMed.AutoSize = true;
            this.lblIdMed.Location = new System.Drawing.Point(291, 117);
            this.lblIdMed.Name = "lblIdMed";
            this.lblIdMed.Size = new System.Drawing.Size(47, 13);
            this.lblIdMed.TabIndex = 7;
            this.lblIdMed.Text = "lblIdMed";
            this.lblIdMed.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(293, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(293, 70);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // GenerarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 327);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblIdMed);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtMedicamentos);
            this.Controls.Add(this.dtBonos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarReceta";
            this.Text = "GenerarReceta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMedicamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarBono;
        private System.Windows.Forms.TextBox tBoxNbono;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarMedicamento;
        private System.Windows.Forms.ComboBox cBoxCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxMedicamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtBonos;
        private System.Windows.Forms.DataGridView dtMedicamentos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblIdMed;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
    }
}