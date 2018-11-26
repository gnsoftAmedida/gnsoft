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
    public partial class frmInformePresupuesto : Form
    {
        private Controladora empresa = Controladora.Instance;
        private System.Data.DataSet eventosDataSet;
        private dsPresupuesto DE = new dsPresupuesto();

        public frmInformePresupuesto()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
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

            DataSet prestamosPresupuesto = empresa.devolverPresupuestoDelMes(presupuesto);

            if (prestamosPresupuesto.Tables["presupuestoMes"].Rows.Count > 0)
            {
                for (int n = 0; n <= prestamosPresupuesto.Tables["presupuestoMes"].Rows.Count - 1; n++)
                {
                    string socio_apellido = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][0].ToString();
                    string socio_nombre = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][1].ToString();
                    string numerocobro = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][2].ToString();
                    string cantidadcuotas = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][3].ToString();
                    string nrocuotas = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][4].ToString();
                    Double AmortizacionCuota = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][5].ToString());
                    Double InteresCuota = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][6].ToString());
                    Double iva = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][7].ToString());
                    Double aportecapital = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][8].ToString());
                    Double excedido = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][9].ToString());
                    Double mora = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][10].ToString());
                    Double ivaMora = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][11].ToString());
                    Double totalADescontar = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][12].ToString());
                    Double AmortizacionVencer = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][13].ToString());
                    Double InteresVencer = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][14].ToString());
                    Double IvaVencer = Convert.ToDouble(prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][15].ToString());
                    String oficina = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][17].ToString();
                    String Inciso = prestamosPresupuesto.Tables["presupuestoMes"].Rows[n][16].ToString();
                    String fecha = DateTime.Today.ToLongDateString();

                    DE.InformePresupuesto.Rows.Add(socio_apellido, socio_nombre, numerocobro, cantidadcuotas, nrocuotas, AmortizacionCuota, InteresCuota, iva, aportecapital, excedido, mora, ivaMora, totalADescontar, AmortizacionVencer, InteresVencer, IvaVencer, oficina, Inciso, fecha, presupuesto);
                }

                frmVerReportes reporte = new frmVerReportes(DE, "PRESUPUESTO_MES");
                reporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sin registros");
            }

        }

        private void frmInformePresupuesto_Load(object sender, EventArgs e)
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
