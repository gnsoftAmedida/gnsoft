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
    public partial class frmInformePrestamo : Form
    {
        private Controladora empresa = Controladora.Instance;
        private System.Data.DataSet eventosDataSet;
        private dsPrestamosCierre DE = new dsPrestamosCierre();


        public frmInformePrestamo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            DE.Clear();

            DataSet prestamosPresupuesto = empresa.devolverPrestamosOtorgadosPresupuesto(presupuesto);

            if (prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows.Count > 0)
            {
                for (int n = 0; n <= prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows.Count - 1; n++)
                {

                    string numerocobro = prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][0].ToString();
                    string cedula = prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][1].ToString();
                    DateTime fecha = Convert.ToDateTime(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][2].ToString());
                    int NumeroPrestamo = Convert.ToInt32(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][3].ToString());
                    Double monto = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][4].ToString());
                    Double saldoAnterior = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][5].ToString());
                    Double total = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][6].ToString());
                    Double totalIntereses = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][7].ToString());
                    Double interesesDeducidos = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][8].ToString());
                    Double saldoIntereses = Convert.ToDouble(prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][9].ToString());
                    String inciso = prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][10].ToString();
                    String oficina = prestamosPresupuesto.Tables["prestamosOtorgadosPresupuesto"].Rows[n][11].ToString();

                    DE.PrestamosPresupuseto.Rows.Add(numerocobro, cedula, fecha.ToShortDateString(), NumeroPrestamo, monto.ToString("##0.00"), saldoAnterior.ToString("##0.00"), total.ToString("##0.00"), totalIntereses.ToString("##0.00"), interesesDeducidos.ToString("##0.00"), saldoIntereses.ToString("##0.00"), inciso, oficina, presupuesto);
                }

                frmVerReportes reporte = new frmVerReportes(DE, "PRESTAMOS_PRESUPUESTO");
                reporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sin registros");
            }
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformePrestamo_Load(object sender, EventArgs e)
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
    }
}
