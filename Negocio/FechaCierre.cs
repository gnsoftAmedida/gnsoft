using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Persistencia;

namespace Negocio
{
    public class FechaCierre
    {

        private int fechaCierre_id;
        private string presupuesto;
        private DateTime fechaDesde;
        private DateTime horaDesde;
        private DateTime fechaHasta;
        private DateTime horaHasta;
        private double totalImporte;
        private double amortizacionAVencer;
        private double interesesAVencer;


        public int FechaCierre_id
        {
            get { return fechaCierre_id; }
            set { fechaCierre_id = value; }
        }
        
        public string Presupuesto
        {
            get { return presupuesto; }
            set { presupuesto = value; }
        }
        
        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }
        
        public DateTime HoraDesde
        {
            get { return horaDesde; }
            set { horaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }

        public DateTime HoraHasta
        {
            get { return horaHasta; }
            set { horaHasta = value; }
        }
        
        public double TotalImporte
        {
            get { return totalImporte; }
            set { totalImporte = value; }
        }
       
        public double AmortizacionAVencer
        {
            get { return amortizacionAVencer; }
            set { amortizacionAVencer = value; }
        }
       
        public double InteresesAVencer
        {
            get { return interesesAVencer; }
            set { InteresesAVencer = value; }
        }

        public void GuardarFechaCierre()
        {
            pFechaCierre tmpFechaCierre = new pFechaCierre();
            tmpFechaCierre.GuardarFechaCierre(Presupuesto, FechaDesde, HoraDesde, FechaHasta, HoraHasta, TotalImporte, AmortizacionAVencer, InteresesAVencer);           
        }

        public DataSet devolverTodos()
        {
            pFechaCierre tmpFechaCierre = new pFechaCierre();
            DataSet fechasCierres = tmpFechaCierre.devolverTodos();
            return fechasCierres;
        }
    }
}
