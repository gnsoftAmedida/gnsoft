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

            if (tipo.Equals("EXCEDIDO"))
            {
                COOPMEF.Reportes.InfoExcedidos reporteCobranzaExcedidos = new COOPMEF.Reportes.InfoExcedidos();

                reporteCobranzaExcedidos.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteCobranzaExcedidos;
            }


            if (tipo.Equals("PRESTAMOS_PRESUPUESTO"))
            {
                COOPMEF.Reportes.reportePrestamosPresupuesto reportePrestamosTmp = new COOPMEF.Reportes.reportePrestamosPresupuesto();

                reportePrestamosTmp.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reportePrestamosTmp;
            }

            //Reporte Cierre
            if (tipo.Equals("PRESUPUESTO_MES"))
            {
                COOPMEF.Reportes.reporte_presupuesto_mes reportePrestamosTmp = new COOPMEF.Reportes.reporte_presupuesto_mes();

                reportePrestamosTmp.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reportePrestamosTmp;
            }

            if (tipo.Equals("SOLICITUD_INGRESO"))
            {
                COOPMEF.Reportes.solicitudIngreso reporteSolicitudIngreso = new COOPMEF.Reportes.solicitudIngreso();

                reporteSolicitudIngreso.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = reporteSolicitudIngreso;
            }

            if (tipo.Equals("SOCIOS_ACTIVOS"))
            {
                COOPMEF.Reportes.socioActivos tmpSocioActivos = new COOPMEF.Reportes.socioActivos();

                tmpSocioActivos.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpSocioActivos;
            }

            if (tipo.Equals("SOCIOS_HISTORICOS"))
            {
                COOPMEF.Reportes.socioHistoricos tmpsocioHistoricos = new COOPMEF.Reportes.socioHistoricos();

                tmpsocioHistoricos.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpsocioHistoricos;

            }

            if (tipo.Equals("SOCIOS_BAJA_EN"))
            {
                COOPMEF.Reportes.reporteSocioBajaEn tmpReporteSocioBajaEn = new COOPMEF.Reportes.reporteSocioBajaEn();

                tmpReporteSocioBajaEn.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteSocioBajaEn;

            }

            if (tipo.Equals("SOCIOS_CUMPLE"))
            {
                COOPMEF.Reportes.socioCumple tmpsocioCumple = new COOPMEF.Reportes.socioCumple();

                tmpsocioCumple.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpsocioCumple;

            }

            if (tipo.Equals("SOCIOS_LISTADO_DEPTO"))
            {
                COOPMEF.Reportes.socioDepartamento tmpSocioDepartamento = new COOPMEF.Reportes.socioDepartamento();

                tmpSocioDepartamento.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpSocioDepartamento;

            }
            if (tipo.Equals("SOCIOS_ACTIVOS_EDAD"))
            {
                COOPMEF.Reportes.socioEdad tmpSocioEdad = new COOPMEF.Reportes.socioEdad();

                tmpSocioEdad.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpSocioEdad;

            }
            if (tipo.Equals("SOCIOS_INGRESADOS_EN"))
            {
                COOPMEF.Reportes.socioDepartamento tmpSocioDepartamento = new COOPMEF.Reportes.socioDepartamento();

                tmpSocioDepartamento.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpSocioDepartamento;

            }
            if (tipo.Equals("INTERFACES_GENERALES"))
            {
                COOPMEF.Reportes.ReporteInterfacesGenerales tmpReporteInterfacesGenerales = new COOPMEF.Reportes.ReporteInterfacesGenerales();

                tmpReporteInterfacesGenerales.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteInterfacesGenerales;
            }

            if (tipo.Equals("FACTURAS"))
            {
                COOPMEF.Reportes.facturas tmpfacturas = new COOPMEF.Reportes.facturas();

                tmpfacturas.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpfacturas;
            }

            if (tipo.Equals("CUENTAS_CORRIENTES"))
            {
                COOPMEF.Reportes.reporteCuentaCorriente tmpReporteCuentaCorriente = new COOPMEF.Reportes.reporteCuentaCorriente();

                tmpReporteCuentaCorriente.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteCuentaCorriente;
            }

            if (tipo.Equals("CANCELACION_ANTICIPADA"))
            {
                COOPMEF.Reportes.reporteCancelacionAnticipada tmpReporteCancelacionAnticipada = new COOPMEF.Reportes.reporteCancelacionAnticipada();

                tmpReporteCancelacionAnticipada.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteCancelacionAnticipada;
            }

            if (tipo.Equals("CANCELACION_FALLECIMIENTO"))
            {
                COOPMEF.Reportes.CancelacionFallecimiento tmpReporteCancelacionFallecimiento = new COOPMEF.Reportes.CancelacionFallecimiento();

                tmpReporteCancelacionFallecimiento.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteCancelacionFallecimiento;
            }

            if (tipo.Equals("PRESTAMOS_PENDIENTES"))
            {
                COOPMEF.Reportes.reportePrestamosPendientes tmpReportePrestamosPendientes = new COOPMEF.Reportes.reportePrestamosPendientes();

                tmpReportePrestamosPendientes.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReportePrestamosPendientes;
            }

            if (tipo.Equals("HISTORICO_GANANCIAS"))
            {
                COOPMEF.Reportes.reporteHistoricoUtilidades tmpReporteHistoricoUtilidades = new COOPMEF.Reportes.reporteHistoricoUtilidades();

                tmpReporteHistoricoUtilidades.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteHistoricoUtilidades;
            }

            if (tipo.Equals("PAGO_EXCEDIDOS_PRESUPUESTO"))
            {
                COOPMEF.Reportes.reportePagoExcedidosPresupuesto tmpReportePagoExcedidosPresupuesto = new COOPMEF.Reportes.reportePagoExcedidosPresupuesto();

                tmpReportePagoExcedidosPresupuesto.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReportePagoExcedidosPresupuesto;
            }
            if (tipo.Equals("EXCEDIDOS_DE_UN_MES"))
            {
                COOPMEF.Reportes.reporteExcedidosDeUnMes tmpReporteExcedidosDeUnMes = new COOPMEF.Reportes.reporteExcedidosDeUnMes();

                tmpReporteExcedidosDeUnMes.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteExcedidosDeUnMes;
            }

            if (tipo.Equals("EXCEDIDOS_SOCIO_HISTORICO"))
            {
                COOPMEF.Reportes.reporteExcedidoSocioHistorico tmpReporteExcedidoSocioHistorico = new COOPMEF.Reportes.reporteExcedidoSocioHistorico();

                tmpReporteExcedidoSocioHistorico.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpReporteExcedidoSocioHistorico;
            }

            if (tipo.Equals("UTILIDAD"))
            {
                COOPMEF.Reportes.pagoUtilidad tmpPagoUtilidad = new COOPMEF.Reportes.pagoUtilidad();

                tmpPagoUtilidad.SetDataSource(DS);

                this.crystalReportViewer1.ReportSource = tmpPagoUtilidad;
            }
        }

        private void frmVerReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
