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
    public partial class frmConsultaSaldosBancarios : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmConsultaSaldosBancarios()
        {
            InitializeComponent();
        }

        private void btnSalirPlan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaSaldosBancarios_Load(object sender, EventArgs e)
        {
            cargarPantalla();
        }

        private void cargarPantalla()
        {
            DataSet dsSaldosBancarios = empresa.DevolverBancos();

            dgvSaldosBancarios.DataSource = dsSaldosBancarios.Tables["bancos"];

            dgvSaldosBancarios.RowHeadersVisible = false;
            dgvSaldosBancarios.ReadOnly = true;
            dgvSaldosBancarios.MultiSelect = false;
            dgvSaldosBancarios.ReadOnly = true;
            dgvSaldosBancarios.AllowDrop = false;
            dgvSaldosBancarios.AllowUserToAddRows = false;
            dgvSaldosBancarios.AllowUserToDeleteRows = false;
            dgvSaldosBancarios.AllowUserToResizeColumns = false;
            dgvSaldosBancarios.AllowUserToResizeRows = false;
            dgvSaldosBancarios.AllowUserToOrderColumns = false;
            dgvSaldosBancarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSaldosBancarios.BackgroundColor = BackColor;
            dgvSaldosBancarios.BorderStyle = BorderStyle.None;

            dgvSaldosBancarios.Columns["codigobanco"].Visible = false;
            dgvSaldosBancarios.Columns["agenciabanco"].Visible = false;            
            dgvSaldosBancarios.Columns["direccionbanco"].Visible = false;
            dgvSaldosBancarios.Columns["telefonobanco"].Visible = false;
            dgvSaldosBancarios.Columns["faxbanco"].Visible = false;
            dgvSaldosBancarios.Columns["mostrarse"].Visible = false;
                   
            dgvSaldosBancarios.Columns["nombrebanco"].HeaderText = "Banco";
            dgvSaldosBancarios.Columns["nombrebanco"].Width = 250;

            dgvSaldosBancarios.Columns["numerocta"].HeaderText = "Nº Cuenta";
            dgvSaldosBancarios.Columns["numerocta"].Width = 150;

            dgvSaldosBancarios.Columns["moneda"].HeaderText = "Moneda";
            dgvSaldosBancarios.Columns["moneda"].Width = 100;

            dgvSaldosBancarios.Columns["saldo"].HeaderText = "Saldo";
            dgvSaldosBancarios.Columns["saldo"].Width = 150;            
        }
    }
}
