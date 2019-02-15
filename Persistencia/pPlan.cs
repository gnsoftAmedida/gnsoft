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
    public class pPlan : CapaDatos
    {
        public DataSet devolverActivos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT plan_id, plan_NroCuotas, plan_TasaAnualEfectiva, plan_IvaSobreIntereses, plan_vigente, plan_nombre, plan_CuotaCada1000 FROM planprestamo where plan_vigente = 1";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "planprestamo");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet devolverTodos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT plan_id, plan_NroCuotas, plan_TasaAnualEfectiva, plan_IvaSobreIntereses, plan_vigente, plan_nombre, plan_CuotaCada1000 FROM planprestamo";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "planprestamo");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //se agrega para comparacion de tasas el 18 oct 2018
        public DataSet devolverTasaPorCantCuotasActivos(int cuotas)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT plan_TasaAnualEfectiva FROM planprestamo where plan_vigente = 1 AND plan_NroCuotas ='" + cuotas + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "planprestamo");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarPlan(int Id)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM planprestamo WHERE plan_id = '" + Id + "'";

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
                        MisExcepciones es = new MisExcepciones("Ya exíste el Plan");
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

        public void modificarPlan(int id_plan, int plan_cantCuotas, double plan_TasaAnualEfectiva, double plan_IvaSobreIntereses, int plan_vigencia, string plan_nombre, double plan_CuotaCada1000)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {

                string sql = "Update planprestamo set plan_NroCuotas = " + plan_cantCuotas + ", plan_TasaAnualEfectiva = " + plan_TasaAnualEfectiva.ToString().Replace(",", ".") + ", plan_IvaSobreIntereses = " + plan_IvaSobreIntereses.ToString().Replace(",", ".") + ", plan_vigente = " + plan_vigencia + ", plan_nombre = '" + plan_nombre + "', plan_CuotaCada1000 = " + plan_CuotaCada1000.ToString().Replace(",", ".") + " WHERE plan_id =" + id_plan;

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


        public void modificarTasas(double nuevaTasa)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {                 
                string sql = "Update planprestamo set plan_TasaAnualEfectiva = '" + nuevaTasa.ToString().Replace(",", ".") + "'";

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

        public void GuardarPlan(int plan_cantCuotas, double plan_TasaAnualEfectiva, double plan_IvaSobreIntereses, int plan_vigencia,string plan_nombre, double plan_CuotaCada1000)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
          
            string sql;
            sql = "INSERT INTO planprestamo (plan_NroCuotas, plan_TasaAnualEfectiva, plan_IvaSobreIntereses, plan_vigente, plan_nombre, plan_CuotaCada1000) VALUES ('" + plan_cantCuotas + "','" + plan_TasaAnualEfectiva.ToString().Replace(",", ".") + "','" + plan_IvaSobreIntereses.ToString().Replace(",", ".") + "','" + plan_vigencia + "','" + plan_nombre + "','" + plan_CuotaCada1000.ToString().Replace(",", ".") + "');" + "Select last_insert_id()";

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
                        MisExcepciones es = new MisExcepciones("Ya exíste el Plan. Verifique descripción");
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