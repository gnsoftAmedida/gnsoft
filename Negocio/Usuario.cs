using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Usuario
    {
        private int id;
        private string alias;
        private string clave;
        private string correo;
        private string telefono;
        private ArrayList accionesPermitidas;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public ArrayList AccionesPermitidas
        {
            get { return accionesPermitidas; }
            set { accionesPermitidas = value; }
        }

        public void LoguearUsuario()
        {
            pUsuario tmpUsuario = new pUsuario();
            tmpUsuario.LoguearUsuario(Alias, Clave);
        }

        public void Guardar()
        {
            pUsuario tmpUsuario = new pUsuario();
            tmpUsuario.GuardarUsuario(Alias, Clave, Correo, Telefono, AccionesPermitidas);
        }

        public DataSet devolverUsuarios()
        {
            pUsuario tmpUsuario = new pUsuario();
            DataSet usuarios = tmpUsuario.devolverTodos();
            return usuarios;
        }

        public void eliminarUsuario()
        {
            pUsuario tmpUsuario = new pUsuario();
            tmpUsuario.EliminarUsuario(Id);
        }

        public void ModificarClave(string claveAnterior)
        {
            pUsuario tmpUsuario = new pUsuario();
            tmpUsuario.VerificarClave(Id, claveAnterior);
            tmpUsuario.ModificarClave(Id, Clave);
        }

        public string ResetearClave()
        {
            pUsuario tmpUsuario = new pUsuario();
            string claveNueva = tmpUsuario.resetearClaveUsuario(Id);

            return claveNueva;
        }

        public void Modificar()
        {
            pUsuario tmpUsuario = new pUsuario();
            tmpUsuario.ModificarUsuario(Id, Alias, Correo, Telefono, AccionesPermitidas);
        }
    }
}
