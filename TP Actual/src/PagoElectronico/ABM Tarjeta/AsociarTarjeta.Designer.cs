﻿namespace PagoElectronico.ABM_Tarjeta
{
    partial class AsociarTarjeta
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
            this.txttarjeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtEmision = new System.Windows.Forms.DateTimePicker();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btAsociar = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.dgBancos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBancos)).BeginInit();
            this.SuspendLayout();
            // 
            // txttarjeta
            // 
            this.txttarjeta.Location = new System.Drawing.Point(126, 2);
            this.txttarjeta.MaxLength = 16;
            this.txttarjeta.Name = "txttarjeta";
            this.txttarjeta.Size = new System.Drawing.Size(200, 20);
            this.txttarjeta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de la tarjeta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Banco emisor:";
            // 
            // dtEmision
            // 
            this.dtEmision.Location = new System.Drawing.Point(125, 110);
            this.dtEmision.Name = "dtEmision";
            this.dtEmision.Size = new System.Drawing.Size(200, 20);
            this.dtEmision.TabIndex = 4;
            this.dtEmision.ValueChanged += new System.EventHandler(this.dtEmision_ValueChanged);
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Location = new System.Drawing.Point(125, 137);
            this.dtVencimiento.Name = "dtVencimiento";
            this.dtVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtVencimiento.TabIndex = 5;
            this.dtVencimiento.ValueChanged += new System.EventHandler(this.dtVencimiento_ValueChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(125, 166);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(199, 20);
            this.txtCodigo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha de vencimiento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de emision:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Codigo de seguridad:";
            // 
            // btAsociar
            // 
            this.btAsociar.Location = new System.Drawing.Point(377, 137);
            this.btAsociar.Name = "btAsociar";
            this.btAsociar.Size = new System.Drawing.Size(97, 30);
            this.btAsociar.TabIndex = 13;
            this.btAsociar.Text = "Asociar";
            this.btAsociar.UseVisualStyleBackColor = true;
            this.btAsociar.Click += new System.EventHandler(this.btAsociar_Click);
            // 
            // btVolver
            // 
            this.btVolver.Location = new System.Drawing.Point(517, 137);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(97, 30);
            this.btVolver.TabIndex = 14;
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // dgBancos
            // 
            this.dgBancos.AllowUserToAddRows = false;
            this.dgBancos.AllowUserToDeleteRows = false;
            this.dgBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBancos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.id,
            this.Pais,
            this.Localidad,
            this.Calle,
            this.Altura});
            this.dgBancos.Location = new System.Drawing.Point(126, 33);
            this.dgBancos.Name = "dgBancos";
            this.dgBancos.ReadOnly = true;
            this.dgBancos.RowHeadersVisible = false;
            this.dgBancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBancos.Size = new System.Drawing.Size(505, 71);
            this.dgBancos.TabIndex = 15;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Descripcion";
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id_banco";
            this.id.Frozen = true;
            this.id.HeaderText = "idbanco";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Pais
            // 
            this.Pais.DataPropertyName = "pais";
            this.Pais.Frozen = true;
            this.Pais.HeaderText = "Pais";
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            // 
            // Localidad
            // 
            this.Localidad.DataPropertyName = "Localidad";
            this.Localidad.Frozen = true;
            this.Localidad.HeaderText = "Localidad";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            // 
            // Calle
            // 
            this.Calle.DataPropertyName = "Calle";
            this.Calle.Frozen = true;
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            // 
            // Altura
            // 
            this.Altura.DataPropertyName = "Altura";
            this.Altura.Frozen = true;
            this.Altura.HeaderText = "Altura";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            // 
            // AsociarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 189);
            this.Controls.Add(this.dgBancos);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btAsociar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dtVencimiento);
            this.Controls.Add(this.dtEmision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttarjeta);
            this.Name = "AsociarTarjeta";
            this.Text = "Asociar tarjeta";
            ((System.ComponentModel.ISupportInitialize)(this.dgBancos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEmision;
        private System.Windows.Forms.DateTimePicker dtVencimiento;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAsociar;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.DataGridView dgBancos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
    }
}