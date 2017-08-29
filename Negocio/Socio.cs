using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Persistencia;

namespace Negocio
{
    public class Socio
    {
        private int socio_id;

        public int Socio_id
        {
            get { return socio_id; }
            set { socio_id = value; }
        }
        private string socio_nombre;

        public string Socio_nombre
        {
            get { return socio_nombre; }
            set { socio_nombre = value; }
        }
        private string socio_apellido;

        public string Socio_apellido
        {
            get { return socio_apellido; }
            set { socio_apellido = value; }
        }
        private string socio_nro;

        public string Socio_nro
        {
            get { return socio_nro; }
            set { socio_nro = value; }
        }
        private string socio_nroCobro;

        public string Socio_nroCobro
        {
            get { return socio_nroCobro; }
            set { socio_nroCobro = value; }
        }
        private DateTime socio_fechaNac;

        public DateTime Socio_fechaNac
        {
            get { return socio_fechaNac; }
            set { socio_fechaNac = value; }
        }
        private DateTime socio_fechaIngreso;

        public DateTime Socio_fechaIngreso
        {
            get { return socio_fechaIngreso; }
            set { socio_fechaIngreso = value; }
        }
        private string socio_estadoCivil;

        public string Socio_estadoCivil
        {
            get { return socio_estadoCivil; }
            set { socio_estadoCivil = value; }
        }
        private char socio_sexo;

        public char Socio_sexo
        {
            get { return socio_sexo; }
            set { socio_sexo = value; }
        }
        private string socio_estado;

        public string Socio_estado
        {
            get { return socio_estado; }
            set { socio_estado = value; }
        }
        private int socio_edad;

        public int Socio_edad
        {
            get { return socio_edad; }
            set { socio_edad = value; }
        }
        private int socio_oficinaId;

        public int Socio_oficinaId
        {
            get { return socio_oficinaId; }
            set { socio_oficinaId = value; }
        }
        private int socio_incisoId;

        public int Socio_incisoId
        {
            get { return socio_incisoId; }
            set { socio_incisoId = value; }
        }
        private string socio_tel;

        public string Socio_tel
        {
            get { return socio_tel; }
            set { socio_tel = value; }
        }
        private string socio_direccion;

        public string Socio_direccion
        {
            get { return socio_direccion; }
            set { socio_direccion = value; }
        }
        private string socio_email;

        public string Socio_email
        {
            get { return socio_email; }
            set { socio_email = value; }
        }

        private int socio_activo;

        public int Socio_activo
        {
            get { return Socio_activo; }
            set { socio_activo = value; }
        }




        public DataSet devolverSocios()
        {
            pSocio tmpSocio = new pSocio();
            DataSet socios = tmpSocio.devolverTodos();
            return socios;
        }

        public DataSet buscarSociosPorCampo(string campo, string valor)
        {
            pSocio tmpSocio = new pSocio();
            DataSet socios = tmpSocio.buscarSociosPorCampo(campo, valor);
            return socios;
        }

        public void Guardar()
        {
            pSocio tmpSocio = new pSocio();
            tmpSocio.GuardarSocio(socio_activo, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email);
        }

        public void ModificarSocio()
        {
            pSocio tmpSocio = new pSocio();
            tmpSocio.GuardarSocioModificado(socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email);
        }

        public void eliminar()
        {
            pSocio tmpSocio = new pSocio();
            tmpSocio.eliminarSocio(this.socio_nro);
        }

        public void buscar()
        {
            pSocio tmpSocio = new pSocio();
            tmpSocio.buscarSocio(this.socio_nro);
        }

        public void modificarSocio()
        {

            pSocio tmpSocio = new pSocio();
            //tmpSocio.modificarSocio(socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email);
        }
    }
}
