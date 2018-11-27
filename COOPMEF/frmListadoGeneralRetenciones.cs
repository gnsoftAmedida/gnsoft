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
    public partial class frmListadoGeneralRetenciones : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsInterfaces tablaInterface = new dsInterfaces();

        public frmListadoGeneralRetenciones()
        {
            InitializeComponent();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoGeneralRetenciones_Load(object sender, EventArgs e)
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

            DataSet interfacesGenerales = empresa.devolverInterfacesGeneralesInforme(presupuesto);

            if (interfacesGenerales.Tables["interfacesInforme"].Rows.Count > 0)
            {
                for (int n = 0; n <= interfacesGenerales.Tables["interfacesInforme"].Rows.Count - 1; n++)
                {
                    String numeroPrestamo = interfacesGenerales.Tables["interfacesInforme"].Rows[n][1].ToString();
                    String cedula = interfacesGenerales.Tables["interfacesInforme"].Rows[n][2].ToString();
                    Double importeCuota = Convert.ToDouble(interfacesGenerales.Tables["interfacesInforme"].Rows[n][3].ToString());
                    Double aportecapital = Convert.ToDouble(interfacesGenerales.Tables["interfacesInforme"].Rows[n][4].ToString());
                    String numeroCobro = interfacesGenerales.Tables["interfacesInforme"].Rows[n][5].ToString();

                    String inciso = interfacesGenerales.Tables["interfacesInforme"].Rows[n][6].ToString();
                    String oficina = interfacesGenerales.Tables["interfacesInforme"].Rows[n][7].ToString();

                    String nombres = interfacesGenerales.Tables["interfacesInforme"].Rows[n][13].ToString();
                    String apellidos = interfacesGenerales.Tables["interfacesInforme"].Rows[n][14].ToString();

                    Double Excedido = Convert.ToDouble(interfacesGenerales.Tables["interfacesInforme"].Rows[n][10].ToString());
                    Double Mora = Convert.ToDouble(interfacesGenerales.Tables["interfacesInforme"].Rows[n][11].ToString());
                    Double IvaMora = Convert.ToDouble(interfacesGenerales.Tables["interfacesInforme"].Rows[n][12].ToString());

                    Double resultadoInter = importeCuota + aportecapital + Excedido + Mora + IvaMora;

                    String fecha = DateTime.Today.ToLongDateString();

                    tablaInterface.Interface.Rows.Add(cedula, nombres, apellidos, numeroCobro, resultadoInter.ToString("##0.00"), inciso, oficina, presupuesto, fecha);
                }
                frmVerReportes reporte = new frmVerReportes(tablaInterface, "INTERFACES_GENERALES");
                reporte.ShowDialog();
                tablaInterface.Interface.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran registros");
            }


        }
    }
}
