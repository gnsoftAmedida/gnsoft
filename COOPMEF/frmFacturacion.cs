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
    public partial class frmFacturacion : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsFactura tmpDsFactura = new dsFactura();

        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
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

            DataSet facturasPresupuesto = empresa.facturacion(presupuesto);

            if (facturasPresupuesto.Tables["facturacion"].Rows.Count > 0)
            {
                for (int n = 0; n <= facturasPresupuesto.Tables["facturacion"].Rows.Count - 1; n++)
                {
                    string socio_apellido = facturasPresupuesto.Tables["facturacion"].Rows[n][0].ToString();
                    string socio_nombre = facturasPresupuesto.Tables["facturacion"].Rows[n][1].ToString();
                    string inciso_codigo = facturasPresupuesto.Tables["facturacion"].Rows[n][2].ToString();
                    string oficina_codigo = facturasPresupuesto.Tables["facturacion"].Rows[n][3].ToString();
                    string InteresCuota = facturasPresupuesto.Tables["facturacion"].Rows[n][4].ToString();
                    string ivaCuota = facturasPresupuesto.Tables["facturacion"].Rows[n][5].ToString();
                    string mora = facturasPresupuesto.Tables["facturacion"].Rows[n][6].ToString();
                    string ivaMora = facturasPresupuesto.Tables["facturacion"].Rows[n][7].ToString();

                    String fecha = DateTime.Today.ToLongDateString();

                    tmpDsFactura.factura.Rows.Add(socio_apellido, socio_nombre, inciso_codigo, oficina_codigo, InteresCuota, ivaCuota, mora, ivaMora);
                }
            }

            frmVerReportes reporte = new frmVerReportes(tmpDsFactura, "FACTURAS");
            reporte.ShowDialog();
            tmpDsFactura.factura.Rows.Clear();
        }
    }
}
