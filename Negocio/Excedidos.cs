using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Excedidos
    {
        private int idExcedido;
        private String presupuesto;
        private String cedula;
        private double aretener;
        private double retenido;
        private DateTime fechadepago;
        private double importepagado;
        private String presupuestodelpago;
        private double aportecapital;

        public int _idExcedido { get; set; }
        public String _presupuesto { get; set; }
        public String _cedula { get; set; }
        public double _aretener { get; set; }
        public double _retenido { get; set; }
        public DateTime _fechadepago { get; set; }
        public double _importepagado { get; set; }
        public String _presupuestodelpago { get; set; }
        public double _aportecapital { get; set; }

        public DataSet devolverExcedidos()
        {
            pExcedidos tmpExcedido = new pExcedidos();
            DataSet excedidos = tmpExcedido.devolverTodos();
            return excedidos;
        }

        public void Guardar()
        {
            pExcedidos tmpExcedido = new pExcedidos();
            tmpExcedido.GuardarExcedido(_presupuesto, _cedula, _aretener, _retenido, _fechadepago, _importepagado, _presupuestodelpago, _aportecapital);
        }

        public void modificarExcedido()
        {
            pExcedidos tmpExcedido = new pExcedidos();
            tmpExcedido.modificarExcedido(_idExcedido,_presupuesto, _cedula, _aretener, _retenido, _fechadepago, _importepagado, _presupuestodelpago, _aportecapital);
        }

        public void eliminar()
        {
            pExcedidos tmpExcedido = new pExcedidos();
            tmpExcedido.eliminarExcedido(this._idExcedido);
        }  
    }
}
