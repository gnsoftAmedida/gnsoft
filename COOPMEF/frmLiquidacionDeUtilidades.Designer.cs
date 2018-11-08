namespace COOPMEF
{
    partial class frmLiquidacionDeUtilidades
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
            this.dgvDetalleUtilidades = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimirRecibo = new System.Windows.Forms.Button();
            this.btnSalirLiqUtil = new System.Windows.Forms.Button();
            this.btnCancelarPrestamo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCesion = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNroSocio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFechaIngresoSocio = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalleUtilidades);
            this.groupBox1.Location = new System.Drawing.Point(11, 160);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(439, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Utilidades liquidadas y no liquidadas";
            // 
            // dgvDetalleUtilidades
            // 
            this.dgvDetalleUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleUtilidades.Location = new System.Drawing.Point(5, 25);
            this.dgvDetalleUtilidades.Name = "dgvDetalleUtilidades";
            this.dgvDetalleUtilidades.Size = new System.Drawing.Size(345, 138);
            this.dgvDetalleUtilidades.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(11, 341);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(356, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total de Utilidades sin liquidar";
            // 
            // btnImprimirRecibo
            // 
            this.btnImprimirRecibo.Enabled = false;
            this.btnImprimirRecibo.Image = global::COOPMEF.Properties.Resources.print;
            this.btnImprimirRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimirRecibo.Location = new System.Drawing.Point(468, 244);
            this.btnImprimirRecibo.Name = "btnImprimirRecibo";
            this.btnImprimirRecibo.Size = new System.Drawing.Size(84, 35);
            this.btnImprimirRecibo.TabIndex = 25;
            this.btnImprimirRecibo.Text = "     Imprimir";
            this.btnImprimirRecibo.UseVisualStyleBackColor = true;
            // 
            // btnSalirLiqUtil
            // 
            this.btnSalirLiqUtil.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirLiqUtil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirLiqUtil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirLiqUtil.Location = new System.Drawing.Point(467, 287);
            this.btnSalirLiqUtil.Name = "btnSalirLiqUtil";
            this.btnSalirLiqUtil.Size = new System.Drawing.Size(84, 35);
            this.btnSalirLiqUtil.TabIndex = 24;
            this.btnSalirLiqUtil.Text = "Salir";
            this.btnSalirLiqUtil.UseVisualStyleBackColor = true;
            // 
            // btnCancelarPrestamo
            // 
            this.btnCancelarPrestamo.Image = global::COOPMEF.Properties.Resources._1486108159_document_edit;
            this.btnCancelarPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarPrestamo.Location = new System.Drawing.Point(467, 201);
            this.btnCancelarPrestamo.Name = "btnCancelarPrestamo";
            this.btnCancelarPrestamo.Size = new System.Drawing.Size(85, 35);
            this.btnCancelarPrestamo.TabIndex = 23;
            this.btnCancelarPrestamo.Text = "      Liquidación";
            this.btnCancelarPrestamo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nro Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(467, 177);
            this.txtNroCheque.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(85, 20);
            this.txtNroCheque.TabIndex = 27;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(122, 26);
            this.txtCedula.Mask = "0.000.000-0";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(88, 20);
            this.txtCedula.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(64, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Dirección";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(11, 111);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(103, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "Cesión de Derechos";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(122, 78);
            this.txtDireccion.MaxLength = 44;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(406, 20);
            this.txtDireccion.TabIndex = 35;
            // 
            // txtCesion
            // 
            this.txtCesion.Location = new System.Drawing.Point(120, 104);
            this.txtCesion.MaxLength = 44;
            this.txtCesion.Name = "txtCesion";
            this.txtCesion.Size = new System.Drawing.Size(408, 20);
            this.txtCesion.TabIndex = 36;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(122, 52);
            this.txtNombres.MaxLength = 44;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(406, 20);
            this.txtNombres.TabIndex = 32;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblApellidos.Location = new System.Drawing.Point(19, 55);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(97, 13);
            this.lblApellidos.TabIndex = 28;
            this.lblApellidos.Text = "Apellidos, Nombres";
            // 
            // lblNroSocio
            // 
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNroSocio.Location = new System.Drawing.Point(76, 29);
            this.lblNroSocio.Name = "lblNroSocio";
            this.lblNroSocio.Size = new System.Drawing.Size(40, 13);
            this.lblNroSocio.TabIndex = 30;
            this.lblNroSocio.Text = "Cédula";
            this.lblNroSocio.Click += new System.EventHandler(this.lblNroSocio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblFechaIngresoSocio);
            this.groupBox3.Controls.Add(this.txtCedula);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtDireccion);
            this.groupBox3.Controls.Add(this.txtCesion);
            this.groupBox3.Controls.Add(this.txtNombres);
            this.groupBox3.Controls.Add(this.lblApellidos);
            this.groupBox3.Controls.Add(this.lblNroSocio);
            this.groupBox3.Location = new System.Drawing.Point(11, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 138);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cooperativista";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(232, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Fecha de ingreso";
            // 
            // lblFechaIngresoSocio
            // 
            this.lblFechaIngresoSocio.AutoSize = true;
            this.lblFechaIngresoSocio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFechaIngresoSocio.Location = new System.Drawing.Point(327, 29);
            this.lblFechaIngresoSocio.Name = "lblFechaIngresoSocio";
            this.lblFechaIngresoSocio.Size = new System.Drawing.Size(16, 13);
            this.lblFechaIngresoSocio.TabIndex = 38;
            this.lblFechaIngresoSocio.Text = "...";
            // 
            // frmLiquidacionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 435);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSalirLiqUtil);
            this.Controls.Add(this.txtNroCheque);
            this.Controls.Add(this.btnImprimirRecibo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarPrestamo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLiquidacionDeUtilidades";
            this.Text = "Liquidación de Utilidades";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDetalleUtilidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImprimirRecibo;
        private System.Windows.Forms.Button btnSalirLiqUtil;
        private System.Windows.Forms.Button btnCancelarPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroCheque;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCesion;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNroSocio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFechaIngresoSocio;
    }
}