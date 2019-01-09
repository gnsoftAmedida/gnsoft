namespace COOPMEF
{
    partial class frmMovimientosBancarios
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
            this.cmbBancos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtDeposito = new System.Windows.Forms.RadioButton();
            this.rbtCheque = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNumeroComprobante = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblErrorGenerico = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.lblImporteBanco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnSalirBanco = new System.Windows.Forms.Button();
            this.btnGuardarBanco = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBancos
            // 
            this.cmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBancos.FormattingEnabled = true;
            this.cmbBancos.Location = new System.Drawing.Point(25, 40);
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.Size = new System.Drawing.Size(302, 24);
            this.cmbBancos.TabIndex = 0;
            this.cmbBancos.SelectedIndexChanged += new System.EventHandler(this.cmbBancos_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBancos);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(20, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(352, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bancos y Números de Cuentas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSaldoActual);
            this.groupBox2.Location = new System.Drawing.Point(25, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(150, 72);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldo Actual";
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Location = new System.Drawing.Point(57, 32);
            this.lblSaldoActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(36, 17);
            this.lblSaldoActual.TabIndex = 0;
            this.lblSaldoActual.Text = "0,00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtDeposito);
            this.groupBox3.Controls.Add(this.rbtCheque);
            this.groupBox3.Location = new System.Drawing.Point(25, 156);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(194, 81);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo Movimiento";
            // 
            // rbtDeposito
            // 
            this.rbtDeposito.AutoSize = true;
            this.rbtDeposito.Location = new System.Drawing.Point(108, 37);
            this.rbtDeposito.Margin = new System.Windows.Forms.Padding(2);
            this.rbtDeposito.Name = "rbtDeposito";
            this.rbtDeposito.Size = new System.Drawing.Size(82, 21);
            this.rbtDeposito.TabIndex = 1;
            this.rbtDeposito.TabStop = true;
            this.rbtDeposito.Text = "Depósito";
            this.rbtDeposito.UseVisualStyleBackColor = true;
            // 
            // rbtCheque
            // 
            this.rbtCheque.AutoSize = true;
            this.rbtCheque.Location = new System.Drawing.Point(23, 37);
            this.rbtCheque.Margin = new System.Windows.Forms.Padding(2);
            this.rbtCheque.Name = "rbtCheque";
            this.rbtCheque.Size = new System.Drawing.Size(75, 21);
            this.rbtCheque.TabIndex = 0;
            this.rbtCheque.TabStop = true;
            this.rbtCheque.Text = "Cheque";
            this.rbtCheque.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumeroComprobante);
            this.groupBox4.Location = new System.Drawing.Point(276, 156);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(135, 81);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nº Comprobante";
            // 
            // txtNumeroComprobante
            // 
            this.txtNumeroComprobante.Location = new System.Drawing.Point(16, 37);
            this.txtNumeroComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroComprobante.MaxLength = 100;
            this.txtNumeroComprobante.Name = "txtNumeroComprobante";
            this.txtNumeroComprobante.Size = new System.Drawing.Size(105, 23);
            this.txtNumeroComprobante.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblErrorGenerico);
            this.groupBox5.Controls.Add(this.lblComprobante);
            this.groupBox5.Controls.Add(this.lblConcepto);
            this.groupBox5.Controls.Add(this.lblImporteBanco);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtConcepto);
            this.groupBox5.Controls.Add(this.txtImporte);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(20, 119);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(484, 277);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles";
            // 
            // lblErrorGenerico
            // 
            this.lblErrorGenerico.AutoSize = true;
            this.lblErrorGenerico.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorGenerico.ForeColor = System.Drawing.Color.Red;
            this.lblErrorGenerico.Location = new System.Drawing.Point(22, 252);
            this.lblErrorGenerico.Name = "lblErrorGenerico";
            this.lblErrorGenerico.Size = new System.Drawing.Size(39, 12);
            this.lblErrorGenerico.TabIndex = 32;
            this.lblErrorGenerico.Text = "label2";
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.ForeColor = System.Drawing.Color.Red;
            this.lblComprobante.Location = new System.Drawing.Point(416, 224);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(39, 12);
            this.lblComprobante.TabIndex = 31;
            this.lblComprobante.Text = "label2";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcepto.ForeColor = System.Drawing.Color.Red;
            this.lblConcepto.Location = new System.Drawing.Point(416, 121);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(39, 12);
            this.lblConcepto.TabIndex = 31;
            this.lblConcepto.Text = "label2";
            // 
            // lblImporteBanco
            // 
            this.lblImporteBanco.AutoSize = true;
            this.lblImporteBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteBanco.ForeColor = System.Drawing.Color.Red;
            this.lblImporteBanco.Location = new System.Drawing.Point(416, 41);
            this.lblImporteBanco.Name = "lblImporteBanco";
            this.lblImporteBanco.Size = new System.Drawing.Size(39, 12);
            this.lblImporteBanco.TabIndex = 31;
            this.lblImporteBanco.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 51);
            this.label3.TabIndex = 7;
            this.label3.Text = " Concepto\r\n      del\r\nMovimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Importe";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(276, 65);
            this.txtConcepto.Margin = new System.Windows.Forms.Padding(2);
            this.txtConcepto.MaxLength = 250;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(136, 70);
            this.txtConcepto.TabIndex = 1;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(276, 32);
            this.txtImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txtImporte.MaxLength = 100;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(136, 23);
            this.txtImporte.TabIndex = 0;
            // 
            // btnSalirBanco
            // 
            this.btnSalirBanco.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirBanco.Location = new System.Drawing.Point(407, 66);
            this.btnSalirBanco.Name = "btnSalirBanco";
            this.btnSalirBanco.Size = new System.Drawing.Size(96, 29);
            this.btnSalirBanco.TabIndex = 3;
            this.btnSalirBanco.Text = "     Salir";
            this.btnSalirBanco.UseVisualStyleBackColor = true;
            this.btnSalirBanco.Click += new System.EventHandler(this.btnSalirBanco_Click);
            // 
            // btnGuardarBanco
            // 
            this.btnGuardarBanco.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarBanco.Location = new System.Drawing.Point(407, 18);
            this.btnGuardarBanco.Name = "btnGuardarBanco";
            this.btnGuardarBanco.Size = new System.Drawing.Size(96, 31);
            this.btnGuardarBanco.TabIndex = 2;
            this.btnGuardarBanco.Text = "     Guardar";
            this.btnGuardarBanco.UseVisualStyleBackColor = true;
            this.btnGuardarBanco.Click += new System.EventHandler(this.btnGuardarBanco_Click);
            // 
            // frmMovimientosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 410);
            this.Controls.Add(this.btnSalirBanco);
            this.Controls.Add(this.btnGuardarBanco);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMovimientosBancarios";
            this.Text = "Movimientos Bancarios - Cheques";
            this.Load += new System.EventHandler(this.frmMovimientosBancarios_Load);
            this.groupBox1.ResumeLayout(false);
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

        private System.Windows.Forms.ComboBox cmbBancos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.RadioButton rbtDeposito;
        private System.Windows.Forms.RadioButton rbtCheque;
        private System.Windows.Forms.TextBox txtNumeroComprobante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Button btnSalirBanco;
        private System.Windows.Forms.Button btnGuardarBanco;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.Label lblImporteBanco;
        private System.Windows.Forms.Label lblErrorGenerico;
    }
}