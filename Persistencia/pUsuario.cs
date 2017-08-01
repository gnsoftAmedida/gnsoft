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
    public class pUsuario : CapaDatos
    {
        /// <summary>
        /// Este método verifica contra la BD si el usuario y la contraseña son válidas.
        /// En caso negativo, hace el throw de una excepción genérica con los datos del error
        /// En caso positivo, sigue el curso normal y guarda los datos del usuario en variables globales.
        /// </summary>
        /// <param name="Alias">Nombre del usuario logueado</param>
        /// <param name="Clave">Contraseña del usuario logueado</param>
        public void LoguearUsuario(string Alias, string Clave)
        {
            MySqlConnection connection = conectar();

            string ClaveEncriptada = FuncionesSeguridad.encriptar(Clave);

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "SELECT usuario_id, usuario_alias FROM usuario" +
                        " WHERE usuario_alias = '" + Alias + "' AND usuario_clave = '" + ClaveEncriptada + "' AND usuario_activo = '1'";

            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "usuarios");
            int idUsuario;
            string alias;

            if (ds.Tables["usuarios"].Rows.Count == 0)
            {
                throw new Exception("El usuario y/o contraseña son inválidos");
            }
            else
            {
                idUsuario = Convert.ToInt32(ds.Tables["usuarios"].Rows[0]["usuario_id"]);
                alias = ds.Tables["usuarios"].Rows[0]["usuario_alias"].ToString();

                Utilidades.UsuarioLogueado.Alias = alias;
                Utilidades.UsuarioLogueado.IdUsuario = idUsuario;

            }
            connection.Close();
        }

        public void GuardarUsuario(string Alias, string Clave, string Correo, string Telefono, ArrayList AccionesPermitidas)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;

            string ClaveEncriptada = FuncionesSeguridad.encriptar(Clave);
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql;
            sql = "INSERT INTO usuario (usuario_alias, usuario_clave, usuario_correo, usuario_telefono, usuario_activo) VALUES ('" + Alias + "','" + ClaveEncriptada + "','" + Correo + "','" + Telefono + "', 1);" + "Select last_insert_id()";

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                MySqlAdapter.InsertCommand = connection.CreateCommand();
                MySqlAdapter.InsertCommand.Transaction = transaction;
                MySqlAdapter.InsertCommand.CommandText = sql;

                int idUsuario = int.Parse(MySqlAdapter.InsertCommand.ExecuteScalar().ToString());
                GuardarAccionesUsuario(AccionesPermitidas, idUsuario, connection, transaction);

                transaction.Commit();
                connection.Close();
            }

            catch (MySqlException ex)
            {
                //Clave Unique de nombre duplicada
                if (ex.Number == 1062)
                {
                    transaction.Rollback();
                    connection.Close();
                    MisExcepciones ep = new MisExcepciones("Nombre de usuario no disponible");
                    throw ep;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }

        private void GuardarAccionesUsuario(ArrayList AccionesPermitidas, int idUsuario, MySqlConnection connection, MySqlTransaction transaction)
        {
            MySqlDataAdapter MySqlAdapter;
            string sql;

            foreach (int idAccion in AccionesPermitidas)
            {
                sql = "INSERT INTO usuario_accion (usuario_id, accion_id) values ('" + idUsuario + "','" + idAccion + "')";
                MySqlAdapter = new MySqlDataAdapter();
                MySqlAdapter.InsertCommand = connection.CreateCommand();
                MySqlAdapter.InsertCommand.Transaction = transaction;
                MySqlAdapter.InsertCommand.CommandText = sql;
                MySqlAdapter.InsertCommand.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int Id)
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "UPDATE usuario SET usuario_activo = 0 WHERE usuario_id =" + Id;

            connection.Open();
            MySqlAdapter.UpdateCommand = connection.CreateCommand();
            MySqlAdapter.UpdateCommand.CommandText = sql;
            MySqlAdapter.UpdateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public DataSet devolverTodos()
        {
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "SELECT usuario_id, usuario_alias, usuario_correo, usuario_telefono FROM usuario WHERE usuario_activo = 1";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "usuarios");
            connection.Close();
            return ds;
        }

        public void ModificarClave(int Id, string Clave)
        {
            MySqlConnection connection = conectar();
            string claveEncriptada = FuncionesSeguridad.encriptar(Clave);
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "UPDATE usuario SET usuario_clave = '" + claveEncriptada + "' WHERE usuario_id =" + Id;

            connection.Open();
            MySqlAdapter.UpdateCommand = connection.CreateCommand();
            MySqlAdapter.UpdateCommand.CommandText = sql;
            MySqlAdapter.UpdateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void VerificarClave(int Id, string claveAnterior)
        {
            string claveBD = "";
            string claveEncriptada = FuncionesSeguridad.encriptar(claveAnterior);
            MySqlConnection connection = conectar();

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "SELECT usuario_clave FROM usuario  WHERE usuario_id = '" + Id + "' AND usuario_activo = 1";
            DataSet ds = new DataSet();

            connection.Open();
            MySqlAdapter.SelectCommand = connection.CreateCommand();
            MySqlAdapter.SelectCommand.CommandText = sql;
            MySqlAdapter.Fill(ds, "usuarios");
            connection.Close();
            if (ds.Tables["usuarios"].Rows.Count > 0)
            {
                claveBD = ds.Tables["usuarios"].Rows[0]["usuario_clave"].ToString();
            }
            if (!claveEncriptada.Equals(claveBD))
            {
                throw new Exception("El campo contraseña anterior no es correcto");
            }
        }

        public string resetearClaveUsuario(int Id)
        {
            string claveNueva = FuncionesSeguridad.generarClave(3);
            ModificarClave(Id, claveNueva);
            return claveNueva;
        }

        public void ModificarUsuario(int Id, string Alias, string Correo, string Telefono, ArrayList AccionesPermitidas)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "UPDATE usuario SET usuario_alias = '" + Alias + "',  usuario_correo = '" + Correo + "', usuario_telefono = '" + Telefono + "', usuario_activo = 1 " + " WHERE usuario_id = " + Id;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                MySqlAdapter.UpdateCommand = connection.CreateCommand();
                MySqlAdapter.UpdateCommand.Transaction = transaction;
                MySqlAdapter.UpdateCommand.CommandText = sql;
                MySqlAdapter.UpdateCommand.ExecuteNonQuery();

                EliminarAccionesUsuario(Id, connection, transaction);
                GuardarAccionesUsuario(AccionesPermitidas, Id, connection, transaction);

                transaction.Commit();
                connection.Close();
            }

            catch (MySqlException ex)
            {
                //Clave Unique de nombre duplicada
                if (ex.Number == 1062)
                {
                    transaction.Rollback();
                    connection.Close();
                    MisExcepciones ep = new MisExcepciones("Nombre de usuario no disponible");
                    throw ep;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                    throw ex;
                }
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }

        private void EliminarAccionesUsuario(int Id, MySqlConnection connection, MySqlTransaction transaction)
        {

            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
            string sql = "DELETE FROM usuario_accion WHERE usuario_id = '" + Id + "'";

            MySqlAdapter.DeleteCommand = connection.CreateCommand();
            MySqlAdapter.DeleteCommand.Transaction = transaction;
            MySqlAdapter.DeleteCommand.CommandText = sql;
            MySqlAdapter.DeleteCommand.ExecuteNonQuery();
        }
    }
}
