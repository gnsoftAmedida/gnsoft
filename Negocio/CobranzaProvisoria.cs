using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class CobranzaProvisoria
    {
        private int cobranzaProvisoria_id;
        private Prestamo prestamo;
        private int prestamo_id; //Pongo nro prestamo para facilitar la migración    
        private int socio_id;
        private Socio socio;
        private string socio_nro; //Pongo la cédula para facilitar la migración
        private double tasa;
        private double porcentajeiva;
        private double monteopedido;
        private int cantidadcuotas;
        private int nroDeCuotas;
        private double importecuota;
        private double amortizacionCuota;
        private double interesCuota;
        private double ivaCuota;
        private double amortizacionVencer;
        private double interesesVencer;

        public int Cobranza_ID
        {
            get { return cobranzaProvisoria_id; }
            set { cobranzaProvisoria_id = value; }
        }

        public Prestamo Prestamo
        {
            get { return prestamo; }
            set { prestamo = value; }
        }

        public Socio Socio
        {
            get { return socio; }
            set { socio = value; }
        }

        public string Socio_nro
        {
            get { return socio_nro; }
            set { socio_nro = value; }
        }

        public int Prestamo_id
        {
            get { return prestamo_id; }
            set { prestamo_id = value; }
        }

        public int Socio_id
        {
            get { return socio_id; }
            set { socio_id = value; }
        }

        public double Monteopedido
        {
            get { return monteopedido; }
            set { monteopedido = value; }
        }

        public double Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }

        public int Cantidadcuotas
        {
            get { return cantidadcuotas; }
            set { cantidadcuotas = value; }
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

        public double Porcentajeiva
        {
            get { return porcentajeiva; }
            set { porcentajeiva = value; }
        }

        public double InteresesVencer
        {
            get { return interesesVencer; }
            set { interesesVencer = value; }
        }

        public int NroDeCuotas
        {
            get { return nroDeCuotas; }
            set { nroDeCuotas = value; }
        }

        public double AmortizacionCuota
        {
            get { return amortizacionCuota; }
            set { amortizacionCuota = value; }
        }

        public double IvaCuota
        {
            get { return ivaCuota; }
            set { ivaCuota = value; }
        }
        public double InteresCuota
        {
            get { return interesCuota; }
            set { interesCuota = value; }
        }

        public void VaciarTablaCobranzaProvisoria()
        {
            pCobranzaProvisoria tmpCobranzaProvisoria = new pCobranzaProvisoria();
            tmpCobranzaProvisoria.VaciarTablaCobranzaProvisoria();
        }

        public DataSet devolverCobranzasProvisorias()
        {
            pCobranzaProvisoria tmpCobranzaProvisoria = new pCobranzaProvisoria();
            DataSet cobranzasProvisorias = tmpCobranzaProvisoria.devolverTodas();
            return cobranzasProvisorias;
        }

        public void eliminarCobranzaProvisoria(int Id)
        {
            pCobranzaProvisoria tmpCobranzaProvisoria = new pCobranzaProvisoria();
            tmpCobranzaProvisoria.eliminarCobranzaProvisoria(Id);
        }

        public DataSet devolverCobranzaProvisoriaSocio(int parametro_socio_id)
        {
            pCobranzaProvisoria tmpCobranzaProvisoria = new pCobranzaProvisoria();
            DataSet cobranzaProvisoriaSocio = tmpCobranzaProvisoria.devolverCobranzaProvisoriaSocio(parametro_socio_id);
            return cobranzaProvisoriaSocio;
        }

        public void GuardarCobranzaProvisoria()
        {
            pCobranzaProvisoria tmpCobranzaProvisoria = new pCobranzaProvisoria();
            tmpCobranzaProvisoria.GuardarCobranzaProvisoria(Prestamo_id, Socio_nro, Tasa, Porcentajeiva, Monteopedido, Cantidadcuotas, NroDeCuotas, Importecuota, AmortizacionCuota, InteresCuota, IvaCuota, amortizacionVencer, InteresesVencer, Socio_id);
        }
    }
}
