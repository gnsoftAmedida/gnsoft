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
    public class pBanco : CapaDatos
    {
        public DataSet devolverTodos()
        {
            try
            {
                //codigobanco, nombrebanco, agenciabanco, direccionbanco, telefonobanco, faxbanco, numerocta, moneda, saldo

                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT codigobanco, nombrebanco, agenciabanco, direccionbanco, telefonobanco, faxbanco, numerocta, moneda, saldo, CONCAT(codigobanco , ' - ' , numerocta, ' - ' , nombrebanco, ' - ' , moneda ) as mostrarse FROM banco";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "bancos");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarBanco(int codigobanco)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM banco WHERE codigobanco = '" + codigobanco + "'";

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

                    case 1062:
                        MisExcepciones es = new MisExcepciones("Ya exíste el Banco. Verifique código");
                        throw es;

                    case 1451:
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten movimientos asociados ");
                        throw fk;
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

        public void modificarBanco(int codigobanco, string nombrebanco, string agenciabanco, string direccionbanco, string telefonobanco, string faxbanco, string numerocta, string moneda, Double saldo)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {

                string sql = "Update banco set nombrebanco = '" + nombrebanco + "', agenciabanco = '" + agenciabanco + "', direccionbanco = '" + direccionbanco + "', telefonobanco = '" + telefonobanco + "', faxbanco = '" + faxbanco + "', numerocta = '" + numerocta + "', moneda = '" + moneda + "', saldo = '" + saldo + "'  WHERE codigobanco =" + codigobanco;

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

        public void GuardarBanco(string nombrebanco, string agenciabanco, string direccionbanco, string telefonobanco, string faxbanco, string numerocta, string moneda, Double saldo)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();


            string sql;
            sql = "INSERT INTO banco (nombrebanco, agenciabanco, direccionbanco, telefonobanco, faxbanco, numerocta, moneda, saldo) VALUES ('" + nombrebanco + "','" + agenciabanco + "','" + direccionbanco + "','" + telefonobanco + "','" + faxbanco + "','" + numerocta + "','" + moneda + "','" + saldo + "');" + "Select last_insert_id()";

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
                        MisExcepciones es = new MisExcepciones("Ya exíste el Banco. Verifique código");
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