﻿using System;
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
using Logs;


namespace COOPMEF
{
    public partial class frmCancelacionAnticipadaDePrestmos : Form
    {
        private int idSocioSeleccionado;
        private Controladora empresa = Controladora.Instance;
        private dsCancelacion DE = new dsCancelacion();
        private int idCobranza = 0;
        private bool sePuedeCancelar = false;
        private string oficina = "";
        private string inciso = "";

        public frmCancelacionAnticipadaDePrestmos(int pIdSocioSeleccionado, string incisoTMP, string oficinaTMP)
        {
            this.idSocioSeleccionado = pIdSocioSeleccionado;
            this.oficina = oficinaTMP;
            this.inciso = incisoTMP;
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

                RegistroSLogs registroLogs = new RegistroSLogs();
                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Cancelación anticipada préstamo " + this.txtCiCA.Text);

            }

            btnGuardarSocio.Enabled = false;
            btnImprimirCobranza.Enabled = false;
        }

        private Boolean estaExcedido()
        {

            if (!(idSocioSeleccionado == 0))
            {
                DataSet dsExcedidosSinPago = empresa.devolverExcedidosSinPago(idSocioSeleccionado);
                if (dsExcedidosSinPago.Tables["excedidosSinPago"].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
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
                btnImprimirCobranza.Enabled = false;
            }
        }

        private void cargaPrestamosCancelacion()
        {
            DataSet socioSeleccionado = empresa.buscarSociosPorCampo("socio_id", this.idSocioSeleccionado.ToString());

            if (socioSeleccionado.Tables["socios"].Rows.Count > 0)
            {
                bool excedido = estaExcedido();

                if (!excedido)
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
                            txtOficinaCA.Text = oficina;
                            txtIncisoCA.Text = inciso;

                            if (Convert.ToDouble(txtAmortizacionAVencerCA.Text) != 0)
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
                        }
                        else
                        {
                            MessageBox.Show("El Socio no tiene Préstamos");
                            sePuedeCancelar = false;
                            this.Close();
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
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("No puede realizar la cancelación. Debe cancelar la deuda pendiente como excedido");
                    sePuedeCancelar = false;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un socio para poder cancelar");
                sePuedeCancelar = false;
                this.Close();
            }
        }

        private void btnImprimirCobranza_Click(object sender, EventArgs e)
        {
            btnGuardarSocio.Enabled = true;

            DE.cancelacion.Rows.Add(txtCiCA.Text, txtNroCobroCA.Text, txtOficinaCA.Text + "/" + txtIncisoCA.Text, txtApeNomCA.Text, txtNroPrestamoCA.Text, txtCuotasPactadasCA.Text, txtCuotasPagadasCA.Text, txtAmortizacionAVencerCA.Text, txtInteresesAVencerCA.Text, txtPresupuestoDeCancelacion.Text, DateTime.Today, Utilidades.UsuarioLogueado.Alias.ToString(), "( " + empresa.ESCNUM(txtAmortizacionAVencerCA.Text) + " )");
            frmVerReportes reporte = new frmVerReportes(DE, "CANCELACION");
            reporte.ShowDialog();
            DE.cancelacion.Rows.Clear();
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
