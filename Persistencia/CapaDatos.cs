using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Utilidades;

namespace Persistencia
{
    public class CapaDatos
    {
        private string connStr = "Server=" + VariablesGlobales.Servidor + "; Database=" + VariablesGlobales.NombreBD + "; Uid=" + VariablesGlobales.Usuario + "; Pwd=" + VariablesGlobales.Clave + ";";

        public string ConnStr
        {
            get { return connStr; }
            set { connStr = value; }
        }

        public MySqlConnection conectar()
        {
            try
            {
                MySqlConnection connection;
                connection = new MySqlConnection();
                connection.ConnectionString = ConnStr;
                return connection;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
