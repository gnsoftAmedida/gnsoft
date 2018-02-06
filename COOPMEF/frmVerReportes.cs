using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace COOPMEF
{
    public partial class frmVerReportes : Form
    {
        public frmVerReportes(System.Data.DataSet DS, String tipo)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (tipo.Equals("RP_EVENTOS"))
            {
                COOPMEF.Reportes.reporteEventos reporteEventos = new COOPMEF.Reportes.reporteEventos();

                reporteEventos.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteEventos;
            }
            
            if (tipo.Equals("SOLICITUD_PRESTAMO"))
            {
                COOPMEF.Reportes.solicitudPrestamo reporteSolicitudPrestamo = new COOPMEF.Reportes.solicitudPrestamo();

                reporteSolicitudPrestamo.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteSolicitudPrestamo;
            }

            if (tipo.Equals("VALE_PRESTAMO"))
            {
                COOPMEF.Reportes.valePrestamo reporteValePrestamo = new COOPMEF.Reportes.valePrestamo();

                reporteValePrestamo.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteValePrestamo;
            }

            if (tipo.Equals("CANCELACION"))
            {
                COOPMEF.Reportes.cancelacionPrestamo reporteCancelacion = new COOPMEF.Reportes.cancelacionPrestamo();

                reporteCancelacion.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteCancelacion;
            }

        }

        private void frmVerReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
