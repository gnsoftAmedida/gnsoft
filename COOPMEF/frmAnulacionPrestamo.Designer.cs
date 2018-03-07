namespace COOPMEF
{
    partial class frmAnulacionPrestamo
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
            this.dgvPrestamosSinLiquidar = new System.Windows.Forms.DataGridView();
            this.btnSalirPrestamo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosSinLiquidar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrestamosSinLiquidar
            // 
            this.dgvPrestamosSinLiquidar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamosSinLiquidar.Location = new System.Drawing.Point(23, 25);
            this.dgvPrestamosSinLiquidar.Name = "dgvPrestamosSinLiquidar";
            this.dgvPrestamosSinLiquidar.RowTemplate.Height = 24;
            this.dgvPrestamosSinLiquidar.Size = new System.Drawing.Size(751, 301);
            this.dgvPrestamosSinLiquidar.TabIndex = 0;
            this.dgvPrestamosSinLiquidar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrestamosSinLiquidar_CellClick);
            this.dgvPrestamosSinLiquidar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrestamosSinLiquidar_CellDoubleClick);
            // 
            // btnSalirPrestamo
            // 
            this.btnSalirPrestamo.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPrestamo.Location = new System.Drawing.Point(662, 333);
            this.btnSalirPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirPrestamo.Name = "btnSalirPrestamo";
            this.btnSalirPrestamo.Size = new System.Drawing.Size(112, 32);
            this.btnSalirPrestamo.TabIndex = 14;
            this.btnSalirPrestamo.Text = "Salir";
            this.btnSalirPrestamo.UseVisualStyleBackColor = true;
            this.btnSalirPrestamo.Click += new System.EventHandler(this.btnSalirPrestamo_Click);
            // 
            // frmAnulacionPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 382);
            this.Controls.Add(this.btnSalirPrestamo);
            this.Controls.Add(this.dgvPrestamosSinLiquidar);
            this.Name = "frmAnulacionPrestamo";
            this.Text = "Anulación de préstamos sin liquidar";
            this.Load += new System.EventHandler(this.frmAnulacionPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosSinLiquidar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrestamosSinLiquidar;
        private System.Windows.Forms.Button btnSalirPrestamo;
    }
}