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
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNroSocio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFechaIngresoSocio = new System.Windows.Forms.Label();
            this.lblNombresApellidos = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCesion = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalleUtilidades);
            this.groupBox1.Location = new System.Drawing.Point(18, 198);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(584, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Utilidades liquidadas y no liquidadas";
            // 
            // dgvDetalleUtilidades
            // 
            this.dgvDetalleUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleUtilidades.Location = new System.Drawing.Point(14, 24);
            this.dgvDetalleUtilidades.Name = "dgvDetalleUtilidades";
            this.dgvDetalleUtilidades.Size = new System.Drawing.Size(555, 138);
            this.dgvDetalleUtilidades.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(18, 387);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(584, 100);
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
            this.btnImprimirRecibo.Location = new System.Drawing.Point(15, 100);
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
            this.btnSalirLiqUtil.Location = new System.Drawing.Point(14, 143);
            this.btnSalirLiqUtil.Name = "btnSalirLiqUtil";
            this.btnSalirLiqUtil.Size = new System.Drawing.Size(84, 35);
            this.btnSalirLiqUtil.TabIndex = 24;
            this.btnSalirLiqUtil.Text = "Salir";
            this.btnSalirLiqUtil.UseVisualStyleBackColor = true;
            this.btnSalirLiqUtil.Click += new System.EventHandler(this.btnSalirLiqUtil_Click);
            // 
            // btnCancelarPrestamo
            // 
            this.btnCancelarPrestamo.Image = global::COOPMEF.Properties.Resources._1486108159_document_edit;
            this.btnCancelarPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarPrestamo.Location = new System.Drawing.Point(14, 57);
            this.btnCancelarPrestamo.Name = "btnCancelarPrestamo";
            this.btnCancelarPrestamo.Size = new System.Drawing.Size(85, 35);
            this.btnCancelarPrestamo.TabIndex = 23;
            this.btnCancelarPrestamo.Text = "      Liquidación";
            this.btnCancelarPrestamo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nro Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(14, 33);
            this.txtNroCheque.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(85, 20);
            this.txtNroCheque.TabIndex = 27;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(72, 18);
            this.txtCedula.Mask = "0.000.000-0";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(88, 20);
            this.txtCedula.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(61, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Dirección:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(11, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "Cesión de Derechos:";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblApellidos.Location = new System.Drawing.Point(17, 28);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(100, 13);
            this.lblApellidos.TabIndex = 28;
            this.lblApellidos.Text = "Apellidos, Nombres:";
            // 
            // lblNroSocio
            // 
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNroSocio.Location = new System.Drawing.Point(26, 21);
            this.lblNroSocio.Name = "lblNroSocio";
            this.lblNroSocio.Size = new System.Drawing.Size(40, 13);
            this.lblNroSocio.TabIndex = 30;
            this.lblNroSocio.Text = "Cédula";
            this.lblNroSocio.Click += new System.EventHandler(this.lblNroSocio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCesion);
            this.groupBox3.Controls.Add(this.lblDireccion);
            this.groupBox3.Controls.Add(this.lblNombresApellidos);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblFechaIngresoSocio);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.lblApellidos);
            this.groupBox3.Location = new System.Drawing.Point(18, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 122);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Cooperativista";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(24, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Fecha de ingreso:";
            // 
            // lblFechaIngresoSocio
            // 
            this.lblFechaIngresoSocio.AutoSize = true;
            this.lblFechaIngresoSocio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFechaIngresoSocio.Location = new System.Drawing.Point(119, 98);
            this.lblFechaIngresoSocio.Name = "lblFechaIngresoSocio";
            this.lblFechaIngresoSocio.Size = new System.Drawing.Size(16, 13);
            this.lblFechaIngresoSocio.TabIndex = 38;
            this.lblFechaIngresoSocio.Text = "...";
            // 
            // lblNombresApellidos
            // 
            this.lblNombresApellidos.AutoSize = true;
            this.lblNombresApellidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombresApellidos.Location = new System.Drawing.Point(119, 28);
            this.lblNombresApellidos.Name = "lblNombresApellidos";
            this.lblNombresApellidos.Size = new System.Drawing.Size(16, 13);
            this.lblNombresApellidos.TabIndex = 40;
            this.lblNombresApellidos.Text = "...";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDireccion.Location = new System.Drawing.Point(119, 50);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(16, 13);
            this.lblDireccion.TabIndex = 41;
            this.lblDireccion.Text = "...";
            // 
            // lblCesion
            // 
            this.lblCesion.AutoSize = true;
            this.lblCesion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCesion.Location = new System.Drawing.Point(119, 75);
            this.lblCesion.Name = "lblCesion";
            this.lblCesion.Size = new System.Drawing.Size(16, 13);
            this.lblCesion.TabIndex = 42;
            this.lblCesion.Text = "...";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.Image = global::COOPMEF.Properties.Resources._1486108741_Search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(166, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 43;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscar);
            this.groupBox4.Controls.Add(this.txtCedula);
            this.groupBox4.Controls.Add(this.lblNroSocio);
            this.groupBox4.Location = new System.Drawing.Point(18, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 53);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Búsqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(168, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(66, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Aporte Capital $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(26, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Gastos Administrativos $";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(423, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(321, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Aporte Capital $";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(423, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(321, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Total a Pagar $";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(168, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "...";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSalirLiqUtil);
            this.groupBox5.Controls.Add(this.txtNroCheque);
            this.groupBox5.Controls.Add(this.btnImprimirRecibo);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnCancelarPrestamo);
            this.groupBox5.Location = new System.Drawing.Point(626, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(113, 190);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            // 
            // frmLiquidacionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 513);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLiquidacionDeUtilidades";
            this.Text = "Liquidación de Utilidades";
            this.Load += new System.EventHandler(this.frmLiquidacionDeUtilidades_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNroSocio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFechaIngresoSocio;
        private System.Windows.Forms.Label lblCesion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNombresApellidos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}