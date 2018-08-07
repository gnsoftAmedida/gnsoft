namespace COOPMEF
{
    partial class frmGeneracionDiscosRetenciones
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbUnidades = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmbOficina = new System.Windows.Forms.ComboBox();
            this.cmbInciso = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAnios = new System.Windows.Forms.ComboBox();
            this.cmbMeses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardarPlan = new System.Windows.Forms.Button();
            this.btnSalirPrestamo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(930, 61);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Seleccione unidad de destino y luego la carpeta donde se generaran los archivos h" +
                "aciendo doble click sobre la carpeta. Si no selecciona ninguna, los archivos se " +
                "generaran en la raíz de destino. ";
            // 
            // cmbUnidades
            // 
            this.cmbUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidades.FormattingEnabled = true;
            this.cmbUnidades.Location = new System.Drawing.Point(110, 40);
            this.cmbUnidades.Name = "cmbUnidades";
            this.cmbUnidades.Size = new System.Drawing.Size(94, 24);
            this.cmbUnidades.TabIndex = 5;
            this.cmbUnidades.SelectedIndexChanged += new System.EventHandler(this.cmbUnidades_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(111, 92);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(227, 110);
            this.treeView1.TabIndex = 6;
            // 
            // cmbOficina
            // 
            this.cmbOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOficina.FormattingEnabled = true;
            this.cmbOficina.Location = new System.Drawing.Point(106, 64);
            this.cmbOficina.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOficina.Name = "cmbOficina";
            this.cmbOficina.Size = new System.Drawing.Size(263, 28);
            this.cmbOficina.TabIndex = 22;
            // 
            // cmbInciso
            // 
            this.cmbInciso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInciso.FormattingEnabled = true;
            this.cmbInciso.Location = new System.Drawing.Point(106, 27);
            this.cmbInciso.Margin = new System.Windows.Forms.Padding(4);
            this.cmbInciso.Name = "cmbInciso";
            this.cmbInciso.Size = new System.Drawing.Size(263, 28);
            this.cmbInciso.TabIndex = 21;
            this.cmbInciso.SelectedIndexChanged += new System.EventHandler(this.cmbInciso_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(25, 68);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(71, 20);
            this.label36.TabIndex = 24;
            this.label36.Text = "Oficinas";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(25, 30);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(62, 20);
            this.label35.TabIndex = 23;
            this.label35.Text = "Incisos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAnios);
            this.groupBox1.Controls.Add(this.cmbMeses);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 94);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presupuesto de...";
            // 
            // cmbAnios
            // 
            this.cmbAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnios.FormattingEnabled = true;
            this.cmbAnios.Items.AddRange(new object[] {
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050"});
            this.cmbAnios.Location = new System.Drawing.Point(254, 41);
            this.cmbAnios.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAnios.Name = "cmbAnios";
            this.cmbAnios.Size = new System.Drawing.Size(96, 28);
            this.cmbAnios.TabIndex = 58;
            // 
            // cmbMeses
            // 
            this.cmbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeses.FormattingEnabled = true;
            this.cmbMeses.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cmbMeses.Location = new System.Drawing.Point(70, 41);
            this.cmbMeses.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMeses.Name = "cmbMeses";
            this.cmbMeses.Size = new System.Drawing.Size(119, 28);
            this.cmbMeses.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Año ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mes ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Unidades";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Controls.Add(this.cmbUnidades);
            this.groupBox2.Location = new System.Drawing.Point(585, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 218);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbOficina);
            this.groupBox3.Controls.Add(this.cmbInciso);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Location = new System.Drawing.Point(14, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 118);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(25, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Carpetas";
            // 
            // btnGuardarPlan
            // 
            this.btnGuardarPlan.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarPlan.Location = new System.Drawing.Point(431, 107);
            this.btnGuardarPlan.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarPlan.Name = "btnGuardarPlan";
            this.btnGuardarPlan.Size = new System.Drawing.Size(128, 38);
            this.btnGuardarPlan.TabIndex = 29;
            this.btnGuardarPlan.Text = "     Aceptar";
            this.btnGuardarPlan.UseVisualStyleBackColor = true;
            // 
            // btnSalirPrestamo
            // 
            this.btnSalirPrestamo.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPrestamo.Location = new System.Drawing.Point(431, 156);
            this.btnSalirPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirPrestamo.Name = "btnSalirPrestamo";
            this.btnSalirPrestamo.Size = new System.Drawing.Size(128, 37);
            this.btnSalirPrestamo.TabIndex = 30;
            this.btnSalirPrestamo.Text = "Salir";
            this.btnSalirPrestamo.UseVisualStyleBackColor = true;
            this.btnSalirPrestamo.Click += new System.EventHandler(this.btnSalirPrestamo_Click);
            // 
            // frmGeneracionDiscosRetenciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 315);
            this.Controls.Add(this.btnSalirPrestamo);
            this.Controls.Add(this.btnGuardarPlan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmGeneracionDiscosRetenciones";
            this.Text = "Generación de Discos para Retenciones";
            this.Load += new System.EventHandler(this.frmGeneracionDiscosRetenciones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbUnidades;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ComboBox cmbOficina;
        private System.Windows.Forms.ComboBox cmbInciso;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAnios;
        private System.Windows.Forms.ComboBox cmbMeses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardarPlan;
        private System.Windows.Forms.Button btnSalirPrestamo;
    }
}