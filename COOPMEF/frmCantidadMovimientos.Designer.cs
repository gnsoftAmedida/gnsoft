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
            this.label1.Location = new System.Drawing.Point(75, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
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
            this.cmbMes.Location = new System.Drawing.Point(143, 35);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(105, 24);
            this.cmbMes.TabIndex = 4;
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(345, 31);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(121, 24);
            this.cmbAnio.TabIndex = 5;
            // 
            // cmbBancosMovPromedio
            // 
            this.cmbBancosMovPromedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBancosMovPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBancosMovPromedio.FormattingEnabled = true;
            this.cmbBancosMovPromedio.Location = new System.Drawing.Point(143, 115);
            this.cmbBancosMovPromedio.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBancosMovPromedio.Name = "cmbBancosMovPromedio";
            this.cmbBancosMovPromedio.Size = new System.Drawing.Size(323, 28);
            this.cmbBancosMovPromedio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Banco";
            // 
            // btnSalirMovPromedio
            // 
            this.btnSalirMovPromedio.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirMovPromedio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirMovPromedio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirMovPromedio.Location = new System.Drawing.Point(338, 212);
            this.btnSalirMovPromedio.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirMovPromedio.Name = "btnSalirMovPromedio";
            this.btnSalirMovPromedio.Size = new System.Drawing.Size(128, 36);
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
            this.btnAceptar.Location = new System.Drawing.Point(143, 212);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(134, 36);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "    Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCantidadMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 281);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalirMovPromedio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBancosMovPromedio);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCantidadMovimientos";
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