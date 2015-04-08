namespace ClinicaFRBA.Operaciones.Bonos
{
    partial class CompraBonos
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
            this.gbCompraBono = new System.Windows.Forms.GroupBox();
            this.lblDatosAfiliado = new System.Windows.Forms.Label();
            this.btnValidarAfiliado = new System.Windows.Forms.Button();
            this.txtNroAfiliado = new System.Windows.Forms.TextBox();
            this.lblNroAfiliado = new System.Windows.Forms.Label();
            this.gbBonosConsulta = new System.Windows.Forms.GroupBox();
            this.txtCantBonosConsulta = new System.Windows.Forms.TextBox();
            this.lblCantBonosConsulta = new System.Windows.Forms.Label();
            this.gbBonosFarmacia = new System.Windows.Forms.GroupBox();
            this.txtCantBonosFarmacia = new System.Windows.Forms.TextBox();
            this.lblCantBonosFarmacia = new System.Windows.Forms.Label();
            this.gbTotal = new System.Windows.Forms.GroupBox();
            this.lblTotGral = new System.Windows.Forms.Label();
            this.lblTotBonosFarm = new System.Windows.Forms.Label();
            this.lblTotBonosCon = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCompraBono.SuspendLayout();
            this.gbBonosConsulta.SuspendLayout();
            this.gbBonosFarmacia.SuspendLayout();
            this.gbTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompraBono
            // 
            this.gbCompraBono.Controls.Add(this.lblDatosAfiliado);
            this.gbCompraBono.Controls.Add(this.btnValidarAfiliado);
            this.gbCompraBono.Controls.Add(this.txtNroAfiliado);
            this.gbCompraBono.Controls.Add(this.lblNroAfiliado);
            this.gbCompraBono.Location = new System.Drawing.Point(13, 13);
            this.gbCompraBono.Name = "gbCompraBono";
            this.gbCompraBono.Size = new System.Drawing.Size(619, 58);
            this.gbCompraBono.TabIndex = 0;
            this.gbCompraBono.TabStop = false;
            this.gbCompraBono.Text = "Datos de Afiliado";
            // 
            // lblDatosAfiliado
            // 
            this.lblDatosAfiliado.AutoSize = true;
            this.lblDatosAfiliado.Location = new System.Drawing.Point(289, 10);
            this.lblDatosAfiliado.Name = "lblDatosAfiliado";
            this.lblDatosAfiliado.Size = new System.Drawing.Size(85, 13);
            this.lblDatosAfiliado.TabIndex = 3;
            this.lblDatosAfiliado.Text = "[lblDatosAfiliado]";
            // 
            // btnValidarAfiliado
            // 
            this.btnValidarAfiliado.Location = new System.Drawing.Point(226, 19);
            this.btnValidarAfiliado.Name = "btnValidarAfiliado";
            this.btnValidarAfiliado.Size = new System.Drawing.Size(56, 23);
            this.btnValidarAfiliado.TabIndex = 2;
            this.btnValidarAfiliado.Text = "Validar";
            this.btnValidarAfiliado.UseVisualStyleBackColor = true;
            this.btnValidarAfiliado.Click += new System.EventHandler(this.btnValidarAfiliado_Click);
            // 
            // txtNroAfiliado
            // 
            this.txtNroAfiliado.Location = new System.Drawing.Point(91, 22);
            this.txtNroAfiliado.Name = "txtNroAfiliado";
            this.txtNroAfiliado.Size = new System.Drawing.Size(129, 20);
            this.txtNroAfiliado.TabIndex = 1;
            this.txtNroAfiliado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroAfiliado_KeyPress);
            // 
            // lblNroAfiliado
            // 
            this.lblNroAfiliado.AutoSize = true;
            this.lblNroAfiliado.Location = new System.Drawing.Point(18, 25);
            this.lblNroAfiliado.Name = "lblNroAfiliado";
            this.lblNroAfiliado.Size = new System.Drawing.Size(67, 13);
            this.lblNroAfiliado.TabIndex = 0;
            this.lblNroAfiliado.Text = "Nro. Afiliado:";
            // 
            // gbBonosConsulta
            // 
            this.gbBonosConsulta.Controls.Add(this.txtCantBonosConsulta);
            this.gbBonosConsulta.Controls.Add(this.lblCantBonosConsulta);
            this.gbBonosConsulta.Location = new System.Drawing.Point(13, 78);
            this.gbBonosConsulta.Name = "gbBonosConsulta";
            this.gbBonosConsulta.Size = new System.Drawing.Size(294, 65);
            this.gbBonosConsulta.TabIndex = 1;
            this.gbBonosConsulta.TabStop = false;
            this.gbBonosConsulta.Text = "Bonos Consulta";
            // 
            // txtCantBonosConsulta
            // 
            this.txtCantBonosConsulta.Enabled = false;
            this.txtCantBonosConsulta.Location = new System.Drawing.Point(76, 23);
            this.txtCantBonosConsulta.Name = "txtCantBonosConsulta";
            this.txtCantBonosConsulta.Size = new System.Drawing.Size(82, 20);
            this.txtCantBonosConsulta.TabIndex = 1;
            this.txtCantBonosConsulta.Leave += new System.EventHandler(this.txtCantBonosConsulta_Leave);
            this.txtCantBonosConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantBonosConsulta_KeyPress);
            // 
            // lblCantBonosConsulta
            // 
            this.lblCantBonosConsulta.AutoSize = true;
            this.lblCantBonosConsulta.Location = new System.Drawing.Point(18, 26);
            this.lblCantBonosConsulta.Name = "lblCantBonosConsulta";
            this.lblCantBonosConsulta.Size = new System.Drawing.Size(52, 13);
            this.lblCantBonosConsulta.TabIndex = 0;
            this.lblCantBonosConsulta.Text = "Cantidad:";
            // 
            // gbBonosFarmacia
            // 
            this.gbBonosFarmacia.Controls.Add(this.txtCantBonosFarmacia);
            this.gbBonosFarmacia.Controls.Add(this.lblCantBonosFarmacia);
            this.gbBonosFarmacia.Location = new System.Drawing.Point(313, 78);
            this.gbBonosFarmacia.Name = "gbBonosFarmacia";
            this.gbBonosFarmacia.Size = new System.Drawing.Size(319, 66);
            this.gbBonosFarmacia.TabIndex = 2;
            this.gbBonosFarmacia.TabStop = false;
            this.gbBonosFarmacia.Text = "Bonos Farmacia";
            // 
            // txtCantBonosFarmacia
            // 
            this.txtCantBonosFarmacia.Enabled = false;
            this.txtCantBonosFarmacia.Location = new System.Drawing.Point(76, 25);
            this.txtCantBonosFarmacia.Name = "txtCantBonosFarmacia";
            this.txtCantBonosFarmacia.Size = new System.Drawing.Size(82, 20);
            this.txtCantBonosFarmacia.TabIndex = 2;
            this.txtCantBonosFarmacia.Leave += new System.EventHandler(this.txtCantBonosFarmacia_Leave);
            this.txtCantBonosFarmacia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantBonosFarmacia_KeyPress);
            // 
            // lblCantBonosFarmacia
            // 
            this.lblCantBonosFarmacia.AutoSize = true;
            this.lblCantBonosFarmacia.Location = new System.Drawing.Point(18, 28);
            this.lblCantBonosFarmacia.Name = "lblCantBonosFarmacia";
            this.lblCantBonosFarmacia.Size = new System.Drawing.Size(52, 13);
            this.lblCantBonosFarmacia.TabIndex = 1;
            this.lblCantBonosFarmacia.Text = "Cantidad:";
            // 
            // gbTotal
            // 
            this.gbTotal.Controls.Add(this.lblTotGral);
            this.gbTotal.Controls.Add(this.lblTotBonosFarm);
            this.gbTotal.Controls.Add(this.lblTotBonosCon);
            this.gbTotal.Location = new System.Drawing.Point(12, 150);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.Size = new System.Drawing.Size(619, 56);
            this.gbTotal.TabIndex = 3;
            this.gbTotal.TabStop = false;
            this.gbTotal.Text = "Totales";
            // 
            // lblTotGral
            // 
            this.lblTotGral.AutoSize = true;
            this.lblTotGral.Location = new System.Drawing.Point(439, 28);
            this.lblTotGral.Name = "lblTotGral";
            this.lblTotGral.Size = new System.Drawing.Size(74, 13);
            this.lblTotGral.TabIndex = 2;
            this.lblTotGral.Text = "Total General:";
            // 
            // lblTotBonosFarm
            // 
            this.lblTotBonosFarm.AutoSize = true;
            this.lblTotBonosFarm.Location = new System.Drawing.Point(223, 28);
            this.lblTotBonosFarm.Name = "lblTotBonosFarm";
            this.lblTotBonosFarm.Size = new System.Drawing.Size(113, 13);
            this.lblTotBonosFarm.TabIndex = 1;
            this.lblTotBonosFarm.Text = "Total Bonos Farmacia:";
            // 
            // lblTotBonosCon
            // 
            this.lblTotBonosCon.AutoSize = true;
            this.lblTotBonosCon.Location = new System.Drawing.Point(18, 28);
            this.lblTotBonosCon.Name = "lblTotBonosCon";
            this.lblTotBonosCon.Size = new System.Drawing.Size(111, 13);
            this.lblTotBonosCon.TabIndex = 0;
            this.lblTotBonosCon.Text = "Total Bonos Consulta:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(655, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(655, 38);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CompraBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 233);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbTotal);
            this.Controls.Add(this.gbBonosFarmacia);
            this.Controls.Add(this.gbBonosConsulta);
            this.Controls.Add(this.gbCompraBono);
            this.Name = "CompraBonos";
            this.Text = "Clínica FRBA: Compra de Bonos";
            this.Load += new System.EventHandler(this.CompraBonos_Load);
            this.gbCompraBono.ResumeLayout(false);
            this.gbCompraBono.PerformLayout();
            this.gbBonosConsulta.ResumeLayout(false);
            this.gbBonosConsulta.PerformLayout();
            this.gbBonosFarmacia.ResumeLayout(false);
            this.gbBonosFarmacia.PerformLayout();
            this.gbTotal.ResumeLayout(false);
            this.gbTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompraBono;
        private System.Windows.Forms.Label lblNroAfiliado;
        private System.Windows.Forms.Button btnValidarAfiliado;
        private System.Windows.Forms.TextBox txtNroAfiliado;
        private System.Windows.Forms.Label lblDatosAfiliado;
        private System.Windows.Forms.GroupBox gbBonosConsulta;
        private System.Windows.Forms.GroupBox gbBonosFarmacia;
        private System.Windows.Forms.GroupBox gbTotal;
        private System.Windows.Forms.Label lblTotBonosFarm;
        private System.Windows.Forms.Label lblTotBonosCon;
        private System.Windows.Forms.Label lblTotGral;
        private System.Windows.Forms.Label lblCantBonosConsulta;
        private System.Windows.Forms.Label lblCantBonosFarmacia;
        private System.Windows.Forms.TextBox txtCantBonosConsulta;
        private System.Windows.Forms.TextBox txtCantBonosFarmacia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}