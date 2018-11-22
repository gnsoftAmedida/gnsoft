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
    public partial class frmExcedidosDeUnMes : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsPagoExcedidosPresupuesto tmpDsPagoExcedidosPresupuesto = new dsPagoExcedidosPresupuesto();

        public frmExcedidosDeUnMes()
        {
            InitializeComponent();
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

            DataSet pagoExcedidosPresupuesto = empresa.ExcedidosDeUnMes(presupuesto);

            if (pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows.Count > 0)
            {
                for (int n = 0; n <= pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows.Count - 1; n++)
                {
                    String socio_apellido = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][0].ToString();
                    String socio_nombre = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][1].ToString();
                    String socio_nroCobro = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][2].ToString();
                    String socio_nro = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][3].ToString();
                    String presupuestodelpago = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][4].ToString();
                    Double aretener = Convert.ToDouble(pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][5].ToString());
                    Double retenido = Convert.ToDouble(pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][6].ToString());
                    Double deuda = Convert.ToDouble(pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][7].ToString());
                    String mora = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][8].ToString();
                    String total = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][9].ToString();
                    String inciso = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][10].ToString();
                    String oficina = pagoExcedidosPresupuesto.Tables["pagoExecidosPorPresupuesto"].Rows[n][11].ToString();

                    tmpDsPagoExcedidosPresupuesto.excedidos.Rows.Add(socio_apellido, socio_nombre, socio_nroCobro, socio_nro, presupuestodelpago, aretener.ToString("##0.00"), retenido.ToString("##0.00"), deuda.ToString("##0.00"), mora, total, inciso, oficina, presupuesto);
                }

                frmVerReportes reporte = new frmVerReportes(tmpDsPagoExcedidosPresupuesto, "EXCEDIDOS_DE_UN_MES");
                reporte.ShowDialog();
                tmpDsPagoExcedidosPresupuesto.excedidos.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran excedidos sin pagos para el presupuesto " + presupuesto);
            }
        }

        private void frmExcedidosDeUnMes_Load(object sender, EventArgs e)
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

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
