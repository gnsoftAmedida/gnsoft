namespace COOPMEF
{
    partial class frmPlanDePrestamo
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
            this.btnSalirPlan = new System.Windows.Forms.Button();
            this.btnCancelarPlan = new System.Windows.Forms.Button();
            this.btnGuardarPlan = new System.Windows.Forms.Button();
            this.btnEliminarPlan = new System.Windows.Forms.Button();
            this.btnEditarPlan = new System.Windows.Forms.Button();
            this.btnNuevoPlan = new System.Windows.Forms.Button();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.texBoxNombrePlan = new System.Windows.Forms.TextBox();
            this.txtBoxCantCuotas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxTasaAnualSinIVA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkVigencia = new System.Windows.Forms.CheckBox();
            this.lblErrorGenerico = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblTasaAnual = new System.Windows.Forms.Label();
            this.lblCantCuotas = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtBoxIVA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalirPlan
            // 
            this.btnSalirPlan.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPlan.Location = new System.Drawing.Point(333, 310);
            this.btnSalirPlan.Name = "btnSalirPlan";
            this.btnSalirPlan.Size = new System.Drawing.Size(96, 29);
            this.btnSalirPlan.TabIndex = 6;
            this.btnSalirPlan.Text = "     Salir";
            this.btnSalirPlan.UseVisualStyleBackColor = true;
            this.btnSalirPlan.Click += new System.EventHandler(this.btnSalirPlan_Click);
            // 
            // btnCancelarPlan
            // 
            this.btnCancelarPlan.Image = global::COOPMEF.Properties.Resources._1486109207_Cancel;
            this.btnCancelarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarPlan.Location = new System.Drawing.Point(221, 309);
            this.btnCancelarPlan.Name = "btnCancelarPlan";
            this.btnCancelarPlan.Size = new System.Drawing.Size(96, 29);
            this.btnCancelarPlan.TabIndex = 5;
            this.btnCancelarPlan.Text = "     Cancelar";
            this.btnCancelarPlan.UseVisualStyleBackColor = true;
            this.btnCancelarPlan.Click += new System.EventHandler(this.btnCancelarPlan_Click);
            // 
            // btnGuardarPlan
            // 
            this.btnGuardarPlan.Enabled = false;
            this.btnGuardarPlan.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarPlan.Location = new System.Drawing.Point(109, 309);
            this.btnGuardarPlan.Name = "btnGuardarPlan";
            this.btnGuardarPlan.Size = new System.Drawing.Size(96, 31);
            this.btnGuardarPlan.TabIndex = 4;
            this.btnGuardarPlan.Text = "     Guardar";
            this.btnGuardarPlan.UseVisualStyleBackColor = true;
            this.btnGuardarPlan.Click += new System.EventHandler(this.btnGuardarPlan_Click);
            // 
            // btnEliminarPlan
            // 
            this.btnEliminarPlan.Image = global::COOPMEF.Properties.Resources.delete16;
            this.btnEliminarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminarPlan.Location = new System.Drawing.Point(494, 148);
            this.btnEliminarPlan.Name = "btnEliminarPlan";
            this.btnEliminarPlan.Size = new System.Drawing.Size(96, 30);
            this.btnEliminarPlan.TabIndex = 3;
            this.btnEliminarPlan.Text = "     Eliminar";
            this.btnEliminarPlan.UseVisualStyleBackColor = true;
            this.btnEliminarPlan.Click += new System.EventHandler(this.btnEliminarPlan_Click);
            // 
            // btnEditarPlan
            // 
            this.btnEditarPlan.Image = global::COOPMEF.Properties.Resources._1486109481_edit_file;
            this.btnEditarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditarPlan.Location = new System.Drawing.Point(494, 97);
            this.btnEditarPlan.Name = "btnEditarPlan";
            this.btnEditarPlan.Size = new System.Drawing.Size(96, 30);
            this.btnEditarPlan.TabIndex = 2;
            this.btnEditarPlan.Text = "     Editar";
            this.btnEditarPlan.UseVisualStyleBackColor = true;
            this.btnEditarPlan.Click += new System.EventHandler(this.btnEditarPlan_Click);
            // 
            // btnNuevoPlan
            // 
            this.btnNuevoPlan.Image = global::COOPMEF.Properties.Resources._1486109530_new_file;
            this.btnNuevoPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNuevoPlan.Location = new System.Drawing.Point(494, 46);
            this.btnNuevoPlan.Name = "btnNuevoPlan";
            this.btnNuevoPlan.Size = new System.Drawing.Size(96, 30);
            this.btnNuevoPlan.TabIndex = 1;
            this.btnNuevoPlan.Text = "    Nuevo";
            this.btnNuevoPlan.UseVisualStyleBackColor = true;
            this.btnNuevoPlan.Click += new System.EventHandler(this.btnNuevoPlan_Click);
            // 
            // cmbPlan
            // 
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(188, 17);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(132, 21);
            this.cmbPlan.TabIndex = 0;
            this.cmbPlan.Text = "Seleccione un plan";
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPLan_SelectedIndexChanged);
            // 
            // texBoxNombrePlan
            // 
            this.texBoxNombrePlan.Location = new System.Drawing.Point(188, 62);
            this.texBoxNombrePlan.Name = "texBoxNombrePlan";
            this.texBoxNombrePlan.Size = new System.Drawing.Size(132, 20);
            this.texBoxNombrePlan.TabIndex = 1;
            // 
            // txtBoxCantCuotas
            // 
            this.txtBoxCantCuotas.Location = new System.Drawing.Point(188, 108);
            this.txtBoxCantCuotas.Name = "txtBoxCantCuotas";
            this.txtBoxCantCuotas.Size = new System.Drawing.Size(132, 20);
            this.txtBoxCantCuotas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cantidad de Cuotas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tasa Anual Efectiva sin IVA";
            // 
            // txtBoxTasaAnualSinIVA
            // 
            this.txtBoxTasaAnualSinIVA.Location = new System.Drawing.Point(188, 152);
            this.txtBoxTasaAnualSinIVA.Name = "txtBoxTasaAnualSinIVA";
            this.txtBoxTasaAnualSinIVA.Size = new System.Drawing.Size(132, 20);
            this.txtBoxTasaAnualSinIVA.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre del Plan";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkVigencia);
            this.panel1.Controls.Add(this.lblErrorGenerico);
            this.panel1.Controls.Add(this.lblIva);
            this.panel1.Controls.Add(this.lblTasaAnual);
            this.panel1.Controls.Add(this.lblCantCuotas);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBoxIVA);
            this.panel1.Controls.Add(this.txtBoxTasaAnualSinIVA);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxCantCuotas);
            this.panel1.Controls.Add(this.texBoxNombrePlan);
            this.panel1.Controls.Add(this.cmbPlan);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 292);
            this.panel1.TabIndex = 0;
            // 
            // chkVigencia
            // 
            this.chkVigencia.AutoSize = true;
            this.chkVigencia.Checked = true;
            this.chkVigencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVigencia.Location = new System.Drawing.Point(188, 230);
            this.chkVigencia.Name = "chkVigencia";
            this.chkVigencia.Size = new System.Drawing.Size(108, 17);
            this.chkVigencia.TabIndex = 12;
            this.chkVigencia.Text = "Habilitar Vigencia";
            this.chkVigencia.UseVisualStyleBackColor = true;
            // 
            // lblErrorGenerico
            // 
            this.lblErrorGenerico.AutoSize = true;
            this.lblErrorGenerico.ForeColor = System.Drawing.Color.Red;
            this.lblErrorGenerico.Location = new System.Drawing.Point(185, 267);
            this.lblErrorGenerico.Name = "lblErrorGenerico";
            this.lblErrorGenerico.Size = new System.Drawing.Size(35, 13);
            this.lblErrorGenerico.TabIndex = 11;
            this.lblErrorGenerico.Text = "label5";
            this.lblErrorGenerico.Visible = false;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.ForeColor = System.Drawing.Color.Red;
            this.lblIva.Location = new System.Drawing.Point(330, 194);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(35, 13);
            this.lblIva.TabIndex = 10;
            this.lblIva.Text = "label5";
            this.lblIva.Visible = false;
            // 
            // lblTasaAnual
            // 
            this.lblTasaAnual.AutoSize = true;
            this.lblTasaAnual.ForeColor = System.Drawing.Color.Red;
            this.lblTasaAnual.Location = new System.Drawing.Point(330, 158);
            this.lblTasaAnual.Name = "lblTasaAnual";
            this.lblTasaAnual.Size = new System.Drawing.Size(35, 13);
            this.lblTasaAnual.TabIndex = 10;
            this.lblTasaAnual.Text = "label5";
            this.lblTasaAnual.Visible = false;
            // 
            // lblCantCuotas
            // 
            this.lblCantCuotas.AutoSize = true;
            this.lblCantCuotas.ForeColor = System.Drawing.Color.Red;
            this.lblCantCuotas.Location = new System.Drawing.Point(327, 114);
            this.lblCantCuotas.Name = "lblCantCuotas";
            this.lblCantCuotas.Size = new System.Drawing.Size(35, 13);
            this.lblCantCuotas.TabIndex = 9;
            this.lblCantCuotas.Text = "label5";
            this.lblCantCuotas.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.Red;
            this.lblNombre.Location = new System.Drawing.Point(327, 68);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "label5";
            this.lblNombre.Visible = false;
            // 
            // txtBoxIVA
            // 
            this.txtBoxIVA.Location = new System.Drawing.Point(188, 191);
            this.txtBoxIVA.Name = "txtBoxIVA";
            this.txtBoxIVA.Size = new System.Drawing.Size(132, 20);
            this.txtBoxIVA.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "% IVA a sumar a Tasa Anual";
            // 
            // frmPlanDePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalirPlan);
            this.Controls.Add(this.btnCancelarPlan);
            this.Controls.Add(this.btnGuardarPlan);
            this.Controls.Add(this.btnEliminarPlan);
            this.Controls.Add(this.btnEditarPlan);
            this.Controls.Add(this.btnNuevoPlan);
            this.MaximizeBox = false;
            this.Name = "frmPlanDePrestamo";
            this.Text = "Plan de Préstamo";
            this.Load += new System.EventHandler(this.frmPlanDePrestamo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalirPlan;
        private System.Windows.Forms.Button btnCancelarPlan;
        private System.Windows.Forms.Button btnGuardarPlan;
        private System.Windows.Forms.Button btnEliminarPlan;
        private System.Windows.Forms.Button btnEditarPlan;
        private System.Windows.Forms.Button btnNuevoPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.TextBox texBoxNombrePlan;
        private System.Windows.Forms.TextBox txtBoxCantCuotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxTasaAnualSinIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCantCuotas;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTasaAnual;
        private System.Windows.Forms.Label lblErrorGenerico;
        private System.Windows.Forms.CheckBox chkVigencia;
        private System.Windows.Forms.TextBox txtBoxIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIva;
    }
}