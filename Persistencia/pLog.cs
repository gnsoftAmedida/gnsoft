using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class pLog : CapaDatos
    {

        public void guardarLog(DateTime dia, String usuario, String registro)
        {
            MySqlConnection connection = conectar();
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "insert into log (log_fecha, log_usuario, log_registro) values ('" + dia.ToString("yyyy/MM/dd H:mm:ss") + "','" + usuario + "','" + registro + "')";
            // HH:ss
            connection.Open();
            MySqlAdapter.InsertCommand = connection.CreateCommand();
            MySqlAdapter.InsertCommand.CommandText = sql;
            MySqlAdapter.InsertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet devolverLogsSegunFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            MySqlConnection connection = conectar();
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT * FROM log where log_fecha >= '" + fechaDesde.ToString("yyyy/MM/dd") + " 00:00' and log_fecha <='" + fechaHasta.ToString("yyyy/MM/dd") + " 23:59'";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "logs");
            connection.Close();
            return ds;
        }
    }
}
