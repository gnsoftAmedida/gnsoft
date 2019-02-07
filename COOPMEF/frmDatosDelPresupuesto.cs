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
    public partial class frmDatosDelPresupuesto : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsDatosPresupuesto tmpDsDatosPresupuesto = new dsDatosPresupuesto();

        public frmDatosDelPresupuesto()
        {
            InitializeComponent();
        }

        private void btnSalirDistribuciUtilidades_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtEjercicio.Text = Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + "/" + (Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + 1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.consultaEjercicio();
        }

        private void consultaEjercicio()
        {

           

            int anio = Convert.ToInt32(cmbAnio.SelectedItem.ToString());

            for (int i = 10; i <= 12; i++)
            {
                int mes = i;

                DataSet presupuesto = empresa.devolverDatosPresupuesto(mes + "/" + anio);

                if (presupuesto.Tables["datosPresupuesto"].Rows.Count > 0)
                {
                    for (int n = 0; n <= presupuesto.Tables["datosPresupuesto"].Rows.Count - 1; n++)
                    {

                        String Presupuesto = presupuesto.Tables["datosPresupuesto"].Rows[n][0].ToString();

                        if (Presupuesto != "")
                        {
                            Double InteresVencer = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][1].ToString());
                            Double AmortizacionVencer = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][2].ToString());
                            Double mora = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][3].ToString());
                            String ejercicio = txtEjercicio.Text;
                            tmpDsDatosPresupuesto.datos.Rows.Add(Presupuesto, InteresVencer.ToString("#,##0.00"), AmortizacionVencer.ToString("#,##0.00"), mora.ToString("#,##0.00"), ejercicio);
                        } 
                        else
                        {
                            tmpDsDatosPresupuesto.datos.Rows.Add(mes + "/" + anio, 0, 0, 0, "---");
                        }
                    }
                }
            }

            anio = anio + 1;

            for (int i = 1; i <= 9; i++)
            {
                int mes = i;

                DataSet presupuesto = empresa.devolverDatosPresupuesto("0" + mes + "/" + anio);

                if (presupuesto.Tables["datosPresupuesto"].Rows.Count > 0)
                {
                    for (int n = 0; n <= presupuesto.Tables["datosPresupuesto"].Rows.Count - 1; n++)
                    {

                        String Presupuesto = presupuesto.Tables["datosPresupuesto"].Rows[n][0].ToString();

                        if (Presupuesto != "")
                        {
                            Double InteresVencer = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][1].ToString());
                            Double AmortizacionVencer = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][2].ToString());
                            Double mora = Convert.ToDouble(presupuesto.Tables["datosPresupuesto"].Rows[n][3].ToString());

                            tmpDsDatosPresupuesto.datos.Rows.Add(Presupuesto, InteresVencer.ToString("##0.00"), AmortizacionVencer.ToString("##0.00"), mora.ToString("##0.00"), this.txtEjercicio.Text);
                        }
                        else
                        {
                            tmpDsDatosPresupuesto.datos.Rows.Add("0" + mes + "/" + anio, 0, 0, 0, "---");
                        }
                    }
                }
            }

            frmVerReportes reporte = new frmVerReportes(tmpDsDatosPresupuesto, "DATOS_PRSUPUESTO");
            reporte.ShowDialog();
            tmpDsDatosPresupuesto.datos.Rows.Clear();
        }

        private void frmDatosDelPresupuesto_Load(object sender, EventArgs e)
        {
            for (int i = 2050; i >= 1985; i--)
            {
                cmbAnio.Items.Add(i);
            }

            cmbAnio.SelectedItem = DateTime.Today.Year;
        }
    }
}
