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
        private int idCobranzaProvisoria = 0;
        private int idSocio = 0;
        private bool sePuedeCancelar = false;

        public frmCancelacionFallecimiento()
        {
            InitializeComponent();
        }

        private void cargaPrestamosCancelacion(int idSocio)
        {

            DataSet socioSeleccionado = empresa.buscarSociosPorCampo("socio_id", idSocio.ToString());

            if (socioSeleccionado.Tables["socios"].Rows.Count > 0)
            {
                if (Convert.ToInt32(socioSeleccionado.Tables["socios"].Rows[0][18].ToString()) == 1)
                {

                    this.txtApeNomCA.Text = socioSeleccionado.Tables["socios"].Rows[0][3].ToString().Trim() + "," + socioSeleccionado.Tables["socios"].Rows[0][2].ToString().Trim();
                    this.txtNroCobroCA.Text = socioSeleccionado.Tables["socios"].Rows[0][4].ToString();

                    txtOficinaCA.Text = socioSeleccionado.Tables["socios"].Rows[0][16].ToString() + " - " + socioSeleccionado.Tables["socios"].Rows[0][23].ToString();
                    txtIncisoCA.Text = socioSeleccionado.Tables["socios"].Rows[0][17].ToString() + " - " + socioSeleccionado.Tables["socios"].Rows[0][24].ToString();

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


                            if (Convert.ToDouble(txtAmortizacionAVencerCA.Text) != 0)
                            {
                                /*    txtAPagarPorCajaCA.Text = txtAmortizacionAVencerCA.Text;

                                    DateTime FechaVto = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15);
                                    txtPresupuestoDeCancelacion.Text = empresa.formatoFechaMid4(FechaVto);*/

                                sePuedeCancelar = true;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtNroPrestamoCA.Text) != 0)
                                {
                                    string anio = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15).ToString().Substring(6, 4);
                                    string mes = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15).ToString().Substring(3, 2);

                                    MessageBox.Show("El Préstamo queda cancelado a partir del vencimiento del presupuesto del mes " + mes + "/" + anio);
                                    sePuedeCancelar = true;

                                }
                                else
                                {
                                    MessageBox.Show("El Socio no tiene Préstamos");
                                    sePuedeCancelar = true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Socio no tiene Préstamos");
                        }
                    }
                    else
                    {
                        idCobranzaProvisoria = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][0].ToString());
                        txtNroPrestamoCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString();
                        txtCuotasPactadasCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString();
                        txtCuotasPagadasCA.Text = 0.ToString();
                        txtTasAnualEfecCA.Text = String.Format(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString(), "##0.00");
                        txtMontoDelValeCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();
                        txtImporteCuotaCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString();
                        txtAmortizacionAVencerCA.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][12].ToString();

                        double CalculotxtInteresesAVencer = (Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString()) * Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString())) - Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                        txtInteresesAVencerCA.Text = Convert.ToString(CalculotxtInteresesAVencer);

                        sePuedeCancelar = true;

                    }
                }
                else
                {
                    MessageBox.Show("El Socio esta dado de Baja.");
                }
            }
            else
            {
                MessageBox.Show("No se ubica al socio");
            }

            if (sePuedeCancelar)
            {
                this.btnCancelarDeudas.Enabled = true;
            }
            else
            {
                this.btnCancelarDeudas.Enabled = false;
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
            this.cancelar();
        }

        private void cancelar()
        {

            this.txtApeNomCA.Text = "";
            this.txtNroCobroCA.Text = "";
            txtNroPrestamoCA.Text = "";
            txtCuotasPactadasCA.Text = "";
            txtCuotasPagadasCA.Text = "";
            txtTasAnualEfecCA.Text = "";
            txtMontoDelValeCA.Text = "";
            txtImporteCuotaCA.Text = "";
            txtAmortizacionAVencerCA.Text = "";
            txtInteresesAVencerCA.Text = "";
            txtOficinaCA.Text = "";
            txtIncisoCA.Text = "";
            txtCedula.Text = "";
            idCobranza = 0;
            idCobranzaProvisoria = 0;
            idSocio = 0;
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
                    this.idSocio = Convert.ToInt32(dsSocio.Tables["socioUtilidades"].Rows[0][0].ToString());
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

        private void btnSalirDistribuciUtilidades_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarDeudas_Click(object sender, EventArgs e)
        {


            string message = "¿Esta Seguro? No podrá volver atrás";
            string caption = "COOPMEF";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (!(idCobranza == 0))
                {
                    empresa.cancelarCobranza(idCobranza);
                }

                if (!(idCobranzaProvisoria == 0))
                {
                    empresa.eliminarCobranzaProvisoria(idCobranzaProvisoria);
                }

                int estado = 1;
                empresa.bajaSocio(idSocio, ref estado);

                String alias = Utilidades.UsuarioLogueado.Alias;

                empresa.GuardarFallecido(Convert.ToInt32(txtNroPrestamoCA.Text), Convert.ToInt32(txtCuotasPactadasCA.Text), Convert.ToInt32(txtCuotasPagadasCA.Text), Convert.ToDouble(txtTasAnualEfecCA.Text), Convert.ToDouble(txtMontoDelValeCA.Text), Convert.ToDouble(txtImporteCuotaCA.Text), Convert.ToDouble(txtAmortizacionAVencerCA.Text), Convert.ToDouble(txtInteresesAVencerCA.Text), txtCedula.Text, alias, DateTime.Today, idSocio);

                MessageBox.Show("Deudas Canceladas correctamente");
                this.cancelar();
            }

            //traer fallecidos

            /*
                        resp = MsgBox("Esta Seguro. No podrá volver atrás.", vbYesNo + vbQuestion + vbDefaultButton2, Me.Caption)

            If resp = vbYes Then

               Busqueda = "select * from cobranza where cedula="
               Busqueda = Busqueda & "'" & TxtCedula & "'"
      
               Set RsCobranza = BaseDatos.OpenRecordset(Busqueda, dbOpenDynaset, dbConsistent)
               BeginTrans
   
               If RsCobranza.RecordCount > 0 Then
                  RsCobranza.Edit
                  RsCobranza!amortizacionvencer = 0
                  RsCobranza!interesvencer = 0
                  RsCobranza.Update
               End If
   
               RsFallecidos.AddNew
               RsFallecidos!numeroprestamo = LblNroPrestamo
               RsFallecidos!cuotaspactadas = LblCuotasPactadas
               RsFallecidos!cuotaspagadas = LblCuotasPagadas
               RsFallecidos!tasa = LblTasaInteres
               RsFallecidos!montovale = LblMontoPrestamo
               RsFallecidos!ImporteCuota = LblImporteCuotaAnterior
               RsFallecidos!amortizacionvencer = LblAmortizacionVencer
               RsFallecidos!interesesvencer = LblInteresesVencer
               'Rs!Presupuesto = LblPresupuesto
               RsFallecidos!cedula = TxtCedula
               RsFallecidos!usuario = Wusuario
               RsFallecidos!fechacancelacion = Date
   
               RsFallecidos.Update
   
               RsSocios.Edit
               RsSocios!baja = Date
               RsSocios!bajadopor = ""
               RsSocios.Update
   
               If LblCuotasPagadas = 0 Then
                  BaseDatos.Execute "DELETE * FROM " _
                  & "cobranzaprovisoria WHERE numeroprestamo = " & LblNroPrestamo
               End If

               CommitTrans
               CmdCancelar_Click
            Else
               CmdCancelar_Click
            End If

            Exit Sub

 


            */

        }

    }
}
