using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Prestamo
    {
        private int id; // Autonumerico. Es el número de prestamo
        private Socio socio; // Es para guardar el ID de Socio
        private string socio_nro; //Pongo la cédula para facilitar la migración
        private DateTime fecha;
        private DateTime hora;
        private double monteopedido;
        private double tasa;
        private int cantidadcuotas;
        private double importecuota;
        private int numeroPrestamoAnt;
        private double montopedidoAnt;
        private double amortizacionVencer;
        private double interesesVencer;
        private int cuotasPactadas;
        private int cuotasPagadas;
        private int cuotaAnt;
        private double tasaanterior;
        private int anulado;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
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

        public int NumeroPrestamoAnt
        {
            get { return numeroPrestamoAnt; }
            set { numeroPrestamoAnt = value; }
        }

        public double MontopedidoAnt
        {
            get { return montopedidoAnt; }
            set { montopedidoAnt = value; }
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

        public int CuotasPactadas
        {
            get { return cuotasPactadas; }
            set { cuotasPactadas = value; }
        }

        public int CuotasPagadas
        {
            get { return cuotasPagadas; }
            set { cuotasPagadas = value; }
        }

        public int CuotaAnt
        {
            get { return cuotaAnt; }
            set { cuotaAnt = value; }
        }

        public double Tasaanterior
        {
            get { return tasaanterior; }
            set { tasaanterior = value; }
        }

        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        public void Guardar()
        {
            pPrestamo tmpPrestamo = new pPrestamo();
            tmpPrestamo.GuardarPrestamo(Socio.Socio_id, Socio_nro, Fecha, Hora, Monteopedido, Tasa, Cantidadcuotas, Importecuota, NumeroPrestamoAnt, MontopedidoAnt, AmortizacionVencer, InteresesVencer, CuotasPactadas, CuotasPagadas, CuotaAnt, Tasaanterior, Anulado);
        }

          public DataSet devolverPrestamoActivoSocio(int idSocio)
        {
            pPrestamo tmpOficina = new pPrestamo();
            DataSet prestamoActivo = tmpOficina.devolverPrestamoActivoSocio(idSocio);
            return prestamoActivo;
        }
    }
}
