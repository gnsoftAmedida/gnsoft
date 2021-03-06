﻿using System;
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

        public DataSet devolverPrestamosPendientes()
        {
            try
            {
                MySqlConnection connection = conectar();
                //faltaría agregar el parámetro aportecapital ya que fue agregado a la BD el 11/10 por Gino
                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT i.inciso_codigo, o.oficina_codigo, s.socio_nroCobro, c.cedula, c.prestamo_id, (c.montopedido - p.amortizacionVencer) as solicitud, (c.cantidadcuotas * c.importecuota) - ((c.AmortizacionVencer + c.InteresVencer + c.importecuota) - c.montopedido)  as total, (c.AmortizacionVencer + c.InteresVencer + c.importecuota) - c.montopedido as intereses  ,c.cantidadcuotas, c.importecuota, c.AmortizacionVencer, c.InteresVencer FROM cobranzaProvisoria c, socio s, inciso i, oficina o, prestamo p where s.socio_id = c.socio_id and s.socio_incisoId = i.inciso_id and s.socio_oficinaId = o.oficina_id and c.prestamo_id = p.prestamo_id";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "prestamoPendientes");
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
                //faltaría agregar el parámetro aportecapital ya que fue agregado a la BD el 11/10 por Gino
                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranzaProvisoria_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, aportecapital, socio_id FROM cobranzaProvisoria";
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

            string sql = "Update cobranzaprovisoria set prestamo_id = '" + parPrestamo_id + "', cedula = '" + parCedula.Replace("-", "").Replace(".", "").Replace(",", "") + "', tasa = '" + parTasa.ToString("##0.00").Replace(",", ".") + "', porcentajeiva = '" + parPorcentajeiva.ToString("##0.00").Replace(",", ".") + "', montopedido = '" + parMontopedido.ToString("##0.00").Replace(",", ".") + "', cantidadcuotas = '" + parCantidadcuotas.ToString().Replace(",", ".") + "', nrodecuotas = '" + parNrodecuotas.ToString().Replace(",", ".") + "', importecuotas = '" + parImportecuota.ToString("##0.00").Replace(",", ".") + "', AmortizacionCuota = '" + parAmortizacioncuota.ToString("##0.00").Replace(",", ".") + "', InteresCuota = '" + parInteresCuota.ToString("##0.00").Replace(",", ".") + "', IvaCuota = '" + parIvaCuota.ToString("##0.00").Replace(",", ".") + "', AmortizacionVencer = '" + parAmortizacionVencer.ToString("##0.00").Replace(",", ".") + "', InteresVencer = '" + parInteresVencer.ToString("##0.00").Replace(",", ".") + "', aportecapital = '" + parAporteCapital.ToString("##0.00").Replace(",", ".") + "', socio_id = '" + parSocio_id + "' WHERE cobranzaprovisoria_id =" + parCobranza_id;

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
            sql = "INSERT INTO cobranzaprovisoria (prestamo_id, cedula , tasa , porcentajeiva , montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota , IvaCuota , AmortizacionVencer , InteresVencer , socio_id ) VALUES ('" + parPrestamo_id + "', '" + parCedula.Replace("-", "").Replace(".", "").Replace(",", "") + "', '" + parTasa.ToString("##0.00").Replace(",", ".") + "','" + parPorcentajeiva.ToString("##0.00").Replace(",", ".") + "','" + parMontopedido.ToString("##0.00").Replace(",", ".") + "', '" + parCantidadcuotas + "', '" + parNrodecuotas + "','" + parImportecuota.ToString("##0.00").Replace(",", ".") + "','" + parAmortizacioncuota.ToString("##0.00").Replace(",", ".") + "','" + parInteresCuota.ToString("##0.00").Replace(",", ".") + "','" + parIvaCuota.ToString("##0.00").Replace(",", ".") + "', '" + parAmortizacionVencer.ToString("##0.00").Replace(",", ".") + "', '" + parInteresVencer.ToString("##0.00").Replace(",", ".") + "','" + parSocio_id + "');" + "Select last_insert_id()";

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