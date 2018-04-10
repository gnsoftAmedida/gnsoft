namespace COOPMEF
{
    partial class frmCompracionDeTasas
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
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.txtTotalAPagar = new System.Windows.Forms.TextBox();
            this.txtMontoCuota = new System.Windows.Forms.TextBox();
            this.txtCantCuotas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTasaCoop = new System.Windows.Forms.TextBox();
            this.txtTasaCoop2 = new System.Windows.Forms.TextBox();
            this.txtTotalAPagarCoop = new System.Windows.Forms.TextBox();
            this.txtMontoCuotaCoop = new System.Windows.Forms.TextBox();
            this.btnSalirComparacion = new System.Windows.Forms.Button();
            this.btnCalcularComparacion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCantCuotas);
            this.groupBox1.Controls.Add(this.txtMontoCuota);
            this.groupBox1.Controls.Add(this.txtTotalAPagar);
            this.groupBox1.Controls.Add(this.txtTasa);
            this.groupBox1.Controls.Add(this.txtMonto);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mercado";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(199, 47);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(84, 22);
            this.txtMonto.TabIndex = 0;
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(199, 159);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(84, 22);
            this.txtTasa.TabIndex = 1;
            // 
            // txtTotalAPagar
            // 
            this.txtTotalAPagar.Location = new System.Drawing.Point(199, 131);
            this.txtTotalAPagar.Name = "txtTotalAPagar";
            this.txtTotalAPagar.Size = new System.Drawing.Size(84, 22);
            this.txtTotalAPagar.TabIndex = 2;
            // 
            // txtMontoCuota
            // 
            this.txtMontoCuota.Location = new System.Drawing.Point(199, 103);
            this.txtMontoCuota.Name = "txtMontoCuota";
            this.txtMontoCuota.Size = new System.Drawing.Size(84, 22);
            this.txtMontoCuota.TabIndex = 3;
            // 
            // txtCantCuotas
            // 
            this.txtCantCuotas.Location = new System.Drawing.Point(199, 75);
            this.txtCantCuotas.Name = "txtCantCuotas";
            this.txtCantCuotas.Size = new System.Drawing.Size(84, 22);
            this.txtCantCuotas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Monto del préstamo $";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tasa efectiva anual %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total a pagar $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Monto de la cuota $";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cantidad de cuotas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMontoCuotaCoop);
            this.groupBox2.Controls.Add(this.txtTotalAPagarCoop);
            this.groupBox2.Controls.Add(this.txtTasaCoop2);
            this.groupBox2.Controls.Add(this.txtTasaCoop);
            this.groupBox2.Location = new System.Drawing.Point(320, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cooperativa";
            // 
            // txtTasaCoop
            // 
            this.txtTasaCoop.Location = new System.Drawing.Point(10, 97);
            this.txtTasaCoop.Name = "txtTasaCoop";
            this.txtTasaCoop.Size = new System.Drawing.Size(61, 22);
            this.txtTasaCoop.TabIndex = 2;
            // 
            // txtTasaCoop2
            // 
            this.txtTasaCoop2.Location = new System.Drawing.Point(77, 97);
            this.txtTasaCoop2.Name = "txtTasaCoop2";
            this.txtTasaCoop2.Size = new System.Drawing.Size(40, 22);
            this.txtTasaCoop2.TabIndex = 3;
            // 
            // txtTotalAPagarCoop
            // 
            this.txtTotalAPagarCoop.Location = new System.Drawing.Point(10, 69);
            this.txtTotalAPagarCoop.Name = "txtTotalAPagarCoop";
            this.txtTotalAPagarCoop.Size = new System.Drawing.Size(107, 22);
            this.txtTotalAPagarCoop.TabIndex = 4;
            // 
            // txtMontoCuotaCoop
            // 
            this.txtMontoCuotaCoop.Location = new System.Drawing.Point(10, 41);
            this.txtMontoCuotaCoop.Name = "txtMontoCuotaCoop";
            this.txtMontoCuotaCoop.Size = new System.Drawing.Size(107, 22);
            this.txtMontoCuotaCoop.TabIndex = 5;
            // 
            // btnSalirComparacion
            // 
            this.btnSalirComparacion.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out1;
            this.btnSalirComparacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirComparacion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirComparacion.Location = new System.Drawing.Point(397, 239);
            this.btnSalirComparacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirComparacion.Name = "btnSalirComparacion";
            this.btnSalirComparacion.Size = new System.Drawing.Size(98, 39);
            this.btnSalirComparacion.TabIndex = 23;
            this.btnSalirComparacion.Text = "    Salir";
            this.btnSalirComparacion.UseVisualStyleBackColor = true;
            this.btnSalirComparacion.Click += new System.EventHandler(this.btnSalirComparacion_Click);
            // 
            // btnCalcularComparacion
            // 
            this.btnCalcularComparacion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalcularComparacion.Image = global::COOPMEF.Properties.Resources._1486806555_calculator;
            this.btnCalcularComparacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcularComparacion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCalcularComparacion.Location = new System.Drawing.Point(320, 40);
            this.btnCalcularComparacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcularComparacion.Name = "btnCalcularComparacion";
            this.btnCalcularComparacion.Size = new System.Drawing.Size(175, 39);
            this.btnCalcularComparacion.TabIndex = 24;
            this.btnCalcularComparacion.Text = "    Calcular";
            this.btnCalcularComparacion.UseVisualStyleBackColor = true;
            // 
            // frmCompracionDeTasas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 305);
            this.Controls.Add(this.btnCalcularComparacion);
            this.Controls.Add(this.btnSalirComparacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCompracionDeTasas";
            this.Text = "Comparación de tasas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantCuotas;
        private System.Windows.Forms.TextBox txtMontoCuota;
        private System.Windows.Forms.TextBox txtTotalAPagar;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMontoCuotaCoop;
        private System.Windows.Forms.TextBox txtTotalAPagarCoop;
        private System.Windows.Forms.TextBox txtTasaCoop2;
        private System.Windows.Forms.TextBox txtTasaCoop;
        private System.Windows.Forms.Button btnSalirComparacion;
        private System.Windows.Forms.Button btnCalcularComparacion;
    }
}