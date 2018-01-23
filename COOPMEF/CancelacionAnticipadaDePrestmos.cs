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


                if (dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows.Count == 0)
                {
                    //             exitiaProvisoria = false;
                    //0 si recien ha ingresado es en el que caso en que se le
                    //haga el alta al socio y ya haya operado
                    if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows.Count > 0)
                    {
                       
                        txtNroPrestamoCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString();
                        txtCuotasPactadasCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString();
                        txtCuotasPagadasCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString();
                        txtTasAnualEfecCA.Text = String.Format(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString(), "##0.00");
                        txtMontoDelValeCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString();
                        txtImporteCuotaCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString();
                        txtAmortizacionAVencerCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][12].ToString();
                        txtInteresesAVencerCA.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][13].ToString();

                         if (Convert.ToDouble(txtAmortizacionAVencerCA.Text) != 0){
                         txtAPagarPorCajaCA.Text = txtAmortizacionAVencerCA.Text;
                         }
         /*               If RsCobranza!amortizacionvencer <> 0 Then
               LblAPagar = RsCobranza!amortizacionvencer
               FechaVto = RsParametros!vtopresupuestoactual + 15
               LblPresupuesto.Caption = Mid(FechaVto, 4)
      */

                    }
                }
                else
                {


                    /*         id_cobranzaProvisoria = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][0].ToString());
                             exitiaProvisoria = true;
                                               */
                    txtNroPrestamoCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString();
                    txtCuotasPactadasCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString();
                    txtCuotasPagadasCA.Text = 0.ToString();
                    txtTasAnualEfecCA.Text = String.Format(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString(), "##0.00");
                    txtMontoDelValeCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();
                    txtImporteCuotaCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString();
                    txtAmortizacionAVencerCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][12].ToString();

                    double CalculotxtInteresesAVencer = (Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString()) * Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString())) - Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                    txtInteresesAVencerCA.Text = Convert.ToString(CalculotxtInteresesAVencer);

                }

            }
        }
    }
}
