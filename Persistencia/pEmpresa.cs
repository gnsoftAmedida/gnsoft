using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Utilidades;
using System.Data;

namespace Persistencia
{
    public class pEmpresa : CapaDatos
    {

        public DataSet devolverTodos()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT empresa_nombre, empresa_sigla,  empresa_direccion,  empresa_dpto,  empresa_codigoPostal,  empresa_tel,  empresa_fax,  empresa_rut,  empresa_aporte,  empresa_MaxUnidad,  empresa_iva,  empresa_intMora,  empresa_mail,  empresa_presidente,  empresa_tesorero, empresa_secretario,  empresa_primerVocal,  empresa_segundoVocal,  empresa_fechaEleccion, empresa_cierreBalance, empresa_usuarioCierre, empresa_cierreEjercicio, empresa_aporteCapital, empresa_cierrePresupuestoAnterior, empresa_horaCierreAnterior, empresa_cierrePresupuestoActual, empresa_horacierreactual, empresa_vtoPresupuestoActual FROM empresa";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "empresas");
                connection.Close();
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarParametrosCierreEmpresa(DateTime empresa_cierrePresupuestoAnterior, DateTime empresa_horaCierreAnterior, DateTime empresa_cierrePresupuestoActual, DateTime empresa_horacierreactual, DateTime empresa_vtoPresupuestoActual, String empresa_usuarioCierre)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;

            sql = "Update empresa set empresa_cierrePresupuestoAnterior='" + empresa_cierrePresupuestoAnterior.ToString("yyyy/MM/dd hh:mm:ss") + "', empresa_horaCierreAnterior='" + empresa_horaCierreAnterior.ToString("yyyy/MM/dd hh:mm:ss") + "',  empresa_cierrePresupuestoActual='" + empresa_cierrePresupuestoActual.ToString("yyyy/MM/dd hh:mm:ss") + "',  empresa_vtoPresupuestoActual='" + empresa_vtoPresupuestoActual.ToString("yyyy/MM/dd hh:mm:ss") + "',  empresa_usuarioCierre='" + empresa_usuarioCierre + "' WHERE idEmpresa = " + 1;

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

        public void GuardarEmpresa(String _nombre, String _sigla, String _direccion, String _departamento, String _codigoPostal, string __telefono, string _fax, String _rut, int _aporte, int _MaxUnidad, int _iva, int _intMora, string _mail, string _presidente, string _tesorero,
            string _secretario, string _primerVocal, string _segundoVocal, DateTime _fechaEleccion)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            int empresaId = 0;
            //sql = "INSERT INTO empresa ( empresa_nombre, empresa_sigla,  empresa_direccion,  empresa_dpto,  empresa_codigoPostal,  empresa_tel,  empresa_fax,  empresa_rut,  empresa_aporte,  empresa_MaxUnidad,  empresa_iva,  empresa_intMora,  empresa_mail,  empresa_presidente,  empresa_tesorero,empresa_secretario,  empresa_primerVocal,  empresa_segundoVocal,  empresa_fechaEleccion) VALUES ('" + _nombre + "','" + _sigla + "','" + _direccion + "','" + _departamento + "','" + _codigoPostal + "','" + __telefono + "','" + _fax + "','" + _rut + "','" + _aporte + "','" + _MaxUnidad + "','" + _iva + "','" + _intMora + "','" + _mail + "','" + _presidente + "','" + _tesorero + "','" + _secretario + "','" + _primerVocal + "','" + _segundoVocal + "','" + _fechaEleccion.ToString("yyyy/MM/dd") + "');" + "' WHERE idEmpresa = " + empresaId;
            sql = "Update empresa set empresa_nombre='" + _nombre + "', empresa_sigla='" + _sigla + "',  empresa_direccion='" + _direccion + "',  empresa_dpto='" + _departamento + "',  empresa_codigoPostal='" + _codigoPostal + "',  empresa_tel='" + __telefono + "',  empresa_fax='" + _fax + "',  empresa_rut='" + _rut + "',  empresa_aporte='" + _aporte + "',  empresa_MaxUnidad='" + _MaxUnidad + "',  empresa_iva='" + _iva + "',  empresa_intMora='" + _intMora + "',  empresa_mail='" + _mail + "',  empresa_presidente='" + _presidente + "',  empresa_tesorero='" + _tesorero + "',empresa_secretario='" + _secretario + "',  empresa_primerVocal='" + _primerVocal + "',  empresa_segundoVocal='" + _segundoVocal + "',  empresa_fechaEleccion='" + _fechaEleccion.ToString("yyyy/MM/dd") + "' WHERE idEmpresa = " + 0;
            //sql = "Update empresa set empresa_nombre='" + _nombre + "', empresa_sigla='" + _sigla + "',  empresa_direccion='" + _direccion + "',  empresa_dpto='" + _departamento + "',  empresa_codigoPostal='" + _codigoPostal + "',  empresa_tel='" + __telefono + "',  empresa_fax='" + _fax + "',  empresa_rut='" + _rut + "',  empresa_aporte='" + _aporte + "',  empresa_MaxUnidad='" + _MaxUnidad + "',  empresa_iva='" + _iva + "',  empresa_intMora='" + _intMora + "',  empresa_mail='" + _mail + "',  empresa_presidente='" + _presidente + "',  empresa_tesorero='" + _tesorero + "',empresa_secretario='" + _secretario + "',  empresa_primerVocal='" + _primerVocal + "',  empresa_segundoVocal='" + _segundoVocal + "',  empresa_fechaEleccion='" + _fechaEleccion + "' WHERE idEmpresa = " + 0;



            //"Update inciso set inciso_codigo = '" + Codigo + "', inciso_nombre = '" + Nombre + "', inciso_abreviatura = '" + Abreviatura + "'  WHERE inciso_id =" + idInciso;

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
    }
}
