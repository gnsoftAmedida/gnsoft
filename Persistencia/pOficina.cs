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
    public class pOficina : CapaDatos
    {
        public void eliminarOficina(int Id)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM oficina WHERE oficina_id = '" + Id + "'";

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
                    case 1451:
                        MisExcepciones fk = new MisExcepciones("No se puede eliminar ya que exísten socios asociados a la oficina ");
                        throw fk;
                }
            }
        }


        public void modificarOficina(String oficina_codigo, String oficina_nombre, String oficina_abreviatura, String oficina_direccion, int oficina_inciso, int departamento, String oficina_codigopostal, String oficina_telefono, String oficina_email, String oficina_nombrecontacto, int idOficina)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql = "Update oficina set oficina_codigo = '" + oficina_codigo + "', oficina_nombre = '" + oficina_nombre + "', oficina_abreviatura = '" + oficina_abreviatura + "', oficina_direccion = '" + oficina_direccion + "', inciso_inciso_id = '" + oficina_inciso + "', departamento_departamento_id = '" + departamento + "', oficina_codigopostal = '" + oficina_codigopostal + "', oficina_telefono = '" + oficina_telefono + "', oficina_email = '" + oficina_email + "', oficina_nombrecontacto = '" + oficina_nombrecontacto + "' WHERE oficina_id =" + idOficina;

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


        public DataSet devolverOficinasPorInciso(int idInciso)
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT oficina_id, oficina_codigo, oficina_nombre, oficina_abreviatura, oficina_direccion, inciso_inciso_id, departamento_departamento_id, oficina_codigopostal, oficina_telefono, oficina_email, oficina_nombrecontacto, CONCAT(oficina_codigo , ' - ' , oficina_abreviatura) as mostrar_nombre FROM oficina where inciso_inciso_id =" + idInciso;
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "oficinas");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarOficina(String oficina_codigo, String oficina_nombre, String oficina_abreviatura, String oficina_direccion, int oficina_inciso, int departamento, String oficina_codigopostal, String oficina_telefono, String oficina_email, String oficina_nombrecontacto)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            sql = "INSERT INTO oficina (oficina_codigo, oficina_nombre, oficina_abreviatura, oficina_direccion, inciso_inciso_id, departamento_departamento_id, oficina_codigopostal, oficina_telefono, oficina_email, oficina_nombrecontacto) VALUES ('" + oficina_codigo + "','" + oficina_nombre + "','" + oficina_abreviatura + "','" + oficina_direccion + "','" + oficina_inciso + "','" + departamento + "','" + oficina_codigopostal + "','" + oficina_telefono + "','" + oficina_email + "','" + oficina_nombrecontacto + "');" + "Select last_insert_id()";

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

        public DataSet devolverTodas()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT * FROM oficina";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "oficinas");
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