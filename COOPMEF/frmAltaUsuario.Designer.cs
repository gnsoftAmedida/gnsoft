namespace COOPMEF
{
    partial class frmAltaUsuario
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
            this.txtConfirmacionClave = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBoxPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPermisos
            // 
            this.groupBoxPermisos.Controls.Add(this.checkBoxSeleccionarTodo);
            this.groupBoxPermisos.Controls.Add(this.checkedListPermisos);
            this.groupBoxPermisos.Location = new System.Drawing.Point(325, 21);
            this.groupBoxPermisos.Name = "groupBoxPermisos";
            this.groupBoxPermisos.Size = new System.Drawing.Size(227, 185);
            this.groupBoxPermisos.TabIndex = 33;
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
            this.checkedListPermisos.Size = new System.Drawing.Size(200, 124);
            this.checkedListPermisos.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(151, 188);
            this.txtTelefono.MaxLength = 44;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(142, 20);
            this.txtTelefono.TabIndex = 31;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(151, 152);
            this.txtCorreo.MaxLength = 44;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(142, 20);
            this.txtCorreo.TabIndex = 29;
            // 
            // txtConfirmacionClave
            // 
            this.txtConfirmacionClave.Location = new System.Drawing.Point(151, 114);
            this.txtConfirmacionClave.MaxLength = 49;
            this.txtConfirmacionClave.Name = "txtConfirmacionClave";
            this.txtConfirmacionClave.PasswordChar = '*';
            this.txtConfirmacionClave.Size = new System.Drawing.Size(142, 20);
            this.txtConfirmacionClave.TabIndex = 26;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(151, 76);
            this.txtClave.MaxLength = 49;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(142, 20);
            this.txtClave.TabIndex = 23;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(151, 38);
            this.txtAlias.MaxLength = 44;
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(142, 20);
            this.txtAlias.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Número Celular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Correo Electrónico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Confirmar Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nombre (Alias)";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(392, 222);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 34;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(477, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAltaUsuario
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(574, 253);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBoxPermisos);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtConfirmacionClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmAltaUsuario";
            this.Text = "Alta Usuario";
            this.Load += new System.EventHandler(this.AltaUsuario_Load);
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
        private System.Windows.Forms.TextBox txtConfirmacionClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}