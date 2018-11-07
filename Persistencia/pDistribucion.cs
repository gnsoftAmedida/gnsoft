using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Utilidades;
using System.Data.OleDb;

namespace Persistencia
{
    public class pDistribucion : CapaDatos
    {



        //public void GuardarDistribucion(int socio_id, string cedula, string ejercicio, Double aportesCapital, Double interesesAportados, Double utilidades, string pagadopor, DateTime fecha, string cheque)
        public void GuardarDistribucion(int socio_id, string cedula, string ejercicio, Double aportesCapital, Double interesesAportados)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
           // sql = "INSERT INTO distribucion (socio_id, cedula, ejercicio, aportesCapital, interesesAportados, utilidades, pagadopor, fecha, cheque) VALUES ('" + socio_id + "', '" + cedula + "', '" + ejercicio + "','" + aportesCapital.ToString().Replace(",", ".") + "','" + interesesAportados.ToString().Replace(",", ".") + "','" + utilidades.ToString().Replace(",", ".") + "','" + pagadopor + "','" + fecha.ToString("yyyy/MM/dd hh:mm:ss") + "', '" + cheque + "');" + "Select last_insert_id()";
            sql = "INSERT INTO distribucion (socio_id, cedula, ejercicio, aportesCapital, interesesAportados) VALUES ('" + socio_id + "', '" + cedula + "', '" + ejercicio + "','" + aportesCapital.ToString().Replace(",", ".") + "','" + interesesAportados.ToString().Replace(",", ".") + "');" + "Select last_insert_id()";
            
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

            catch (MySqlException ex)
            {
                transaction.Rollback();
                connection.Close();

                switch (ex.Number)
                {
                    case 1406:
                        MisExcepciones ep = new MisExcepciones("Datos muy largos");
                        throw ep;
                }
            }
        }

        public void actualizarUtilidadesDistribucionEjercicio(Double aDistribuir, Double totalInteres, string ejercicio)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {

                string sql = "Update distribucion set utilidades = (interesesaportados) * " + aDistribuir.ToString().Replace(",", ".") + "/" + totalInteres.ToString().Replace(",", ".") + " WHERE ejercicio ='" + ejercicio + "'";

                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlAdapter.UpdateCommand = connection.CreateCommand();
                MySqlAdapter.UpdateCommand.Transaction = transaction;

                MySqlAdapter.UpdateCommand.CommandText = sql;
                MySqlAdapter.UpdateCommand.ExecuteNonQuery();

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


        public Boolean ejercicioProcesado(String ejercicio)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "SELECT * FROM distribucion where ejercicio = '" + ejercicio + "'";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "distribucion");
            connection.Close();

            if (ds.Tables["distribucion"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
