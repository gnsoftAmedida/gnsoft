using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

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

        private void btnGuardarParametrosSistema_Click(object sender, EventArgs e)
        {
            nuevaEmpresa();
        }

        private void nuevaEmpresa() {
            int iva;
            bool parametrosOK = true;

            if (this.txtNombreCoop.Text.Trim() == "")
            {
                parametrosOK = false;
            }

            if (this.txtIVACoop.Text.Trim() == "")
            {
                parametrosOK = false;
            }
            else iva = Convert.ToInt32(txtIVACoop.Text);

            if (this.txtAporteCoop.Text.Trim() == "")
            {
                parametrosOK = false;
            }

            if (this.txtInteresMoraCoop.Text.Trim() == "")
            {
                parametrosOK = false;
            }

            if (this.txtMaxUnidCoop.Text.Trim() == "")
            {
                parametrosOK = false;
            }
            
            if (parametrosOK)
            {
            //int id_departamento = Convert.ToInt32(dsDepartamentos.Tables["departamentos"].Rows[this.cmbDepartamentoCoop.SelectedIndex][0].ToString());
                DateTime fechaEleccion = Convert.ToDateTime(dtpFechaEleccion.Value);
                empresa.AltaEmpresa(txtNombreCoop.Text, txtSiglaCoop.Text, txtDirecciónCoop.Text, txtDeptoCoop.Text, txtCodPostal.Text, txtTelCoop.Text, txtFaxCoop.Text, txtRUTCoop.Text, Convert.ToInt32(txtAporteCoop.Text), Convert.ToInt32(txtMaxUnidCoop.Text), Convert.ToInt32(txtIVACoop.Text), Convert.ToInt32(txtInteresMoraCoop.Text), txtEmailCoop.Text, txtPresidenteCoop.Text, txtTesoreroCoop.Text, txtSecretarioCoop.Text, txtPrimerVocalCoop.Text, txtSegVocalCoop.Text, fechaEleccion);
                MessageBox.Show("Los datos de la empresa han sido actualizados");
                this.Close();
            }else
                MessageBox.Show("Falta cargar datos obligatorios * ");

        
        }
    }
}
