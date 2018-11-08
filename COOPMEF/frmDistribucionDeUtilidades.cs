using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Microsoft.VisualBasic;

namespace COOPMEF
{
    public partial class frmDistribucionDeUtilidades : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmDistribucionDeUtilidades()
        {
            InitializeComponent();
        }

        private void btnSalirDistribuciUtilidades_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDistribuir_Click(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + 1;
            if (empresa.cierreEfectuado("09/" + anio.ToString()))
            {                
                if (txtUtilidades.Text.Trim() != "")
                {
                    if (empresa.esEntero(txtUtilidades.Text))
                    {
                        if (Convert.ToInt32(txtUtilidades.Text) > 0)
                        {
                            if (Convert.ToInt32(txtUtilidades.Text) <= Convert.ToDouble(lblInteres.Text))
                            {
                                if (!(empresa.ejercicioProcesado(txtEjercicio.Text)))
                                {

                                    string message = "¿Está seguro que desea distribuir las utilidades?";
                                    string caption = "Gestión COOPMEF";
                                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                    DialogResult result;

                                    result = MessageBox.Show(message, caption, buttons);

                                    if (result == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        generarDistribucion();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El Ejercicio ya fue procesado");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las utilidades deben ser menores a los intereses");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar un valor numérico entero positivo para utilidades");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar un valor numérico entero positivo para utilidades");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor para utilidades");
                }

            }
            else
            {
                MessageBox.Show("El Ejercicio no está cerrado");
            }
        }

        private void generarDistribucion()
        {

            DataSet dsSociosDistribucion = empresa.distribucionUtilidadesPorPresupuesto(consultaPreviaDistribucion());
            string ejercicio = txtEjercicio.Text;
            Double TotalInteres = 0;
            Double TotalAportes = 0;

            if (dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows.Count > 0)
            {
                for (int i = 0; i <= dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows.Count - 1; i++)
                {
                    int socio_id = Convert.ToInt32(dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows[i][0].ToString());
                    string cedula = dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows[i][1].ToString();
                    Double aporteCapital = Convert.ToDouble(dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows[i][3].ToString());
                    Double interesesAportados = Convert.ToDouble(dsSociosDistribucion.Tables["utilidadesPorPresupuesto"].Rows[i][2].ToString());

                    TotalInteres = TotalInteres + interesesAportados;
                    TotalAportes = TotalAportes + aporteCapital;

                    empresa.GuardarDistribucion(socio_id, cedula, ejercicio, aporteCapital, interesesAportados);

                }

                empresa.actualizarUtilidadesDistribucionEjercicio(Convert.ToDouble(txtUtilidades.Text), TotalInteres, ejercicio);
            }

            MessageBox.Show("Se ha completado la Distribución de Utilidades del Ejercicio " + txtEjercicio.Text + Environment.NewLine + " Intereses Aportados $ " + TotalInteres.ToString("###,###,##0.00") + Environment.NewLine + " Aportes de Capital $ " + TotalAportes.ToString("###,###,##0.00") + Environment.NewLine + " Utilidades Distribuidas $ " + Convert.ToDouble(txtUtilidades.Text).ToString("###,###,##0.00"));

        }

        private string consultaPreviaDistribucion()
        {
            string Sentencia = "";
            bool primerEntrada = true;

            foreach (DataGridViewRow row in dgvUtilidades.Rows)
            {
                if (primerEntrada)
                {
                    Sentencia += "SELECT distinctrow socio_id, cedula, SUM(InteresCuota), SUM(aportecapital) FROM coopmef.historia where historia.presupuesto=" + "'" + row.Cells[0].Value.ToString() + "'";
                    primerEntrada = false;
                }
                else
                {
                    Sentencia = Sentencia + " or historia.presupuesto=" + "'" + row.Cells[0].Value.ToString() + "'";
                }
            }

            Sentencia = Sentencia + " group by historia.cedula";

            return Sentencia;
        }

        private void frmDistribucionDeUtilidades_Load(object sender, EventArgs e)
        {
            for (int i = 2050; i >= 1985; i--)
            {
                cmbAnio.Items.Add(i);
            }

            cmbAnio.SelectedItem = DateTime.Today.Year;

            dgvUtilidades.RowHeadersVisible = false;
            dgvUtilidades.ReadOnly = true;
            dgvUtilidades.MultiSelect = false;
            dgvUtilidades.ReadOnly = true;
            dgvUtilidades.AllowDrop = false;
            dgvUtilidades.AllowUserToAddRows = false;
            dgvUtilidades.AllowUserToDeleteRows = false;
            dgvUtilidades.AllowUserToResizeColumns = false;
            dgvUtilidades.AllowUserToResizeRows = false;
            dgvUtilidades.AllowUserToOrderColumns = false;
            dgvUtilidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUtilidades.BackgroundColor = BackColor;
            dgvUtilidades.BorderStyle = BorderStyle.None;


            //centrar los datos y los cabezales en el dgv
            for (int i = 0; i <= 11; i++)
            {
                dgvUtilidades.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvUtilidades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void iniciar()
        {
            dgvUtilidades.Rows.Clear();

            int anio = Convert.ToInt32(cmbAnio.SelectedItem.ToString());

            DataSet utilidadMes;
            Double interesCuota = 0;
            Double aporteCapital = 0;
            Double sumaInteres = 0;
            Double sumaAportes = 0;

            for (int i = 10; i <= 12; i++)
            {
                int mes = i;
                int cantDias = Convert.ToInt32(DateTime.DaysInMonth(anio, mes));

                utilidadMes = empresa.devolverUtilidadesPorPresupuesto(mes + "/" + anio);

                if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows.Count > 0)
                {
                    if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][0].ToString() != "")
                    {
                        interesCuota = Convert.ToDouble(utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][0].ToString());
                    }
                    else
                    {
                        interesCuota = 0;
                    }


                    if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][1].ToString() != "")
                    {
                        aporteCapital = Convert.ToDouble(utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][1].ToString());
                    }
                    else
                    {
                        aporteCapital = 0;
                    }

                    sumaInteres += interesCuota;
                    sumaAportes += aporteCapital;
                }

