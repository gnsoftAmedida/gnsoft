namespace COOPMEF
{
    partial class frmModificarUsuario
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
            this.groupBoxPermisos = new System.Windows.Forms.GroupBox();
            this.checkBoxSeleccionarTodo = new System.Windows.Forms.CheckBox();
            this.checkedListPermisos = new System.Windows.Forms.CheckedListBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBoxPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPermisos
            // 
            this.groupBoxPermisos.Controls.Add(this.checkBoxSeleccionarTodo);
            this.groupBoxPermisos.Controls.Add(this.checkedListPermisos);
            this.groupBoxPermisos.Location = new System.Drawing.Point(19, 139);
            this.groupBoxPermisos.Name = "groupBoxPermisos";
            this.groupBoxPermisos.Size = new System.Drawing.Size(267, 200);
            this.groupBoxPermisos.TabIndex = 48;
            this.groupBoxPermisos.TabStop = false;
            this.groupBoxPermisos.Text = "Permisos";
            // 
            // checkBoxSeleccionarTodo
            // 
            this.checkBoxSeleccionarTodo.AutoSize = true;
            this.checkBoxSeleccionarTodo.Location = new System.Drawing.Point(14, 20);
            this.checkBoxSeleccionarTodo.Name = "checkBoxSeleccionarTodo";
            this.checkBoxSeleccionarTodo.Size = new System.Drawing.Size(189, 17);
            this.checkBoxSeleccionarTodo.TabIndex = 0;
            this.checkBoxSeleccionarTodo.Text = "Seleccionar / Deseleccionar Todo";
            this.checkBoxSeleccionarTodo.UseVisualStyleBackColor = true;
            this.checkBoxSeleccionarTodo.CheckedChanged += new System.EventHandler(this.checkBoxSeleccionarTodo_CheckedChanged_1);
            // 
            // checkedListPermisos
            // 
            this.checkedListPermisos.FormattingEnabled = true;
            this.checkedListPermisos.Location = new System.Drawing.Point(14, 48);
            this.checkedListPermisos.Name = "checkedListPermisos";
            this.checkedListPermisos.Size = new System.Drawing.Size(244, 139);
            this.checkedListPermisos.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(135, 96);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(142, 20);
            this.txtTelefono.TabIndex = 44;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(135, 60);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(142, 20);
            this.txtCorreo.TabIndex = 43;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(135, 24);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(142, 20);
            this.txtAlias.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Número Celular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Correo Electrónico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Nombre (Alias)";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(130, 345);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 50;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(211, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmModificarUsuario
            // 
            this.AcceptButton = this.btnModificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(298, 377);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBoxPermisos);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "frmModificarUsuario";
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.frmModificarUsuario_Load);
            this.groupBoxPermisos.ResumeLayout(false);
            this.groupBoxPermisos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPermisos;
        private System.Windows.Forms.CheckBox checkBoxSeleccionarTodo;
        private System.Windows.Forms.CheckedListBox checkedListPermisos;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;

    }
}