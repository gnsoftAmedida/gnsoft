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
                    string caption = "Presupuesto";
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
                    DataSet prestamosPresupuesto = empresa.devolverPresupuestoDelMes(this.txtPresupuestoIngExc.Text);

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

                        DE.InformePresupuesto.Rows.Add(socio_apellido, socio_nombre, numerocobro, cantidadcuotas, nrocuotas, AmortizacionCuota, InteresCuota, iva, aportecapital, excedido, mora, ivaMora, totalADescontar, AmortizacionVencer, InteresVencer, IvaVencer, oficina, Inciso, fecha, this.txtPresupuestoIngExc.Text);
                    }

                    frmVerReportes reporte = new frmVerReportes(DE, "PRESUPUESTO_MES");
                    reporte.ShowDialog();
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
