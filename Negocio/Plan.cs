using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Persistencia;

namespace Negocio
{
    public class Plan
    {
        private int plan_id;
        private string plan_codigo;
        private string plan_descripcion;
        private int plan_cantCuotas;
        private double plan_interes;

        public int Plan_id
        {
            get { return plan_id; }
            set { plan_id = value; }
        }

        public string Plan_codigo
        {
            get { return plan_codigo; }
            set { plan_codigo = value; }
        }

        public string Plan_descripcion
        {
            get { return plan_descripcion; }
            set { plan_descripcion = value; }
        }

        public int Plan_cantCuotas
        {
            get { return plan_cantCuotas; }
            set { plan_cantCuotas = value; }
        }

        public double Plan_interes
        {
            get { return plan_interes; }
            set { plan_interes = value; }
        }

        public DataSet devolverPlanes()
        {
            pPlan tmpPlan = new pPlan();
            DataSet planes = tmpPlan.devolverTodos();
            return planes;
        }

        public void Guardar()
        {
            pPlan tmpPlan = new pPlan();
            //tmpPlan.GuardarPlan(Plan_codigo, Plan_descripcion, Plan_cantCuotas, Plan_interes);
            tmpPlan.GuardarPlan(Plan_descripcion, Plan_descripcion, Plan_cantCuotas, Plan_interes);
        }

        public void eliminar()
        {
            pPlan tmpPlan = new pPlan();
            tmpPlan.eliminarPlan(this.Plan_id);
        }

        public void modificarPlan()
        {
            pPlan tmpPlan = new pPlan();
            tmpPlan.modificarPlan(Plan_descripcion, Plan_descripcion, Plan_cantCuotas, Plan_interes, Plan_id);
        }
    }
}
