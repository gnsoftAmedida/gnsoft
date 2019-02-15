namespace COOPMEF
{
    partial class frmModificarTodasLasTasas
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
            this.btnSalirPlan = new System.Windows.Forms.Button();
            this.btnGuardarPlan = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese Nueva Tasa par todos los planes";
            // 
            // btnSalirPlan
            // 
            this.btnSalirPlan.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPlan.Location = new System.Drawing.Point(281, 59);
            this.btnSalirPlan.Name = "btnSalirPlan";
            this.btnSalirPlan.Size = new System.Drawing.Size(96, 31);
            this.btnSalirPlan.TabIndex = 1;
            this.btnSalirPlan.Text = "     Salir";
            this.btnSalirPlan.UseVisualStyleBackColor = true;
            this.btnSalirPlan.Click += new System.EventHandler(this.btnSalirPlan_Click);
            // 
            // btnGuardarPlan
            // 
            this.btnGuardarPlan.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarPlan.Location = new System.Drawing.Point(281, 22);
            this.btnGuardarPlan.Name = "btnGuardarPlan";
            this.btnGuardarPlan.Size = new System.Drawing.Size(96, 31);
            this.btnGuardarPlan.TabIndex = 0;
            this.btnGuardarPlan.Text = "     Guardar";
            this.btnGuardarPlan.UseVisualStyleBackColor = true;
            this.btnGuardarPlan.Click += new System.EventHandler(this.btnGuardarPlan_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 78);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // frmModificarTodasLasTasas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 108);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalirPlan);
            this.Controls.Add(this.btnGuardarPlan);
            this.MaximizeBox = false;
            this.Name = "frmModificarTodasLasTasas";
            this.Text = "Modificación de tasas";
            this.Load += new System.EventHandler(this.frmModificarTodasLasTasas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalirPlan;
        private System.Windows.Forms.Button btnGuardarPlan;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}