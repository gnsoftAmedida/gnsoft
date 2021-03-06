﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using COOPMEF.CrystalDataSets;

namespace COOPMEF
{
    public partial class frmSociosBajaEn : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsSociosIngresadosEn ingresadosEn = new dsSociosIngresadosEn();

        public frmSociosBajaEn()
        {
            InitializeComponent();
        }

        private void frmSociosBajaEn_Load(object sender, EventArgs e)
        {
            int anio = 2018;
            int posAnio = 38;
            int anioActual = DateTime.Today.Year;

            posAnio = anioActual - anio + posAnio;

            try
            {
                cmbAnios.SelectedIndex = posAnio;
                cmbMeses.SelectedIndex = DateTime.Today.Month - 1;
            }
            catch
            {
                MessageBox.Show("Verifique que la fecha de su ordenador sea correcta");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(this.cmbMeses.SelectedIndex + 1);
            string mesNombre = cmbMeses.SelectedItem.ToString(); ;
            string anio = cmbAnios.SelectedItem.ToString();

            DateTime fechaInicial = Convert.ToDateTime(anio + "-" + mes + "-" + "01");
            DateTime fechaFinal = fechaInicial.AddMonths(1).AddDays(-1);

            DataSet sociosResultado = empresa.devolverBajasEntreFechas(fechaInicial, fechaFinal);

            if (sociosResultado.Tables["sociosEntreFechas"].Rows.Count > 0)
            {
                for (int n = 0; n <= sociosResultado.Tables["sociosEntreFechas"].Rows.Count - 1; n++)
                {
                    string socio_apellido = sociosResultado.Tables["sociosEntreFechas"].Rows[n][3].ToString();
                    string socio_nombre = sociosResultado.Tables["sociosEntreFechas"].Rows[n][2].ToString();
                    string numerocobro = sociosResultado.Tables["sociosEntreFechas"].Rows[n][4].ToString();
                    string numeroSocio = sociosResultado.Tables["sociosEntreFechas"].Rows[n][1].ToString();
                    string fechaIngreso = sociosResultado.Tables["sociosEntreFechas"].Rows[n][6].ToString();
                    string baja = sociosResultado.Tables["sociosEntreFechas"].Rows[n][22].ToString();
                    string telefono = sociosResultado.Tables["sociosEntreFechas"].Rows[n][13].ToString();
                    string oficina = sociosResultado.Tables["sociosEntreFechas"].Rows[n][16].ToString();
                    string Inciso = sociosResultado.Tables["sociosEntreFechas"].Rows[n][17].ToString();

                    ingresadosEn.SociosIngresadosEn.Rows.Add(socio_apellido, socio_nombre, numeroSocio, fechaIngreso, baja, telefono, mesNombre, anio, Inciso, oficina, numerocobro);
                }

                frmVerReportes reporte = new frmVerReportes(ingresadosEn, "SOCIOS_BAJA_EN");
                reporte.ShowDialog();
                ingresadosEn.SociosIngresadosEn.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No se encuentran socios dados de baja en la fechas seleccionadas");
            }
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
