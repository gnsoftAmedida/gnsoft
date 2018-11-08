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
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUtilidades = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblInteres = new System.Windows.Forms.Label();
            this.lblAportes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDistribuir = new System.Windows.Forms.Button();
            this.btnEliminarUtili = new System.Windows.Forms.Button();
            this.btnSalirDistribuciUtilidades = new System.Windows.Forms.Button();
            this.dgvUtilidades = new System.Windows.Forms.DataGridView();
            this.presupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intereses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEjercicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAnio);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(632, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(140, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Año";
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(20, 32);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(103, 28);
            this.cmbAnio.TabIndex = 31;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUtilidades);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(787, 97);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(135, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Utilidades $";
            // 
            // txtUtilidades
            // 
            this.txtUtilidades.Location = new System.Drawing.Point(18, 33);
            this.txtUtilidades.Name = "txtUtilidades";
            this.txtUtilidades.Size = new System.Drawing.Size(104, 26);
            this.txtUtilidades.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(632, 241);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(290, 184);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Importante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 96);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblInteres);
            this.groupBox4.Controls.Add(this.lblAportes);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(81, 374);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(470, 108);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(273, 76);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "label8";
            // 
            // lblInteres
            // 
            this.lblInteres.AutoSize = true;
            this.lblInteres.Location = new System.Drawing.Point(273, 44);
            this.lblInteres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInteres.Name = "lblInteres";
            this.lblInteres.Size = new System.Drawing.Size(45, 20);
            this.lblInteres.TabIndex = 4;
            this.lblInteres.Text = "label7";
            // 
            // lblAportes
            // 
            this.lblAportes.AutoSize = true;
            this.lblAportes.Location = new System.Drawing.Point(273, 21);
            this.lblAportes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAportes.Name = "lblAportes";
            this.lblAportes.Size = new System.Drawing.Size(45, 20);
            this.lblAportes.TabIndex = 3;
            this.lblAportes.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(171, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total         $";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Intereses   $";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aportes     $";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(846, 393);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 3;
            // 
            // btnDistribuir
            // 
            this.btnDistribuir.Image = global::COOPMEF.Properties.Resources._1486256671_personal_loan;
            this.btnDistribuir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDistribuir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDistribuir.Location = new System.Drawing.Point(729, 443);
            this.btnDistribuir.Name = "btnDistribuir";
            this.btnDistribuir.Size = new System.Drawing.Size(96, 39);
            this.btnDistribuir.TabIndex = 27;
            this.btnDistribuir.Text = "    Distribuir";
            this.btnDistribuir.UseVisualStyleBackColor = true;
            this.btnDistribuir.Click += new System.EventHandler(this.btnDistribuir_Click);
            // 
            // btnEliminarUtili
            // 
            this.btnEliminarUtili.Image = global::COOPMEF.Properties.Resources.delete16;
            this.btnEliminarUtili.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUtili.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminarUtili.Location = new System.Drawing.Point(631, 443);
            this.btnEliminarUtili.Name = "btnEliminarUtili";
            this.btnEliminarUtili.Size = new System.Drawing.Size(96, 38);
            this.btnEliminarUtili.TabIndex = 28;
            this.btnEliminarUtili.Text = "   Eliminar";
            this.btnEliminarUtili.UseVisualStyleBackColor = true;
            this.btnEliminarUtili.Click += new System.EventHandler(this.btnEliminarUtili_Click);
            // 
            // btnSalirDistribuciUtilidades
            // 
            this.btnSalirDistribuciUtilidades.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out1;
            this.btnSalirDistribuciUtilidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirDistribuciUtilidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirDistribuciUtilidades.Location = new System.Drawing.Point(825, 443);
            this.btnSalirDistribuciUtilidades.Name = "btnSalirDistribuciUtilidades";
            this.btnSalirDistribuciUtilidades.Size = new System.Drawing.Size(96, 39);
            this.btnSalirDistribuciUtilidades.TabIndex = 26;
            this.btnSalirDistribuciUtilidades.Text = "   Salir";
            this.btnSalirDistribuciUtilidades.UseVisualStyleBackColor = true;
            this.btnSalirDistribuciUtilidades.Click += new System.EventHandler(this.btnSalirDistribuciUtilidades_Click);
            // 
            // dgvUtilidades
            // 
            this.dgvUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtilidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.presupuesto,
            this.aporte,
            this.intereses,
            this.Total});
            this.dgvUtilidades.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUtilidades.Location = new System.Drawing.Point(12, 54);
            this.dgvUtilidades.Name = "dgvUtilidades";
            this.dgvUtilidades.Size = new System.Drawing.Size(602, 313);
            this.dgvUtilidades.TabIndex = 29;
            this.dgvUtilidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUtilidades_CellContentClick);
            // 
            // presupuesto
            // 
            this.presupuesto.HeaderText = "Presupuesto";
            this.presupuesto.Name = "presupuesto";
            this.presupuesto.ReadOnly = true;
            // 
            // aporte
            // 
            this.aporte.HeaderText = "Aporte Capital $";
            this.aporte.Name = "aporte";
            this.aporte.ReadOnly = true;
            this.aporte.Width = 150;
            // 
            // intereses
            // 
            this.intereses.HeaderText = "Intereses Aporte $";
            this.intereses.Name = "intereses";
            this.intereses.ReadOnly = true;
            this.intereses.Width = 150;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total Aporte + Intereses $";
            this.Total.Name = "Total";
            this.Total.Width = 155;
            // 
            // txtEjercicio
            // 
            this.txtEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjercicio.Location = new System.Drawing.Point(237, 12);
            this.txtEjercicio.Name = "txtEjercicio";
            this.txtEjercicio.ReadOnly = true;
            this.txtEjercicio.Size = new System.Drawing.Size(104, 21);
            this.txtEjercicio.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(154, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 31;
            this.label7.Text = "Ejercicio";
            // 
            // frmDistribucionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 537);
            this.Controls.Add(this.txtEjercicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvUtilidades);
            this.Controls.Add(this.btnDistribuir);
            this.Controls.Add(this.btnEliminarUtili);
            this.Controls.Add(this.btnSalirDistribuciUtilidades);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDistribucionDeUtilidades";
            this.Text = "Distribución de Utilidades";
            this.Load += new System.EventHandler(this.frmDistribucionDeUtilidades_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUtilidades;
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
        private System.Windows.Forms.DataGridView dgvUtilidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn presupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn aporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn intereses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.TextBox txtEjercicio;
        private System.Windows.Forms.Label label7;
    }
}