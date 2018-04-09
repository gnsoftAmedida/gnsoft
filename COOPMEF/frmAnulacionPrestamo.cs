using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Logs;

namespace COOPMEF
{
    public partial class frmAnulacionPrestamo : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmAnulacionPrestamo()
        {
            InitializeComponent();
        }

        private void cargarPantalla()
        {
            DataSet dsCobranzasProvisorias = empresa.DevolverCobranzasProvisorias();

            dgvPrestamosSinLiquidar.DataSource = dsCobranzasProvisorias.Tables["cobranzasProvisorias"];

            dgvPrestamosSinLiquidar.RowHeadersVisible = false;
            dgvPrestamosSinLiquidar.ReadOnly = true;
            dgvPrestamosSinLiquidar.MultiSelect = false;
            dgvPrestamosSinLiquidar.ReadOnly = true;
            dgvPrestamosSinLiquidar.AllowDrop = false;
            dgvPrestamosSinLiquidar.AllowUserToAddRows = false;
            dgvPrestamosSinLiquidar.AllowUserToDeleteRows = false;
            dgvPrestamosSinLiquidar.AllowUserToResizeColumns = false;
            dgvPrestamosSinLiquidar.AllowUserToResizeRows = false;
            dgvPrestamosSinLiquidar.AllowUserToOrderColumns = false;
            dgvPrestamosSinLiquidar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamosSinLiquidar.BackgroundColor = BackColor;
            dgvPrestamosSinLiquidar.BorderStyle = BorderStyle.None;

            dgvPrestamosSinLiquidar.Columns["cobranzaProvisoria_id"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["tasa"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["porcentajeiva"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["nrodecuotas"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["AmortizacionCuota"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["InteresCuota"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["IvaCuota"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["AmortizacionVencer"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["InteresVencer"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["aportecapital"].Visible = false;
            dgvPrestamosSinLiquidar.Columns["socio_id"].Visible = false;

            dgvPrestamosSinLiquidar.Columns["prestamo_id"].HeaderText = "Nro Préstamo";
            dgvPrestamosSinLiquidar.Columns["prestamo_id"].Width = 150;

            dgvPrestamosSinLiquidar.Columns["cedula"].HeaderText = "Cédula";
            dgvPrestamosSinLiquidar.Columns["cedula"].Width = 150;

            dgvPrestamosSinLiquidar.Columns["montopedido"].HeaderText = "Monto $";
            dgvPrestamosSinLiquidar.Columns["montopedido"].Width = 150;

            dgvPrestamosSinLiquidar.Columns["cantidadcuotas"].HeaderText = "Cuotas";
            dgvPrestamosSinLiquidar.Columns["cantidadcuotas"].Width = 100;

            dgvPrestamosSinLiquidar.Columns["importecuota"].HeaderText = "Cuota $";
            dgvPrestamosSinLiquidar.Columns["importecuota"].Width = 180;

        }

        private void frmAnulacionPrestamo_Load(object sender, EventArgs e)
        {
            cargarPantalla();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPrestamosSinLiquidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvPrestamosSinLiquidar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgvPrestamosSinLiquidar.CurrentRow == null))
            {
                int index = dgvPrestamosSinLiquidar.CurrentRow.Index;
                int idCobranzaProvisoria = (int)dgvPrestamosSinLiquidar.Rows[index].Cells["cobranzaProvisoria_id"].Value;

                if (index != -1)
                {
                    string message = "¿Está seguro que desea anular el préstamo?";
                    string caption = "COOPMEF";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        empresa.eliminarCobranzaProvisoria(idCobranzaProvisoria);
                        MessageBox.Show("Préstamo anulado correctamente");

                        RegistroSLogs registroLogs = new RegistroSLogs();
                        registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Anulación préstamo " + dgvPrestamosSinLiquidar.Rows[index].Cells["cedula"].Value);

                        cargarPantalla();
                    }
                }
            }
        }
    }
}
