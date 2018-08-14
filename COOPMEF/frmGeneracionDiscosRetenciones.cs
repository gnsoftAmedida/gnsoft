using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Negocio;

namespace COOPMEF
{
    public partial class frmGeneracionDiscosRetenciones : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsIncisos;
        public frmGeneracionDiscosRetenciones()
        {
            InitializeComponent();
        }

        private void cargarIncisosOficinas()
        {
            dsIncisos = empresa.DevolverIncisos();

            this.cmbInciso.DataSource = dsIncisos.Tables["incisos"];
            this.cmbInciso.DisplayMember = "nombre_completo";
            this.cmbInciso.ValueMember = "inciso_id";
            this.cmbInciso.Enabled = true;
            this.cmbInciso.SelectedIndex = 0;
        }

        private void frmGeneracionDiscosRetenciones_Load(object sender, EventArgs e)
        {
            //Environment.GetLogicalDrives()

            cargarIncisosOficinas();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                cmbUnidades.Items.Add(d);
            }

            cmbAnios.SelectedIndex = 0;
            cmbMeses.SelectedIndex = 0;
            cmbUnidades.SelectedIndex = 0;
        }

        private void cmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String[] dirs = System.IO.Directory.GetDirectories(cmbUnidades.SelectedItem.ToString());

                treeView1.Nodes.Clear();

                foreach (String dir in dirs)
                {
                    treeView1.Nodes.Add(dir.ToString());
                }
            }
            catch
            {
                MessageBox.Show("El dispositivo no está listo");
            }
        }

        private void cmbInciso_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsOficinasDelInciso = null;
            int index = this.cmbInciso.SelectedIndex;
            int idInciso = Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString());

            dsOficinasDelInciso = empresa.DevolverOficinasPorInciso(idInciso);

            if (dsOficinasDelInciso.Tables["oficinas"].Rows.Count > 0)
            {
                this.cmbOficina.DataSource = dsOficinasDelInciso.Tables["oficinas"];
                this.cmbOficina.DisplayMember = "mostrar_nombre";
                this.cmbOficina.ValueMember = "oficina_id";
                this.cmbOficina.Enabled = true;

            }
            else
            {
                this.cmbOficina.DataSource = null;
                this.cmbOficina.Items.Clear();
                this.cmbOficina.Refresh();
            }
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarPlan_Click(object sender, EventArgs e)
        {
            string inciso = cmbInciso.Text;
            string oficina = cmbOficina.Text;
            string mes = cmbMeses.Text;
            string anio = cmbAnios.Text;

            try
            {
                string unidad = treeView1.SelectedNode.Text;
                MessageBox.Show(empresa.generarInterfaces(inciso, oficina, mes, anio, unidad));
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una unidad de destino para generar la interface");
            }
        }
    }
}
