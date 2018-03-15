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
    public partial class frmMovimientosBancarios : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsBancos;

        public frmMovimientosBancarios()
        {
            InitializeComponent();
        }

        private void frmMovimientosBancarios_Load(object sender, EventArgs e)
        {
            //Cargo Bancos
            dsBancos = empresa.DevolverBancos();
            pantallaInicial();
        }


        public void pantallaInicial()
        {
            dsBancos = empresa.DevolverBancos();
            this.cmbBancos.DataSource = dsBancos.Tables["bancos"];
            this.cmbBancos.DisplayMember = "mostrarse";
            this.cmbBancos.ValueMember = "codigobanco";
            this.cmbBancos.SelectedIndex = -1;
            this.cmbBancos.Enabled = true;

            this.rbtCheque.Checked = true;
            this.txtConcepto.Clear();
            this.txtImporte.Clear();
            this.txtNumeroComprobante.Clear();
            this.lblSaldoActual.Text = "0.00";

            this.lblConcepto.Visible = false;
            this.lblComprobante.Visible = false;
            this.lblErrorGenerico.Visible = false;
            this.lblImporteBanco.Visible = false;
        }

        private void btnSalirBanco_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool esDecimal(string nroPrueba)
        {
            double resultado = 0;
            Boolean esDouble = double.TryParse(nroPrueba, out resultado);

            Boolean esPositivo = false;

            if (esDouble)
            {

                if (resultado > 0)
                {
                    esPositivo = true;
                }
            }

            return esDouble && esPositivo;
        }

        private void btnGuardarBanco_Click(object sender, EventArgs e)
        {
            bool valido = true;

            this.lblImporteBanco.Text = "";
            this.lblImporteBanco.Visible = false;

            this.lblConcepto.Text = "";
            this.lblConcepto.Visible = false;

            this.lblComprobante.Text = "";
            this.lblComprobante.Visible = false;

            this.lblErrorGenerico.Text = "";
            this.lblErrorGenerico.Visible = false;

            if (this.txtImporte.Text.Trim() == "")
            {
                this.lblImporteBanco.Visible = true;
                this.lblImporteBanco.Text = "Obligatorio";
                valido = false;
            }

            if (this.txtConcepto.Text.Trim() == "")
            {
                this.lblConcepto.Visible = true;
                this.lblConcepto.Text = "Obligatorio";
                valido = false;
            }

            if (this.txtNumeroComprobante.Text.Trim() == "")
            {
                this.lblComprobante.Visible = true;
                this.lblComprobante.Text = "Obligatorio";
                valido = false;
            }

             if (!esDecimal(txtImporte.Text.Replace(".", ",")) || (!esDecimal(txtImporte.Text.Replace(".", ","))))
            {
                this.lblImporteBanco.Visible = true;
                this.lblImporteBanco.Text = "Numérico";
                valido = false;
            }

            if (valido)
            {
                try
                {
                    int index = this.cmbBancos.SelectedIndex;
                    if (index != -1)
                    {

                        int codigoBanco = Convert.ToInt32(dsBancos.Tables["bancos"].Rows[index][0].ToString());
                        string numeroCuenta = dsBancos.Tables["bancos"].Rows[index][6].ToString();
                        string debeHaber;
                        double saldo = Convert.ToDouble(dsBancos.Tables["bancos"].Rows[index][8].ToString());
                        int factorMultiplicador = 1;

                        if (rbtCheque.Checked)
                        {
                            debeHaber = "Cheque";
                            factorMultiplicador = - factorMultiplicador;
                        }
                        else
                        {
                            debeHaber = "Deposito";
                        }

                        empresa.AltaMovimiento(DateTime.Today, codigoBanco, numeroCuenta, txtNumeroComprobante.Text, debeHaber, Convert.ToDouble(txtImporte.Text), txtConcepto.Text, saldo);

                        empresa.actualizarSaldo(codigoBanco, saldo + factorMultiplicador * (Convert.ToDouble(txtImporte.Text)));

                        MessageBox.Show("Movimiento ingresado correctamente");
                        pantallaInicial();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una cuenta bancaria");
                    }

                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void cmbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbBancos.SelectedIndex;
            if (index != -1)
            {
                this.lblSaldoActual.Text = dsBancos.Tables["bancos"].Rows[index][8].ToString();
            }
        }
    }
}
