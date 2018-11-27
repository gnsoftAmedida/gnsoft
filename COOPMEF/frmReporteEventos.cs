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
    public partial class frmReporteEventos : Form
    {
        private Controladora empresa = Controladora.Instance;
        private System.Data.DataSet eventosDataSet;
        private dsEventos DE = new dsEventos();


        public frmReporteEventos()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            eventosDataSet = empresa.devolverEventosEntreFechas(this.dtpFechaDesde.Value, this.dtpFechaHasta.Value);

            if (eventosDataSet.Tables["eventos"].Rows.Count > 0)
            {
                for (int n = 0; n <= eventosDataSet.Tables["eventos"].Rows.Count - 1; n++)
                {
                    DateTime fecha = eventosDataSet.Tables["eventos"].Rows[n].Field<DateTime>("fecha");
                    String descripcion = eventosDataSet.Tables["eventos"].Rows[n].Field<String>("descripcion");

                    DE.evento.Rows.Add(fecha.ToString("dd/MM/yyyy"), descripcion);
                }
                frmVerReportes reporte = new frmVerReportes(DE, "RP_EVENTOS");
                reporte.ShowDialog();
                DE.evento.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran registros para las fechas seleccionadas");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
