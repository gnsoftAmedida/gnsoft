using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Utilidades;
using Logs;

namespace COOPMEF
{
    public partial class frmLogin : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal();
            principal.ShowDialog();
            this.Close();

                 //string mensaje = "";
                 //try
                 //{
                 //    ValidarCamposVacios();
                 //    empresa.LoguearUsuario(txtUsuario.Text, txtClave.Text);
                 //    this.Visible = false;

                 //    if (this.validarLicencia())
                 //    {
                 //        if (this.validarVencimiento())
                 //        {
                 //            RegistroSLogs registroLogs = new RegistroSLogs();
                 //            registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Ingreso al sistema");

                 //            frmPrincipal principal = new frmPrincipal();
                 //            principal.ShowDialog();
                 //            this.Close();
                 //        }
                 //        else
                 //        {
                 //            MessageBox.Show("Licencia vencida, consulte con su proveedor");
                 //        }
                 //    }
                 //    else
                 //    {
                 //        MessageBox.Show("Licencia inválida, consulte con su proveedor");
                 //    }
                 //}
                 //catch (Exception ex)
                 //{
                 //    mensaje = ex.Message;
                 //    MessageBox.Show(mensaje);
                 //} 
        } 

        private bool validarLicencia()
        {
            return empresa.controlarLicencia();
        }

        private bool validarVencimiento()
        {
            return empresa.controlarVencimiento();
        }

        private void ValidarCamposVacios()
        {

            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                throw new Exception("Complete todos los campos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
