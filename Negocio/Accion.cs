using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Persistencia;

namespace Negocio
{
    public class Accion
    {
        private int id;
        private string nombre;
        private string descripcion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DataSet DevolverTodos()
        {
            pAccion tmpAccion = new pAccion();
            DataSet acciones = tmpAccion.DevolverTodos();
            return acciones;
        }

        public DataSet DevolverAccionesXUsuario(int idUsuario)
        {
            pAccion tmpAccion = new pAccion();
            DataSet acciones = tmpAccion.DevolverAccionesXUsuario(idUsuario);
            return acciones;
        }
    }
}
