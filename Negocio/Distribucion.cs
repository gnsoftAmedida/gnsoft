using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Persistencia;

namespace Negocio
{
    public class Distribucion
    {
        private int distribucion_id;

        public int Distribucion_id
        {
            get { return distribucion_id; }
            set { distribucion_id = value; }
        }
        private int socio_id;

        public int Socio_id
        {
            get { return socio_id; }
            set { socio_id = value; }
        }
        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        private string ejercicio;

        public string Ejercicio
        {
            get { return ejercicio; }
            set { ejercicio = value; }
        }
        private Double aportesCapital;

        public Double AportesCapital
        {
            get { return aportesCapital; }
            set { aportesCapital = value; }
        }
        private Double interesesAportados;

        public Double InteresesAportados
        {
            get { return interesesAportados; }
            set { interesesAportados = value; }
        }
        private Double utilidades;

        public Double Utilidades
        {
            get { return utilidades; }
            set { utilidades = value; }
        }
        private string pagadopor;

        public string Pagadopor
        {
            get { return pagadopor; }
            set { pagadopor = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string cheque;

        public string Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }

        public void GuardarDistribucion()
        {
            pDistribucion tmpDistribucion = new pDistribucion();
            //tmpDistribucion.GuardarDistribucion(Socio_id, Cedula, Ejercicio, AportesCapital, InteresesAportados, Utilidades, Pagadopor, Fecha, Cheque);
            tmpDistribucion.GuardarDistribucion(Socio_id, Cedula, Ejercicio, AportesCapital, InteresesAportados);
        }

        public void actualizarUtilidadesDistribucionEjercicio(Double aDistribuir, Double totalInteres, string ejercicio)
        {
            pDistribucion tmpDistribucion = new pDistribucion();
            tmpDistribucion.actualizarUtilidadesDistribucionEjercicio(aDistribuir, totalInteres, ejercicio);
        }

        public Boolean ejercicioProcesado(String ejercicio)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            return tmppDistribucion.ejercicioProcesado(ejercicio);
        }

        public Boolean verificarEjercicioSinPagos(String ejercicio)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            return tmppDistribucion.verificarEjercicioSinPagos(ejercicio);
        }

        public DataSet detalleUtilidadesLiquidadasYnoLiquidadas(int socio_id)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            return tmppDistribucion.detalleUtilidadesLiquidadasYnoLiquidadas(socio_id);
        }

        public DataSet utilidadesSocio(int socio_id)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            return tmppDistribucion.utilidadesSocio(socio_id);
        }

        public void eliminarDistribucion(String ejercicio)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            tmppDistribucion.eliminarDistribucion(ejercicio);
        }

        public void actualizarPagoDistribucion(int socio_id, string pagadoPor, DateTime fecha, string cheque)
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            tmppDistribucion.actualizarPagoDistribucion(socio_id, pagadoPor, fecha, cheque);
        }

        public DataSet historicoAportesInteresesUtilidades()
        {
            pDistribucion tmppDistribucion = new pDistribucion();
            return tmppDistribucion.historicoAportesInteresesUtilidades();
        }

    }
}
