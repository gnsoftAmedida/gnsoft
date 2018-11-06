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
            if (empresa.cierreEfectuado("09/" + cmbAnio.SelectedItem.ToString()))
            {
                if (txtUtilidades.Text.Trim() != "")
                {
                    if (empresa.esEntero(txtUtilidades.Text))
                    {
                        if (Convert.ToInt32(txtUtilidades.Text) > 0)
                        {
                            if (Convert.ToInt32(txtUtilidades.Text) <= Convert.ToDouble(lblInteres.Text))
                            {
                                MessageBox.Show("Sigo");

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
            this.txtEjercicio.Text = Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + " / " + (Convert.ToInt32(cmbAnio.SelectedItem.ToString()) + 1);
            iniciar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
