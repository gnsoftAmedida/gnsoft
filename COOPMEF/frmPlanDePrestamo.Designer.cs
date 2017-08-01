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
            this.texBoxDescripcion = new System.Windows.Forms.TextBox();
            this.txtBoxCantCuotas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxInteres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCantCuotas = new System.Windows.Forms.Label();
            this.lblInteres = new System.Windows.Forms.Label();
            this.lblErrorGenerico = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalirPlan
            // 
            this.btnSalirPlan.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirPlan.Location = new System.Drawing.Point(336, 234);
            this.btnSalirPlan.Name = "btnSalirPlan";
            this.btnSalirPlan.Size = new System.Drawing.Size(96, 29);
            this.btnSalirPlan.TabIndex = 35;
            this.btnSalirPlan.Text = "     Salir";
            this.btnSalirPlan.UseVisualStyleBackColor = true;
            this.btnSalirPlan.Click += new System.EventHandler(this.btnSalirPlan_Click);
            // 
            // btnCancelarPlan
            // 
            this.btnCancelarPlan.Image = global::COOPMEF.Properties.Resources._1486109207_Cancel;
            this.btnCancelarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarPlan.Location = new System.Drawing.Point(224, 233);
            this.btnCancelarPlan.Name = "btnCancelarPlan";
            this.btnCancelarPlan.Size = new System.Drawing.Size(96, 29);
            this.btnCancelarPlan.TabIndex = 34;
            this.btnCancelarPlan.Text = "     Cancelar";
            this.btnCancelarPlan.UseVisualStyleBackColor = true;
            this.btnCancelarPlan.Click += new System.EventHandler(this.btnCancelarPlan_Click);
            // 
            // btnGuardarPlan
            // 
            this.btnGuardarPlan.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarPlan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarPlan.Location = new System.Drawing.Point(112, 233);
            this.btnGuardarPlan.Name = "btnGuardarPlan";
            this.btnGuardarPlan.Size = new System.Drawing.Size(96, 31);
            this.btnGuardarPlan.TabIndex = 33;
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
            this.btnEliminarPlan.TabIndex = 32;
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
            this.btnEditarPlan.TabIndex = 31;
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
            this.btnNuevoPlan.TabIndex = 30;
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
            // texBoxDescripcion
            // 
            this.texBoxDescripcion.Location = new System.Drawing.Point(188, 62);
            this.texBoxDescripcion.Name = "texBoxDescripcion";
            this.texBoxDescripcion.Size = new System.Drawing.Size(132, 20);
            this.texBoxDescripcion.TabIndex = 1;
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
            this.label2.Location = new System.Drawing.Point(97, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cant Cuotas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Interés";
            // 
            // txtBoxInteres
            // 
            this.txtBoxInteres.Location = new System.Drawing.Point(188, 152);
            this.txtBoxInteres.Name = "txtBoxInteres";
            this.txtBoxInteres.Size = new System.Drawing.Size(132, 20);
            this.txtBoxInteres.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripción";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblErrorGenerico);
            this.panel1.Controls.Add(this.lblInteres);
            this.panel1.Controls.Add(this.lblCantCuotas);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBoxInteres);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxCantCuotas);
            this.panel1.Controls.Add(this.texBoxDescripcion);
            this.panel1.Controls.Add(this.cmbPlan);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 215);
            this.panel1.TabIndex = 36;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.Red;
            this.lblDescripcion.Location = new System.Drawing.Point(327, 68);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(35, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "label5";
            this.lblDescripcion.Visible = false;
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
            // lblInteres
            // 
            this.lblInteres.AutoSize = true;
            this.lblInteres.ForeColor = System.Drawing.Color.Red;
            this.lblInteres.Location = new System.Drawing.Point(330, 158);
            this.lblInteres.Name = "lblInteres";
            this.lblInteres.Size = new System.Drawing.Size(35, 13);
            this.lblInteres.TabIndex = 10;
            this.lblInteres.Text = "label5";
            this.lblInteres.Visible = false;
            // 
            // lblErrorGenerico
            // 
            this.lblErrorGenerico.AutoSize = true;
            this.lblErrorGenerico.ForeColor = System.Drawing.Color.Red;
            this.lblErrorGenerico.Location = new System.Drawing.Point(185, 189);
            this.lblErrorGenerico.Name = "lblErrorGenerico";
            this.lblErrorGenerico.Size = new System.Drawing.Size(35, 13);
            this.lblErrorGenerico.TabIndex = 11;
            this.lblErrorGenerico.Text = "label5";
            this.lblErrorGenerico.Visible = false;
            // 
            // frmPlanDePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 274);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalirPlan);
            this.Controls.Add(this.btnCancelarPlan);
            this.Controls.Add(this.btnGuardarPlan);
            this.Controls.Add(this.btnEliminarPlan);
            this.Controls.Add(this.btnEditarPlan);
            this.Controls.Add(this.btnNuevoPlan);
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
        private System.Windows.Forms.TextBox texBoxDescripcion;
        private System.Windows.Forms.TextBox txtBoxCantCuotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxInteres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCantCuotas;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblInteres;
        private System.Windows.Forms.Label lblErrorGenerico;
    }
}