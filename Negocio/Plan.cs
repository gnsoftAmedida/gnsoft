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
        private int plan_cantCuotas;
        private double plan_TasaAnualEfectiva;
        private double plan_IvaSobreIntereses;
        private int plan_vigencia;
        private string plan_nombre;
        private double plan_CuotaCada1000;

        public int Plan_id
        {
            get { return plan_id; }
            set { plan_id = value; }
        }

        public int Plan_cantCuotas
        {
            get { return plan_cantCuotas; }
            set { plan_cantCuotas = value; }
        }

        public double Plan_TasaAnualEfectiva
        {
            get { return plan_TasaAnualEfectiva; }
            set { plan_TasaAnualEfectiva = value; }
        }

        public double Plan_IvaSobreIntereses
        {
            get { return plan_IvaSobreIntereses; }
            set { plan_IvaSobreIntereses = value; }
        }

        public int Plan_vigencia
        {
            get { return plan_vigencia; }
            set { plan_vigencia = value; }
        }

        public string Plan_nombre
        {
            get { return plan_nombre; }
            set { plan_nombre = value; }
        }

        public double Plan_CuotaCada1000
        {
            get { return plan_CuotaCada1000; }
            set { plan_CuotaCada1000 = value; }
        }

        public DataSet devolverPlanes()
        {
            pPlan tmpPlan = new pPlan();
            DataSet planes = tmpPlan.devolverTodos();
            return planes;
        }

        public DataSet devolverActivos()
        {
            pPlan tmpPlan = new pPlan();
            DataSet planes = tmpPlan.devolverActivos();
            return planes;
        }

        public DataSet devolverTasaPorCantCuotasActivos(int cuotas)
        {
            pPlan tmpTasa = new pPlan();
            DataSet planes = tmpTasa.devolverTasaPorCantCuotasActivos(cuotas);
            return planes;
        }


        public void Guardar()
        {
            pPlan tmpPlan = new pPlan();

            tmpPlan.GuardarPlan(Plan_cantCuotas, Plan_TasaAnualEfectiva, Plan_IvaSobreIntereses, Plan_vigencia, Plan_nombre, Plan_CuotaCada1000);
        }

        public void eliminar()
        {
            pPlan tmpPlan = new pPlan();
            tmpPlan.eliminarPlan(this.Plan_id);
        }

        public void modificarPlan()
        {
            pPlan tmpPlan = new pPlan();
            tmpPlan.modificarPlan(Plan_id, Plan_cantCuotas, Plan_TasaAnualEfectiva, Plan_IvaSobreIntereses, Plan_vigencia, Plan_nombre, Plan_CuotaCada1000);
        }

        public void modificarTasas(double nuevaTasa)
        {
            pPlan tmpPlan = new pPlan();
            tmpPlan.modificarTasas(nuevaTasa);
        }
    }
}
