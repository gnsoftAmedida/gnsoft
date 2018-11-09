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
    public partial class frmLiquidacionDeUtilidades : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmLiquidacionDeUtilidades()
        {
            InitializeComponent();
        }

        private void lblNroSocio_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String cedula = txtCedula.Text;
           

            if (!(txtCedula.Text.Replace(".", "").Replace("-", "").Replace(",", "").Replace("_", "").Trim() == ""))
            {
                DataSet dsSocio = empresa.buscarSociosUtilidades(cedula.Replace(",", "."));

                if (dsSocio.Tables["socioUtilidades"].Rows.Count == 1)
                {
                    lblNombresApellidos.Text = empresa.NomPropio(dsSocio.Tables["socioUtilidades"].Rows[0][3].ToString()) + ", " + empresa.NomPropio(dsSocio.Tables["socioUtilidades"].Rows[0][2].ToString());
                    lblDireccion.Text = dsSocio.Tables["socioUtilidades"].Rows[0][7].ToString();
                    lblCesion.Text = dsSocio.Tables["socioUtilidades"].Rows[0][6].ToString();
                    lblFechaIngresoSocio.Text = dsSocio.Tables["socioUtilidades"].Rows[0][5].ToString().Substring(0, 10);

                    moledarDGV(Convert.ToInt32(dsSocio.Tables["socioUtilidades"].Rows[0][0]));


                   


                }
                else
                {
                    MessageBox.Show("No se Ubica el Socio.");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar la cédula del socio");
            }
        }

        private void frmLiquidacionDeUtilidades_Load(object sender, EventArgs e)
        {
            // Consulta para generar la cáscara del DGV
            moledarDGV(0);
        }

        private void moledarDGV(int id_socio)
        {

            DataSet dsDetalleUtilidades = empresa.detalleUtilidadesLiquidadasYnoLiquidadas(id_socio);

            dgvDetalleUtilidades.DataSource = dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"];

            dgvDetalleUtilidades.RowHeadersVisible = false;
            dgvDetalleUtilidades.ReadOnly = true;
            dgvDetalleUtilidades.MultiSelect = false;
            dgvDetalleUtilidades.ReadOnly = true;
            dgvDetalleUtilidades.AllowDrop = false;
            dgvDetalleUtilidades.AllowUserToAddRows = false;
            dgvDetalleUtilidades.AllowUserToDeleteRows = false;
            dgvDetalleUtilidades.AllowUserToResizeColumns = false;
            dgvDetalleUtilidades.AllowUserToResizeRows = false;
            dgvDetalleUtilidades.AllowUserToOrderColumns = false;
            dgvDetalleUtilidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleUtilidades.BackgroundColor = BackColor;
            dgvDetalleUtilidades.BorderStyle = BorderStyle.None;


            dgvDetalleUtilidades.Columns["iddistribucion"].Visible = false;
            dgvDetalleUtilidades.Columns["socio_id"].Visible = false;
            dgvDetalleUtilidades.Columns["cedula"].Visible = false;
            dgvDetalleUtilidades.Columns["interesesAportados"].Visible = false;
            dgvDetalleUtilidades.Columns["socio_id"].Visible = false;

            dgvDetalleUtilidades.Columns["ejercicio"].HeaderText = "Ejercicio";
            dgvDetalleUtilidades.Columns["ejercicio"].Width = 70;

            dgvDetalleUtilidades.Columns["aportesCapital"].HeaderText = "Ap.Cap $";
            dgvDetalleUtilidades.Columns["aportesCapital"].Width = 95;

            dgvDetalleUtilidades.Columns["utilidades"].HeaderText = "Utilidades $";
            dgvDetalleUtilidades.Columns["utilidades"].Width = 95;

            dgvDetalleUtilidades.Columns["pagadopor"].HeaderText = "Pagado Por";
            dgvDetalleUtilidades.Columns["pagadopor"].Width = 100;

            dgvDetalleUtilidades.Columns["fecha"].HeaderText = "Fecha Pago";
            dgvDetalleUtilidades.Columns["fecha"].Width = 90;

            dgvDetalleUtilidades.Columns["cheque"].HeaderText = "Cheque";
            dgvDetalleUtilidades.Columns["cheque"].Width = 100;



            Double totalAportes = 0;
            Double totalUtilidades = 0;

            for (int i = 0; i <= dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows.Count - 1; i++)
            {
                //if fecha es nula
                totalAportes = totalAportes + Convert.ToDouble(dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][4]);
                totalUtilidades = totalUtilidades + Convert.ToDouble(dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][6]);
            }

        }

        private void btnSalirLiqUtil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
