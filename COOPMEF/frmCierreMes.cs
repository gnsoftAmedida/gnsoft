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
using Logs;

namespace COOPMEF
{
    public partial class frmCierreMes : Form
    {

        private Controladora empresa = Controladora.Instance;

        public frmCierreMes()
        {
            InitializeComponent();
        }

        private void frmCierreMes_Load(object sender, EventArgs e)
        {
            inicio();
        }

        private void inicio()
        {
            lblTrabajando.Visible = false;

            btnSeleccionarSocio.Enabled = true;
            btnCancelarBusqueda.Enabled = true;

            DataSet dsEmpresas = empresa.DevolverEmpresa();
            DateTime fechaPresupuestoAnterior = Convert.ToDateTime(dsEmpresas.Tables["empresas"].Rows[0][23].ToString().ToString());
            DateTime horaPresupuestoAnterior = Convert.ToDateTime(dsEmpresas.Tables["empresas"].Rows[0][24].ToString().ToString());

            DateTime fechaPresupuestoUltimo = Convert.ToDateTime(dsEmpresas.Tables["empresas"].Rows[0][25].ToString().ToString());
            DateTime horaPresupuestoUltimo = Convert.ToDateTime(dsEmpresas.Tables["empresas"].Rows[0][26].ToString().ToString());

            DateTime fechaVencimientoPresupuesto = Convert.ToDateTime(dsEmpresas.Tables["empresas"].Rows[0][27].ToString().ToString());



            this.lblFechaPresupuestoAnterior.Text = fechaPresupuestoAnterior.ToString("dd/MM/yyyy");
            //   this.lblHoraPresupuestoAnterior.Text = horaPresupuestoAnterior.AddHours(12).ToString("HH:mm:ss");
            this.lblHoraPresupuestoAnterior.Text = horaPresupuestoAnterior.ToString("HH:mm:ss");
            this.lblFechaPresupuestoUltimo.Text = fechaPresupuestoUltimo.ToString("dd/MM/yyyy");
            //this.lblHoraPresupuestoUltimo.Text = horaPresupuestoUltimo.AddHours(12).ToString("HH:mm:ss");
            this.lblHoraPresupuestoUltimo.Text = horaPresupuestoUltimo.ToString("HH:mm:ss");
            this.lblFechaVencimientoPresupuesto.Text = fechaVencimientoPresupuesto.ToString("dd/MM/yyyy");

            this.lblFechaCierre.Text = empresa.presupuesto();
        }

        private void btnSeleccionarSocio_Click(object sender, EventArgs e)
        {
            lblTrabajando.Visible = true;

            if (!(empresa.cierreEfectuado(empresa.presupuesto())))
            {
                string message = "¿Está seguro de que desea realizar el cierre mensual?";
                string caption = "Cierre Mes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    btnSeleccionarSocio.Enabled = false;
                    btnCancelarBusqueda.Enabled = false;

                    empresa.cierre();

                    MessageBox.Show("Cierre efectuado correctamente");

                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Cierre mes " + this.lblFechaCierre.Text);

                    inicio();
                }
                else
                {
                    lblTrabajando.Visible = false;
                }
            }
            else
            {
                lblTrabajando.Visible = false;
                MessageBox.Show("El cierre para el presupuesto " + empresa.presupuesto() + " ya fué realizado");
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
