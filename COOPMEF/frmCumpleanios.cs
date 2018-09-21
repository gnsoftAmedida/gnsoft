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
    public partial class frmCumpleanios : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsSociosIngresadosEn ingresadosEn = new dsSociosIngresadosEn();

        public frmCumpleanios()
        {
            InitializeComponent();
        }

        private void frmCumpleanios_Load(object sender, EventArgs e)
        {
           cmbMeses.SelectedIndex = DateTime.Today.Month - 1;
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(this.cmbMeses.SelectedIndex + 1);
            string mesNombre = cmbMeses.SelectedItem.ToString();

            DataSet sociosResultado = empresa.devolverCumpleMes(mes);

            if (sociosResultado.Tables["sociosCumpleMes"].Rows.Count > 0)
            {
                for (int n = 0; n <= sociosResultado.Tables["sociosCumpleMes"].Rows.Count - 1; n++)
                {
                    string socio_apellido = sociosResultado.Tables["sociosCumpleMes"].Rows[n][3].ToString();
                    string socio_nombre = sociosResultado.Tables["sociosCumpleMes"].Rows[n][2].ToString();
                    string numerocobro = sociosResultado.Tables["sociosCumpleMes"].Rows[n][4].ToString();
                    string numeroSocio = sociosResultado.Tables["sociosCumpleMes"].Rows[n][1].ToString();
                    string fechaNac = sociosResultado.Tables["sociosCumpleMes"].Rows[n][5].ToString();
                    string baja = sociosResultado.Tables["sociosCumpleMes"].Rows[n][14].ToString();
                    string telefono = sociosResultado.Tables["sociosCumpleMes"].Rows[n][13].ToString();
                    string oficina = sociosResultado.Tables["sociosCumpleMes"].Rows[n][17].ToString();
                    string Inciso = sociosResultado.Tables["sociosCumpleMes"].Rows[n][16].ToString();

                    ingresadosEn.SociosIngresadosEn.Rows.Add(socio_apellido, socio_nombre, numeroSocio, fechaNac, baja, telefono, mesNombre, mesNombre, Inciso, oficina, numerocobro);
                }
                frmVerReportes reporte = new frmVerReportes(ingresadosEn, "SOCIOS_CUMPLE");
                reporte.ShowDialog();
                ingresadosEn.SociosIngresadosEn.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No hay socios cuyo cumpleaños sea en " + mesNombre);
            }
        }
    }
}
