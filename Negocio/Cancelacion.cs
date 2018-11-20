using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    class Cancelacion
    {
        private int cancelacion_id;
        private Prestamo prestamo;
        private int prestamo_id; //Pongo nro prestamo para facilitar la migración   
        private int cuotaspactadas;
        private int cuotaspagadas;
        private double tasa;
        private double montoVale;
        private double importecuota;
        private double amortizacionVencer;
        private double interesesVencer;
        private int socio_id;
        private Socio socio;
        private String socio_nro;
        private String presupuesto;
        private String usuario;
        private DateTime fechaCancelacion;

        public int Cancelacion_id
        {
            get { return cancelacion_id; }
            set { cancelacion_id = value; }
        }

        public Prestamo Prestamo
        {
            get { return prestamo; }
            set { prestamo = value; }
        }

        public int Prestamo_id
        {
            get { return prestamo_id; }
            set { prestamo_id = value; }
        }

        public int Cuotaspactadas
        {
            get { return cuotaspactadas; }
            set { cuotaspactadas = value; }
        }

        public int Cuotaspagadas
        {
            get { return cuotaspagadas; }
            set { cuotaspagadas = value; }
        }

        public double Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }

        public double MontoVale
        {
            get { return montoVale; }
            set { montoVale = value; }
        }

        public double Importecuota
        {
            get { return importecuota; }
            set { importecuota = value; }
        }

        public double AmortizacionVencer
        {
            get { return amortizacionVencer; }
            set { amortizacionVencer = value; }
        }

        public double InteresesVencer
        {
            get { return interesesVencer; }
            set { interesesVencer = value; }
        }

        public int Socio_id
        {
            get { return socio_id; }
            set { socio_id = value; }
        }

        public Socio Socio
        {
            get { return socio; }
            set { socio = value; }
        }

        public String Socio_nro
        {
            get { return socio_nro; }
            set { socio_nro = value; }
        }

        public String Presupuesto
        {
            get { return presupuesto; }
            set { presupuesto = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public DateTime FechaCancelacion
        {
            get { return fechaCancelacion; }
            set { fechaCancelacion = value; }
        }

        public void GuardarCancelacion()
        {
            pCancelacion tmpCancelacion = new pCancelacion();
            tmpCancelacion.GuardarCancelacion(Prestamo_id, Cuotaspactadas, Cuotaspagadas, Tasa, MontoVale, Importecuota, AmortizacionVencer, InteresesVencer, Presupuesto, Socio_nro, Usuario, FechaCancelacion, Socio_id);
        }

        public DataSet devolverCanelacionesPresupuesto(string presupuesto)
        {
            pCancelacion tmpCancelacion = new pCancelacion();
            return tmpCancelacion.devolverCanelacionesPresupuesto(presupuesto);
        }
    }
}
