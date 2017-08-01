using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Persistencia
{
    public class pEvento : CapaDatos
    {
        public void GuardarEvento(DateTime fecha, string descripcion)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO evento (fecha, descripcion) VALUES ('" + fecha.ToString("yyyy/MM/dd") + "','" + descripcion + "');" + "Select last_insert_id()";

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                MySqlAdapter.InsertCommand = connection.CreateCommand();
                MySqlAdapter.InsertCommand.Transaction = transaction;
                MySqlAdapter.InsertCommand.CommandText = sql;
                MySqlAdapter.InsertCommand.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }


        public System.Data.DataSet devolverEventos(DateTime fecha)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT evento_id, fecha, descripcion FROM evento WHERE fecha ='" + fecha.ToString("yyyy/MM/dd") + "'";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "eventos");
            connection.Close();
            return ds;
        }

        public System.Data.DataSet devolverEventosEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT evento_id, fecha, descripcion FROM evento WHERE fecha >='" + fechaDesde.ToString("yyyy/MM/dd") + "' AND fecha <='" + fechaHasta.ToString("yyyy/MM/dd") + "'";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "eventos");
            connection.Close();
            return ds;
        }

        public System.Data.DataSet devolverEvento(int idEvento)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "SELECT evento_id, fecha, descripcion FROM evento WHERE evento_id =" + idEvento;
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "evento");
            connection.Close();
            return ds;
        }

        public void EliminarEvento(int Id)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "Delete from evento WHERE evento_id =" + Id;

            connection.Open();
            MySqlAdapter.UpdateCommand = connection.CreateCommand();
            MySqlAdapter.UpdateCommand.CommandText = sql;
            MySqlAdapter.UpdateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void modificarEvento(int id, DateTime fecha, string descripcion)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "Update evento set fecha = '" + fecha.ToString("yyyy/MM/dd") + "', descripcion = '" + descripcion + "' WHERE evento_id =" + id;

            connection.Open();
            MySqlAdapter.UpdateCommand = connection.CreateCommand();
            MySqlAdapter.UpdateCommand.CommandText = sql;
            MySqlAdapter.UpdateCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
