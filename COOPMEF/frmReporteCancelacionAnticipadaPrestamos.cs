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
    public partial class frmReporteCancelacionAnticipadaPrestamos : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsCancelacionAnticipada cancelaciones = new dsCancelacionAnticipada();

        public frmReporteCancelacionAnticipadaPrestamos()
        {
            InitializeComponent();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteCancelacionAnticipadaPrestamos_Load(object sender, EventArgs e)
        {

            int anio = 2018;
            int posAnio = 38;
            int anioActual = DateTime.Today.Year;

            posAnio = anioActual - anio + posAnio;

            try
            {
                cmbAnios.SelectedIndex = posAnio;
                cmbMeses.SelectedIndex = DateTime.Today.Month - 1;
            }
            catch
            {
                MessageBox.Show("Verifique que la fecha de su ordenador sea correcta");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            int mes = Convert.ToInt32(this.cmbMeses.SelectedIndex + 1);
            string mesNombre = cmbMeses.SelectedItem.ToString(); ;
            string anio = cmbAnios.SelectedItem.ToString();

            string presupuesto;

            if (mes < 10)
            {
                presupuesto = "0" + mes + "/" + anio;
            }
            else
            {
                presupuesto = mes + "/" + anio;
            }

            DataSet cancelacionesAnticipadas = empresa.devolverCanelacionesPresupuesto(presupuesto);

            if (cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows.Count > 0)
            {
                for (int n = 0; n <= cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows.Count - 1; n++)
                {
                    DateTime FechaCancelacion = Convert.ToDateTime(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][0].ToString());
                    String socio_nro = cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][1].ToString();
                    String socio_nombre = cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][2].ToString();
                    String socio_apellido = cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][3].ToString();
                    String NumeroPrestamo = cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][4].ToString();
                    int CuotasPactadas = Convert.ToInt32(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][5].ToString());
                    int CuotasPagadas = Convert.ToInt32(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][6].ToString());
                    Double Tasa = Convert.ToDouble(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][7].ToString());
                    Double MontoVale = Convert.ToDouble(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][8].ToString());
                    Double ImporteCuota = Convert.ToDouble(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][9].ToString());
                    Double AmortizacionVencer = Convert.ToDouble(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][10].ToString());
                    Double InteresesVencer = Convert.ToDouble(cancelacionesAnticipadas.Tables["canelacionesAnticipadas"].Rows[n][11].ToString());

                    String fecha = DateTime.Today.ToShortDateString();

                    cancelaciones.cancelacion.Rows.Add(FechaCancelacion, socio_nro, socio_nombre, socio_apellido, NumeroPrestamo, CuotasPactadas, CuotasPagadas, Tasa.ToString("##0.00"), MontoVale.ToString("##0.00"), ImporteCuota.ToString("##0.00"), AmortizacionVencer.ToString("##0.00"), InteresesVencer.ToString("##0.00"), presupuesto, fecha);
                }

                frmVerReportes reporte = new frmVerReportes(cancelaciones, "CANCELACION_ANTICIPADA");
                reporte.ShowDialog();
                cancelaciones.cancelacion.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran cancelaciones anticipadas para el presupuesto buscado");
            }
        }
    }
}
