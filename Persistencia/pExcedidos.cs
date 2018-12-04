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
                MySqlAdapter.DeleteCommand = connection.CreateCommand();
                MySqlAdapter.DeleteCommand.Transaction = transaction;

                MySqlAdapter.DeleteCommand.CommandText = sql;
                MySqlAdapter.DeleteCommand.ExecuteNonQuery();
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

            string sql = "Update excedidos set fechadepago = '" + fechadepago.ToString("yyyy/MM/dd") + "', importepagado = '" + importepagado.ToString("##0.00").Replace(",", ".") + "', presupuestodelpago = '" + presupuestodelpago + "' WHERE excedidos_id =" + idExcedido;

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

            string sql = "Update excedidos set presupuesto = '" + presupuesto + "', cedula = '" + cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "', aretener = '" + aretener.ToString("##0.00").Replace(",", ".") + "', retenido = '" + retenido.ToString("##0.00").Replace(",", ".") + "', fechadepago = '" + fechadepago + "', importepagado = '" + importepagado.ToString("##0.00").Replace(",", ".") + "', presupuestodelpago = '" + presupuestodelpago + "', aportecapital = '" + aportecapital.ToString("##0.00").Replace(",", ".") + "', socio_id ='" + socio_id + "' WHERE excedidos_id =" + idExcedido;

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
            sql = "INSERT INTO excedidos (presupuesto,  cedula,  aretener,  retenido,  fechadepago,  importepagado,  presupuestodelpago,  aportecapital, socio_id) VALUES ('" + presupuesto + "','" + cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "','" + aretener.ToString("##0.00").Replace(",", ".") + "','" + retenido.ToString("##0.00").Replace(",", ".") + "','" + fechadepago + "','" + importepagado.ToString("##0.00").Replace(",", ".") + "','" + presupuestodelpago + "','" + aportecapital.ToString("##0.00").Replace(",", ".") + "','" + socio_id + "');" + "Select last_insert_id()";

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

        public DataSet PagoDeExcedidosPorPresupuesto(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT DISTINCT s.socio_apellido, s.socio_nombre, s.socio_nroCobro, s.socio_nro, e.presupuestodelpago, e.aretener, e.retenido, (e.aretener - e.retenido) as deuda, h.mora, (h.mora + (e.aretener - e.retenido)) as total, CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre) FROM coopmef.excedidos e, coopmef.oficina o, coopmef.inciso i, coopmef.socio s, coopmef.historia h where h.socio_id = e.socio_id and e.socio_id = s.socio_id and s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and e.presupuesto = h.presupuesto and e.presupuestodelpago != '' and e.presupuesto = '" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "pagoExecidosPorPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ExcedidosDeUnMes(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT DISTINCT s.socio_apellido, s.socio_nombre, s.socio_nroCobro, s.socio_nro, 'presupuesto del pago N/A', e.aretener, e.retenido, (e.aretener - e.retenido) as deuda, 'Mora N/A', 'total N/A', CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre) FROM coopmef.excedidos e, coopmef.oficina o, coopmef.inciso i, coopmef.socio s where e.socio_id = s.socio_id and s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and e.presupuestodelpago = '' and e.presupuesto = '" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "pagoExecidosPorPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

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

        public DataSet devolverExcedidosPorSocio(int idSocio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT e.presupuesto, e.aretener, e.retenido, ((e.aretener - e.retenido)) as saldo, h.mora, e.importepagado, e.presupuestodelpago, s.socio_nro, s.socio_apellido, s.socio_nombre FROM excedidos e, historia h, socio s where e.socio_id = s.socio_id and e.socio_id = h.socio_id and e.presupuesto = h.Presupuesto and e.socio_id='" + idSocio + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidosPorSocio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet devolverExcedidosPorSocioIdyPresupuesto(int idSocio, string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM excedidos where socio_id='" + idSocio + "' and presupuesto='" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "excedidosPorSocioIdyPresupuesto");
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