                dgvUtilidades.Rows.Add(mes + "/" + anio, interesCuota.ToString("###,###,##0.00"), aporteCapital.ToString("###,###,##0.00"), (interesCuota + aporteCapital).ToString("###,###,##0.00"));
            }

            anio = anio + 1;

            for (int i = 1; i <= 9; i++)
            {
                int mes = i;
                int cantDias = Convert.ToInt32(DateTime.DaysInMonth(anio, mes));

                utilidadMes = empresa.devolverUtilidadesPorPresupuesto(mes + "/" + anio);

                if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows.Count > 0)
                {
                    if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][0].ToString() != "")
                    {
                        interesCuota = Convert.ToDouble(utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][0].ToString());
                    }
                    else
                    {
                        interesCuota = 0;
                    }


                    if (utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][1].ToString() != "")
                    {
                        aporteCapital = Convert.ToDouble(utilidadMes.Tables["devolverUtilidadesPorPresupuesto"].Rows[0][1].ToString());
                    }
                    else
                    {
                        aporteCapital = 0;
                    }
                    sumaInteres += interesCuota;
                    sumaAportes += aporteCapital;
                }
                dgvUtilidades.Rows.Add("0" + mes + "/" + anio, interesCuota.ToString("###,###,##0.00"), aporteCapital.ToString("###,###,##0.00"), (interesCuota + aporteCapital).ToString("###,###,##0.00"));
            }


            this.lblInteres.Text = sumaInteres.ToString("###,###,##0.00");
            this.lblAportes.Text = sumaAportes.ToString("###,###,##0.00");
            this.lblTotal.Text = (sumaInteres + sumaAportes).ToString("###,###,##0.00");
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtEjercicio.Text = Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + "/" + (Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + 1);
            iniciar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvUtilidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminarUtili_Click(object sender, EventArgs e)
        {
            if (empresa.ejercicioProcesado(txtEjercicio.Text))
            {
                if (empresa.verificarEjercicioSinPagos(txtEjercicio.Text))
                {
                    string message = "¿Confirma que desea eliminar la distribución del ejercicio " + txtEjercicio.Text + "?";
                    string caption = "Gestión COOPMEF";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        empresa.eliminarDistribucion(txtEjercicio.Text);
                        MessageBox.Show("Se ha Eliminado la distribución del ejercicio " + txtEjercicio.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Imposible Eliminar ese Ejercicio. Ya" + Environment.NewLine + "se han hecho pagos sobre el mismo." + Environment.NewLine + "La Operación ha sido Cancelada.");
                }
            }
            else
            {
                MessageBox.Show("No se ubica el Ejercicio " + txtEjercicio.Text);
            }
        }
    }
}
