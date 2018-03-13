using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace COOPMEF
{
    public partial class frmBanco : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsBancos;
        private bool nuevo = true;

        public frmBanco()
        {
            InitializeComponent();
        }

        private void btnSalirBanco_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBanco_Load(object sender, EventArgs e)
        {
            //Cargo Bancos
            dsBancos = empresa.DevolverBancos();
            pantallaInicial();
        }

        public void pantallaInicial()
        {
            this.cmbBusqueda.DataSource = dsBancos.Tables["bancos"];
            this.cmbBusqueda.DisplayMember = "nombrebanco";
            this.cmbBusqueda.ValueMember = "codigobanco";
            this.cmbBusqueda.SelectedIndex = -1;
            this.cmbBusqueda.Enabled = true;

            this.btnNuevoBanco.Enabled = true;

            this.txtCodigoBanco.Clear();
            this.txtCodigoBanco.Enabled = false;
            this.lblCodigoBanco.Visible = false;

            this.txtNombreBanco.Clear();
            this.txtNombreBanco.Enabled = false;
            this.lblNombreBanco.Visible = false;

            this.txtAgenciaBanco.Clear();
            this.txtAgenciaBanco.Enabled = false;
            this.lblAgenciaBanco.Visible = false;

            this.txtDireccionBanco.Clear();
            this.txtDireccionBanco.Enabled = false;
            this.lblDireccionBanco.Visible = false;

            this.txtTelefonoBanco.Clear();
            this.txtTelefonoBanco.Enabled = false;
            this.lblTelfonoBanco.Visible = false;

            this.txtFaxBanco.Clear();
            this.txtFaxBanco.Enabled = false;

            this.txtCuentaBanco.Clear();
            this.txtCuentaBanco.Enabled = false;
            this.lblCuentaBanco.Visible = false;

            this.cmbMonedaBanco.Enabled = false;
            this.cmbMonedaBanco.SelectedIndex = 0;

            this.btnEliminarBanco.Enabled = false;
            this.btnEditarBanco.Enabled = false;
            this.btnGuardarBanco.Enabled = false;
            this.btnCancelarBanco.Enabled = false;

            this.lblErrorGenerico.Visible = false;

        }

        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            this.nuevo = true;

            this.cmbBusqueda.Enabled = false;
            this.cmbBusqueda.SelectedIndex = -1;

            this.txtCodigoBanco.Clear();
            this.txtCodigoBanco.Enabled = true;

            this.txtNombreBanco.Clear();
            this.txtNombreBanco.Enabled = true;

            this.txtAgenciaBanco.Clear();
            this.txtAgenciaBanco.Enabled = true;

            this.txtDireccionBanco.Clear();
            this.txtDireccionBanco.Enabled = true;

            this.txtTelefonoBanco.Clear();
            this.txtTelefonoBanco.Enabled = true;

            this.txtFaxBanco.Clear();
            this.txtFaxBanco.Enabled = true;

            this.txtCuentaBanco.Clear();
            this.txtCuentaBanco.Enabled = true;

            this.cmbMonedaBanco.Enabled = true;
            this.cmbMonedaBanco.SelectedIndex = 0;

            this.btnEditarBanco.Enabled = false;
            this.btnEliminarBanco.Enabled = false;
            this.btnCancelarBanco.Enabled = true;
            this.btnGuardarBanco.Enabled = true;
            this.lblErrorGenerico.Visible = false;
        }

        private void btnEliminarBanco_Click(object sender, EventArgs e)
        {
            string message = "¿Está seguro de que desea eliminar al Banco?";
            string caption = "Baja Banco";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int index = this.cmbBusqueda.SelectedIndex;

                try
                {
                    empresa.bajaBanco(Convert.ToInt32(dsBancos.Tables["bancos"].Rows[index][0].ToString()));

                    MessageBox.Show("Banco eliminado correctamente");

                    //Cargo Incisos
                    dsBancos = empresa.DevolverBancos();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void btnCancelarBanco_Click(object sender, EventArgs e)
        {
            this.pantallaInicial();
        }

        private void btnEditarBanco_Click(object sender, EventArgs e)
        {
            this.nuevo = false;

            this.cmbBusqueda.Enabled = false;

            this.txtCodigoBanco.Enabled = false;
            this.txtNombreBanco.Enabled = true;
            this.txtAgenciaBanco.Enabled = true;
            this.txtDireccionBanco.Enabled = true;
            this.txtTelefonoBanco.Enabled = true;
            this.txtFaxBanco.Enabled = true;
            this.txtCuentaBanco.Enabled = true;
            this.cmbMonedaBanco.Enabled = true;

            this.btnNuevoBanco.Enabled = false;
            this.btnEditarBanco.Enabled = true;
            this.btnEliminarBanco.Enabled = false;
            this.btnCancelarBanco.Enabled = true;
            this.btnGuardarBanco.Enabled = true;
            this.lblErrorGenerico.Visible = false;
        }

        private void nuevoBanco()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.txtCodigoBanco.Text.Trim() == "")
            {
                this.lblCodigoBanco.Visible = true;
                this.lblCodigoBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombreBanco.Text.Trim() == "")
            {
                this.lblNombreBanco.Visible = true;
                this.lblNombreBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtAgenciaBanco.Text.Trim() == "")
            {
                this.lblAgenciaBanco.Visible = true;
                this.lblAgenciaBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtDireccionBanco.Text.Trim() == "")
            {
                this.lblDireccionBanco.Visible = true;
                this.lblDireccionBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtTelefonoBanco.Text.Trim() == "")
            {
                this.lblTelfonoBanco.Visible = true;
                this.lblTelfonoBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtCuentaBanco.Text.Trim() == "")
            {
                this.lblCuentaBanco.Visible = true;
                this.lblCuentaBanco.Text = "Campo obligatorio";
                valido = false;
            }


            // Control de duplicado para código. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsBancos.Tables["bancos"].Rows.Count; i++)
            {
                if (this.txtCodigoBanco.Text.Trim() == dsBancos.Tables["bancos"].Rows[i][1].ToString())
                {
                    this.lblCodigoBanco.Visible = true;
                    this.lblCodigoBanco.Text = "Ya exíste";
                    valido = false;
                }
            }

            if (valido)
            {
                try
                {

                    empresa.AltaBanco(this.txtNombreBanco.Text, this.txtAgenciaBanco.Text, this.txtDireccionBanco.Text, this.txtTelefonoBanco.Text, this.txtFaxBanco.Text, this.txtCuentaBanco.Text, this.cmbMonedaBanco.Text);

                    MessageBox.Show("Banco creado correctamente");

                    //Cargo Incisos
                    dsBancos = empresa.DevolverBancos();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void editarBanco()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.txtCodigoBanco.Text.Trim() == "")
            {
                this.lblCodigoBanco.Visible = true;
                this.lblCodigoBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombreBanco.Text.Trim() == "")
            {
                this.lblNombreBanco.Visible = true;
                this.lblNombreBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtAgenciaBanco.Text.Trim() == "")
            {
                this.lblAgenciaBanco.Visible = true;
                this.lblAgenciaBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtDireccionBanco.Text.Trim() == "")
            {
                this.lblDireccionBanco.Visible = true;
                this.lblDireccionBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtTelefonoBanco.Text.Trim() == "")
            {
                this.lblTelfonoBanco.Visible = true;
                this.lblTelfonoBanco.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtCuentaBanco.Text.Trim() == "")
            {
                this.lblCuentaBanco.Visible = true;
                this.lblCuentaBanco.Text = "Campo obligatorio";
                valido = false;
            }

            int index = this.cmbBusqueda.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsBancos.Tables["bancos"].Rows.Count; i++)
            {
                if (Convert.ToInt32(dsBancos.Tables["bancos"].Rows[index][0].ToString()) != Convert.ToInt32(dsBancos.Tables["bancos"].Rows[i][0].ToString()))
                {

                    if (this.txtCodigoBanco.Text.Trim() == dsBancos.Tables["bancos"].Rows[i][1].ToString())
                    {
                        this.lblCodigoBanco.Visible = true;
                        this.lblCodigoBanco.Text = "Ya exíste";
                        valido = false;
                    }
                }
            }

            if (valido)
            {

                string message = "¿Está seguro de que desea modificar el Banco?";
                string caption = "Modificar Banco";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        empresa.modificarBanco(this.txtNombreBanco.Text, this.txtAgenciaBanco.Text, this.txtDireccionBanco.Text, this.txtTelefonoBanco.Text, this.txtFaxBanco.Text, this.txtCuentaBanco.Text, this.cmbMonedaBanco.Text, Convert.ToInt32(dsBancos.Tables["bancos"].Rows[index][0].ToString()));

                        MessageBox.Show("Banco modificado correctamente");

                        //Cargo Banco
                        dsBancos = empresa.DevolverBancos();
                        pantallaInicial();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                }
            }
        }

        private void btnGuardarBanco_Click(object sender, EventArgs e)
        {
            this.lblNombreBanco.Text = "";
            this.lblNombreBanco.Visible = false;

            this.lblCodigoBanco.Text = "";
            this.lblCodigoBanco.Visible = false;

            this.lblAgenciaBanco.Text = "";
            this.lblAgenciaBanco.Visible = false;

            this.lblDireccionBanco.Text = "";
            this.lblDireccionBanco.Visible = false;

            this.lblTelfonoBanco.Text = "";
            this.lblTelfonoBanco.Visible = false;

            this.lblCuentaBanco.Text = "";
            this.lblCuentaBanco.Visible = false;

            this.lblErrorGenerico.Text = "";
            this.lblErrorGenerico.Visible = false;

            if (nuevo)
            {
                this.nuevoBanco();
            }
            else
            {
                this.editarBanco();
            }
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbBusqueda.SelectedIndex;
            if (index != -1)
            {

                this.txtCodigoBanco.Enabled = false;
                this.txtNombreBanco.Enabled = false;
                this.txtAgenciaBanco.Enabled = false;
                this.txtDireccionBanco.Enabled = false;
                this.txtTelefonoBanco.Enabled = false;
                this.txtFaxBanco.Enabled = false;
                this.txtCuentaBanco.Enabled = false;
                this.cmbMonedaBanco.Enabled = false;

                this.btnEliminarBanco.Enabled = true;
                this.btnEditarBanco.Enabled = true;
                this.btnGuardarBanco.Enabled = false;
                this.btnCancelarBanco.Enabled = true;

                this.txtCodigoBanco.Text = dsBancos.Tables["bancos"].Rows[index][0].ToString();
                this.txtNombreBanco.Text = dsBancos.Tables["bancos"].Rows[index][1].ToString();
                this.txtAgenciaBanco.Text = dsBancos.Tables["bancos"].Rows[index][2].ToString();
                this.txtDireccionBanco.Text = dsBancos.Tables["bancos"].Rows[index][3].ToString();
                this.txtTelefonoBanco.Text = dsBancos.Tables["bancos"].Rows[index][4].ToString();
                this.txtFaxBanco.Text = dsBancos.Tables["bancos"].Rows[index][5].ToString();
                this.txtCuentaBanco.Text = dsBancos.Tables["bancos"].Rows[index][6].ToString();
                this.cmbMonedaBanco.Text = dsBancos.Tables["bancos"].Rows[index][7].ToString();
            }
        }
    }
}
