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
        public DataSet buscarSociosPorCampo(string campo, string valor) {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, o.oficina_codigo, i.inciso_codigo, s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and " + campo + " like " + " '%" + valor + "%' ORDER BY " + campo + " ASC ";
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

        public DataSet devolverTodosBusqueda(string campo)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, o.oficina_codigo, i.inciso_codigo, s.socio_activo, s.socio_detalles, s.socio_postal, s.socio_departamento FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id ORDER BY " + campo + " ASC ";
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
                string sql = "SELECT socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email, socio_detalles, socio_postal, socio_departamento FROM socio";
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
                string sql = "SELECT socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email, socio_detalles, socio_postal, socio_departamento FROM socio where socio_activo = 1";
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

        public void eliminarSocio(int nro, ref int estaActivoOdeBaja)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            int nuevoEstado = 0;
            if (estaActivoOdeBaja == 0) nuevoEstado = 1;
            estaActivoOdeBaja = nuevoEstado;
            string sql = "UPDATE socio SET socio_activo = '" + nuevoEstado + "' WHERE socio_id = '" + nro + "'";

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

        public void GuardarSocio(int Tsocio_activo, string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, string Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email, string Tsocio_postal, string detalles, String Departamento)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO socio (socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email,socio_activo, socio_detalles, socio_postal, socio_departamento) VALUES ('" + Tsocio_nombre.Replace("'", "") + "','" + Tsocio_apellido.Replace("'", "") + "','" + Tsocio_nro + "','" + Tsocio_nroCobro.Replace("'", "") + "','" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "','" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "','" + Tsocio_estadoCivil + "','" + Tsocio_sexo + "','" + Tsocio_estado + "','" + Tsocio_edad + "','" + Tsocio_oficinaId + "','" + Tsocio_incisoId + "','" + Tsocio_tel.Replace("'", "") + "','" + Tsocio_direccion.Replace("'", "") + "','" + Tsocio_email.Replace("'", "") + "','" + Tsocio_activo + "','" + detalles + "','" + Tsocio_postal + "','" + Departamento + "');" + "Select last_insert_id()";

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

        public void GuardarSocioModificado(int Tsocio_id, string socio_nro, string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, string Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email, string detalles, string postal, string departamento)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "Update socio set socio_nombre ='" + Tsocio_nombre.Replace("'", "") + "', socio_nro  ='" + socio_nro + "', socio_apellido ='" + Tsocio_apellido.Replace("'", "") + "', socio_nroCobro ='" + Tsocio_nroCobro.Replace("'", "") + "',socio_fechaNac='" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "',socio_fechaIngreso ='" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "',socio_sexo = '" + Tsocio_sexo + "', socio_estado = '" + Tsocio_estado + "', socio_estadoCivil = '" + Tsocio_estadoCivil + "', socio_edad='" + Tsocio_edad + "', socio_oficinaId = '" + Tsocio_oficinaId + "', socio_incisoId = '" + Tsocio_incisoId + "', socio_tel='" + Tsocio_tel.Replace("'", "") + "', socio_direccion='" + Tsocio_direccion.Replace("'", "") + "', socio_email='" + Tsocio_email.Replace("'", "") + "', socio_detalles='" + detalles + "', socio_postal='" +  postal + "', socio_departamento='" + departamento + "' WHERE socio_id =" + Tsocio_id;

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