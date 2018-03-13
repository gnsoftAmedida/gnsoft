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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSalirBanco = new System.Windows.Forms.Button();
            this.btnGuardarBanco = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroComprobante = new System.Windows.Forms.TextBox();
            this.rbtCheque = new System.Windows.Forms.RadioButton();
            this.rbtDeposito = new System.Windows.Forms.RadioButton();
            this.lblImporteBanco = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblErrorGenerico = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBancos
            // 
            this.cmbBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBancos.FormattingEnabled = true;
            this.cmbBancos.Location = new System.Drawing.Point(33, 49);
            this.cmbBancos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.Size = new System.Drawing.Size(402, 28);
            this.cmbBancos.TabIndex = 1;
            this.cmbBancos.SelectedIndexChanged += new System.EventHandler(this.cmbBancos_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBancos);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 116);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bancos y Números de Cuentas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSaldoActual);
            this.groupBox2.Location = new System.Drawing.Point(33, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 89);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saldo Actual";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtDeposito);
            this.groupBox3.Controls.Add(this.rbtCheque);
            this.groupBox3.Location = new System.Drawing.Point(33, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo Movimiento";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumeroComprobante);
            this.groupBox4.Location = new System.Drawing.Point(368, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nº Comprobante";
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
            this.groupBox5.Location = new System.Drawing.Point(26, 146);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(645, 341);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalles";
            // 
            // btnSalirBanco
            // 
            this.btnSalirBanco.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirBanco.Location = new System.Drawing.Point(543, 81);
            this.btnSalirBanco.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirBanco.Name = "btnSalirBanco";
            this.btnSalirBanco.Size = new System.Drawing.Size(128, 36);
            this.btnSalirBanco.TabIndex = 16;
            this.btnSalirBanco.Text = "     Salir";
            this.btnSalirBanco.UseVisualStyleBackColor = true;
            this.btnSalirBanco.Click += new System.EventHandler(this.btnSalirBanco_Click);
            // 
            // btnGuardarBanco
            // 
            this.btnGuardarBanco.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarBanco.Location = new System.Drawing.Point(543, 22);
            this.btnGuardarBanco.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarBanco.Name = "btnGuardarBanco";
            this.btnGuardarBanco.Size = new System.Drawing.Size(128, 38);
            this.btnGuardarBanco.TabIndex = 15;
            this.btnGuardarBanco.Text = "     Guardar";
            this.btnGuardarBanco.UseVisualStyleBackColor = true;
            this.btnGuardarBanco.Click += new System.EventHandler(this.btnGuardarBanco_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(368, 40);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(180, 27);
            this.txtImporte.TabIndex = 5;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(368, 80);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(180, 85);
            this.txtConcepto.TabIndex = 5;
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Location = new System.Drawing.Point(99, 40);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(40, 20);
            this.lblSaldoActual.TabIndex = 0;
            this.lblSaldoActual.Text = "0,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Importe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 60);
            this.label3.TabIndex = 7;
            this.label3.Text = " Concepto\r\n      del\r\nMovimiento";
            // 
            // txtNumeroComprobante
            // 
            this.txtNumeroComprobante.Location = new System.Drawing.Point(22, 45);
            this.txtNumeroComprobante.Name = "txtNumeroComprobante";
            this.txtNumeroComprobante.Size = new System.Drawing.Size(139, 27);
            this.txtNumeroComprobante.TabIndex = 5;
            // 
            // rbtCheque
            // 
            this.rbtCheque.AutoSize = true;
            this.rbtCheque.Location = new System.Drawing.Point(31, 45);
            this.rbtCheque.Name = "rbtCheque";
            this.rbtCheque.Size = new System.Drawing.Size(87, 24);
            this.rbtCheque.TabIndex = 0;
            this.rbtCheque.TabStop = true;
            this.rbtCheque.Text = "Cheque";
            this.rbtCheque.UseVisualStyleBackColor = true;
            // 
            // rbtDeposito
            // 
            this.rbtDeposito.AutoSize = true;
            this.rbtDeposito.Location = new System.Drawing.Point(144, 45);
            this.rbtDeposito.Name = "rbtDeposito";
            this.rbtDeposito.Size = new System.Drawing.Size(97, 24);
            this.rbtDeposito.TabIndex = 1;
            this.rbtDeposito.TabStop = true;
            this.rbtDeposito.Text = "Depósito";
            this.rbtDeposito.UseVisualStyleBackColor = true;
            // 
            // lblImporteBanco
            // 
            this.lblImporteBanco.AutoSize = true;
            this.lblImporteBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteBanco.ForeColor = System.Drawing.Color.Red;
            this.lblImporteBanco.Location = new System.Drawing.Point(555, 51);
            this.lblImporteBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImporteBanco.Name = "lblImporteBanco";
            this.lblImporteBanco.Size = new System.Drawing.Size(49, 16);
            this.lblImporteBanco.TabIndex = 31;
            this.lblImporteBanco.Text = "label2";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcepto.ForeColor = System.Drawing.Color.Red;
            this.lblConcepto.Location = new System.Drawing.Point(555, 149);
            this.lblConcepto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(49, 16);
            this.lblConcepto.TabIndex = 31;
            this.lblConcepto.Text = "label2";
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.ForeColor = System.Drawing.Color.Red;
            this.lblComprobante.Location = new System.Drawing.Point(555, 276);
            this.lblComprobante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(49, 16);
            this.lblComprobante.TabIndex = 31;
            this.lblComprobante.Text = "label2";
            // 
            // lblErrorGenerico
            // 
            this.lblErrorGenerico.AutoSize = true;
            this.lblErrorGenerico.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorGenerico.ForeColor = System.Drawing.Color.Red;
            this.lblErrorGenerico.Location = new System.Drawing.Point(30, 310);
            this.lblErrorGenerico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorGenerico.Name = "lblErrorGenerico";
            this.lblErrorGenerico.Size = new System.Drawing.Size(49, 16);
            this.lblErrorGenerico.TabIndex = 32;
            this.lblErrorGenerico.Text = "label2";
            // 
            // frmMovimientosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 505);
            this.Controls.Add(this.btnSalirBanco);
            this.Controls.Add(this.btnGuardarBanco);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
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