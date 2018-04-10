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
    public partial class frmInformeCierre : Form
    {
        private Controladora empresa = Controladora.Instance;
        private System.Data.DataSet eventosDataSet;
        private dsHistorico DE = new dsHistorico();

        public frmInformeCierre()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataSet eventosDataSet = new DataSet(); //=  empresa.devolverEventosEntreFechas(this.dtpFechaDesde.Value, this.dtpFechaHasta.Value);

            DE.Inciso.Rows.Add("MEF",1,1);
            DE.Inciso.Rows.Add("MEF",1, 2);
            DE.Inciso.Rows.Add("MEF",1, 2);


            DE.Oficina.Rows.Add("DGS", 1, 1);
            DE.Oficina.Rows.Add("CGN", 1, 2);

            DE.historico.Rows.Add("4257-4", 1);
            DE.historico.Rows.Add("35164-5", 2);

            /* 
                        for (int n = 0; n <= eventosDataSet.Tables["eventos"].Rows.Count - 1; n++)
                        {
                            DateTime fecha = eventosDataSet.Tables["eventos"].Rows[n].Field<DateTime>("fecha");
                            String descripcion = eventosDataSet.Tables["eventos"].Rows[n].Field<String>("descripcion");

                            DE.evento.Rows.Add(fecha.ToString("dd/MM/yyyy"), descripcion);
                        }
                        */
            frmVerReportes reporte = new frmVerReportes(DE, "CIERRE");
            reporte.ShowDialog();
           // DE.evento.Rows.Clear();
        }
    }
}
