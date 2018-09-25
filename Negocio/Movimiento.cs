using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Movimiento
    {

        //movimiento, fecha, codigobanco, numerocta, numerodocumento, debehaber, importe, saldo, concepto
        private int movimiento;
        private DateTime fecha;
        private int codigobanco;
        private string numerocta;
        private string numerodocumento;
        private string debehaber;
        private Double importe;
        private Double saldo;
        private string concepto;

        public int Movimiento1
        {
            get { return movimiento; }
            set { movimiento = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Codigobanco
        {
            get { return codigobanco; }
            set { codigobanco = value; }
        }

        public string Numerocta
        {
            get { return numerocta; }
            set { numerocta = value; }
        }

        public string Numerodocumento
        {
            get { return numerodocumento; }
            set { numerodocumento = value; }
        }

        public string Debehaber
        {
            get { return debehaber; }
            set { debehaber = value; }
        }

        public Double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }


        public DataSet movimientosPromedio(int codigoBancoConsulta, int diaDesde, int diaHasta, int mes, int anio)
        {
            pMovimiento tmpMovimiento = new pMovimiento();
            DataSet consulta = tmpMovimiento.movimientosPromedio(codigoBancoConsulta, diaDesde, diaHasta, mes, anio);
            return consulta;
        }

        public void Guardar()
        {
            pMovimiento tmpMovimiento = new pMovimiento();
            tmpMovimiento.GuardarMovimiento(fecha, codigobanco, numerocta, numerodocumento, debehaber, importe, concepto, Saldo);
        }

        public DataSet devolverCuentaCorriente(int id_banco, DateTime fechaDesde, DateTime fechaHasta, String concepto)
        {
            pMovimiento tmpMovimiento = new pMovimiento();
            return tmpMovimiento.devolverCuentaCorriente(id_banco, fechaDesde, fechaHasta, concepto);
        }

    }
}
