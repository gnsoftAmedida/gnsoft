namespace COOPMEF
{
    partial class frmInformePrestamo
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
            this.label42 = new System.Windows.Forms.Label();
            this.txtPresupuestoIngExc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic);
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(111, 46);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(73, 13);
            this.label42.TabIndex = 16;
            this.label42.Text = "\"Ej: 12/2017\"";
            // 
            // txtPresupuestoIngExc
            // 
            this.txtPresupuestoIngExc.Location = new System.Drawing.Point(98, 14);
            this.txtPresupuestoIngExc.Name = "txtPresupuestoIngExc";
            this.txtPresupuestoIngExc.Size = new System.Drawing.Size(100, 20);
            this.txtPresupuestoIngExc.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(7, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Presupuesto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(250, 44);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(250, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(83, 23);
            this.btnActualizar.TabIndex = 17;
            this.btnActualizar.Text = "Emitir";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.txtPresupuestoIngExc);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(226, 76);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // frmInformePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 101);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInformePrestamo";
            this.Text = "Listado de Préstamos Otorgados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtPresupuestoIngExc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}