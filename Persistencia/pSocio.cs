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
                string sql = "SELECT s.socio_id, s.socio_nro, s.socio_nombre, s.socio_apellido, s.socio_nroCobro, s.socio_fechaNac, s.socio_fechaIngreso, s.socio_estadoCivil, s.socio_sexo, s.socio_estado, s.socio_edad, s.socio_oficinaId, s.socio_incisoId, s.socio_tel, s.socio_direccion, s.socio_email, o.oficina_nombre, i.inciso_nombre  FROM socio s, inciso i, oficina o  where s.socio_oficinaId = o.oficina_id and s.socio_incisoId = i.inciso_id and " + campo + " like " + " '%" + valor + "%' ORDER BY " + campo + " ASC ";
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
                string sql = "SELECT socio_id, socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email FROM socio";
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

        public void eliminarSocio(string nro)
        {

            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM socio WHERE socio_nro = '" + nro + "'";

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
                // if (Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString()) != Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[i][0].ToString()))

                //string numSocio = this.txtNroSocio.Text.Trim();
                int numSocioTable = Convert.ToInt32(dsSocios.Tables["socio"].Rows[i][3].ToString());
                if (numSocio.Equals(numSocioTable))
                {
                    //Socio s = new Socio();
                    //return dsSocios.Tables[0].ge

                }

            }
        }

        //public void modificarPlan(string Plan_cod, string Plan_descrip, int Plan_cantCuo, double Plan_int, int Plan_id)
        //{
        //    MySqlConnection connection = conectar();
        //    MySqlTransaction transaction = null;
        //    MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

        //    try
        //    {

        //        string sql = "Update planprestamo set plan_codigo = '" + Plan_cod + "', plan_descripcion = '" + Plan_descrip + "', plan_cantCuotas = '" + Plan_cantCuo + "', plan_interes = '" + Plan_int + "'  WHERE plan_id =" + Plan_id;

        //        connection.Open();
        //        transaction = connection.BeginTransaction();
        //        MySqlAdapter.UpdateCommand = connection.CreateCommand();
        //        MySqlAdapter.UpdateCommand.Transaction = transaction;

        //        MySqlAdapter.UpdateCommand.CommandText = sql;
        //        MySqlAdapter.UpdateCommand.ExecuteNonQuery();

        //        transaction.Commit();

        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        connection.Close();
        //        throw ex;
        //    }
        //}

        public void GuardarSocio(string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, int Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO socio (socio_nombre, socio_apellido, socio_nro, socio_nroCobro, socio_fechaNac, socio_fechaIngreso, socio_estadoCivil, socio_sexo, socio_estado, socio_edad, socio_oficinaId, socio_incisoId, socio_tel, socio_direccion, socio_email) VALUES ('" + Tsocio_nombre + "','" + Tsocio_apellido + "','" + Tsocio_nro + "','" + Tsocio_nroCobro + "','" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "','" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "','" + Tsocio_estadoCivil + "','" + Tsocio_sexo + "','" + Tsocio_estado + "','" + Tsocio_edad + "','" + Tsocio_oficinaId + "','" + Tsocio_incisoId + "','" + Tsocio_tel + "','" + Tsocio_direccion + "','" + Tsocio_email + "');" + "Select last_insert_id()";

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

            //catch (MySqlException ex)
            //{
            //    transaction.Rollback();
            //    connection.Close();

            //    switch (ex.Number)
            //    {
            //        case 1406:
            //            MisExcepciones ep = new MisExcepciones("Datos muy largos");
            //            throw ep;

            //        //case 1062:
            //        //    MisExcepciones es = new MisExcepciones("Ya exíste el Socio. Verifique su nro");
            //        //    throw es;

            //    }

            //    MisExcepciones eg = new MisExcepciones("(Error: " + ex.Number + ")" + " Consulte con el departamento de Sistemas");
            //    throw eg;
            //}
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }

        public void GuardarSocioModificado(string Tsocio_nombre, string Tsocio_apellido, string Tsocio_nro, int Tsocio_nroCobro, DateTime Tsocio_fechaNac, DateTime Tsocio_fechaIngreso, string Tsocio_estadoCivil, char Tsocio_sexo, string Tsocio_estado, int Tsocio_edad, int Tsocio_oficinaId, int Tsocio_incisoId, string Tsocio_tel, string Tsocio_direccion, string Tsocio_email)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "Update socio set socio_nombre ='" + Tsocio_nombre + "', socio_apellido ='" + Tsocio_apellido + "', socio_nroCobro ='" + Tsocio_nroCobro + "',socio_fechaNac='" + Tsocio_fechaNac.ToString("yyyy/MM/dd") + "',socio_fechaIngreso ='" + Tsocio_fechaIngreso.ToString("yyyy/MM/dd") + "',socio_sexo = '" + Tsocio_sexo + "', socio_estado = '" + Tsocio_estado + "', socio_estadoCivil = '" + Tsocio_estadoCivil + "', socio_edad='" + Tsocio_edad + "', socio_oficinaId = '" + Tsocio_oficinaId + "', socio_incisoId = '" + Tsocio_incisoId + "', socio_tel='" + Tsocio_tel + "', socio_direccion='" + Tsocio_direccion + "', socio_email='" + Tsocio_email + "'WHERE socio_nro =" + Tsocio_nro;

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

            //catch (MySqlException ex)
            //{
            //    transaction.Rollback();
            //    connection.Close();

            //    switch (ex.Number)
            //    {
            //        case 1406:
            //            MisExcepciones ep = new MisExcepciones("Datos muy largos");
            //            throw ep;

            //        //case 1062:
            //        //    MisExcepciones es = new MisExcepciones("Ya exíste el Socio. Verifique su nro");
            //        //    throw es;

            //    }

            //    MisExcepciones eg = new MisExcepciones("(Error: " + ex.Number + ")" + " Consulte con el departamento de Sistemas");
            //    throw eg;
            //}
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }
    }
}