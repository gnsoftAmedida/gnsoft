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
    public partial class CancelacionAnticipadaDePrestmos : Form
    {
        private int idSocioSeleccionado;
        private Controladora empresa = Controladora.Instance;

        public CancelacionAnticipadaDePrestmos(int pIdSocioSeleccionado)
        {
            this.idSocioSeleccionado = pIdSocioSeleccionado;
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcularCobranza_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "calc";
            proc.Start();
        }

        private void btnSalirPlan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarSocio_Click(object sender, EventArgs e)
        {
            string message = "¿Está seguro de que desea cancelar este préstamo? No podrá volver atrás";
            string caption = "Cancelar Préstamo";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Préstamo cancelado");
            }
        }

        private void CancelacionAnticipadaDePrestmos_Load(object sender, EventArgs e)
        {
            DataSet socioSeleccionado = empresa.buscarSociosPorCampo("socio_id", this.idSocioSeleccionado.ToString());

            if (socioSeleccionado.Tables["socios"].Rows.Count > 0)
            {
                this.txtApeNomCA.Text = socioSeleccionado.Tables["socios"].Rows[0][3].ToString().Trim() + "," + socioSeleccionado.Tables["socios"].Rows[0][2].ToString().Trim();
                this.txtCiCA.Text = socioSeleccionado.Tables["socios"].Rows[0][1].ToString();
                this.txtNroCobroCA.Text = socioSeleccionado.Tables["socios"].Rows[0][4].ToString();

                DataSet dsCobranzaProvisoriaSocio = empresa.devolverCobranzaProvisoriaSocio(idSocioSeleccionado);
                DataSet dsCobranzaSocio = empresa.devolverCobranzaSocio(idSocioSeleccionado);

                /*
                                        if (dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows.Count == 0)
                                        {
                                            exitiaProvisoria = false;
                                            //0 si recien ha ingresado es en el que caso en que se le
                                            //haga el alta al socio y ya haya operado
                                            if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows.Count == 0)
                                            {
                                                txtNroPréstamo.Text = "0";
                                                txtCuotas.Text = "0";
                                                txtPagas.Text = "0";
                                                txtTasa.Text = "0";
                                                txtMonto.Text = "0";
                                                txtImporteCuotaPendiente.Text = "0";
                                                txtAmortización.Text = "0";
                                                txtInteresesAVencer.Text = "0";
                                                cuotaAnteriorPrestamo = 0;
                                                tasaAnteriorPrestamo = 0;
                                                nro_prestamoAnterior = 0;
                                                montoAnterior = 0;

                                                /* si si tiene pero lo termina ese mes
                                                   o puede ser que tampoco haya tenido pero amortizacion
                                                   a vencer va a aparecer en 0
                                                */
                /*          }
                          else
                          {
                              txtNroPréstamo.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString();
                              txtCuotas.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString();
                              txtPagas.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString();
                              txtTasa.Text = String.Format(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString(), "##0.00");
                              txtMonto.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString();
                              txtImporteCuotaPendiente.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString();
                              txtAmortización.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][12].ToString();
                              txtInteresesAVencer.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][13].ToString();

                              cuotaAnteriorPrestamo = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString());
                              tasaAnteriorPrestamo = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString());
                              nro_prestamoAnterior = Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString());
                              montoAnterior = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString());
                              txtTotalDeuda.Text = montoAnterior.ToString();

                              if (Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString()) != 0)
                              {
                                  if (Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString()) < Math.Abs(Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString())) / 2)
                                  {
                                      MessageBox.Show("El prestamo no tiene más del 50% de cuotas pagas.");
                                  }
                              }
                          }
                      }
                      else
                      {

                          cuotaAnteriorPrestamo = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString());
                          tasaAnteriorPrestamo = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString());
                          nro_prestamoAnterior = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString());
                          montoAnterior = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                          txtTotalDeuda.Text = montoAnterior.ToString();

                          id_cobranzaProvisoria = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][0].ToString());
                          exitiaProvisoria = true;

                          txtNroPréstamo.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString();
                          txtCuotas.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString();
                          txtPagas.Text = 0.ToString();
                          txtTasa.Text = String.Format(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString(), "##0.00");
                          txtMonto.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();
                          txtImporteCuotaPendiente.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString();
                          txtAmortización.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][12].ToString();

                          double CalculotxtInteresesAVencer = (Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString()) * Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString())) - Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                          txtInteresesAVencer.Text = Convert.ToString(CalculotxtInteresesAVencer);
                      }
                  }
                  else
                  {
                      MessageBox.Show("El Socio tiene deudas pendientes. No puede operar hasta cancelar la totalidad de la misma.");
                  }
              }
          */

            }
        }
    }
}
