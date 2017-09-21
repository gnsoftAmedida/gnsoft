using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Utilidades;

namespace Persistencia
{
    public class pEmpresa : CapaDatos
    {
        public void GuardarEmpresa(String empresa_nombre, String empresa_sigla, String empresa_direccion, int empresa_departamento, String empresa_codigoPostal, string empresa__telefono, string empresa_fax, String empresa_rut, int empresa_aporte, int empresa_MaxUnidad, int empresa_iva, int empresa_intMora, string empresa_mail, string empresa_presidente, string empresa__tesorero,
            string empresa_secretario, string empresa_primerVocal, string empresa_segundoVocal, DateTime empresa_fechaEleccion)
        {
            MySqlConnection connection = conectar();
            MySqlTransaction transaction = null;
            MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();

            string sql;
            //sql = "INSERT INTO empresa ( empresa_nombre, empresa_sigla,  empresa_direccion,  empresa_departamento,  empresa_codigoPostal,  empresa__telefono,  empresa_fax,  empresa_rut,  empresa_aporte,  empresa_MaxUnidad,  empresa_iva,  empresa_intMora,  empresa_mail,  empresa_presidente,  empresa__tesorero,empresa_secretario,  empresa_primerVocal,  empresa_segundoVocal,  empresa_fechaEleccion) VALUES ('" + empresa_nombre + "','" + empresa_sigla + "','" + empresa_direccion + "','" + empresa_departamento + "','" + empresa_codigoPostal + "','" + empresa__telefono + "','" + empresa_fax + "','" + empresa_rut + "','" + empresa_aporte + "','" + empresa_MaxUnidad + "','" + empresa_iva + "','" + empresa_intMora+ "','" +empresa_mail+ "','" + empresa_presidente+ "','" + empresa__tesorero + "','" +empresa_secretario+ "','" +empresa_primerVocal+ "','" +empresa_segundoVocal+ "','" + empresa_fechaEleccion+"');"  + "Select last_insert_id()";
            sql = "UPDATE empresa SET ( empresa_nombre, empresa_sigla,  empresa_direccion,  empresa_departamento,  empresa_codigoPostal,  empresa__telefono,  empresa_fax,  empresa_rut,  empresa_aporte,  empresa_MaxUnidad,  empresa_iva,  empresa_intMora,  empresa_mail,  empresa_presidente,  empresa__tesorero,empresa_secretario,  empresa_primerVocal,  empresa_segundoVocal,  empresa_fechaEleccion) VALUES ('" + empresa_nombre + "','" + empresa_sigla + "','" + empresa_direccion + "','" + empresa_departamento + "','" + empresa_codigoPostal + "','" + empresa__telefono + "','" + empresa_fax + "','" + empresa_rut + "','" + empresa_aporte + "','" + empresa_MaxUnidad + "','" + empresa_iva + "','" + empresa_intMora + "','" + empresa_mail + "','" + empresa_presidente + "','" + empresa__tesorero + "','" + empresa_secretario + "','" + empresa_primerVocal + "','" + empresa_segundoVocal + "','" + empresa_fechaEleccion + "'+ WHERE empresa_id =" + 0;

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
