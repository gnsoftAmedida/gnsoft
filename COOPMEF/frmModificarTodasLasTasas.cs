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


    public partial class frmModificarTodasLasTasas : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmModificarTodasLasTasas()
        {
            InitializeComponent();
        }

        private void frmModificarTodasLasTasas_Load(object sender, EventArgs e)
        {

        }

        private void btnSalirPlan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool esDecimal(string nroPrueba)
        {
            double resultado = 0;
            Boolean esDouble = double.TryParse(nroPrueba, out resultado);

            Boolean esPositivo = false;

            if (esDouble)
            {

                if (resultado > 0)
                {
                    esPositivo = true;
                }
            }

            return esDouble && esPositivo;
        }

        private void btnGuardarPlan_Click(object sender, EventArgs e)
        {
            if (esDecimal(textBox1.Text.Replace(".", ",")))
            {
                if (Convert.ToDouble(textBox1.Text.Replace(".", ",")) >= 1)
                {
                    string message = "¿Está seguro de que desea modificar todas las tasas?";
                    string caption = "Modificar tasas";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        empresa.modificarTasas(Convert.ToDouble(textBox1.Text.Replace(".", ",")));
                        MessageBox.Show("Tasas modificadas correctamente");
                        textBox1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("La tasa debe ser un valor numérico positivo mayor o igual a 1");
                }
            }
            else
            {

                MessageBox.Show("La tasa debe ser un valor numérico positivo mayor o igual a 1");
            }
        }
    }
}
