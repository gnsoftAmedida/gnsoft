using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Oficina
    {
        private int oficina_id;
        private string oficina_codigo;
        private string oficina_nombre;
        private string oficina_abreviatura;
        private string oficina_direccion;
        private string oficina_codigopostal;
        private string oficina_telefono;
        private string oficina_nombrecontacto;
        private string oficina_email;
        private Inciso oficina_inciso;
        private Departamento departamento;

        public int Oficina_id
        {
            get { return oficina_id; }
            set { oficina_id = value; }
        }

        public string Oficina_codigo
        {
            get { return oficina_codigo; }
            set { oficina_codigo = value; }
        }

        public string Oficina_nombre
        {
            get { return oficina_nombre; }
            set { oficina_nombre = value; }
        }

        public string Oficina_abreviatura
        {
            get { return oficina_abreviatura; }
            set { oficina_abreviatura = value; }
        }

        public string Oficina_direccion
        {
            get { return oficina_direccion; }
            set { oficina_direccion = value; }
        }

        public string Oficina_codigopostal
        {
            get { return oficina_codigopostal; }
            set { oficina_codigopostal = value; }
        }

        public string Oficina_telefono
        {
            get { return oficina_telefono; }
            set { oficina_telefono = value; }
        }

        public string Oficina_email
        {
            get { return oficina_email; }
            set { oficina_email = value; }
        }

        public string Oficina_nombrecontacto
        {
            get { return oficina_nombrecontacto; }
            set { oficina_nombrecontacto = value; }
        }

        public Inciso Oficina_inciso
        {
            get { return oficina_inciso; }
            set { oficina_inciso = value; }
        }
        
        public Departamento Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public DataSet devolverOficinas()
        {
            pOficina tmpInciso = new pOficina();
            DataSet oficinas = tmpInciso.devolverTodas();
            return oficinas;
        }

        public DataSet devolverOficinasPorInciso(int idInciso)
        {
            pOficina tmpOficina = new pOficina();
            DataSet oficinasInciso = tmpOficina.devolverOficinasPorInciso(idInciso);
            return oficinasInciso;
        }

        public void Guardar()
        {
            pOficina tmpOficina = new pOficina();
            tmpOficina.GuardarOficina(Oficina_codigo, Oficina_nombre, Oficina_abreviatura, Oficina_direccion, Oficina_inciso.Inciso_id, Departamento.Departamento_id, Oficina_codigopostal, Oficina_telefono, Oficina_email, Oficina_nombrecontacto);
        }

        public void modificarOficina()
        {
            pOficina tmpOficina = new pOficina();
            tmpOficina.modificarOficina(Oficina_codigo, Oficina_nombre, Oficina_abreviatura, Oficina_direccion, Oficina_inciso.Inciso_id, Departamento.Departamento_id, Oficina_codigopostal, Oficina_telefono, Oficina_email, Oficina_nombrecontacto, Oficina_id);
        }

        public void eliminar()
        {
            pOficina tmpOficina = new pOficina();
            tmpOficina.eliminarOficina(this.Oficina_id);
        }        
    }
}
