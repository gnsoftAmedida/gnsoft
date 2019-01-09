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
    public class pSocio : CapaDatos
    {
        public DataSet buscarSociosPorCampo(string campo, string valor)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_cesion, s.socio_direccion, s.socio_email, o.oficina_codigo, i.inciso_codigo, s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, o.oficina_abreviatura, i.inciso_abreviatura FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and " + campo + " like " + " '%" + valor.Replace("-", "").Replace(".", "").Replace(",", "") + "%' ORDER BY " + campo + " ASC ";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socios");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet buscarSociosUtilidades(string cedula)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaIngreso, s.socio_cesion, s.socio_direccion FROM socio s where s.socio_nro ='" + cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socioUtilidades");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet devolverTodosBusqueda(string campo)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, o.oficina_codigo, i.inciso_codigo, s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion, o.oficina_abreviatura, i.inciso_abreviatura FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id ORDER BY " + campo + " ASC ";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socios");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverBajasEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_fecha_baja, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_activo = '0' and s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and socio_fecha_baja between '" + fechaInicial.ToString("yyyy/MM/dd") + "' and '" + fechaFinal.ToString("yyyy/MM/dd") + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "sociosEntreFechas");
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverCumpleMes(int mes)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, CONCAT(s.socio_direccion, ' [' , s.socio_postal, '-', s.socio_departamento , ']') , s.socio_email, CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and socio_activo='1' and MONTH(socio_fechaNac) = '" + mes + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "sociosCumpleMes");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverIngresadosEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and socio_fechaIngreso between '" + fechaInicial.ToString("yyyy/MM/dd") + "' and '" + fechaFinal.ToString("yyyy/MM/dd") + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "sociosEntreFechas");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet listadoSociosDepartamento(String signo, String departamento)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, CONCAT(s.socio_direccion, ' [' , s.socio_postal, '-', s.socio_departamento , ']'), s.socio_email, CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and socio_activo = '1' and socio_departamento" + signo + "'" + departamento + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "sociosDepartamento");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverSociosSegunEstado(int estado) // 1 = activo 0 = historico o baja
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, CONCAT(s.socio_direccion, ' [' , s.socio_postal, '-', s.socio_departamento , ']'), s.socio_email, CONCAT(o.oficina_codigo, ' - ', o.oficina_nombre), CONCAT(i.inciso_codigo, ' - ', i.inciso_nombre), s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and s.socio_activo ='" + estado + "'";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socios");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverSociosActivosEdad() // 1 = activo 0 = historico o baja
        {
            int estado = 1;
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, CONCAT(s.socio_direccion, ' [' , s.socio_postal, '-', s.socio_departamento , ']'), s.socio_email, o.oficina_abreviatura, i.inciso_abreviatura, s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento, s.socio_cesion FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and s.socio_activo ='" + estado + "' ORDER BY socio_fechaNac ASC";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socios");
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
                string sql = "SELECT socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email, socio_detalles, socio_postal, socio_departamento, socio_activo, socio_cesion FROM socio";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socios");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverSocio(int id_socio)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM socio where socio_id='" + id_socio + "'";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socioPorId");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverActivos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email, socio_detalles, socio_postal, socio_departamento, socio_cesion FROM socio where socio_activo = 1";
                DataSet ds = new DataSet();
                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "socio");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet devolverCancelacionesFallecidos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT c.FechaCancelacion, s.socio_nro, s.socio_nombre, s.socio_apellido, c.NumeroPrestamo, c.CuotasPactadas, c.CuotasPagadas, c.Tasa, c.MontoVale, c.ImporteCuota, c.AmortizacionVencer, c.InteresesVencer FROM fallecidos c, socio s where c.socio_id = s.socio_id";

                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "canelacionesFallecidos");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarFallecido(int NumeroPrestamo, int CuotasPactadas, int CuotasPagadas, Double Tasa, Double MontoVale, Double ImporteCuota, Double AmortizacionVencer, Double InteresesVencer, String Cedula, String Usuario, DateTime FechaCancelacion, int socio_id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO fallecidos (NumeroPrestamo, CuotasPactadas, CuotasPagadas, Tasa, MontoVale, ImporteCuota, AmortizacionVencer, InteresesVencer, Cedula, Usuario, FechaCancelacion, socio_id) VALUES ('" + NumeroPrestamo + "','" + CuotasPactadas + "','" + CuotasPagadas + "','" + Tasa.ToString("##0.00").Replace(",", ".") + "','" + MontoVale.ToString("##0.00").Replace(",", ".") + "','" + ImporteCuota.ToString("##0.00").Replace(",", ".") + "','" + AmortizacionVencer.ToString("##0.00").Replace(",", ".") + "','" + InteresesVencer.ToString("##0.00").Replace(",", ".") + "','" + Cedula.Replace("-", "").Replace(".", "").Replace(",", "") + "','" + Usuario + "','" + FechaCancelacion.ToString("yyyy/MM/dd") + "','" + socio_id + "');" + "Select last_insert_id()";
                                                                                                                                                                                                                               
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
                        MisExcepciones es = new MisExcepciones("Ya exíste un socio registrado con ese documento");
                        throw es;

                    case 1451:
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten prestamos asociadas ");
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

        public void eliminarSocio(int nro, ref int estaActivoOdeBaja)
        {
            //Para agregar fecha
            DateTime fechaBaja = DateTime.Today;

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            int nuevoEstado = 0;
            string sql;
            if (estaActivoOdeBaja == 0)
            {
                nuevoEstado = 1;
                sql = "UPDATE socio SET socio_activo = '" + nuevoEstado + "', socio_fecha_baja=null WHERE socio_id = '" + nro + "'";
            }
            else
            {
                estaActivoOdeBaja = nuevoEstado;
                 sql = "UPDATE socio SET socio_activo = '" + nuevoEstado + "', socio_fecha_baja='" + fechaBaja.ToString("yyyy/MM/dd") + "' WHERE socio_id = '" + nro + "'";
            }            

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

                    //case 1062:
                    //    MisExcepciones es = new MisExcepciones("Ya exíste el Socio");
                    //    throw es;

                    //case 1451:
                    //    MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten prestamos asociadas ");
                    //    throw fk;
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

        public void buscarSocio(string numSocio)
        {
            DataSet dsSocios = devolverTodos();

            int f = dsSocios.Tables[0].Rows.Count;

            for (int i = 0; i < f; i++)
            {
                int numSocioTable = Convert.ToInt32(dsSocios.Tables["socio"].Rows[i][3].ToString());
                if (numSocio.Equals(numSocioTable))
                {
                    //Socio s = new Socio();
                    //return dsSocios.Tables[0].ge

                }

            }
        }

        public void GuardarSocio(int Tsocio_activo, string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, string Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email, string Tsocio_postal, string detalles, String Departamento, String socioCesion)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO socio (socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email,socio_activo, socio_detalles, socio_postal, socio_departamento, socio_cesion) VALUES ('" + Tsocio_nombre.Replace("'", "") + "','" + Tsocio_apellido.Replace("'", "") + "','" + Tsocio_nro.Replace("-", "").Replace(".", "").Replace(",", "") + "','" + Tsocio_nroCobro.Replace("'", "") + "','" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "','" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "','" + Tsocio_estadoCivil + "','" + Tsocio_sexo + "','" + Tsocio_estado + "','" + Tsocio_edad + "','" + Tsocio_oficinaId + "','" + Tsocio_incisoId + "','" + Tsocio_tel.Replace("'", "") + "','" + Tsocio_direccion.Replace("'", "") + "','" + Tsocio_email.Replace("'", "") + "','" + Tsocio_activo + "','" + detalles + "','" + Tsocio_postal + "','" + Departamento + "','" + socioCesion + "');" + "Select last_insert_id()";

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
                        MisExcepciones es = new MisExcepciones("Ya exíste un socio registrado con ese documento");
                        throw es;

                    case 1451:
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten prestamos asociadas ");
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

        public void GuardarSocioModificado(int Tsocio_id, string socio_nro, string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, string Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email, string detalles, string postal, string departamento, string socioCesion)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "Update socio set socio_nombre ='" + Tsocio_nombre.Replace("'", "") + "', socio_nro  ='" + socio_nro.Replace("-", "").Replace(".", "").Replace(",", "") + "', socio_apellido ='" + Tsocio_apellido.Replace("'", "") + "', socio_nroCobro ='" + Tsocio_nroCobro.Replace("'", "") + "',socio_fechaNac='" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "',socio_fechaIngreso ='" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "',socio_sexo = '" + Tsocio_sexo + "', socio_estado = '" + Tsocio_estado + "', socio_cesion = '" + socioCesion + "', socio_estadoCivil = '" + Tsocio_estadoCivil + "', socio_edad='" + Tsocio_edad + "', socio_oficinaId = '" + Tsocio_oficinaId + "', socio_incisoId = '" + Tsocio_incisoId + "', socio_tel='" + Tsocio_tel.Replace("'", "") + "', socio_direccion='" + Tsocio_direccion.Replace("'", "") + "', socio_email='" + Tsocio_email.Replace("'", "") + "', socio_detalles='" + detalles + "', socio_postal='" + postal + "', socio_departamento='" + departamento + "' WHERE socio_id =" + Tsocio_id;

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
                        MisExcepciones es = new MisExcepciones("Ya exíste un socio con registrado con ese documento");
                        throw es;

                    case 1451:
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten prestamos asociadas ");
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
    }
}