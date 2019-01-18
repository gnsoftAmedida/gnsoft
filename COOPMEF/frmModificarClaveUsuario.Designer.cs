namespace COOPMEF
{
    partial class frmModificarClaveUsuario
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaveAnterior = new System.Windows.Forms.TextBox();
            this.txtConfirmacionClave = new System.Windows.Forms.TextBox();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(129, 146);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(214, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Contraseña Anterior";
            // 
            // txtClaveAnterior
            // 
            this.txtClaveAnterior.Location = new System.Drawing.Point(147, 25);
            this.txtClaveAnterior.MaxLength = 49;
            this.txtClaveAnterior.Name = "txtClaveAnterior";
            this.txtClaveAnterior.PasswordChar = '*';
            this.txtClaveAnterior.Size = new System.Drawing.Size(142, 20);
            this.txtClaveAnterior.TabIndex = 16;
            // 
            // txtConfirmacionClave
            // 
            this.txtConfirmacionClave.Location = new System.Drawing.Point(147, 102);
            this.txtConfirmacionClave.MaxLength = 49;
            this.txtConfirmacionClave.Name = "txtConfirmacionClave";
            this.txtConfirmacionClave.PasswordChar = '*';
            this.txtConfirmacionClave.Size = new System.Drawing.Size(142, 20);
            this.txtConfirmacionClave.TabIndex = 18;
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.Location = new System.Drawing.Point(147, 64);
            this.txtClaveNueva.MaxLength = 49;
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PasswordChar = '*';
            this.txtClaveNueva.Size = new System.Drawing.Size(142, 20);
            this.txtClaveNueva.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Confirmar Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Contraseña Nueva";
            // 
            // frmModificarClaveUsuario
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(307, 186);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClaveAnterior);
            this.Controls.Add(this.txtConfirmacionClave);
            this.Controls.Add(this.txtClaveNueva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmModificarClaveUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Clave Usuario";
            this.Load += new System.EventHandler(this.frmModificarClaveUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaveAnterior;
        private System.Windows.Forms.TextBox txtConfirmacionClave;
        private System.Windows.Forms.TextBox txtClaveNueva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}