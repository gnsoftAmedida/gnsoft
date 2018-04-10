namespace COOPMEF
{
    partial class frmLiquidacionDeUtilidades
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
            this.dgvDetalleUtilidades = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimirRecibo = new System.Windows.Forms.Button();
            this.btnSalirLiqUtil = new System.Windows.Forms.Button();
            this.btnCancelarPrestamo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalleUtilidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Utilidades liquidadas y no liquidadas";
            // 
            // dgvDetalleUtilidades
            // 
            this.dgvDetalleUtilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleUtilidades.Location = new System.Drawing.Point(7, 31);
            this.dgvDetalleUtilidades.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalleUtilidades.Name = "dgvDetalleUtilidades";
            this.dgvDetalleUtilidades.Size = new System.Drawing.Size(460, 170);
            this.dgvDetalleUtilidades.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total de Utilidades sin liquidar";
            // 
            // btnImprimirRecibo
            // 
            this.btnImprimirRecibo.Enabled = false;
            this.btnImprimirRecibo.Image = global::COOPMEF.Properties.Resources.print;
            this.btnImprimirRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimirRecibo.Location = new System.Drawing.Point(541, 239);
            this.btnImprimirRecibo.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimirRecibo.Name = "btnImprimirRecibo";
            this.btnImprimirRecibo.Size = new System.Drawing.Size(112, 43);
            this.btnImprimirRecibo.TabIndex = 25;
            this.btnImprimirRecibo.Text = "     Imprimir";
            this.btnImprimirRecibo.UseVisualStyleBackColor = true;
            // 
            // btnSalirLiqUtil
            // 
            this.btnSalirLiqUtil.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirLiqUtil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirLiqUtil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirLiqUtil.Location = new System.Drawing.Point(540, 292);
            this.btnSalirLiqUtil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirLiqUtil.Name = "btnSalirLiqUtil";
            this.btnSalirLiqUtil.Size = new System.Drawing.Size(112, 43);
            this.btnSalirLiqUtil.TabIndex = 24;
            this.btnSalirLiqUtil.Text = "Salir";
            this.btnSalirLiqUtil.UseVisualStyleBackColor = true;
            // 
            // btnCancelarPrestamo
            // 
            this.btnCancelarPrestamo.Image = global::COOPMEF.Properties.Resources._1486108159_document_edit;
            this.btnCancelarPrestamo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPrestamo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarPrestamo.Location = new System.Drawing.Point(540, 186);
            this.btnCancelarPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarPrestamo.Name = "btnCancelarPrestamo";
            this.btnCancelarPrestamo.Size = new System.Drawing.Size(113, 43);
            this.btnCancelarPrestamo.TabIndex = 23;
            this.btnCancelarPrestamo.Text = "      Liquidación";
            this.btnCancelarPrestamo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nro Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(540, 156);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(112, 22);
            this.txtNroCheque.TabIndex = 27;
            // 
            // frmLiquidacionDeUtilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 345);
            this.Controls.Add(this.btnSalirLiqUtil);
            this.Controls.Add(this.txtNroCheque);
            this.Controls.Add(this.btnImprimirRecibo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarPrestamo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLiquidacionDeUtilidades";
            this.Text = "Liquidación de Utilidades";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleUtilidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDetalleUtilidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImprimirRecibo;
        private System.Windows.Forms.Button btnSalirLiqUtil;
        private System.Windows.Forms.Button btnCancelarPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroCheque;
    }
}