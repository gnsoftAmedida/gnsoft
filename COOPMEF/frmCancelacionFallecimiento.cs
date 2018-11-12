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
    public partial class frmCancelacionFallecimiento : Form
    {
        private Controladora empresa = Controladora.Instance;
        private int idCobranza = 0;

        public frmCancelacionFallecimiento()
        {
            InitializeComponent();
        }

        private void cargaPrestamosCancelacion(int idSocio)
        {
            DataSet socioSeleccionado = empresa.buscarSociosPorCampo("socio_id", idSocio.ToString());

            if (socioSeleccionado.Tables["socios"].Rows.Count > 0)
            {
                this.txtApeNomCA.Text = socioSeleccionado.Tables["socios"].Rows[0][3].ToString().Trim() + "," + socioSeleccionado.Tables["socios"].Rows[0][2].ToString().Trim();
                this.txtNroCobroCA.Text = socioSeleccionado.Tables["socios"].Rows[0][4].ToString();

                DataSet dsCobranzaProvisoriaSocio = empresa.devolverCobranzaProvisoriaSocio(idSocio);
                DataSet dsCobranzaSocio = empresa.devolverCobranzaSocio(idSocio);
                DataSet dsParametros = empresa.DevolverEmpresa();

                if (dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows.Count == 0)
                {
                    if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows.Count > 0)
                    {
                        idCobranza = Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][0].ToString());
                        txtNroPrestamoCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString();
                        txtCuotasPactadasCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString();
                        txtCuotasPagadasCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString();
                        txtTasAnualEfecCA.Text = String.Format(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString(), "##0.00");
                        txtMontoDelValeCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString();
                        txtImporteCuotaCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString();
                        txtAmortizacionAVencerCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][12].ToString();
                        txtInteresesAVencerCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][13].ToString();
                        //   txtOficinaCA.Text = oficina;
                        //      txtIncisoCA.Text = inciso;


                        /*    if (Convert.ToDouble(txtAmortizacionAVencerCA.Text) != 0)
                            {
                                txtAPagarPorCajaCA.Text = txtAmortizacionAVencerCA.Text;

                                DateTime FechaVto = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15);
                                txtPresupuestoDeCancelacion.Text = empresa.formatoFechaMid4(FechaVto);
                                sePuedeCancelar = true;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtNroPrestamoCA.Text) != 0)
                                {
                                    string anio = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15).ToString().Substring(6, 4);
                                    string mes = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15).ToString().Substring(3, 2);

                                    MessageBox.Show("El Préstamo queda cancelado a partir del vencimiento del presupuesto del mes " + mes + "/" + anio);
                                    sePuedeCancelar = false;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("El Socio no tiene Préstamos");
                                    sePuedeCancelar = false;
                                    this.Close();
                                }
                            }
                         * */
                    }
                    else
                    {
                        MessageBox.Show("El Socio no tiene Préstamos");
                    }
                }
                else
                {

                    txtNroPrestamoCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString();
                    txtCuotasPactadasCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString();
                    txtCuotasPagadasCA.Text = 0.ToString();
                    txtTasAnualEfecCA.Text = String.Format(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString(), "##0.00");
                    txtMontoDelValeCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();
                    txtImporteCuotaCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString();
                    txtAmortizacionAVencerCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][12].ToString();

                    double CalculotxtInteresesAVencer = (Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString()) * Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString())) - Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                    txtInteresesAVencerCA.Text = Convert.ToString(CalculotxtInteresesAVencer);

              //      MessageBox.Show("No puede realizar la cancelación. Debe Anular el Presente Préstamo");
             
                }
            }
        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void frmCancelacionFallecimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void buscar()
        {
            String cedula = txtCedula.Text;

            if (!(txtCedula.Text.Replace(".", "").Replace("-", "").Replace(",", "").Replace("_", "").Trim() == ""))
            {
                DataSet dsSocio = empresa.buscarSociosUtilidades(cedula.Replace(",", "."));

                if (dsSocio.Tables["socioUtilidades"].Rows.Count == 1)
                {
                    cargaPrestamosCancelacion(Convert.ToInt32(dsSocio.Tables["socioUtilidades"].Rows[0][0].ToString()));  
                }
                else
                {
                    MessageBox.Show("No se Ubica el Socio.");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar la cédula del socio");
            }
        }
    }
}
