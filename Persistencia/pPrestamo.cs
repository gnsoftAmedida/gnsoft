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

        public DataSet devolverPrestamoActivoSocio(int idSocio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM prestamo where socio_id =" + idSocio + " and anulado=0";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "prestamoActivoSocio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void anularPrestamo(int nroPrestamo)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "UPDATE prestamo SET anulado = 1 WHERE prestamo_id = " + nroPrestamo;

            try
            {

                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlAdapter.UpdateCommand = connection.CreateCommand();
                MySqlAdapter.UpdateCommand.Transaction = transaction;

                MySqlAdapter.UpdateCommand.CommandText = sql;
                MySqlAdapter.UpdateCommand.ExecuteNonQuery();
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

                    //case 1062:
                    //    MisExcepciones es = new MisExcepciones("Ya exíste el Socio");
                    //    throw es;

                    //case 1451:
                    //    MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten prestamos asociadas ");
                    //    throw fk;
                }

                MisExcepciones eg = new MisExcepciones("(Error: " + ex.Number + ")" + " Consulte con el departamento de Sistemas");
                throw eg;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }


        public int GuardarPrestamo(int id_socio,
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
                                    double cuotaAnt,
                                    double tasaanterior,
                                    int anulado)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "INSERT INTO prestamo (socio_id, socio_nro, fecha, hora, monteopedido, tasa, cantidadcuotas, importecuota, numeroPrestamoAnt, montopedidoAnt, amortizacionVencer, interesesVencer, cuotasPactadas, cuotasPagadas, cuotaAnt, tasaanterior, anulado) VALUES (" + id_socio + ",'" + socio_nro + "','" + fecha.ToString("yyyy/MM/dd") + "','" + hora.ToString("yyyy/MM/dd hh:mm:ss") + "'," + monteopedido.ToString().Replace(",", ".") + "," + tasa.ToString().Replace(",", ".") + ", " + cantidadcuotas.ToString().Replace(",", ".") + " ," + importecuota.ToString().Replace(",", ".") + "," + numeroPrestamoAnt.ToString().Replace(",", ".") + "," + montopedidoAnt.ToString().Replace(",", ".") + ", " + amortizacionVencer.ToString().Replace(",", ".") + "," + interesesVencer.ToString().Replace(",", ".") + "," + cuotasPactadas.ToString().Replace(",", ".") + "," + cuotasPagadas.ToString().Replace(",", ".") + "," + cuotaAnt.ToString().Replace(",", ".") + "," + tasaanterior.ToString().Replace(",", ".") + "," + anulado + ");" + "Select last_insert_id()";

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                MySqlAdapter.InsertCommand = connection.CreateCommand();
                MySqlAdapter.InsertCommand.Transaction = transaction;
                MySqlAdapter.InsertCommand.CommandText = sql;
                int id = Convert.ToInt32(MySqlAdapter.InsertCommand.ExecuteScalar());
              //  MySqlAdapter.InsertCommand.ExecuteNonQuery();
                transaction.Commit();
                
                connection.Close();
                return id;
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