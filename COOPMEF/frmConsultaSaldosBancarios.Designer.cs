namespace COOPMEF
{
    partial class frmConsultaSaldosBancarios
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
            this.dgvSaldosBancarios = new System.Windows.Forms.DataGridView();
            this.btnSalirPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldosBancarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSaldosBancarios
            // 
            this.dgvSaldosBancarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldosBancarios.Location = new System.Drawing.Point(10, 22);
            this.dgvSaldosBancarios.Name = "dgvSaldosBancarios";
            this.dgvSaldosBancarios.Size = new System.Drawing.Size(654, 245);
            this.dgvSaldosBancarios.TabIndex = 4;
            // 
            // btnSalirPlan
            // 
            this.btnSalirPlan.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPlan.Location = new System.Drawing.Point(561, 273);
            this.btnSalirPlan.Name = "btnSalirPlan";
            this.btnSalirPlan.Size = new System.Drawing.Size(103, 33);
            this.btnSalirPlan.TabIndex = 37;
            this.btnSalirPlan.Text = "     Salir";
            this.btnSalirPlan.UseVisualStyleBackColor = true;
            this.btnSalirPlan.Click += new System.EventHandler(this.btnSalirPlan_Click);
            // 
            // frmConsultaSaldosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 315);
            this.Controls.Add(this.btnSalirPlan);
            this.Controls.Add(this.dgvSaldosBancarios);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmConsultaSaldosBancarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Saldos Bancarios";
            this.Load += new System.EventHandler(this.frmConsultaSaldosBancarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldosBancarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSaldosBancarios;
        private System.Windows.Forms.Button btnSalirPlan;
    }
}