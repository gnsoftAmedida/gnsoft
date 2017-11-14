using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Utilidades;
using System.Data.OleDb;

namespace Persistencia
{
    public class pHistoria: CapaDatos
    {

        public DataSet devolverTodos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT historia_id,Presupuesto, NumeroPrestamo, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas,nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota, AmortizacionVencer, InteresVencer,aportecapital,numerocobro,Inciso,oficina,excedido,mora,IvaMora,socio_id FROM historia";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "historias");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarHistoria(int Id)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM historia WHERE historia_id = '" + Id + "'";

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

        public void modificarHistoria(int Id, string _Presupuesto, int _NumeroPrestamo, string _cedula, double _tasa,double _porcentajeiva,
            double _montopedido,double _cantidadcuotas, double _nrodecuotas,double _importecuota,double _AmortizacionCuota,double _InteresCuota,double _IvaCuota,
            double _AmortizacionVencer,double _InteresVencer,double _aportecapital,string _numerocobro,int _Inciso,int _oficina,double _excedido,double _mora,
            double _IvaMora, int _socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {

                string sql = "Update historia set Presupuesto = '" + _Presupuesto + "', NumeroPrestamo = '" + _NumeroPrestamo + "',cedula = '" + _cedula + "', tasa = '" + _tasa + "', porcentajeiva = '" + _porcentajeiva + "', montopedido = '" + _montopedido + "', cantidadcuotas = '" + _cantidadcuotas + "', nrodecuotas = '" + _nrodecuotas + "', importecuota = '" + _importecuota + "', AmortizacionCuota = '" + _AmortizacionCuota + "', InteresCuota = '" + _InteresCuota + "', IvaCuota = '" + _IvaCuota + "',  AmortizacionVencer = '" + _AmortizacionVencer + "', InteresVencer = '" + _InteresVencer + "', aportecapital = '" + _aportecapital + "' , numerocobro = '" + _numerocobro + "', Inciso = '" + _Inciso + "', oficina = '" + _oficina + "', excedido = '" + _excedido + "', mora = '" + _mora + "', IvaMora = '" + _IvaMora + "', socio_id='" + _socio_id + "' WHERE historia_id =" + Id;
                           
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

        public void GuardarHistoria(string _Presupuesto, int _NumeroPrestamo, string _cedula, double _tasa, double _porcentajeiva,
            double _montopedido, double _cantidadcuotas, double _nrodecuotas, double _importecuota, double _AmortizacionCuota, double _InteresCuota, double _IvaCuota,
            double _AmortizacionVencer, double _InteresVencer, double _aportecapital, string _numerocobro, int _Inciso, int _oficina, double _excedido, double _mora,
            double _IvaMora, int _socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO historia (Presupuesto, NumeroPrestamo, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas,nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota, AmortizacionVencer, InteresVencer,aportecapital,numerocobro,Inciso,oficina,excedido,mora,IvaMora,socio_id) VALUES ('" + _Presupuesto + "','" + _NumeroPrestamo + "','" + _cedula + "','" + _tasa + "','" + _porcentajeiva + "','" + _montopedido + "','" + _cantidadcuotas + "','" + _nrodecuotas + "','" + _importecuota + "','" + _AmortizacionCuota + "' ,'" + _InteresCuota + "','" + _IvaCuota + "','" + _AmortizacionVencer + "','" + _InteresVencer + "','" + _aportecapital + "','" + _numerocobro + "','" + _Inciso + "','" + _oficina + "','" + _excedido + "','" + _mora + "','" + _IvaMora + "','" + _socio_id + "');" + "Select last_insert_id()";

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
