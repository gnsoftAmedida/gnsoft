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
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUtilidades = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAporte = new System.Windows.Forms.Label();
            this.lblAp = new System.Windows.Forms.Label();
            this.btnImprimirRecibo = new System.Windows.Forms.Button();
            this.btnSalirLiqUtil = new System.Windows.Forms.Button();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNroSocio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCesion = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNombresApellidos = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFechaIngresoSocio = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblUtilidades);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblAporte);
            this.groupBox2.Controls.Add(this.lblAp);
            this.groupBox2.Location = new System.Drawing.Point(18, 387);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(584, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total de Utilidades sin liquidar";
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
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(423, 61);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(16, 13);
            this.lblTotal.TabIndex = 47;
            this.lblTotal.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(303, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Total a Pagar $";
            // 
            // lblUtilidades
            // 
            this.lblUtilidades.AutoSize = true;
            this.lblUtilidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUtilidades.Location = new System.Drawing.Point(423, 34);
            this.lblUtilidades.Name = "lblUtilidades";
            this.lblUtilidades.Size = new System.Drawing.Size(16, 13);
            this.lblUtilidades.TabIndex = 45;
            this.lblUtilidades.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(321, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Utilidades $";
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
            // lblAporte
            // 
            this.lblAporte.AutoSize = true;
            this.lblAporte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAporte.Location = new System.Drawing.Point(168, 34);
            this.lblAporte.Name = "lblAporte";
            this.lblAporte.Size = new System.Drawing.Size(16, 13);
            this.lblAporte.TabIndex = 42;
            this.lblAporte.Text = "...";
            // 
            // lblAp
            // 
            this.lblAp.AutoSize = true;
            this.lblAp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAp.Location = new System.Drawing.Point(66, 34);
            this.lblAp.Name = "lblAp";
            this.lblAp.Size = new System.Drawing.Size(82, 13);
            this.lblAp.TabIndex = 41;
            this.lblAp.Text = "Aporte Capital $";
            // 
            // btnImprimirRecibo
            // 
            this.btnImprimirRecibo.Enabled = false;
            this.btnImprimirRecibo.Image = global::COOPMEF.Properties.Resources.print;
            this.btnImprimirRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimirRecibo.Location = new System.Drawing.Point(17, 192);
            this.btnImprimirRecibo.Name = "btnImprimirRecibo";
            this.btnImprimirRecibo.Size = new System.Drawing.Size(84, 35);
            this.btnImprimirRecibo.TabIndex = 25;
            this.btnImprimirRecibo.Text = "     Imprimir";
            this.btnImprimirRecibo.UseVisualStyleBackColor = true;
            this.btnImprimirRecibo.Click += new System.EventHandler(this.btnImprimirRecibo_Click);
            // 
            // btnSalirLiqUtil
            // 
            this.btnSalirLiqUtil.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirLiqUtil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirLiqUtil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirLiqUtil.Location = new System.Drawing.Point(17, 233);
            this.btnSalirLiqUtil.Name = "btnSalirLiqUtil";
            this.btnSalirLiqUtil.Size = new System.Drawing.Size(84, 35);
            this.btnSalirLiqUtil.TabIndex = 24;
            this.btnSalirLiqUtil.Text = "Salir";
            this.btnSalirLiqUtil.UseVisualStyleBackColor = true;
            this.btnSalirLiqUtil.Click += new System.EventHandler(this.btnSalirLiqUtil_Click);
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Image = global::COOPMEF.Properties.Resources._1486108159_document_edit;
            this.btnLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiquidar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLiquidar.Location = new System.Drawing.Point(17, 151);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(85, 35);
            this.btnLiquidar.TabIndex = 23;
            this.btnLiquidar.Text = "      Liquidación";
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nro Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(8, 32);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.btnSalirLiqUtil);
            this.groupBox5.Controls.Add(this.btnImprimirRecibo);
            this.groupBox5.Controls.Add(this.btnLiquidar);
            this.groupBox5.Location = new System.Drawing.Point(626, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(122, 303);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtpFechaPago);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Location = new System.Drawing.Point(9, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(105, 60);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Checked = false;
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(12, 34);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(82, 20);
            this.dtpFechaPago.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Fecha";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtNroCheque);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(10, 75);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(104, 62);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(569, 11);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(171, 20);
            this.txtUsuario.TabIndex = 27;
            // 
            // frmLiquidacionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 513);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
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
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDetalleUtilidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImprimirRecibo;
        private System.Windows.Forms.Button btnSalirLiqUtil;
        private System.Windows.Forms.Button btnLiquidar;
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
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUtilidades;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAporte;
        private System.Windows.Forms.Label lblAp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
    }
}