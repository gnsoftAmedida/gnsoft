namespace COOPMEF
{
    partial class frmCuentaCorriente
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
            this.dsFactura1 = new COOPMEF.CrystalDataSets.dsFactura();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.btnSalirBanco = new System.Windows.Forms.Button();
            this.btnNuevoBanco = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsFactura1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsFactura1
            // 
            this.dsFactura1.DataSetName = "dsFactura";
            this.dsFactura1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(98, 36);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(286, 24);
            this.cmbBusqueda.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 79);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bancos y Números de Cuenta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpFechaHasta);
            this.groupBox2.Controls.Add(this.dtpFechaDesde);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 118);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rango de fechas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Checked = false;
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(69, 69);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(143, 24);
            this.dtpFechaHasta.TabIndex = 9;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Checked = false;
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(69, 36);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(143, 24);
            this.dtpFechaDesde.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtConcepto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(265, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 118);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Concepto del Movimiento";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(21, 49);
            this.txtConcepto.MaxLength = 249;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(188, 24);
            this.txtConcepto.TabIndex = 0;
            // 
            // btnSalirBanco
            // 
            this.btnSalirBanco.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirBanco.Location = new System.Drawing.Point(394, 221);
            this.btnSalirBanco.Name = "btnSalirBanco";
            this.btnSalirBanco.Size = new System.Drawing.Size(96, 29);
            this.btnSalirBanco.TabIndex = 7;
            this.btnSalirBanco.Text = "     Salir";
            this.btnSalirBanco.UseVisualStyleBackColor = true;
            this.btnSalirBanco.Click += new System.EventHandler(this.btnSalirBanco_Click);
            // 
            // btnNuevoBanco
            // 
            this.btnNuevoBanco.Image = global::COOPMEF.Properties.Resources._1486109530_new_file;
            this.btnNuevoBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNuevoBanco.Location = new System.Drawing.Point(286, 221);
            this.btnNuevoBanco.Name = "btnNuevoBanco";
            this.btnNuevoBanco.Size = new System.Drawing.Size(96, 30);
            this.btnNuevoBanco.TabIndex = 6;
            this.btnNuevoBanco.Text = "    Aceptar";
            this.btnNuevoBanco.UseVisualStyleBackColor = true;
            this.btnNuevoBanco.Click += new System.EventHandler(this.btnNuevoBanco_Click);
            // 
            // frmCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 271);
            this.Controls.Add(this.btnSalirBanco);
            this.Controls.Add(this.btnNuevoBanco);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmCuentaCorriente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Corrientes";
            this.Load += new System.EventHandler(this.frmCuentaCorriente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsFactura1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDataSets.dsFactura dsFactura1;
        private System.Windows.Forms.ComboBox cmbBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Button btnSalirBanco;
        private System.Windows.Forms.Button btnNuevoBanco;

    }
}