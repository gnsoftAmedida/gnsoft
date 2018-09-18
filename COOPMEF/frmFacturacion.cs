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
        private dsSociosIngresadosEn ingresadosEn = new dsSociosIngresadosEn();

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
            this.cmbAnios.SelectedIndex = 0;
            this.cmbMeses.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(this.cmbMeses.SelectedIndex + 1);
            string mesNombre = cmbMeses.SelectedItem.ToString(); ;
            string anio = cmbAnios.SelectedItem.ToString();

            string presupuesto = mes + "/" + anio;

            //Ver si es por mes o por presupuesto
            DataSet sociosResultado = empresa.facturacion(presupuesto);

            if (sociosResultado.Tables["sociosEntreFechas"].Rows.Count > 0)
            {
                for (int n = 0; n <= sociosResultado.Tables["sociosEntreFechas"].Rows.Count - 1; n++)
                {
                    string socio_apellido = sociosResultado.Tables["sociosEntreFechas"].Rows[n][3].ToString();
                    string socio_nombre = sociosResultado.Tables["sociosEntreFechas"].Rows[n][2].ToString();
                    string numerocobro = sociosResultado.Tables["sociosEntreFechas"].Rows[n][4].ToString();
                    string numeroSocio = sociosResultado.Tables["sociosEntreFechas"].Rows[n][1].ToString();
                    string fechaIngreso = sociosResultado.Tables["sociosEntreFechas"].Rows[n][6].ToString();
                    string baja = sociosResultado.Tables["sociosEntreFechas"].Rows[n][22].ToString();
                    string telefono = sociosResultado.Tables["sociosEntreFechas"].Rows[n][13].ToString();
                    string oficina = sociosResultado.Tables["sociosEntreFechas"].Rows[n][17].ToString();
                    string Inciso = sociosResultado.Tables["sociosEntreFechas"].Rows[n][16].ToString();

                    ingresadosEn.SociosIngresadosEn.Rows.Add(socio_apellido, socio_nombre, numeroSocio, fechaIngreso, baja, telefono, mesNombre, anio, Inciso, oficina, numerocobro);
                }
            }

            frmVerReportes reporte = new frmVerReportes(ingresadosEn, "SOCIOS_BAJA_EN");
            reporte.ShowDialog();
            ingresadosEn.SociosIngresadosEn.Rows.Clear();
        }
    }
}
