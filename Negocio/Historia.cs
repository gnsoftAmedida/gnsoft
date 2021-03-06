﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Historia
    {
        private int historia_id;
        private string Presupuesto;
        private int NumeroPrestamo;
        private string cedula;
        private double tasa;
        private double porcentajeiva;
        private double montopedido;
        private double cantidadcuotas;
        private double nrodecuotas;
        private double importecuota;
        private double AmortizacionCuota;
        private double InteresCuota;
        private double IvaCuota;
        private double AmortizacionVencer;
        private double InteresVencer;
        private double aportecapital;
        private string numerocobro;
        private int Inciso;
        private int oficina;
        private double excedido;
        private double mora;
        private double IvaMora;
        private int socio_id;

        public int _historia_id { get; set; }
        public string _Presupuesto { get; set; }
        public int _NumeroPrestamo { get; set; }
        public string _cedula { get; set; }
        public double _tasa { get; set; }
        public double _porcentajeiva { get; set; }
        public double _montopedido { get; set; }
        public double _cantidadcuotas { get; set; }
        public double _nrodecuotas { get; set; }
        public double _importecuota { get; set; }
        public double _AmortizacionCuota { get; set; }
        public double _InteresCuota { get; set; }
        public double _IvaCuota { get; set; }
        public double _AmortizacionVencer { get; set; }
        public double _InteresVencer { get; set; }
        public double _aportecapital { get; set; }
        public string _numerocobro { get; set; }
        public int _Inciso { get; set; }
        public int _oficina { get; set; }
        public double _excedido { get; set; }
        public double _mora { get; set; }
        public double _IvaMora { get; set; }
        public int _socio_id { get; set; }

        public void Guardar()
        {
            pHistoria tmpHistoria = new pHistoria();
            tmpHistoria.GuardarHistoria(_Presupuesto, _NumeroPrestamo, _cedula, _tasa, _porcentajeiva, _montopedido, _cantidadcuotas,
                _nrodecuotas, _importecuota, _AmortizacionCuota, _InteresCuota, _IvaCuota, _AmortizacionVencer, _InteresVencer,
                _aportecapital, _numerocobro, _Inciso, _oficina, _excedido, _mora, _IvaMora, _socio_id);
        }

        public DataSet devolverHistoria()
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.devolverTodos();
            return historias;
        }

        public DataSet devolverPrestamosOtorgadosPresupuesto(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.devolverPrestamosOtorgadosPresupuesto(presupuesto);
            return historias;
        }

        public DataSet devolverBusquedaInterfaz(string Busqueda)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.devolverBusquedaInterfaz(Busqueda);
            return historias;
        }

        public DataSet devolverDatosPresupuesto(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.devolverDatosPresupuesto(presupuesto);
            return historias;
        }

        public DataSet devolverPresupuestoDelMes(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.devolverPresupuestoDelMes(presupuesto);
            return historias;
        }

        public DataSet facturacion(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet historias = tmpHistoria.facturacion(presupuesto);
            return historias;
        }

        public DataSet devolverHistoriaPorIdSocio(int idSocio)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverHistoriaPorIdSocio(idSocio);
        }

        public DataSet devolverHistoriaPorIDyPresupuesto(int idSocio, string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverHistoriaPorIDyPresupuesto(idSocio, presupuesto);
        }

        public DataSet devolverHistoria(string ci, string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverHistoria(ci, presupuesto);
        }

        public DataSet devolverInterfacesGeneralesInforme(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverInterfacesGeneralesInforme(presupuesto);
        }

        public void eliminar()
        {
            pHistoria tmpHistoria = new pHistoria();
            tmpHistoria.eliminarHistoria(this.historia_id);
        }

        public void modificarHistoria()
        {
            pHistoria tmpHistoria = new pHistoria();
            tmpHistoria.modificarHistoria(_historia_id, _Presupuesto, _NumeroPrestamo, _cedula, _tasa, _porcentajeiva, _montopedido, _cantidadcuotas,
                _nrodecuotas, _importecuota, _AmortizacionCuota, _InteresCuota, _IvaCuota, _AmortizacionVencer, _InteresVencer,
                _aportecapital, _numerocobro, _Inciso, _oficina, _excedido, _mora, _IvaMora, _socio_id);
        }

        public DataSet devolverUtilidadesPorPresupuesto(string presupuesto)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverUtilidadesPorPresupuesto(presupuesto);
        }

        public DataSet devolverHistoriaPorIdSocioCompleta(int idSocio)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.devolverHistoriaPorIdSocioCompleta(idSocio);
        }

        public DataSet salidasIngresos(string mes, int anio)
        {
            pHistoria tmpHistoria = new pHistoria();
            DataSet consulta = tmpHistoria.salidasIngresos(mes, anio);
            return consulta;
        }

        public DataSet distribucionUtilidadesPorPresupuesto(string consultaPrevia)
        {
            pHistoria tmpHistoria = new pHistoria();
            return tmpHistoria.distribucionUtilidadesPorPresupuesto(consultaPrevia);
        }
    }
}
