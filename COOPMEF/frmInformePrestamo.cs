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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int anioActual;
            int anioPresup;
            bool anioBien = false;
            DE.Clear();

            if (txtPresupuestoIngExc.Text.Length == 7)
            {
                anioActual = DateTime.Today.Year;
                anioPresup = Convert.ToInt32(this.txtPresupuestoIngExc.Text.Substring(3, 4));

                if (anioActual != anioPresup)
                {
                    string message = "El año ingresado no se corresponde con el año en curso. ¿Continúa?";
                    string caption = "Excedidos";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        anioBien = true;
                    }
                }
                else
                {
                    anioBien = true;
                }

                if (anioBien)
                {
                    DataSet prestamosPresupuesto = empresa.devolverPrestamosOtorgadosPresupuesto(this.txtPresupuestoIngExc.Text);

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

                            DE.PrestamosPresupuseto.Rows.Add(numerocobro, cedula, fecha, NumeroPrestamo, monto, saldoAnterior, total, totalIntereses, interesesDeducidos, saldoIntereses, inciso, oficina, txtPresupuestoIngExc.Text);
                        }

                        frmVerReportes reporte = new frmVerReportes(DE, "PRESTAMOS_PRESUPUESTO");
                        reporte.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sin registros");
                    }
                }
            }
            else
            {
                MessageBox.Show("Formato de presupuesto incorrecto");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
