using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Utilidades;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace Persistencia
{
    public class pFechaCierre : CapaDatos
    {
        public void GuardarFechaCierre(String Presupuesto, DateTime FechaDesde, DateTime HoraDesde, DateTime FechaHasta, DateTime HoraHasta, Double TotalImporte, Double AmortizacionAVencer, Double InteresesAVencer)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO fechascierre (Presupuesto, FechaDesde, HoraDesde, FechaHasta, HoraHasta, TotalImporte, AmortizacionAVencer, InteresesAVencer) VALUES ('" + Presupuesto + "', '" + FechaDesde.ToString("yyyy/MM/dd hh:mm:ss") + "', '" + HoraDesde.ToString("yyyy/MM/dd hh:mm:ss") + "','" + FechaHasta.ToString("yyyy/MM/dd hh:mm:ss") + "','" + HoraHasta.ToString("yyyy/MM/dd hh:mm:ss") + "', '" + TotalImporte.ToString("##0.00").Replace(",", ".") + "', '" + AmortizacionAVencer.ToString("##0.00").Replace(",", ".") + "','" + InteresesAVencer.ToString("##0.00").Replace(",", ".") + "');" + "Select last_insert_id()";

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

        public Boolean cierreEfectuado(String presupuesto)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "SELECT * FROM FechasCierre where Presupuesto = '" + presupuesto + "'";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "fechasCierre");
            connection.Close();

            if (ds.Tables["fechasCierre"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet devolverTodos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT  fechaCierre_id, Presupuesto, FechaDesde, HoraDesde, FechaHasta, HoraHasta, TotalImporte, AmortizacionAVencer, InteresesAVencer FROM FechasCierre";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "fechasCierre");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}