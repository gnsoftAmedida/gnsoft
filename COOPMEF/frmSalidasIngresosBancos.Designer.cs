namespace COOPMEF
{
    partial class frmSalidasIngresosBancos
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
            this.btnSeleccionarSocio = new System.Windows.Forms.Button();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvIngresosSalidas = new System.Windows.Forms.DataGridView();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalIngresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEjercicio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalirMovPromedio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSeleccionarSocio
            // 
            this.btnSeleccionarSocio.Image = global::COOPMEF.Properties.Resources._1486109086_Check1;
            this.btnSeleccionarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarSocio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSeleccionarSocio.Location = new System.Drawing.Point(606, 95);
            this.btnSeleccionarSocio.Name = "btnSeleccionarSocio";
            this.btnSeleccionarSocio.Size = new System.Drawing.Size(103, 33);
            this.btnSeleccionarSocio.TabIndex = 7;
            this.btnSeleccionarSocio.Text = "     Aceptar";
            this.btnSeleccionarSocio.UseVisualStyleBackColor = true;
            this.btnSeleccionarSocio.Click += new System.EventHandler(this.btnSeleccionarSocio_Click);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(606, 56);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(103, 21);
            this.cmbAnio.TabIndex = 9;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ejercicio";
            // 
            // dgvIngresosSalidas
            // 
            this.dgvIngresosSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresosSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mes,
            this.totalPrestado,
            this.totalIngresos});
            this.dgvIngresosSalidas.Location = new System.Drawing.Point(12, 56);
            this.dgvIngresosSalidas.Name = "dgvIngresosSalidas";
            this.dgvIngresosSalidas.Size = new System.Drawing.Size(544, 389);
            this.dgvIngresosSalidas.TabIndex = 10;
            // 
            // mes
            // 
            this.mes.HeaderText = "En el Mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            // 
            // totalPrestado
            // 
            this.totalPrestado.HeaderText = "Total Prestado $";
            this.totalPrestado.Name = "totalPrestado";
            this.totalPrestado.ReadOnly = true;
            this.totalPrestado.Width = 200;
            // 
            // totalIngresos
            // 
            this.totalIngresos.HeaderText = "Total Ingresos $";
            this.totalIngresos.Name = "totalIngresos";
            this.totalIngresos.ReadOnly = true;
            this.totalIngresos.Width = 200;
            // 
            // txtEjercicio
            // 
            this.txtEjercicio.Location = new System.Drawing.Point(234, 15);
            this.txtEjercicio.Name = "txtEjercicio";
            this.txtEjercicio.ReadOnly = true;
            this.txtEjercicio.Size = new System.Drawing.Size(120, 20);
            this.txtEjercicio.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Año";
            // 
            // btnSalirMovPromedio
            // 
            this.btnSalirMovPromedio.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirMovPromedio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirMovPromedio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirMovPromedio.Location = new System.Drawing.Point(606, 134);
            this.btnSalirMovPromedio.Name = "btnSalirMovPromedio";
            this.btnSalirMovPromedio.Size = new System.Drawing.Size(103, 33);
            this.btnSalirMovPromedio.TabIndex = 12;
            this.btnSalirMovPromedio.Text = "     Salir";
            this.btnSalirMovPromedio.UseVisualStyleBackColor = true;
            this.btnSalirMovPromedio.Click += new System.EventHandler(this.btnSalirMovPromedio_Click);
            // 
            // frmSalidasIngresosBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 459);
            this.Controls.Add(this.btnSalirMovPromedio);
            this.Controls.Add(this.txtEjercicio);
            this.Controls.Add(this.dgvIngresosSalidas);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSeleccionarSocio);
            this.MaximizeBox = false;
            this.Name = "frmSalidasIngresosBancos";
            this.Text = "Salidas de bancos por préstamos e ingresos según presupuesto del mes";
            this.Load += new System.EventHandler(this.frmSalidasIngresosBancos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosSalidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarSocio;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvIngresosSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIngresos;
        private System.Windows.Forms.TextBox txtEjercicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirMovPromedio;
    }
}