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
    {
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
        /*
                public void eliminarInciso(int Id)
                {

                    MySqlConnection connection = conectar();
                    MySqlTransaction transaction = null;
                    MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                    string sql = "DELETE FROM inciso WHERE inciso_id = '" + Id + "'";

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
                                MisExcepciones es = new MisExcepciones("Ya exíste el Inciso. Verifique código, nombre y abreviatura");
                                throw es;

                            case 1451:
                                MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten oficinas asociadas ");
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

                public void modificarInciso(string Codigo, string Nombre, string Abreviatura, int idInciso)
                {
                    MySqlConnection connection = conectar();
                    MySqlTransaction transaction = null;
                    MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

                    try
                    {
                            
                        string sql = "Update inciso set inciso_codigo = '" + Codigo + "', inciso_nombre = '" + Nombre + "', inciso_abreviatura = '" + Abreviatura + "'  WHERE inciso_id =" + idInciso;

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

                public void GuardarInciso(string Codigo, string Nombre, string Abreviatura)
                {
                    MySqlConnection connection = conectar();
                    MySqlTransaction transaction = null;
                    MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

                    string sql;
                    sql = "INSERT INTO inciso (inciso_codigo, inciso_nombre, inciso_abreviatura) VALUES ('" + Codigo + "','" + Nombre + "','" + Abreviatura + "');" + "Select last_insert_id()";

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
                                MisExcepciones es = new MisExcepciones("Ya exíste el Inciso. Verifique código, nombre y abreviatura");
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
         *  * */
    }

}