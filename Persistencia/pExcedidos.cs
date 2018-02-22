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
    public class pExcedidos : CapaDatos
    {
        public void eliminarExcedido(int Id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM excedidos WHERE excedidos_id = '" + Id + "'";

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
                    
                }
            }
        }

        public void actualizarExcedidoCierre(int idExcedido, DateTime fechadepago, double importepagado, String presupuestodelpago)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update excedidos set fechadepago = '" + fechadepago.ToString("yyyy/MM/dd") + "', importepagado = '" + importepagado.ToString().Replace(",", ".") + "', presupuestodelpago = '" + presupuestodelpago + "' WHERE excedidos_id =" + idExcedido;

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



        public void modificarExcedido(int idExcedido, String presupuesto, String cedula, double aretener, double retenido, DateTime fechadepago, double importepagado, String presupuestodelpago, double aportecapital, int socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update excedidos set presupuesto = '" + presupuesto + "', cedula = '" + cedula + "', aretener = '" + aretener.ToString().Replace(",", ".") + "', retenido = '" + retenido.ToString().Replace(",", ".") + "', fechadepago = '" + fechadepago + "', importepagado = '" + importepagado.ToString().Replace(",", ".") + "', presupuestodelpago = '" + presupuestodelpago + "', aportecapital = '" + aportecapital.ToString().Replace(",", ".") + "', socio_id ='" + socio_id + "' WHERE excedidos_id =" + idExcedido;

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

        public void GuardarExcedido(String presupuesto, String cedula, double aretener, double retenido, DateTime fechadepago, double importepagado, String presupuestodelpago, double aportecapital, int socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO excedidos (presupuesto,  cedula,  aretener,  retenido,  fechadepago,  importepagado,  presupuestodelpago,  aportecapital, socio_id) VALUES ('" + presupuesto + "','" + cedula + "','" + aretener.ToString().Replace(",", ".") + "','" + retenido.ToString().Replace(",", ".") + "','" + fechadepago + "','" + importepagado.ToString().Replace(",", ".") + "','" + presupuestodelpago + "','" + aportecapital.ToString().Replace(",", ".") + "','" + socio_id + "');" + "Select last_insert_id()";

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

       /*  Busqueda = "select * from excedidos where cedula=" & "'" & RsCobranza!cedula & "'"
                           Busqueda = Busqueda & "and importepagado=0"
         */

        public DataSet devolverExcedidosSinPago(int id_socio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM excedidos where socio_id='" + id_socio + "' and importepagado=0";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidosSinPago");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverExcedidosPorCIyPresupuesto(string ci, string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM excedidos where cedula='" + ci + "' and presupuesto=presupuesto";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidosPorCIyPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverExcedidosPorCI(string ci)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM excedidos where cedula='" + ci + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidosPorCI");
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
                string sql = "SELECT * FROM excedidos";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidos");
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
