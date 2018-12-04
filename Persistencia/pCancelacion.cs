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
    public class pCancelacion : CapaDatos
    {

        public DataSet devolverCanelacionesPresupuesto(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT c.FechaCancelacion, s.socio_nro, s.socio_nombre, s.socio_apellido, c.NumeroPrestamo, c.CuotasPactadas, c.CuotasPagadas, c.Tasa, c.MontoVale, c.ImporteCuota, c.AmortizacionVencer, c.InteresesVencer FROM cancelacion c, socio s where c.socio_id = s.socio_id and c.presupuesto='" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "canelacionesAnticipadas");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GuardarCancelacion(int parNumeroPrestamo, int parCuotasPactadas, int parCuotasPagadas, double parTasa, double parMontoVale, double parImporteCuota, double parAmortizacionVencer, double parInteresesVencer, String parPresupuesto, String parSocioNumero, String parUsuario, DateTime FechaCancelacion, int socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO cancelacion (NumeroPrestamo, CuotasPactadas, CuotasPagadas, Tasa, MontoVale, ImporteCuota, AmortizacionVencer, InteresesVencer, Presupuesto, SocioNumero, Usuario, FechaCancelacion, socio_id ) VALUES ('" + parNumeroPrestamo + "', '" + parCuotasPactadas + "', '" + parCuotasPagadas + "', '" + parTasa.ToString("##0.00").Replace(",", ".") + "', '" + parMontoVale.ToString("##0.00").Replace(",", ".") + "', '" + parImporteCuota.ToString("##0.00").Replace(",", ".") + "', '" + parAmortizacionVencer.ToString("##0.00").Replace(",", ".") + "', '" + parInteresesVencer.ToString("##0.00").Replace(",", ".") + "', '" + parPresupuesto + "', '" + parSocioNumero.Replace("-", "").Replace(".", "").Replace(",", "") + "', '" + parUsuario + "', '" + FechaCancelacion.ToString("yyyy/MM/dd") + "', '" + socio_id + "');" + "Select last_insert_id()";

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
    }
}
