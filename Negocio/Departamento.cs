using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Departamento
    {
        private int departamento_id;
        private string departamento_nombre;

        public int Departamento_id
        {
            get { return departamento_id; }
            set { departamento_id = value; }
        }

        public string Departamento_nombre
        {
            get { return departamento_nombre; }
            set { departamento_nombre = value; }
        }

        public DataSet devolverDepartamentos()
        {
            pDepartamento tmpDepartamento = new pDepartamento();
            DataSet departamentos = tmpDepartamento.devolverTodos();
            return departamentos;
        }
    }
}
