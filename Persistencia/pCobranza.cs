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
    public class pCobranza : CapaDatos
    {   //método agregado el 11/10/17 por Gino
        public void eliminarCobranza(int Id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM cobranza WHERE cobranza_id = '" + Id + "'";

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

        public void agregarAporteCapitalrCobranza(int parCobranza_id, double parAporteCapital)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update cobranza set aportecapital = '" + parAporteCapital.ToString().Replace(",", ".") + "' WHERE cobranza_id =" + parCobranza_id;

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

        public void cancelarCobranza(int parCobranza_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update cobranza set AmortizacionVencer = '0', InteresVencer = '0' WHERE cobranza_id =" + parCobranza_id;

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
        public void modificarCobranza(int parCobranza_id, int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update cobranza set prestamo_id = '" + parPrestamo_id + "', cedula = '" + parCedula + "', tasa = '" + parTasa.ToString().Replace(",", ".") + "', porcentajeiva = '" + parPorcentajeiva.ToString().Replace(",", ".") + "', montopedido = '" + parMontopedido.ToString().Replace(",", ".") + "', cantidadcuotas = '" + parCantidadcuotas + "', nrodecuotas = '" + parNrodecuotas + "', importecuotas = '" + parImportecuota.ToString().Replace(",", ".") + "', AmortizacionCuota = '" + parAmortizacioncuota.ToString().Replace(",", ".") + "', InteresCuota = '" + parInteresCuota.ToString().Replace(",", ".") + "', IvaCuota = '" + parIvaCuota.ToString().Replace(",", ".") + "', AmortizacionVencer = '" + parAmortizacionVencer.ToString().Replace(",", ".") + "', InteresVencer = '" + parInteresVencer.ToString().Replace(",", ".") + "', aportecapital = '" + parAporteCapital.ToString().Replace(",", ".") + "', socio_id = '" + parSocio_id + "' WHERE cobranza_id =" + parCobranza_id;

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
        public void GuardarCobranza(int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO cobranza (prestamo_id, cedula , tasa , porcentajeiva , montopedido, cantidadcuotas, nrodecuotas, importecuotas, AmortizacionCuota, InteresCuota , IvaCuota , AmortizacionVencer , InteresVencer , aportecapital, socio_id ) VALUES ('" + parPrestamo_id + "', '" + parCedula + "', '" + parTasa.ToString().Replace(",", ".") + "','" + parPorcentajeiva.ToString().Replace(",", ".") + "','" + parMontopedido.ToString().Replace(",", ".") + "', '" + parCantidadcuotas + "', '" + parNrodecuotas + "','" + parImportecuota.ToString().Replace(",", ".") + "','" + parAmortizacioncuota.ToString().Replace(",", ".") + "','" + parInteresCuota.ToString().Replace(",", ".") + "','" + parIvaCuota.ToString().Replace(",", ".") + "', '" + parAmortizacionVencer.ToString().Replace(",", ".") + "', '" + parInteresVencer.ToString().Replace(",", ".") + "','" + parAporteCapital.ToString().Replace(",", ".") + "','" + parSocio_id + "');" + "Select last_insert_id()";

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


        public void eliminarAmortizacionVencerCero()
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM cobranza WHERE amortizacionvencer = 0";

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
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public DataSet devolverTotales()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT Sum(importecuota+aportecapital) AS [a_1], sum(amortizacionvencer) as [b_1], sum(interesvencer) as [c_1] from cobranza ";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "totalesCobranzas");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverCobranzaSocio(int parametro_socio_id)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranza_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, aportecapital, socio_id FROM cobranza where socio_id= " + parametro_socio_id;
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cobranzaSocio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverTodas()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranza_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, aportecapital, socio_id FROM cobranza";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cobranzas");
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