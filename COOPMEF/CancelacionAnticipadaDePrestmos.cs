using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Microsoft.VisualBasic;
using COOPMEF.CrystalDataSets;


namespace COOPMEF
{
    public partial class CancelacionAnticipadaDePrestmos : Form
    {
        private int idSocioSeleccionado;
        private Controladora empresa = Controladora.Instance;
        private dsCancelacion DE = new dsCancelacion();
        private int idCobranza = 0;
        private bool sePuedeCancelar = false;

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

                empresa.guardarCancelacion(Convert.ToInt32(txtNroPrestamoCA.Text), Convert.ToInt32(txtCuotasPactadasCA.Text), Convert.ToInt32(txtCuotasPagadasCA.Text), Convert.ToDouble(txtTasAnualEfecCA.Text), Convert.ToDouble(txtMontoDelValeCA.Text), Convert.ToDouble(txtImporteCuotaCA.Text), Convert.ToDouble(txtAmortizacionAVencerCA.Text), Convert.ToDouble(txtInteresesAVencerCA.Text), txtPresupuestoDeCancelacion.Text, txtCiCA.Text, Utilidades.UsuarioLogueado.Alias.ToString(), DateTime.Today, idSocioSeleccionado);

                empresa.cancelarCobranza(idCobranza);

                MessageBox.Show("Préstamo cancelado");
            }

            btnGuardarSocio.Enabled = false;
        }

        private void CancelacionAnticipadaDePrestmos_Load(object sender, EventArgs e)
        {
            cargaPrestamosCancelacion();

            if (sePuedeCancelar)
            {
                btnImprimirCobranza.Enabled = true;
            }
            else
            {
                //cambiar a false. Es solo para prueba
                btnImprimirCobranza.Enabled = true;
            }
        }

        private void cargaPrestamosCancelacion()
        {
            DataSet socioSeleccionado = empresa.buscarSociosPorCampo("socio_id", this.idSocioSeleccionado.ToString());

            if (socioSeleccionado.Tables["socios"].Rows.Count > 0)
            {
                this.txtApeNomCA.Text = socioSeleccionado.Tables["socios"].Rows[0][3].ToString().Trim() + "," + socioSeleccionado.Tables["socios"].Rows[0][2].ToString().Trim();
                this.txtCiCA.Text = socioSeleccionado.Tables["socios"].Rows[0][1].ToString();
                this.txtNroCobroCA.Text = socioSeleccionado.Tables["socios"].Rows[0][4].ToString();

                DataSet dsCobranzaProvisoriaSocio = empresa.devolverCobranzaProvisoriaSocio(idSocioSeleccionado);
                DataSet dsCobranzaSocio = empresa.devolverCobranzaSocio(idSocioSeleccionado);
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

                        if (Convert.ToDouble(txtAmortizacionAVencerCA.Text) != 0)
                        {
                            txtAPagarPorCajaCA.Text = txtAmortizacionAVencerCA.Text;

                            DateTime FechaVto = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][29].ToString()).AddDays(15);
                            txtPresupuestoDeCancelacion.Text = empresa.formatoFechaMid4(FechaVto);
                            sePuedeCancelar = true;
                        }
                        else
                        {
                            if (Convert.ToInt32(txtNroPrestamoCA.Text) != 0)
                            {
                                MessageBox.Show("El Préstamo queda cancelado a partir del vencimiento del presupuesto del mes" + Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][29].ToString()).AddDays(15).ToString().Substring(4, 2) + "/" + Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][29].ToString()).AddDays(15).ToString().Substring(7));
                                sePuedeCancelar = false;
                            }
                            else
                            {
                                MessageBox.Show("El Socio no tiene Préstamos");
                                sePuedeCancelar = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Socio no tiene Préstamos");
                        sePuedeCancelar = false;
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

                    MessageBox.Show("No puede realizar la cancelación. Debe Anular el Presente Préstamo");
                    sePuedeCancelar = false;
                }
            }
        }

        private void btnImprimirCobranza_Click(object sender, EventArgs e)
        {
            btnGuardarSocio.Enabled = true;

            DE.cancelacion.Rows.Add(txtCiCA.Text, txtNroCobroCA.Text, txtOficinaCA.Text + "/" + txtIncisoCA.Text, txtApeNomCA.Text, txtNroPrestamoCA.Text, txtCuotasPactadasCA.Text, txtCuotasPagadasCA.Text, txtAmortizacionAVencerCA.Text, txtInteresesAVencerCA.Text, txtPresupuestoDeCancelacion.Text, DateTime.Today, Utilidades.UsuarioLogueado.Alias.ToString(),"( " +  empresa.ESCNUM(txtAmortizacionAVencerCA.Text) + " )");
            frmVerReportes reporte = new frmVerReportes(DE, "CANCELACION");
            reporte.ShowDialog();
            DE.cancelacion.Rows.Clear();
        }
    }
}
