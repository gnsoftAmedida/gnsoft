using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Logs;

namespace COOPMEF
{
    public partial class ParámetrosDelSistema : Form
    {
        private Controladora empresa = Controladora.Instance;

        DataSet dsDepartamentos;
        DataSet dsEmpresas;

        public ParámetrosDelSistema()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ParámetrosDelSistema_Load(object sender, EventArgs e) {
           
            dsEmpresas = empresa.DevolverEmpresa();

            txtNombreCoop.Text = dsEmpresas.Tables["empresas"].Rows[0][0].ToString();
            txtSiglaCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][1].ToString();
            txtDirecciónCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][2].ToString();
            txtDeptoCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][3].ToString();
            txtCodPostal.Text= dsEmpresas.Tables["empresas"].Rows[0][4].ToString();
            txtTelCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][5].ToString();
            txtFaxCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][6].ToString();
            txtRUTCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][7].ToString();
            txtAporteCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][8].ToString();
            txtMaxUnidCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][9].ToString();
            txtIVACoop.Text= dsEmpresas.Tables["empresas"].Rows[0][10].ToString();
            txtInteresMoraCoop.Text = dsEmpresas.Tables["empresas"].Rows[0][11].ToString();
            txtEmailCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][12].ToString();
            txtPresidenteCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][13].ToString(); 
            txtTesoreroCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][14].ToString();
            txtSecretarioCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][15].ToString();
            txtPrimerVocalCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][16].ToString();
            txtSegVocalCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][17].ToString();
            dtpFechaEleccion.Text = dsEmpresas.Tables["empresas"].Rows[0][18].ToString(); 


        
        
        }
        

        private void btnSalirParametrosSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //devuelve true si lo ingresado es numérico y si es < a 1 lo convierte en nro entero
        public Boolean validarNumericoPositivo(String numero)
        {
            try
            {
                Decimal num = Convert.ToDecimal(numero);
                
                if (num >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnGuardarParametrosSistema_Click(object sender, EventArgs e)
        {
            nuevaEmpresa();
        }

        private void nuevaEmpresa() {
            int iva;
            bool parametrosOK = true;
            string nombreCoop =this.txtNombreCoop.Text.Trim();
            string ivaCoop =this.txtIVACoop.Text.Trim() ;
            string aporteCoop =this.txtAporteCoop.Text.Trim();
            string interesMoraCoop =this.txtInteresMoraCoop.Text.Trim() ;
            string maxUnidCoop =this.txtMaxUnidCoop.Text.Trim() ;


            if ( nombreCoop == "")
            {
                parametrosOK = false;
            }

            if (!validarNumericoPositivo(ivaCoop) || ivaCoop== "")
            {
                parametrosOK = false;
            }
            else iva = Convert.ToInt32(txtIVACoop.Text);

            if (!validarNumericoPositivo(aporteCoop)|| aporteCoop== "")
            {
                parametrosOK = false;
            }

            if (!validarNumericoPositivo(interesMoraCoop) || interesMoraCoop== "")
            {
                parametrosOK = false;
            }

            if (!validarNumericoPositivo(maxUnidCoop) || maxUnidCoop== "")
            {
                parametrosOK = false;
            }
            
            
            if (parametrosOK)
            {
                DateTime fechaEleccion = Convert.ToDateTime(dtpFechaEleccion.Value);
                empresa.AltaEmpresa(txtNombreCoop.Text, txtSiglaCoop.Text, txtDirecciónCoop.Text, txtDeptoCoop.Text, txtCodPostal.Text, txtTelCoop.Text, txtFaxCoop.Text, txtRUTCoop.Text, Convert.ToInt32(txtAporteCoop.Text), Convert.ToInt32(txtMaxUnidCoop.Text), Convert.ToInt32(txtIVACoop.Text), Convert.ToInt32(txtInteresMoraCoop.Text), txtEmailCoop.Text, txtPresidenteCoop.Text, txtTesoreroCoop.Text, txtSecretarioCoop.Text, txtPrimerVocalCoop.Text, txtSegVocalCoop.Text, fechaEleccion);
                MessageBox.Show("Los datos de la empresa han sido actualizados");

                RegistroSLogs registroLogs = new RegistroSLogs();
                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Parámetros Empresa Modificados");

                this.Close();
            }else
                MessageBox.Show("Falta cargar datos obligatorios * o los mismos no tienen el formato correcto ");

        
        }
    }
}
