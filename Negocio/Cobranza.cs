﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Cobranza
    {
        private int cobranza_id;
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
        private double aporteCapital;

        public int Cobranza_ID
        {
            get { return cobranza_id; }
            set { cobranza_id = value; }
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

        public double AporteCapital
        {
            get { return aporteCapital; }
            set { aporteCapital = value; }
        }

        public double InteresCuota
        {
            get { return interesCuota; }
            set { interesCuota = value; }
        }

        public DataSet devolverTotales()
        {
            pCobranza tmpCobranza = new pCobranza();
            DataSet cobranzas = tmpCobranza.devolverTotales();
            return cobranzas;
        }

        public DataSet devolverCobranzas()
        {
            pCobranza tmpCobranza = new pCobranza();
            DataSet cobranzas = tmpCobranza.devolverTodas();
            return cobranzas;
        }

        public DataSet devolverCobranzaSocio(int parametro_socio_id)
        {
            pCobranza tmpCobranza = new pCobranza();
            DataSet cobranzaSocio = tmpCobranza.devolverCobranzaSocio(parametro_socio_id);
            return cobranzaSocio;
        }

        public void eliminarAmortizacionVencerCero()
        {
            pCobranza tmpCobranza = new pCobranza();
            tmpCobranza.eliminarAmortizacionVencerCero();
        }

        public void modificarCobranza()
        {
            pCobranza tmpCobranza = new pCobranza();
            tmpCobranza.modificarCobranza(Cobranza_ID, Prestamo_id, Socio_nro, Tasa, Porcentajeiva, Monteopedido, Cantidadcuotas, NroDeCuotas, Importecuota, AmortizacionCuota, InteresCuota, IvaCuota, amortizacionVencer, InteresesVencer, AporteCapital, Socio_id);
        }

        public void cancelarCobranza()
        {
            pCobranza tmpCobranza = new pCobranza();
            tmpCobranza.cancelarCobranza(Cobranza_ID);
        }

        public void GuardarCobranza()
        {
            pCobranza tmpCobranza = new pCobranza();
            tmpCobranza.GuardarCobranza(Prestamo_id, Socio_nro, Tasa, Porcentajeiva, Monteopedido, Cantidadcuotas, NroDeCuotas, Importecuota, AmortizacionCuota, InteresCuota, IvaCuota, amortizacionVencer, InteresesVencer, AporteCapital, Socio_id);
        }

        public void agregarAporteCapitalCobranza()
        {
            pCobranza tmpCobranza = new pCobranza();
            tmpCobranza.agregarAporteCapitalrCobranza(Cobranza_ID, AporteCapital);
        }
    }
}
