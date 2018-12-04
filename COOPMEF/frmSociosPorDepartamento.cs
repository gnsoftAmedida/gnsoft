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
    public partial class frmSociosPorDepartamento : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsSociosIngresadosEn ingresadosEn = new dsSociosIngresadosEn();

        public frmSociosPorDepartamento()
        {
            InitializeComponent();
        }

        private void frmSociosPorDepartamento_Load(object sender, EventArgs e)
        {
            DataSet dsDepartamentos = empresa.DevolverDepartamentos();
            this.cmbDepartamento.DataSource = dsDepartamentos.Tables["departamentos"];
            this.cmbDepartamento.DisplayMember = "departamento_nombre";
            this.cmbDepartamento.ValueMember = "departamento_id";
            this.cmbDepartamento.SelectedIndex = 9;

            this.cmbSigno.SelectedIndex = 0;
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string departamento = cmbDepartamento.SelectedValue.ToString();           
            string signo = cmbSigno.SelectedItem.ToString();

            DataSet sociosResultado = empresa.listadoSociosDepartamento(signo, departamento);

            if (sociosResultado.Tables["sociosDepartamento"].Rows.Count > 0)
            {
                for (int n = 0; n <= sociosResultado.Tables["sociosDepartamento"].Rows.Count - 1; n++)
                {
                    string socio_apellido = sociosResultado.Tables["sociosDepartamento"].Rows[n][3].ToString();
                    string socio_nombre = sociosResultado.Tables["sociosDepartamento"].Rows[n][2].ToString();
                    string numerocobro = sociosResultado.Tables["sociosDepartamento"].Rows[n][4].ToString();
                    string numeroSocio = sociosResultado.Tables["sociosDepartamento"].Rows[n][1].ToString();
                    string direccion = sociosResultado.Tables["sociosDepartamento"].Rows[n][14].ToString();
                    string baja = sociosResultado.Tables["sociosDepartamento"].Rows[n][18].ToString();
                    string bajaResultado = "NO";

                    if (baja == "0")
                    {
                        bajaResultado = "SI";
                    }

                    string telefono = sociosResultado.Tables["sociosDepartamento"].Rows[n][13].ToString();
                    string oficina = sociosResultado.Tables["sociosDepartamento"].Rows[n][17].ToString();
                    string Inciso = sociosResultado.Tables["sociosDepartamento"].Rows[n][16].ToString();

                    ingresadosEn.SociosIngresadosEn.Rows.Add(socio_apellido, socio_nombre, numeroSocio, direccion, bajaResultado, telefono, DateTime.Today.ToShortDateString(), DateTime.Today.ToShortTimeString(), Inciso, oficina, numerocobro);
                }
                frmVerReportes reporte = new frmVerReportes(ingresadosEn, "SOCIOS_LISTADO_DEPTO");
                reporte.ShowDialog();
                ingresadosEn.SociosIngresadosEn.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran socios en el departamento seleccionado");
            }
        }
    }
}
