using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class pAccion : CapaDatos
    {
        public DataSet DevolverTodos()
        {
            MySqlConnection connection = conectar();
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT * FROM accion";

            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;

            DataSet ds = new DataSet();
            MySqlAdapter.Fill(ds, "acciones");

            connection.Close();
            return ds;
        }

        public DataSet DevolverAccionesXUsuario(int idUsuario)
        {
            MySqlConnection connection = conectar();
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT * FROM accion a, usuario_accion ua WHERE a.accion_id = ua.accion_id AND ua.usuario_id = '" + idUsuario + "'";
            DataSet ds = new DataSet();

            connection.Open();

            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "acciones");

            connection.Close();
            return ds;
        }
    }

}
