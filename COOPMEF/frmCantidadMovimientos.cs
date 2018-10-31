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
    public partial class frmCantidadMovimientos : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsBancos;

        public frmCantidadMovimientos()
        {
            InitializeComponent();
        }

        private void btnSalirMovPromedio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCantidadMovimientos_Load(object sender, EventArgs e)
        {
            dsBancos = empresa.DevolverBancos();

            this.cmbBancosMovPromedio.DataSource = dsBancos.Tables["bancos"];
            this.cmbBancosMovPromedio.DisplayMember = "mostrarse";
            this.cmbBancosMovPromedio.ValueMember = "codigobanco";
            this.cmbBancosMovPromedio.SelectedIndex = 0;
            this.cmbBancosMovPromedio.Enabled = true;
            this.cmbMes.SelectedIndex = 0;

            for (int i = 1950; i <= 2050; i++)
            {
                cmbAnio.Items.Add(i);
            }
            cmbAnio.SelectedItem = DateTime.Today.Year;


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int index = this.cmbBancosMovPromedio.SelectedIndex;
            int codigoBanco = Convert.ToInt32(dsBancos.Tables["bancos"].Rows[index][0].ToString());
            int dia = Convert.ToInt32(DateTime.DaysInMonth(Convert.ToInt32(cmbAnio.SelectedItem.ToString()), Convert.ToInt32(cmbMes.SelectedItem.ToString())));
            int mes = Convert.ToInt32(cmbMes.SelectedItem.ToString());
            int anio = Convert.ToInt32(cmbAnio.SelectedItem.ToString());
            DataSet movimientoPro;

            movimientoPro = empresa.movimientosPromedio(codigoBanco, 1, dia, mes, anio);

            if (movimientoPro.Tables["consultaMovimiento"].Rows.Count > 1)
            {
                int depositos = 0;
                Double promedioDeposito = 0;
                int cheques = 0;
                Double PromedioCheques = 0;

                if (movimientoPro.Tables["consultaMovimiento"].Rows[0][0].ToString() != "")
                {
                    depositos = Convert.ToInt32(movimientoPro.Tables["consultaMovimiento"].Rows[0][0].ToString());
                }

                if (movimientoPro.Tables["consultaMovimiento"].Rows[0][1].ToString() != "")
                {
                    promedioDeposito = Convert.ToDouble(movimientoPro.Tables["consultaMovimiento"].Rows[0][1].ToString());
                }

                if (movimientoPro.Tables["consultaMovimiento"].Rows[1][0].ToString() != "")
                {
                    cheques = Convert.ToInt32(movimientoPro.Tables["consultaMovimiento"].Rows[1][0].ToString());
                }

                if (movimientoPro.Tables["consultaMovimiento"].Rows[1][1].ToString() != "")
                {
                    PromedioCheques = Convert.ToDouble(movimientoPro.Tables["consultaMovimiento"].Rows[1][1].ToString());
                }

                double promedioTotal = (promedioDeposito + PromedioCheques) / 2;

                MessageBox.Show("Depositos: " + depositos + Environment.NewLine + "Cheques: " + cheques + Environment.NewLine + "Total: " + (Convert.ToInt32(depositos) + Convert.ToInt32(cheques)) + Environment.NewLine + "Promedio Mensual: " + promedioTotal + Environment.NewLine + "A la fecha: " + dia + "/" + mes + "/" + anio);
            }
            else
            {
                MessageBox.Show("No se encontraron resultados");

            }
        }
    }
}
