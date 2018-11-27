namespace COOPMEF
{
    partial class frmConsultaLogs
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
            this.dataGridLogs = new System.Windows.Forms.DataGridView();
            this.groupBoxPrioridad = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).BeginInit();
            this.groupBoxPrioridad.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridLogs);
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 240);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dataGridLogs
            // 
            this.dataGridLogs.AllowUserToAddRows = false;
            this.dataGridLogs.AllowUserToDeleteRows = false;
            this.dataGridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogs.Location = new System.Drawing.Point(23, 30);
            this.dataGridLogs.Name = "dataGridLogs";
            this.dataGridLogs.ReadOnly = true;
            this.dataGridLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLogs.Size = new System.Drawing.Size(647, 194);
            this.dataGridLogs.TabIndex = 12;
            // 
            // groupBoxPrioridad
            // 
            this.groupBoxPrioridad.Controls.Add(this.groupBox6);
            this.groupBoxPrioridad.Controls.Add(this.label4);
            this.groupBoxPrioridad.Controls.Add(this.label3);
            this.groupBoxPrioridad.Controls.Add(this.dtpFechaHasta);
            this.groupBoxPrioridad.Controls.Add(this.dtpFechaDesde);
            this.groupBoxPrioridad.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPrioridad.Name = "groupBoxPrioridad";
            this.groupBoxPrioridad.Size = new System.Drawing.Size(467, 105);
            this.groupBoxPrioridad.TabIndex = 14;
            this.groupBoxPrioridad.TabStop = false;
            this.groupBoxPrioridad.Text = "Consulta de logs por fecha";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnActualizar);
            this.groupBox6.Location = new System.Drawing.Point(288, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(158, 74);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(21, 29);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(119, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Consultar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Tag = "";
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Tag = "";
            this.label3.Text = "Desde";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(64, 67);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(202, 20);
            this.dtpFechaHasta.TabIndex = 1;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(64, 23);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(202, 20);
            this.dtpFechaDesde.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(585, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmConsultaLogs
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(714, 422);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxPrioridad);
            this.MaximizeBox = false;
            this.Name = "frmConsultaLogs";
            this.Text = "Consulta Logs";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).EndInit();
            this.groupBoxPrioridad.ResumeLayout(false);
            this.groupBoxPrioridad.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridLogs;
        private System.Windows.Forms.GroupBox groupBoxPrioridad;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Button btnCancelar;
    }
}