﻿using System;
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
    public class pHistoria : CapaDatos
    {

        public DataSet devolverBusquedaInterfaz(String sql)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "interfaz");
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

        public void modificarHistoria(int Id, string _Presupuesto, int _NumeroPrestamo, string _cedula, double _tasa, double _porcentajeiva,
            double _montopedido, double _cantidadcuotas, double _nrodecuotas, double _importecuota, double _AmortizacionCuota, double _InteresCuota, double _IvaCuota,
            double _AmortizacionVencer, double _InteresVencer, double _aportecapital, string _numerocobro, int _Inciso, int _oficina, double _excedido, double _mora,
            double _IvaMora, int _socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            try
            {

                string sql = "Update historia set Presupuesto = '" + _Presupuesto + "', NumeroPrestamo = '" + _NumeroPrestamo + "',cedula = '" + _cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "', tasa = '" + _tasa.ToString("##0.00").Replace(",", ".") + "', porcentajeiva = '" + _porcentajeiva.ToString("##0.00").Replace(",", ".") + "', montopedido = '" + _montopedido.ToString("##0.00").Replace(",", ".") + "', cantidadcuotas = '" + _cantidadcuotas + "', nrodecuotas = '" + _nrodecuotas + "', importecuota = '" + _importecuota.ToString("##0.00").Replace(",", ".") + "', AmortizacionCuota = '" + _AmortizacionCuota.ToString("##0.00").Replace(",", ".") + "', InteresCuota = '" + _InteresCuota.ToString("##0.00").Replace(",", ".") + "', IvaCuota = '" + _IvaCuota.ToString("##0.00").Replace(",", ".") + "',  AmortizacionVencer = '" + _AmortizacionVencer.ToString("##0.00").Replace(",", ".") + "', InteresVencer = '" + _InteresVencer.ToString("##0.00").Replace(",", ".") + "', aportecapital = '" + _aportecapital.ToString("##0.00").Replace(",", ".") + "' , numerocobro = '" + _numerocobro + "', Inciso = '" + _Inciso + "', oficina = '" + _oficina + "', excedido = '" + _excedido.ToString("##0.00").Replace(",", ".") + "', mora = '" + _mora.ToString("##0.00").Replace(",", ".") + "', IvaMora = '" + _IvaMora.ToString("##0.00").Replace(",", ".") + "', socio_id='" + _socio_id + "' WHERE historia_id =" + Id;

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

        public DataSet devolverHistoria(string ci, string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM historia where cedula='" + ci.Replace("-", "").Replace(".", "").Replace(",", "") + "' and presupuesto =" + presupuesto;
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

        public DataSet devolverInterfacesGeneralesInforme(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT DISTINCTROW historia.presupuesto,historia.numeroprestamo, historia.cedula,historia.importecuota,historia.aportecapital,historia.numerocobro, CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), historia.inciso, historia.oficina,historia.excedido, historia.mora,historia.ivamora,socio.socio_nombre, socio.socio_apellido, socio.socio_departamento, socio.socio_fechaIngreso,socio.socio_detalles FROM oficina o, inciso i, socio INNER JOIN historia on socio.socio_nro=historia.cedula WHERE historia.oficina = o.oficina_id and historia.Inciso = i.inciso_id and historia.presupuesto= '" + presupuesto + "'	ORDER BY historia.cedula";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "interfacesInforme");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverPresupuestoDelMes(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

                // apellidos nombres 

                string sql = "SELECT s.socio_apellido, s.socio_nombre, h.numerocobro, h.cantidadcuotas, h.nrocuotas, h.AmortizacionCuota, h.InteresCuota, (h.InteresCuota * (h.porcentajeiva / 100)), h.aportecapital, h.excedido, h.mora, h.ivaMora, (h.AmortizacionCuota + h.InteresCuota + h.IvaCuota + h.excedido + h.mora + h.ivaMora + h.aportecapital), h.AmortizacionVencer, h.InteresVencer /  (1 + h.porcentajeiva / 100), h.InteresVencer - (h.InteresVencer /  (1 + h.porcentajeiva / 100)), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre) FROM historia h, oficina o, inciso i, socio s where h.socio_id = s.socio_id and h.oficina = o.oficina_id and h.Inciso = i.inciso_id and h.Presupuesto ='" + presupuesto + "' order by s.socio_apellido ASC ";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "presupuestoMes");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet facturacion(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

                // apellidos nombres 

                string sql = "SELECT s.socio_apellido, s.socio_nombre, i.inciso_codigo, o.oficina_codigo, h.InteresCuota, h.IvaCuota, h.mora, h.ivaMora, (h.InteresCuota * (h.porcentajeiva / 100)), (h.excedido + h.mora + h.ivaMora + h.aportecapital), h.NumeroPrestamo, h.cedula FROM historia h, oficina o, inciso i, socio s where h.socio_id = s.socio_id and h.oficina = o.oficina_id and h.Inciso = i.inciso_id and h.Presupuesto ='" + presupuesto + "' and (h.IvaCuota <> '0' or h.ivaMora <> '0')  ORDER BY h.Inciso, h.oficina";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "facturacion");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet devolverDatosPresupuesto(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT distinctrow h.Presupuesto, SUM(h.InteresVencer), SUM(h.AmortizacionVencer), sum(h.mora) FROM coopmef.historia h where h.presupuesto= '" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "datosPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverHistoriaPorIDyPresupuesto(int idSocio, string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM historia where socio_id='" + idSocio + "' and Presupuesto= '" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "historiasIdyPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverHistoriaPorIdSocioCompleta(int idSocio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT Distinct p.fecha, h.NumeroPrestamo, ROUND(p.monteopedido - p.amortizacionVencer) as monteopedido , p.amortizacionVencer, Round((h.cantidadcuotas * h.importecuota),2) as totalvale, h.cantidadcuotas, h.importecuota, p.numeroPrestamoAnt, p.cuotasPactadas, p.cuotasPagadas,  ((p.cuotasPagadas * 100)/p.cuotasPactadas) as porcentagePagado, s.socio_nro, s.socio_apellido, s.socio_nombre FROM historia h, prestamo p, socio s where s.socio_id = h.socio_id and h.NumeroPrestamo = p.prestamo_id and h.socio_id='" + idSocio + "' ORDER BY p.fecha DESC";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "historiasIdSocio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverHistoriaPorIdSocio(int idSocio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT Presupuesto, NumeroPrestamo, montopedido, cantidadcuotas, nrocuotas, importecuota, tasa FROM historia where socio_id='" + idSocio + "'" + " and NumeroPrestamo != '0' ";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "historiasIdSocio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverPrestamosOtorgadosPresupuesto(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT h.numerocobro, h.cedula, p.fecha, h.NumeroPrestamo, (p.monteopedido - p.AmortizacionVencer), p.AmortizacionVencer, h.montopedido, h.InteresVencer + h.InteresCuota + h.IvaCuota, p.interesesVencer, (h.InteresVencer + h.InteresCuota + h.IvaCuota) - p.interesesVencer, CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre) FROM historia h, prestamo p, oficina o, inciso i where h.oficina = o.oficina_id and h.Inciso = i.inciso_id and h.NumeroPrestamo = p.prestamo_id and h.Presupuesto ='" + presupuesto + "' and h.nrocuotas = 1";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "prestamosOtorgadosPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet devolverUtilidadesPorPresupuesto(string presupuesto)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT Round(SUM(InteresCuota),2), Round(SUM(aportecapital),2) FROM coopmef.historia where Presupuesto='" + presupuesto + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "devolverUtilidadesPorPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //**************************************
        public DataSet distribucionUtilidadesPorPresupuesto(string consultaPrevia)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = consultaPrevia;
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "utilidadesPorPresupuesto");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet salidasIngresos(string mes, int anio)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            // pagos e ingresos
            string sql = "select sum(p.monteopedido - p.amortizacionVencer) as pagos from coopmef.prestamo p where month(p.fecha) = '" + mes + "' and year(p.fecha) = '" + anio + "' and not p.anulado union select sum(h.importecuota + h.aportecapital + h.mora) as ingresos from coopmef.historia h where h.Presupuesto = '" + mes + "/" + anio + "'";

            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "salidaIngreso");
            connection.Close();
            return ds;
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
            sql = "INSERT INTO historia (Presupuesto, NumeroPrestamo, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas,nrocuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota, AmortizacionVencer, InteresVencer,aportecapital,numerocobro,Inciso,oficina,excedido,mora,IvaMora,socio_id) VALUES ('" + _Presupuesto + "','" + _NumeroPrestamo + "','" + _cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "','" + _tasa.ToString("##0.00").Replace(",", ".") + "','" + _porcentajeiva.ToString("##0.00").Replace(",", ".") + "','" + _montopedido.ToString("##0.00").Replace(",", ".") + "','" + _cantidadcuotas + "','" + _nrodecuotas + "','" + _importecuota.ToString("##0.00").Replace(",", ".") + "','" + _AmortizacionCuota.ToString("##0.00").Replace(",", ".") + "' ,'" + _InteresCuota.ToString("##0.00").Replace(",", ".") + "','" + _IvaCuota.ToString("##0.00").Replace(",", ".") + "','" + _AmortizacionVencer.ToString("##0.00").Replace(",", ".") + "','" + _InteresVencer.ToString("##0.00").Replace(",", ".") + "','" + _aportecapital.ToString("##0.00").Replace(",", ".") + "','" + _numerocobro + "','" + _Inciso + "','" + _oficina + "','" + _excedido.ToString("##0.00").Replace(",", ".") + "','" + _mora.ToString("##0.00").Replace(",", ".") + "','" + _IvaMora.ToString("##0.00").Replace(",", ".") + "','" + _socio_id + "');" + "Select last_insert_id()";

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
