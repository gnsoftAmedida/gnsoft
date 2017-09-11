using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;
using Microsoft.VisualBasic;


namespace Negocio
{
    public class Prestamo
    {
        private int id; // Autonumerico. Es el número de prestamo
        private Socio socio; // Es para guardar el ID de Socio
        private string cedulasocio; //Pongo la cédula para facilitar la migración
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

        public string Cedulasocio
        {
            get { return cedulasocio; }
            set { cedulasocio = value; }
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

        public DateTime VtoPrimerCuota(DateTime Fecha)
        {
            DateTime VtoPrimerCuota;
            DateTime FechaNueva;

            FechaNueva = DateTime.Today.AddDays(15);

            // VEEER porque en la original se llamaba a la función UltimoDiaMes que Leo no la pasó
            VtoPrimerCuota = Convert.ToDateTime(DateTime.DaysInMonth(FechaNueva.Year, FechaNueva.Month) + "/" + FechaNueva.Month + "/" + FechaNueva.Year);
              
            return VtoPrimerCuota;
        }

        public DateTime VtoPto(DateTime Fecha)
        {
            DateTime VtoPto;
            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Day) <= 10))
            { //Fecha tope dentro del mes para cierre de presupuesto
                if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) != 2))
                {
                    VtoPto = Convert.ToDateTime("30" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
                else
                {
                    VtoPto = Convert.ToDateTime("28" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
            }

            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 12))
            { // Si mes es igual a 12 y día mayor a 10 debe cerrar 

                VtoPto = Convert.ToDateTime("30" + "/01/" + (Fecha.Year + 1)); // El mes siguiente del año siguiente
            }
            else if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 1))
            {
                VtoPto = Convert.ToDateTime("28" + "/02/" + (Fecha.Year));
            }
            else
            {
                VtoPto = Convert.ToDateTime("30" + "/" + (Fecha.Month + 1) + "/" + Fecha.Year);
            }
            return VtoPto;
        }

        public double IntVencer(double ImpCuota, int CantidadCuotas, int NroCuota, double AmoVencer)
        {

            double IntVencer;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                IntVencer = 0;
            }
            else
            {
                IntVencer = Convert.ToDouble(Strings.Format(((ImpCuota * (CantidadCuotas - NroCuota)) - AmoVencer), "##########.00"));
            }
            return IntVencer;
        }

        public double Pago_Mora(double Importe, string Presupuesto, double Xmora, string QueFecha)
        {
            double Pago_Mora;

            // Importe es la base de cálculo que quedó debiendo
            // Presupuesto es el mes en que no se le pudo descontar
            // Xmora  es la tasa para cobro de mora seteado en parametros

            string Mes; // * 2;  VEEERRR
            string Año; //* 4;   VEEERRR
            DateTime FechasDesde;
            DateTime QueFechaResultado;
            int CantidadDias;
            double TasaDeCobro;

            Mes = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2);
            Año = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4);
            TasaDeCobro = 0;

            if (Microsoft.VisualBasic.Conversion.Val(Mes) == 12)
            {
                FechasDesde = Convert.ToDateTime("01/01/" + (Microsoft.VisualBasic.Conversion.Val(Año) + 1));
            }
            else
            {
                FechasDesde = Convert.ToDateTime("01/" + (Microsoft.VisualBasic.Conversion.Val(Mes) + 1) + "/" + Año);
            }

            if (QueFecha != "")
            {
                QueFechaResultado = Convert.ToDateTime(QueFecha);
            }

            if (QueFecha == "") //cobranza por caja
            {
                TimeSpan ts = DateTime.Today - FechasDesde;
                CantidadDias = ts.Days;
            }
            else
            {
                TimeSpan ts = Convert.ToDateTime(QueFecha) - FechasDesde;
                CantidadDias = ts.Days;
            }

            // tasa = tasa + 100; //ejemp. 60 + 100 = 160
            // tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            // tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            TasaDeCobro = Math.Pow(TasaDeCobro, CantidadDias / 360);
            TasaDeCobro = TasaDeCobro - 1;
            Pago_Mora = Importe * TasaDeCobro;

            return Pago_Mora;
        }

        public double AmortVencer(double tasa, int CantidadCuotas, int NroCuota, double ImpCuota)
        {
            double AmortVencer;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                AmortVencer = 0;
            }

            AmortVencer = Convert.ToDouble(Strings.Format(ImpCuota * ((1 - Math.Pow(1 / (1 + (tasa)), (CantidadCuotas - NroCuota))) / tasa), "##########.00"));

            return AmortVencer;
        }

        public double AmortCuota(double tasa, int NroCuota, int CantidadCuotas, double Capital)
        {
            double AmortCuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            AmortCuota = Convert.ToDouble(Strings.Format(Financial.PPmt(tasa, NroCuota, CantidadCuotas, -Capital, 0, 0), "##########.00"));

            return AmortCuota;
        }

        public double Cuota(double tasa, int CantidadCuotas, double Capital)
        {
            double Cuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            Cuota = Convert.ToDouble(Strings.Format(Financial.Pmt(tasa, CantidadCuotas, -Capital), "##########.00"));

            return Cuota;
        }

        public double CalculoInteres(int Dias, int NroCuotas, double tasa, double Iva)
        {
            double Wiva;
            double Wtasa;
            double InteresMensual;
            double Wdias;
            double CalculoInteres;

            Wtasa = (tasa + 100) / 100;
            Wiva = (Iva + 100) / 100;
            Wdias = Dias / 30;

            /*aclaración de parámetros
             * días días al primer vencimiento
             * Nrocuota para saber si es la primera o las consecutivas
             * tasa interes anual iva incluido
             * iva porcentaje de iva componente de la cuota 
            */

            InteresMensual = Math.Pow(Wtasa, (1 / 12));

            if (NroCuotas == 1)
            {
                CalculoInteres = Math.Pow(InteresMensual, Wdias);
                CalculoInteres = CalculoInteres - 1;
                CalculoInteres = (CalculoInteres / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
            else
            {
                CalculoInteres = ((InteresMensual - 1) / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
        }
    }
}
