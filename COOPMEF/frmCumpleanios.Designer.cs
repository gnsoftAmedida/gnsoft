﻿namespace COOPMEF
{
    partial class frmCumpleanios
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
            this.cmbMeses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalirPrestamo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMeses);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 78);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
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
            this.cmbMeses.Location = new System.Drawing.Point(66, 27);
            this.cmbMeses.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMeses.Name = "cmbMeses";
            this.cmbMeses.Size = new System.Drawing.Size(145, 24);
            this.cmbMeses.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mes ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBuscar.Image = global::COOPMEF.Properties.Resources._1486108741_Search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(16, 97);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 37);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "Ver";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalirPrestamo
            // 
            this.btnSalirPrestamo.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPrestamo.Location = new System.Drawing.Point(143, 97);
            this.btnSalirPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirPrestamo.Name = "btnSalirPrestamo";
            this.btnSalirPrestamo.Size = new System.Drawing.Size(119, 37);
            this.btnSalirPrestamo.TabIndex = 19;
            this.btnSalirPrestamo.Text = "Salir";
            this.btnSalirPrestamo.UseVisualStyleBackColor = true;
            this.btnSalirPrestamo.Click += new System.EventHandler(this.btnSalirPrestamo_Click);
            // 
            // frmCumpleanios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 166);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnSalirPrestamo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCumpleanios";
            this.Text = "Cumpleaños";
            this.Load += new System.EventHandler(this.frmCumpleanios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnSalirPrestamo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMeses;
        private System.Windows.Forms.Label label1;
    }
}