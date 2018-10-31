using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace COOPMEF
{
    public partial class frmSalidasIngresosBancos : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmSalidasIngresosBancos()
        {
            InitializeComponent();
        }

        private void btnSeleccionarSocio_Click(object sender, EventArgs e)
        {
            iniciar();            
        }

        private void iniciar() {
            dgvIngresosSalidas.Rows.Clear();

            int anio = Convert.ToInt32(cmbAnio.SelectedItem.ToString());
            DataSet movimientoPro;
            Double sumaCheques = 0;
            Double sumaDepositos = 0;
            Double promedioCheque = 0;
            Double promedioDeposito = 0;
            Double cheque = 0;
            Double deposito = 0;

            for (int i = 10; i <= 12; i++)
            {
                int mes = i;
                int cantDias = Convert.ToInt32(DateTime.DaysInMonth(anio, mes));

                movimientoPro = empresa.salidasIngresos(1, cantDias, mes, anio);

                if (movimientoPro.Tables["salidaIngreso"].Rows.Count > 0)
                {

                    try
                    {
                        if (movimientoPro.Tables["salidaIngreso"].Rows[1][0].ToString() != "")
                        {
                            cheque = Convert.ToDouble(movimientoPro.Tables["salidaIngreso"].Rows[1][0].ToString());
                            sumaCheques += cheque;
                        }
                        else
                        {
                            cheque = 0;
                        }
                    }
                    catch
                    {
                        cheque = 0;
                    }

                    try
                    {
                        if (movimientoPro.Tables["salidaIngreso"].Rows[0][0].ToString() != "")
                        {
                            deposito = Convert.ToDouble(movimientoPro.Tables["salidaIngreso"].Rows[0][0].ToString());
                            sumaDepositos += deposito;
                        }
                        else
                        {
                            deposito = 0;
                        }
                    }
                    catch
                    {
                        deposito = 0;
                    }

                }
                else
                {
                    deposito = 0;
                    cheque = 0;
                }

                dgvIngresosSalidas.Rows.Add(mes + "/" + anio, cheque, deposito);
            }

            anio = anio + 1;

            for (int i = 1; i <= 9; i++)
            {
                int mes = i;
                int cantDias = Convert.ToInt32(DateTime.DaysInMonth(anio, mes));
                movimientoPro = empresa.salidasIngresos(1, cantDias, mes, anio);


                if (movimientoPro.Tables["salidaIngreso"].Rows.Count > 0)
                {

                    try
                    {
                        if (movimientoPro.Tables["salidaIngreso"].Rows[1][0].ToString() != "")
                        {
                            cheque = Convert.ToDouble(movimientoPro.Tables["salidaIngreso"].Rows[1][0].ToString());
                            sumaCheques += cheque;
                        }
                        else
                        {
                            cheque = 0;
                        }
                    }
                    catch
                    {
                        cheque = 0;
                    }

                    try
                    {
                        if (movimientoPro.Tables["salidaIngreso"].Rows[0][0].ToString() != "")
                        {
                            deposito = Convert.ToDouble(movimientoPro.Tables["salidaIngreso"].Rows[0][0].ToString());
                            sumaDepositos += deposito;
                        }
                        else
                        {
                            deposito = 0;
                        }
                    }
                    catch
                    {
                        deposito = 0;
                    }
                }
                else
                {
                    deposito = 0;
                    cheque = 0;
                }

                dgvIngresosSalidas.Rows.Add("0" + mes + "/" + anio, cheque, deposito);
            }

            promedioCheque = sumaCheques / 12;
            promedioDeposito = sumaDepositos / 12;

            dgvIngresosSalidas.Rows.Add("", "", "");
            dgvIngresosSalidas.Rows.Add("Total", sumaCheques, sumaDepositos);
            dgvIngresosSalidas.Rows.Add("Promedio Mensual", promedioCheque, promedioDeposito);

        }

        private void frmSalidasIngresosBancos_Load(object sender, EventArgs e)
        {

            for (int i = 2050; i >= 1985; i--)
            {
                cmbAnio.Items.Add(i);
            }

            cmbAnio.SelectedItem = DateTime.Today.Year;

            dgvIngresosSalidas.RowHeadersVisible = false;
            dgvIngresosSalidas.ReadOnly = true;
            dgvIngresosSalidas.MultiSelect = false;            
            dgvIngresosSalidas.ReadOnly = true;
            dgvIngresosSalidas.AllowDrop = false;
            dgvIngresosSalidas.AllowUserToAddRows = false;
            dgvIngresosSalidas.AllowUserToDeleteRows = false;
            dgvIngresosSalidas.AllowUserToResizeColumns = false;
            dgvIngresosSalidas.AllowUserToResizeRows = false;
            dgvIngresosSalidas.AllowUserToOrderColumns = false;
            dgvIngresosSalidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresosSalidas.BackgroundColor = BackColor;
            dgvIngresosSalidas.BorderStyle = BorderStyle.None;

            iniciar();  
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtEjercicio.Text = Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + " / " + (Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + 1);
        }

        private void btnSalirMovPromedio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
