using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using COOPMEF.CrystalDataSets;

namespace COOPMEF
{
    public partial class frmCuentaCorriente : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsBancos;
        private dsCuentaCorriente tablaCuentaCorriente = new dsCuentaCorriente();

        public frmCuentaCorriente()
        {
            InitializeComponent();
        }

        private void frmCuentaCorriente_Load(object sender, EventArgs e)
        {
            dsBancos = empresa.DevolverBancos();
            pantallaInicial();
        }

        public void pantallaInicial()
        {
            this.cmbBusqueda.DataSource = dsBancos.Tables["bancos"];
            this.cmbBusqueda.DisplayMember = "mostrarse";
            this.cmbBusqueda.ValueMember = "codigobanco";
            this.cmbBusqueda.SelectedIndex = -1;
            this.cmbBusqueda.Enabled = true;
            this.cmbBusqueda.SelectedIndex = 1;
        }

        private void btnSalirBanco_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            string id_banco = cmbBusqueda.SelectedValue.ToString();
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;
            String concepto = txtConcepto.Text;
            Double totalHaber = 0;
            Double totalDebe = 0;

            DataSet cuentaCorriente = empresa.devolverCuentaCorriente(Convert.ToInt32(id_banco), fechaDesde, fechaHasta, concepto);

            if (cuentaCorriente.Tables["cuentacorriente"].Rows.Count > 0)
            {
                if (cuentaCorriente.Tables["cuentacorriente"].Rows.Count > 0)
                {
                    for (int n = 0; n <= cuentaCorriente.Tables["cuentacorriente"].Rows.Count - 1; n++)
                    {
                        string nombrebanco = cuentaCorriente.Tables["cuentacorriente"].Rows[n][0].ToString();
                        string numerocta = cuentaCorriente.Tables["cuentacorriente"].Rows[n][1].ToString();
                        string moneda = cuentaCorriente.Tables["cuentacorriente"].Rows[n][2].ToString();
                        string movimiento = cuentaCorriente.Tables["cuentacorriente"].Rows[n][3].ToString();
                        DateTime fecha = Convert.ToDateTime(cuentaCorriente.Tables["cuentacorriente"].Rows[n][4].ToString());
                        string numerodocumento = cuentaCorriente.Tables["cuentacorriente"].Rows[n][5].ToString();
                        string conceptoCompleto = cuentaCorriente.Tables["cuentacorriente"].Rows[n][6].ToString();
                        string debehaber = cuentaCorriente.Tables["cuentacorriente"].Rows[n][7].ToString();
                        string importe = cuentaCorriente.Tables["cuentacorriente"].Rows[n][8].ToString();
                        string saldo = cuentaCorriente.Tables["cuentacorriente"].Rows[n][9].ToString();

                        string fechaActual = DateTime.Today.ToLongDateString();

                        string debe = "";
                        string haber = "";

                        if (debehaber == "Deposito")
                        {
                            debe = "";
                            haber = importe;
                            totalHaber = totalHaber + Convert.ToDouble(importe);

                            saldo = (Convert.ToDouble(saldo) + Convert.ToDouble(importe)).ToString("##0.00");
                        }

                        if (debehaber == "Cheque")
                        {
                            debe = importe;
                            haber = "";
                            totalDebe = totalDebe + Convert.ToDouble(importe);

                            saldo = (Convert.ToDouble(saldo) - Convert.ToDouble(importe)).ToString("##0.00");
                        }
                        tablaCuentaCorriente.CuentaCorriente.Rows.Add(nombrebanco, numerocta, moneda, movimiento, fecha.ToString("dd/MM/yyyy"), numerodocumento, conceptoCompleto, debe, haber, importe, saldo, fechaActual, totalDebe, totalHaber);
                    }
                }

                frmVerReportes reporte = new frmVerReportes(tablaCuentaCorriente, "CUENTAS_CORRIENTES");
                reporte.ShowDialog();
                tablaCuentaCorriente.CuentaCorriente.Rows.Clear();

            }
            else
            {
                MessageBox.Show("No hay registros para los datos ingresados");
            }
        }
    }
}
