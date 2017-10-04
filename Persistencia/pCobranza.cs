﻿using System;
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
    public class pCobranza : CapaDatos
    {
        public DataSet devolverTodas()
        {
            try
            {
                MySqlConnection connection = conectar();

                MySqlDataAdapter MySqlAdapter = new MySqlDataAdapter();
                string sql = "SELECT cobranza_id, prestamo_id, cedula, tasa, porcentajeiva, montopedido, cantidadcuotas, nrodecuotas, importecuota, AmortizacionCuota, InteresCuota, IvaCuota,  AmortizacionVencer,InteresVencer, aportecapital, socio_id FROM cobranza";
                DataSet ds = new DataSet();

                connection.Open();
                MySqlAdapter.SelectCommand = connection.CreateCommand();
                MySqlAdapter.SelectCommand.CommandText = sql;
                MySqlAdapter.Fill(ds, "cobranzas");
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