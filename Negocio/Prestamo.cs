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
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

     /*   public double Cuota(double tasa, string CantidadCuotas, double Capital)
        {
            double Cuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            Cuota = __Financial.

        }
       */ 
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
                return Convert.ToDouble(CalculoInteres.ToString("##.#000000"));
            }
            else
            {
                CalculoInteres = ((InteresMensual - 1) / Wiva);
                return Convert.ToDouble(CalculoInteres.ToString("##.#000000"));
            }
        }
    }
}
