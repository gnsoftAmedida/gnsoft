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
    public class pMovimiento : CapaDatos
    {

        //movimiento, fecha, codigobanco, numerocta, numerodocumento, debehaber, importe, saldo, concepto

        public DataSet movimientosPromedio(int codigoBancoConsulta, int diaDesde, int diaHasta, int mes, int anio)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            //Ver condición de que la tabla debeHaber tenga valor "Cheque" en migración
            //string sql = "SELECT count(debeHaber), count(movimiento), AVG(saldo) FROM movimientos where codigobanco = '" + codigoBancoConsulta + "' and fecha <= '" + anio + "/" + mes + "/" + diaHasta + "' and fecha >= '" + +anio + "/" + mes + "/" + diaDesde + "'";


            string sql = "SELECT count(debeHaber), AVG(saldo) FROM movimientos where codigobanco = '" + codigoBancoConsulta + "' and fecha <= '" + anio + "/" + mes + "/" + diaHasta + "' and fecha >= '" + +anio + "/" + mes + "/" + diaDesde + "' and debehaber = 'Deposito' union SELECT count(debeHaber), AVG(saldo) FROM movimientos where codigobanco = '" + codigoBancoConsulta + "' and fecha <= '" + anio + "/" + mes + "/" + diaHasta + "' and fecha >= '" + +anio + "/" + mes + "/" + diaDesde + "' and debehaber = 'Cheque'";

            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "consultaMovimiento");
            connection.Close();
            return ds;
        }
        
        public DataSet devolverCuentaCorriente(int id_banco, DateTime fechaDesde, DateTime fechaHasta, String concepto)
        {
            try
            {

                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT b.nombrebanco, b.numerocta ,b.moneda, m.movimiento, m.fecha, m.numerodocumento, m.concepto, m.debehaber, m.importe, m.saldo from movimientos m, banco b where m.codigobanco = b.codigobanco and b.codigobanco ='" + id_banco + "' and m.fecha BETWEEN '" + fechaDesde.ToString("yyyy/MM/dd") + "' and '" + fechaHasta.ToString("yyyy/MM/dd") + "' and m.concepto like '%" + concepto + "%' ORDER BY  m.movimiento ASC ";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cuentacorriente");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void GuardarMovimiento(DateTime fecha, int codigobanco, string numerocta, string numerodocumento, string debehaber, Double importe, string concepto, Double saldo)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();


            string sql;
            sql = "INSERT INTO movimientos (fecha, codigobanco, numerocta, numerodocumento, debehaber, importe, concepto, saldo) VALUES ('" + fecha.ToString("yyyy/MM/dd") + "','" + codigobanco + "','" + numerocta + "','" + numerodocumento + "','" + debehaber + "','" + importe.ToString("##0.00").Replace(",", ".") + "','" + concepto + "','" + saldo.ToString("##0.00").Replace(",", ".") + "');" + "Select last_insert_id()";

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

                    case 1062:
                        MisExcepciones es = new MisExcepciones("Ya exíste el Movimiento. Verifique el número");
                        throw es;

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
    }
}