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
    public class pPrestamo : CapaDatos
    {
        public void GuardarPrestamo(int id_socio,
                                    string socio_nro,
                                    DateTime fecha,
                                    DateTime hora,
                                    double monteopedido,
                                    double tasa,
                                    int cantidadcuotas,
                                    double importecuota,
                                    int numeroPrestamoAnt,
                                    double montopedidoAnt,
                                    double amortizacionVencer,
                                    double interesesVencer,
                                    int cuotasPactadas,
                                    int cuotasPagadas,
                                    int cuotaAnt,
                                    double tasaanterior,
                                    int anulado)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "INSERT INTO prestamo (socio_id, socio_nro, fecha, hora, monteopedido, tasa, cantidadcuotas, importecuota, numeroPrestamoAnt, montopedidoAnt, amortizacionVencer, interesesVencer, cuotasPactadas, cuotasPagadas, cuotaAnt, tasaanterior, anulado) VALUES (" + id_socio + ",'" + socio_nro + "','" + fecha.ToString("yyyy/MM/dd") + "','" + hora.ToString("yyyy/MM/dd hh:mm:ss") + "'," + monteopedido + "," + tasa + ", " + cantidadcuotas + " ," + importecuota + "," + numeroPrestamoAnt + "," + montopedidoAnt + ", " + amortizacionVencer + "," + interesesVencer + "," + cuotasPactadas + "," + cuotasPagadas + "," + cuotaAnt + "," + tasaanterior + "," + anulado + ");" + "Select last_insert_id()";

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
    }
}