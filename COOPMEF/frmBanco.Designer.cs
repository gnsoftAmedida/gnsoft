﻿namespace COOPMEF
{
    partial class frmBanco
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
            this.btnSalirBanco = new System.Windows.Forms.Button();
            this.btnCancelarBanco = new System.Windows.Forms.Button();
            this.btnGuardarBanco = new System.Windows.Forms.Button();
            this.btnEliminarBanco = new System.Windows.Forms.Button();
            this.btnEditarBanco = new System.Windows.Forms.Button();
            this.btnNuevoBanco = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.cmbMonedaBanco = new System.Windows.Forms.ComboBox();
            this.txtCuentaBanco = new System.Windows.Forms.TextBox();
            this.txtFaxBanco = new System.Windows.Forms.TextBox();
            this.txtDireccionBanco = new System.Windows.Forms.TextBox();
            this.txtTelefonoBanco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorGenerico = new System.Windows.Forms.Label();
            this.lblCuentaBanco = new System.Windows.Forms.Label();
            this.lblTelfonoBanco = new System.Windows.Forms.Label();
            this.lblDireccionBanco = new System.Windows.Forms.Label();
            this.lblAgenciaBanco = new System.Windows.Forms.Label();
            this.lblCodigoBanco = new System.Windows.Forms.Label();
            this.lblNombreBanco = new System.Windows.Forms.Label();
            this.txtCodigoBanco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.txtNombreBanco = new System.Windows.Forms.TextBox();
            this.txtAgenciaBanco = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalirBanco
            // 
            this.btnSalirBanco.Image = global::COOPMEF.Properties.Resources._1486109187_Log_Out;
            this.btnSalirBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalirBanco.Location = new System.Drawing.Point(523, 219);
            this.btnSalirBanco.Name = "btnSalirBanco";
            this.btnSalirBanco.Size = new System.Drawing.Size(96, 29);
            this.btnSalirBanco.TabIndex = 5;
            this.btnSalirBanco.Text = "     Salir";
            this.btnSalirBanco.UseVisualStyleBackColor = true;
            this.btnSalirBanco.Click += new System.EventHandler(this.btnSalirBanco_Click);
            // 
            // btnCancelarBanco
            // 
            this.btnCancelarBanco.Image = global::COOPMEF.Properties.Resources._1486109207_Cancel;
            this.btnCancelarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelarBanco.Location = new System.Drawing.Point(523, 176);
            this.btnCancelarBanco.Name = "btnCancelarBanco";
            this.btnCancelarBanco.Size = new System.Drawing.Size(96, 29);
            this.btnCancelarBanco.TabIndex = 4;
            this.btnCancelarBanco.Text = "     Cancelar";
            this.btnCancelarBanco.UseVisualStyleBackColor = true;
            this.btnCancelarBanco.Click += new System.EventHandler(this.btnCancelarBanco_Click);
            // 
            // btnGuardarBanco
            // 
            this.btnGuardarBanco.Image = global::COOPMEF.Properties.Resources._1486108920_Save;
            this.btnGuardarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardarBanco.Location = new System.Drawing.Point(523, 138);
            this.btnGuardarBanco.Name = "btnGuardarBanco";
            this.btnGuardarBanco.Size = new System.Drawing.Size(96, 31);
            this.btnGuardarBanco.TabIndex = 3;
            this.btnGuardarBanco.Text = "     Guardar";
            this.btnGuardarBanco.UseVisualStyleBackColor = true;
            this.btnGuardarBanco.Click += new System.EventHandler(this.btnGuardarBanco_Click);
            // 
            // btnEliminarBanco
            // 
            this.btnEliminarBanco.Image = global::COOPMEF.Properties.Resources.delete16;
            this.btnEliminarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminarBanco.Location = new System.Drawing.Point(523, 98);
            this.btnEliminarBanco.Name = "btnEliminarBanco";
            this.btnEliminarBanco.Size = new System.Drawing.Size(96, 30);
            this.btnEliminarBanco.TabIndex = 2;
            this.btnEliminarBanco.Text = "     Eliminar";
            this.btnEliminarBanco.UseVisualStyleBackColor = true;
            this.btnEliminarBanco.Click += new System.EventHandler(this.btnEliminarBanco_Click);
            // 
            // btnEditarBanco
            // 
            this.btnEditarBanco.Image = global::COOPMEF.Properties.Resources._1486109481_edit_file;
            this.btnEditarBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditarBanco.Location = new System.Drawing.Point(523, 62);
            this.btnEditarBanco.Name = "btnEditarBanco";
            this.btnEditarBanco.Size = new System.Drawing.Size(96, 30);
            this.btnEditarBanco.TabIndex = 1;
            this.btnEditarBanco.Text = "     Editar";
            this.btnEditarBanco.UseVisualStyleBackColor = true;
            this.btnEditarBanco.Click += new System.EventHandler(this.btnEditarBanco_Click);
            // 
            // btnNuevoBanco
            // 
            this.btnNuevoBanco.Image = global::COOPMEF.Properties.Resources._1486109530_new_file;
            this.btnNuevoBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNuevoBanco.Location = new System.Drawing.Point(523, 25);
            this.btnNuevoBanco.Name = "btnNuevoBanco";
            this.btnNuevoBanco.Size = new System.Drawing.Size(96, 30);
            this.btnNuevoBanco.TabIndex = 0;
            this.btnNuevoBanco.Text = "    Nuevo";
            this.btnNuevoBanco.UseVisualStyleBackColor = true;
            this.btnNuevoBanco.Click += new System.EventHandler(this.btnNuevoBanco_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.cmbMonedaBanco);
            this.groupBox12.Controls.Add(this.txtCuentaBanco);
            this.groupBox12.Controls.Add(this.txtFaxBanco);
            this.groupBox12.Controls.Add(this.txtDireccionBanco);
            this.groupBox12.Controls.Add(this.txtTelefonoBanco);
            this.groupBox12.Controls.Add(this.label2);
            this.groupBox12.Controls.Add(this.label3);
            this.groupBox12.Controls.Add(this.label4);
            this.groupBox12.Controls.Add(this.lblErrorGenerico);
            this.groupBox12.Controls.Add(this.lblCuentaBanco);
            this.groupBox12.Controls.Add(this.lblTelfonoBanco);
            this.groupBox12.Controls.Add(this.lblDireccionBanco);
            this.groupBox12.Controls.Add(this.lblAgenciaBanco);
            this.groupBox12.Controls.Add(this.lblCodigoBanco);
            this.groupBox12.Controls.Add(this.lblNombreBanco);
            this.groupBox12.Controls.Add(this.txtCodigoBanco);
            this.groupBox12.Controls.Add(this.label1);
            this.groupBox12.Controls.Add(this.cmbBusqueda);
            this.groupBox12.Controls.Add(this.txtNombreBanco);
            this.groupBox12.Controls.Add(this.txtAgenciaBanco);
            this.groupBox12.Controls.Add(this.label31);
            this.groupBox12.Controls.Add(this.label30);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(10, 11);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(478, 318);
            this.groupBox12.TabIndex = 12;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Mantenimiento de Bancos";
            // 
            // cmbMonedaBanco
            // 
            this.cmbMonedaBanco.FormattingEnabled = true;
            this.cmbMonedaBanco.Items.AddRange(new object[] {
            "Dólares",
            "Pesos"});
            this.cmbMonedaBanco.Location = new System.Drawing.Point(270, 241);
            this.cmbMonedaBanco.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMonedaBanco.MaxLength = 45;
            this.cmbMonedaBanco.Name = "cmbMonedaBanco";
            this.cmbMonedaBanco.Size = new System.Drawing.Size(105, 23);
            this.cmbMonedaBanco.TabIndex = 8;
            // 
            // txtCuentaBanco
            // 
            this.txtCuentaBanco.Location = new System.Drawing.Point(160, 241);
            this.txtCuentaBanco.MaxLength = 45;
            this.txtCuentaBanco.Name = "txtCuentaBanco";
            this.txtCuentaBanco.Size = new System.Drawing.Size(105, 23);
            this.txtCuentaBanco.TabIndex = 7;
            // 
            // txtFaxBanco
            // 
            this.txtFaxBanco.Location = new System.Drawing.Point(270, 206);
            this.txtFaxBanco.MaxLength = 45;
            this.txtFaxBanco.Name = "txtFaxBanco";
            this.txtFaxBanco.Size = new System.Drawing.Size(105, 23);
            this.txtFaxBanco.TabIndex = 6;
            // 
            // txtDireccionBanco
            // 
            this.txtDireccionBanco.Location = new System.Drawing.Point(160, 165);
            this.txtDireccionBanco.MaxLength = 150;
            this.txtDireccionBanco.Name = "txtDireccionBanco";
            this.txtDireccionBanco.Size = new System.Drawing.Size(173, 23);
            this.txtDireccionBanco.TabIndex = 4;
            // 
            // txtTelefonoBanco
            // 
            this.txtTelefonoBanco.Location = new System.Drawing.Point(160, 205);
            this.txtTelefonoBanco.MaxLength = 45;
            this.txtTelefonoBanco.Name = "txtTelefonoBanco";
            this.txtTelefonoBanco.Size = new System.Drawing.Size(105, 23);
            this.txtTelefonoBanco.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(18, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nº Cuenta / Mon.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(18, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Teléfono / FAX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(18, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Dirección";
            // 
            // lblErrorGenerico
            // 
            this.lblErrorGenerico.AutoSize = true;
            this.lblErrorGenerico.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorGenerico.ForeColor = System.Drawing.Color.Red;
            this.lblErrorGenerico.Location = new System.Drawing.Point(18, 292);
            this.lblErrorGenerico.Name = "lblErrorGenerico";
            this.lblErrorGenerico.Size = new System.Drawing.Size(39, 12);
            this.lblErrorGenerico.TabIndex = 30;
            this.lblErrorGenerico.Text = "label2";
            // 
            // lblCuentaBanco
            // 
            this.lblCuentaBanco.AutoSize = true;
            this.lblCuentaBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaBanco.ForeColor = System.Drawing.Color.Red;
            this.lblCuentaBanco.Location = new System.Drawing.Point(380, 245);
            this.lblCuentaBanco.Name = "lblCuentaBanco";
            this.lblCuentaBanco.Size = new System.Drawing.Size(39, 12);
            this.lblCuentaBanco.TabIndex = 30;
            this.lblCuentaBanco.Text = "label2";
            // 
            // lblTelfonoBanco
            // 
            this.lblTelfonoBanco.AutoSize = true;
            this.lblTelfonoBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelfonoBanco.ForeColor = System.Drawing.Color.Red;
            this.lblTelfonoBanco.Location = new System.Drawing.Point(380, 210);
            this.lblTelfonoBanco.Name = "lblTelfonoBanco";
            this.lblTelfonoBanco.Size = new System.Drawing.Size(39, 12);
            this.lblTelfonoBanco.TabIndex = 30;
            this.lblTelfonoBanco.Text = "label2";
            // 
            // lblDireccionBanco
            // 
            this.lblDireccionBanco.AutoSize = true;
            this.lblDireccionBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionBanco.ForeColor = System.Drawing.Color.Red;
            this.lblDireccionBanco.Location = new System.Drawing.Point(338, 169);
            this.lblDireccionBanco.Name = "lblDireccionBanco";
            this.lblDireccionBanco.Size = new System.Drawing.Size(39, 12);
            this.lblDireccionBanco.TabIndex = 30;
            this.lblDireccionBanco.Text = "label2";
            // 
            // lblAgenciaBanco
            // 
            this.lblAgenciaBanco.AutoSize = true;
            this.lblAgenciaBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgenciaBanco.ForeColor = System.Drawing.Color.Red;
            this.lblAgenciaBanco.Location = new System.Drawing.Point(295, 144);
            this.lblAgenciaBanco.Name = "lblAgenciaBanco";
            this.lblAgenciaBanco.Size = new System.Drawing.Size(39, 12);
            this.lblAgenciaBanco.TabIndex = 30;
            this.lblAgenciaBanco.Text = "label2";
            // 
            // lblCodigoBanco
            // 
            this.lblCodigoBanco.AutoSize = true;
            this.lblCodigoBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoBanco.ForeColor = System.Drawing.Color.Red;
            this.lblCodigoBanco.Location = new System.Drawing.Point(250, 82);
            this.lblCodigoBanco.Name = "lblCodigoBanco";
            this.lblCodigoBanco.Size = new System.Drawing.Size(39, 12);
            this.lblCodigoBanco.TabIndex = 30;
            this.lblCodigoBanco.Text = "label2";
            // 
            // lblNombreBanco
            // 
            this.lblNombreBanco.AutoSize = true;
            this.lblNombreBanco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreBanco.ForeColor = System.Drawing.Color.Red;
            this.lblNombreBanco.Location = new System.Drawing.Point(370, 113);
            this.lblNombreBanco.Name = "lblNombreBanco";
            this.lblNombreBanco.Size = new System.Drawing.Size(39, 12);
            this.lblNombreBanco.TabIndex = 30;
            this.lblNombreBanco.Text = "label2";
            // 
            // txtCodigoBanco
            // 
            this.txtCodigoBanco.Location = new System.Drawing.Point(159, 71);
            this.txtCodigoBanco.MaxLength = 10;
            this.txtCodigoBanco.Name = "txtCodigoBanco";
            this.txtCodigoBanco.Size = new System.Drawing.Size(85, 23);
            this.txtCodigoBanco.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Código";
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(159, 41);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(286, 24);
            this.cmbBusqueda.TabIndex = 0;
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.Location = new System.Drawing.Point(159, 102);
            this.txtNombreBanco.MaxLength = 100;
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.Size = new System.Drawing.Size(205, 23);
            this.txtNombreBanco.TabIndex = 2;
            // 
            // txtAgenciaBanco
            // 
            this.txtAgenciaBanco.Location = new System.Drawing.Point(159, 133);
            this.txtAgenciaBanco.MaxLength = 100;
            this.txtAgenciaBanco.Name = "txtAgenciaBanco";
            this.txtAgenciaBanco.Size = new System.Drawing.Size(130, 23);
            this.txtAgenciaBanco.TabIndex = 3;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(17, 136);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 17);
            this.label31.TabIndex = 2;
            this.label31.Text = "Agencia";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(17, 105);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 17);
            this.label30.TabIndex = 1;
            this.label30.Text = "Nombre";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(17, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(55, 17);
            this.label28.TabIndex = 0;
            this.label28.Text = "Banco";
            // 
            // frmBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 345);
            this.Controls.Add(this.btnSalirBanco);
            this.Controls.Add(this.btnCancelarBanco);
            this.Controls.Add(this.btnGuardarBanco);
            this.Controls.Add(this.btnEliminarBanco);
            this.Controls.Add(this.btnEditarBanco);
            this.Controls.Add(this.btnNuevoBanco);
            this.Controls.Add(this.groupBox12);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Bancos";
            this.Load += new System.EventHandler(this.frmBanco_Load);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalirBanco;
        private System.Windows.Forms.Button btnCancelarBanco;
        private System.Windows.Forms.Button btnGuardarBanco;
        private System.Windows.Forms.Button btnEliminarBanco;
        private System.Windows.Forms.Button btnEditarBanco;
        private System.Windows.Forms.Button btnNuevoBanco;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label lblErrorGenerico;
        private System.Windows.Forms.Label lblAgenciaBanco;
        private System.Windows.Forms.Label lblCodigoBanco;
        private System.Windows.Forms.Label lblNombreBanco;
        private System.Windows.Forms.TextBox txtCodigoBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusqueda;
        private System.Windows.Forms.TextBox txtNombreBanco;
        private System.Windows.Forms.TextBox txtAgenciaBanco;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtCuentaBanco;
        private System.Windows.Forms.TextBox txtFaxBanco;
        private System.Windows.Forms.TextBox txtDireccionBanco;
        private System.Windows.Forms.TextBox txtTelefonoBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonedaBanco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCuentaBanco;
        private System.Windows.Forms.Label lblTelfonoBanco;
        private System.Windows.Forms.Label lblDireccionBanco;
    }
}