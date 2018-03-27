namespace COOPMEF
{
    partial class frmDistribucionDeUtilidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistribucionDeUtilidades));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEjercicio = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtUtilidades = new System.Windows.Forms.TextBox();
            this.dgvDistribucionUtilidades = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAportes = new System.Windows.Forms.Label();
            this.lblInteres = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnDistribuir = new System.Windows.Forms.Button();
            this.btnEliminarUtili = new System.Windows.Forms.Button();
            this.btnSalirDistribuciUtilidades = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucionUtilidades)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.txtEjercicio);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ejercicio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUtilidades);
            this.groupBox2.Location = new System.Drawing.Point(206, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Utilidades $";
            // 
            // txtEjercicio
            // 
            this.txtEjercicio.Location = new System.Drawing.Point(32, 39);
            this.txtEjercicio.Margin = new System.Windows.Forms.Padding(4);
            this.txtEjercicio.Name = "txtEjercicio";
            this.txtEjercicio.Size = new System.Drawing.Size(132, 22);
            this.txtEjercicio.TabIndex = 4;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(29, 65);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(90, 17);
            this.label42.TabIndex = 14;
            this.label42.Text = "\"Ej: 12/2017\"";
            // 
            // txtUtilidades
            // 
            this.txtUtilidades.Location = new System.Drawing.Point(31, 39);
            this.txtUtilidades.Margin = new System.Windows.Forms.Padding(4);
            this.txtUtilidades.Name = "txtUtilidades";
            this.txtUtilidades.Size = new System.Drawing.Size(104, 22);
            this.txtUtilidades.TabIndex = 5;
            // 
            // dgvDistribucionUtilidades
            // 
            this.dgvDistribucionUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDistribucionUtilidades.Location = new System.Drawing.Point(13, 120);
            this.dgvDistribucionUtilidades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDistribucionUtilidades.Name = "dgvDistribucionUtilidades";
            this.dgvDistribucionUtilidades.Size = new System.Drawing.Size(351, 240);
            this.dgvDistribucionUtilidades.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(372, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 150);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Importante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 102);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblInteres);
            this.groupBox4.Controls.Add(this.lblAportes);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(372, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 129);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aportes $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Interés   $";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total    $";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 3;
            // 
            // lblAportes
            // 
            this.lblAportes.AutoSize = true;
            this.lblAportes.Location = new System.Drawing.Point(172, 31);
            this.lblAportes.Name = "lblAportes";
            this.lblAportes.Size = new System.Drawing.Size(46, 17);
            this.lblAportes.TabIndex = 3;
            this.lblAportes.Text = "label6";
            // 
            // lblInteres
            // 
            this.lblInteres.AutoSize = true;
            this.lblInteres.Location = new System.Drawing.Point(172, 59);
            this.lblInteres.Name = "lblInteres";
            this.lblInteres.Size = new System.Drawing.Size(46, 17);
            this.lblInteres.TabIndex = 4;
            this.lblInteres.Text = "label7";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(172, 99);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 17);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "label8";
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.Image = global::COOPMEF.Properties.Resources._1486256671_personal_loan;
            this.btnDistribuir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDistribuir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDistribuir.Location = new System.Drawing.Point(449, 321);
            this.btnDistribuir.Margin = new System.Windows.Forms.Padding(4);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(92, 39);
            this.btnDistribuir.TabIndex = 27;
            this.btnDistribuir.Text = "    Distribuir";
            this.btnDistribuir.UseVisualStyleBackColor = true;
            // 
            // btnEliminarUtili
            // 
            this.btnEliminarUtili.Image = global::COOPMEF.Properties.Resources.delete16;
            this.btnEliminarUtili.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUtili.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminarUtili.Location = new System.Drawing.Point(372, 321);
            this.btnEliminarUtili.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarUtili.Name = "btnEliminarUtili";
            this.btnEliminarUtili.Size = new System.Drawing.Size(78, 38);
            this.btnEliminarUtili.TabIndex = 28;
            this.btnEliminarUtili.Text = "   Eliminar";
            this.btnEliminarUtili.UseVisualStyleBackColor = true;
            // 
            // btnSalirDistribuciUtilidades
            // 
            this.btnSalirDistribuciUtilidades.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out1;
            this.btnSalirDistribuciUtilidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirDistribuciUtilidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirDistribuciUtilidades.Location = new System.Drawing.Point(540, 321);
            this.btnSalirDistribuciUtilidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirDistribuciUtilidades.Name = "btnSalirDistribuciUtilidades";
            this.btnSalirDistribuciUtilidades.Size = new System.Drawing.Size(83, 39);
            this.btnSalirDistribuciUtilidades.TabIndex = 26;
            this.btnSalirDistribuciUtilidades.Text = "   Salir";
            this.btnSalirDistribuciUtilidades.UseVisualStyleBackColor = true;
            this.btnSalirDistribuciUtilidades.Click += new System.EventHandler(this.btnSalirDistribuciUtilidades_Click);
            // 
            // frmDistribucionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 385);
            this.Controls.Add(this.btnDistribuir);
            this.Controls.Add(this.btnEliminarUtili);
            this.Controls.Add(this.btnSalirDistribuciUtilidades);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvDistribucionUtilidades);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDistribucionDeUtilidades";
            this.Text = "Distribución de Utilidades";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucionUtilidades)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEjercicio;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtUtilidades;
        private System.Windows.Forms.DataGridView dgvDistribucionUtilidades;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblInteres;
        private System.Windows.Forms.Label lblAportes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDistribuir;
        private System.Windows.Forms.Button btnSalirDistribuciUtilidades;
        private System.Windows.Forms.Button btnEliminarUtili;
    }
}