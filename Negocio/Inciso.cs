using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Inciso
    {
        private int inciso_id;
        private string inciso_codigo;
        private string inciso_nombre;
        private string inciso_abreviatura;

        public int Inciso_id
        {
            get { return inciso_id; }
            set { inciso_id = value; }
        }

        public string Inciso_codigo
        {
            get { return inciso_codigo; }
            set { inciso_codigo = value; }
        }

        public string Inciso_nombre
        {
            get { return inciso_nombre; }
            set { inciso_nombre = value; }
        }

        public string Inciso_abreviatura
        {
            get { return inciso_abreviatura; }
            set { inciso_abreviatura = value; }
        }

        public DataSet devolverIncisos()
        {
            pInciso tmpInciso = new pInciso();
            DataSet incisos = tmpInciso.devolverTodos();
            return incisos;
        }

        public void Guardar()
        {
            pInciso tmpInciso = new pInciso();
            tmpInciso.GuardarInciso(Inciso_codigo, Inciso_nombre, Inciso_abreviatura);
        }

        public void eliminar()
        {
            pInciso tmpInciso = new pInciso();
            tmpInciso.eliminarInciso(this.Inciso_id);
        }

        public void modificarInciso()
        {
            pInciso tmpInciso = new pInciso();
            tmpInciso.modificarInciso(Inciso_codigo, Inciso_nombre, Inciso_abreviatura, Inciso_id);
        }
    }
}
