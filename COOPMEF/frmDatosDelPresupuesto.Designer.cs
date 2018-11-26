namespace COOPMEF
{
    partial class frmDatosDelPresupuesto
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
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.txtEjercicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalirDistribuciUtilidades = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAnio);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(266, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(140, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Año";
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(20, 36);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(103, 28);
            this.cmbAnio.TabIndex = 31;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // txtEjercicio
            // 
            this.txtEjercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjercicio.Location = new System.Drawing.Point(106, 43);
            this.txtEjercicio.Name = "txtEjercicio";
            this.txtEjercicio.ReadOnly = true;
            this.txtEjercicio.Size = new System.Drawing.Size(104, 21);
            this.txtEjercicio.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(23, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Ejercicio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEjercicio);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 94);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::COOPMEF.Properties.Resources._1486256671_personal_loan;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConsultar.Location = new System.Drawing.Point(428, 22);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(96, 39);
            this.btnConsultar.TabIndex = 37;
            this.btnConsultar.Text = "    Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalirDistribuciUtilidades
            // 
            this.btnSalirDistribuciUtilidades.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out1;
            this.btnSalirDistribuciUtilidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirDistribuciUtilidades.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirDistribuciUtilidades.Location = new System.Drawing.Point(428, 67);
            this.btnSalirDistribuciUtilidades.Name = "btnSalirDistribuciUtilidades";
            this.btnSalirDistribuciUtilidades.Size = new System.Drawing.Size(96, 39);
            this.btnSalirDistribuciUtilidades.TabIndex = 36;
            this.btnSalirDistribuciUtilidades.Text = "   Salir";
            this.btnSalirDistribuciUtilidades.UseVisualStyleBackColor = true;
            this.btnSalirDistribuciUtilidades.Click += new System.EventHandler(this.btnSalirDistribuciUtilidades_Click);
            // 
            // frmDatosDelPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 128);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnSalirDistribuciUtilidades);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmDatosDelPresupuesto";
            this.Text = "Datos del presupuesto";
            this.Load += new System.EventHandler(this.frmDatosDelPresupuesto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.TextBox txtEjercicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalirDistribuciUtilidades;
    }
}