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
    public class pCobranzaProvisoria : CapaDatos
    {
        public DataSet devolverTodas()
        {
            try
            {
                MySqlConnection connection = conectar();
                //faltaría agregar el parámetro aportecapital ya que fue agregado a la BD el 11/10 por Gino
                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranzaProvisoria_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, socio_id FROM cobranzaProvisoria";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cobranzasProvisorias");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverCobranzaProvisoriaSocio(int parametro_socio_id)
        {
            try
            {
                MySqlConnection connection = conectar();
                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranzaProvisoria_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, socio_id FROM cobranzaProvisoria where socio_id=" + parametro_socio_id;
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cobranzasProvisoriasSocio");
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void VaciarTablaCobranzaProvisoria()
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM cobranzaprovisoria";

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
                    case 1451:
                        //revisar siguiente línea  //  GINO
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten cobranzas pendientes ");
                        throw fk;
                }
            }
        }

        //método agregado el 11/10/17 por Gino
        public void eliminarCobranzaProvisoria(int Id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM cobranzaprovisoria WHERE cobranzaProvisoria_id = '" + Id + "'";

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
                    case 1451:
                        //revisar siguiente línea  //  GINO
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten cobranzas pendientes ");
                        throw fk;
                }
            }
        }

        //método agregado el 11/10/17 por Gino
        public void modificarCobranzaProvisoria(int parCobranza_id, int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, String parSocio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update cobranzaprovisoria set prestamo_id = '" + parPrestamo_id + "', cedula = '" + parCedula + "', tasa = '" + parTasa + "', porcentajeiva = '" + parPorcentajeiva + "', montopedido = '" + parMontopedido + "', cantidadcuotas = '" + parCantidadcuotas + "', nrodecuotas = '" + parNrodecuotas + "', importecuotas = '" + parImportecuota + "', AmortizacionCuota = '" + parAmortizacioncuota + "', InteresCuota = '" + parInteresCuota + "', IvaCuota = '" + parIvaCuota + "', AmortizacionVencer = '" + parAmortizacionVencer + "', InteresVencer = '" + parInteresVencer + "', aportecapital = '" + parAporteCapital + "', socio_id = '" + parSocio_id + "' WHERE cobranzaprovisoria_id =" + parCobranza_id;

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
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }

        //método agregado el 11/10/17 por Gino
        public void GuardarCobranzaProvisoria(int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, int parSocio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO cobranzaprovisoria (prestamo_id, cedula , tasa , porcentajeiva , montopedido, cantidadcuotas, nrodecuotas, importecuotas, AmortizacionCuota, InteresCuota , IvaCuota , AmortizacionVencer , InteresVencer , socio_id ) VALUES ('" + parPrestamo_id + "', '" + parCedula + "', '" + parTasa + "','" + parPorcentajeiva + "','" + parMontopedido + "', '" + parCantidadcuotas + "', '" + parNrodecuotas + "','" + parImportecuota + "','" + parAmortizacioncuota + "','" + parInteresCuota + "','" + parIvaCuota + "', '" + parAmortizacionVencer + "', '" + parInteresVencer + "','" +  parSocio_id + "');" + "Select last_insert_id()";

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