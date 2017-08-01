using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logs;

namespace COOPMEF
{
    public partial class frmConsultaLogs : Form
    {
        private DataSet dsLogs;

        public frmConsultaLogs()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RegistroSLogs tmpLog = new RegistroSLogs();

            dsLogs = tmpLog.devolverLogsSegunFecha(dtpFechaDesde.Value, dtpFechaHasta.Value);
            dataGridLogs.DataSource = dsLogs.Tables["logs"];
            dataGridLogs.RowHeadersVisible = false;
            dataGridLogs.ReadOnly = true;
            dataGridLogs.MultiSelect = false;
            dataGridLogs.ReadOnly = true;
            dataGridLogs.AllowDrop = false;
            dataGridLogs.AllowUserToAddRows = false;
            dataGridLogs.AllowUserToDeleteRows = false;
            dataGridLogs.AllowUserToResizeColumns = false;
            dataGridLogs.AllowUserToResizeRows = false;
            dataGridLogs.AllowUserToOrderColumns = false;
            dataGridLogs.BackgroundColor = BackColor;
            dataGridLogs.BorderStyle = BorderStyle.None;
            dataGridLogs.Columns["log_id"].HeaderText = "Número";
            dataGridLogs.Columns["log_id"].Visible = false;
            dataGridLogs.Columns["log_fecha"].HeaderText = "Fecha";
            dataGridLogs.Columns["log_fecha"].Width = 120;
            dataGridLogs.Columns["log_usuario"].HeaderText = "Usuario";
            dataGridLogs.Columns["log_registro"].HeaderText = "Registro";
            dataGridLogs.Columns["log_registro"].Width = 400;
        }
    }
}
