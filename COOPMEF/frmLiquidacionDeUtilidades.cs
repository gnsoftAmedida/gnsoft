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
    public partial class frmLiquidacionDeUtilidades : Form
    {
        private Controladora empresa = Controladora.Instance;
        private Boolean primeraVez = true;
        private Boolean hayParaLiquidar = false;
        private Boolean reciboImpreso = false;
        private String primerEjercicio = "";
        private String ultimoEjercicio = "";
        private DataSet dsDistribucion = null;
        private dsDistribucion dsD = new dsDistribucion();

        public frmLiquidacionDeUtilidades()
        {
            InitializeComponent();
        }

        private void lblNroSocio_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            hayParaLiquidar = false;
            String cedula = txtCedula.Text;
            btnImprimirRecibo.Enabled = false;
            reciboImpreso = false;
            lblAporte.Text = "...";
            lblUtilidades.Text = "...";
            lblTotal.Text = "...";
            this.dsDistribucion = null;

            if (!(txtCedula.Text.Replace(".", "").Replace("-", "").Replace(",", "").Replace("_", "").Trim() == ""))
            {
                DataSet dsSocio = empresa.buscarSociosUtilidades(cedula.Replace(",", "."));

                if (dsSocio.Tables["socioUtilidades"].Rows.Count == 1)
                {
                    lblNombresApellidos.Text = empresa.NomPropio(dsSocio.Tables["socioUtilidades"].Rows[0][3].ToString()) + ", " + empresa.NomPropio(dsSocio.Tables["socioUtilidades"].Rows[0][2].ToString());
                    lblDireccion.Text = dsSocio.Tables["socioUtilidades"].Rows[0][7].ToString();
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
            this.txtUsuario.Text = Utilidades.UsuarioLogueado.Alias;
            hayParaLiquidar = false;

        }

        private void moledarDGV(int id_socio)
        {

            DataSet dsDetalleUtilidades = empresa.detalleUtilidadesLiquidadasYnoLiquidadas(id_socio);

            dsDistribucion = dsDetalleUtilidades;

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

            dgvDetalleUtilidades.Columns["fecha"].HeaderText = "Fecha";
            dgvDetalleUtilidades.Columns["fecha"].Width = 80;

            dgvDetalleUtilidades.Columns["cheque"].HeaderText = "Cheque";
            dgvDetalleUtilidades.Columns["cheque"].Width = 100;

            if (!(primeraVez))
            {
                totalesUtilidades(dsDetalleUtilidades);
            }
            else
            {
                primeraVez = false;
            }
        }

        private void totalesUtilidades(DataSet dsDetalleUtilidades)
        {

            if (dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows.Count > 0)
            {

                Double totalAportes = 0;
                Double totalUtilidades = 0;
                Double gastosAdministrativos = 0;

                for (int i = 0; i <= dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows.Count - 1; i++)
                {
                    if (dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][8].ToString() == "")
                    {
                        totalAportes = totalAportes + Convert.ToDouble(dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][4]);
                        totalUtilidades = totalUtilidades + Convert.ToDouble(dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][6]);
                        hayParaLiquidar = true;
                    }

                    if (dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][8].ToString() == "")
                    {
                        if (primerEjercicio == "")
                        {
                            primerEjercicio = dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][3].ToString();
                        }
                    }

                    if (i + 1 == dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows.Count)
                    {
                        ultimoEjercicio = dsDetalleUtilidades.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][3].ToString();
                    }
                }

                if (hayParaLiquidar)
                {
                    btnImprimirRecibo.Enabled = true;
                }
                else
                {
                    btnImprimirRecibo.Enabled = false;
                }

                gastosAdministrativos = totalUtilidades * 0.2;

                lblAporte.Text = totalAportes.ToString("###,###,##0.00");
                lblUtilidades.Text = totalUtilidades.ToString("###,###,##0.00");
                lblTotal.Text = (totalAportes + totalUtilidades).ToString("###,###,##0.00");
            }
            else
            {
                MessageBox.Show("El Socio no tiene utilidades Generadas.");
            }
        }

        private void btnSalirLiqUtil_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            if (!(txtNroCheque.Text.Trim() == ""))
            {
                reciboImpreso = true;             
                dsD.Clear();
                dsD.utilidad.Rows.Add(lblTotal.Text, txtCedula.Text, lblNombresApellidos.Text, dtpFechaPago.Value.ToShortDateString(), txtNroCheque.Text, primerEjercicio, ultimoEjercicio, "");
                frmVerReportes reporte = new frmVerReportes(dsD, "UTILIDAD");
                reporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("No ha impreso Recibo.");
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            if (hayParaLiquidar)
            {
                if (!(txtNroCheque.Text.Trim() == ""))
                {
                    if (reciboImpreso)
                    {
                        for (int i = 0; i <= dsDistribucion.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows.Count - 1; i++)
                        {
                            if (dsDistribucion.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][9].ToString() == "")
                            {
                                int socio_id = Convert.ToInt32(dsDistribucion.Tables["utilidadesLiquidadasYnoLiquidadas"].Rows[i][1]);
                                String pagadoPor = this.txtUsuario.Text;
                                DateTime fecha = this.dtpFechaPago.Value;
                                String cheque = this.txtNroCheque.Text;
                                empresa.actualizarPagoDistribucion(socio_id, pagadoPor, fecha, cheque);
                            }
                        }
                        MessageBox.Show("Liquidación correcta");
                        buscar();
                    }
                    else
                    {
                        MessageBox.Show("No ha impreso Recibo.");
                    }
                }
                else
                {
                    MessageBox.Show("No ha completado los datos. Falta Cheque");
                }
            }
            else
            {
                MessageBox.Show("No hay utilidades para liquidar.");
            }         
        }
    }
}
