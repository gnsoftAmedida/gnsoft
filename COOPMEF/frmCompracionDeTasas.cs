﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Microsoft.VisualBasic;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

using Utilidades;
using System.Globalization;
using Microsoft.VisualBasic;
using System.IO;



namespace COOPMEF
{
    public partial class frmCompracionDeTasas : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsPlanes;
        public frmCompracionDeTasas()
        {
            InitializeComponent();
        }

        private void btnSalirComparacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCalcularComparacion_Click(object sender, EventArgs e)
        {
            txtMontoCuotaCoop.Text = "0";
            txtTotalAPagarCoop.Text = "0";
            txtTasaCoop.Text = "0";
            txtAhorro.Text = "0";
            double tasaInteres = 0;
            if (empresa.esNumerico(txtMonto.Text) && empresa.esEntero(txtCantCuotas.Text) && empresa.esNumerico(txtCantCuotas.Text) && empresa.esNumerico(txtMontoCuota.Text))
            {
            double totalAPagarCompetencia = ((Convert.ToDouble(txtMontoCuota.Text.Replace(".", ","))) * (Convert.ToDouble(txtCantCuotas.Text.Replace(".", ","))));
            
            
            if (totalAPagarCompetencia == Convert.ToDouble(txtMonto.Text.Replace(".", ",")))
                MessageBox.Show("Sin intereses, tasa insuperable");
            else
                
                    if (txtMonto.Text != "" && txtCantCuotas.Text != "" && txtMontoCuota.Text != "")
                    {


                        dsPlanes = empresa.devolverTasaPorCantCuotasActivos(Convert.ToInt32(txtCantCuotas.Text.Replace(".", ",")));
                        if (dsPlanes.Tables["planprestamo"].Rows.Count > 0)
                        {
                            tasaInteres = Convert.ToDouble(dsPlanes.Tables["planprestamo"].Rows[0][0].ToString());

                        }
                        else
                            MessageBox.Show("No hay un plan de préstamos para la cantidad de cuotas especificada");

                    }

                    txtTotalAPagar.Text = (totalAPagarCompetencia).ToString("##########.");
                    txtTasa.Text = (queTasa(Convert.ToDouble(txtMonto.Text.Replace(".", ",")), Convert.ToDouble(txtMontoCuota.Text.Replace(".", ",")), Convert.ToInt32(txtCantCuotas.Text.Replace(".", ",")))).ToString("##########.");

                    if (tasaInteres != 0)
                    {
                        txtMontoCuotaCoop.Text = (Cuota(tasaInteres, Convert.ToInt32(txtCantCuotas.Text.Replace(".", ",")), Convert.ToDouble(txtMonto.Text.Replace(".", ",")))).ToString("##########.");
                        txtTotalAPagarCoop.Text = ((Convert.ToDouble(txtMontoCuotaCoop.Text.Replace(".", ","))) * (Convert.ToInt32(txtCantCuotas.Text.Replace(".", ",")))).ToString("##########.");
                        txtTasaCoop.Text = tasaInteres.ToString("##########.");
                        txtAhorro.Text = (Convert.ToDouble(txtTotalAPagar.Text.Replace(".", ",")) - Convert.ToDouble(txtTotalAPagarCoop.Text.Replace(".", ","))).ToString("##########.");
                    }
                }else
                MessageBox.Show("Los campos deben ser numéricos y la cantidad de cuotas debe ser entero");
        }



        private double Cuota(double tasa, int CantidadCuotas, double Capital)
        {
            tasa = tasa + 100; //' ejemp. 60 + 100 = 160
            tasa = tasa / 100; //' ejemp. 160 / 100 = 1.60
            Decimal exp= (1.00m /12.00m);
            string num =Convert.ToString(Math.Pow(tasa, Convert.ToDouble(exp)));
            tasa =  Convert.ToDouble(num) - 1; //' esta es la tasa mensual
            //'modificado 14/10/09
            return empresa.Format(tasa, CantidadCuotas, Capital);
        }


        private Double queTasa(double Capital, double ImpCuota, int CanCuotas)
        {
            double TasaMensual=0;
            double TasaAnual = 0; ;

            TasaMensual = empresa.Rate(CanCuotas, ImpCuota, Capital);
            TasaMensual = TasaMensual + 1;
            TasaAnual = Math.Pow(TasaMensual, 12);
            TasaAnual = TasaAnual - 1;
            TasaAnual = TasaAnual * 100;
            return TasaAnual;




        }

        private void frmCompracionDeTasas_Load(object sender, EventArgs e)
        {

        }

    }
}

