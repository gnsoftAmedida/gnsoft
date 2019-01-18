namespace COOPMEF
{
    partial class frmCantidadMovimientos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.cmbBancosMovPromedio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalirMovPromedio = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMes.Location = new System.Drawing.Point(107, 28);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(80, 21);
            this.cmbMes.TabIndex = 4;
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(259, 25);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(92, 21);
            this.cmbAnio.TabIndex = 5;
            // 
            // cmbBancosMovPromedio
            // 
            this.cmbBancosMovPromedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBancosMovPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBancosMovPromedio.FormattingEnabled = true;
            this.cmbBancosMovPromedio.Location = new System.Drawing.Point(107, 93);
            this.cmbBancosMovPromedio.Name = "cmbBancosMovPromedio";
            this.cmbBancosMovPromedio.Size = new System.Drawing.Size(243, 24);
            this.cmbBancosMovPromedio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Banco";
            // 
            // btnSalirMovPromedio
            // 
            this.btnSalirMovPromedio.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirMovPromedio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirMovPromedio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirMovPromedio.Location = new System.Drawing.Point(254, 172);
            this.btnSalirMovPromedio.Name = "btnSalirMovPromedio";
            this.btnSalirMovPromedio.Size = new System.Drawing.Size(96, 29);
            this.btnSalirMovPromedio.TabIndex = 8;
            this.btnSalirMovPromedio.Text = "     Salir";
            this.btnSalirMovPromedio.UseVisualStyleBackColor = true;
            this.btnSalirMovPromedio.Click += new System.EventHandler(this.btnSalirMovPromedio_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::COOPMEF.Properties.Resources._1486109086_Check1;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAceptar.Location = new System.Drawing.Point(107, 172);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 29);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "    Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCantidadMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 228);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalirMovPromedio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBancosMovPromedio);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmCantidadMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad de Movimientos y Promedio";
            this.Load += new System.EventHandler(this.frmCantidadMovimientos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.ComboBox cmbBancosMovPromedio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalirMovPromedio;
        private System.Windows.Forms.Button btnAceptar;
    }
}