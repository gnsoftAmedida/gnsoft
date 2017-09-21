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
        }

        private void ParámetrosDelSistema_Load(object sender, EventArgs e) {
            //Cargo Departamentos
            /*dsDepartamentos = empresa.DevolverDepartamentos();
            this.cmbDepartamentoCoop.DataSource = dsDepartamentos.Tables["departamentos"];
            this.cmbDepartamentoCoop.DisplayMember = "departamento_nombre";
            this.cmbDepartamentoCoop.ValueMember = "departamento_id";
            this.cmbDepartamentoCoop.SelectedIndex = -1;*/


            txtNombreCoop.Text = dsEmpresas.Tables["empresas"].Rows[0][1].ToString();
            txtSiglaCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][2].ToString();
            txtDirecciónCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][3].ToString();
            txtDeptoCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][4].ToString();
            txtCodPostal.Text= dsEmpresas.Tables["empresas"].Rows[0][5].ToString();
            txtTelCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][6].ToString();
            txtFaxCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][7].ToString();
            txtRUTCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][8].ToString();
            txtAporteCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][9].ToString();
            txtMaxUnidCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][10].ToString();
            txtIVACoop.Text= dsEmpresas.Tables["empresas"].Rows[0][11].ToString();
            txtInteresMoraCoop.Text = dsEmpresas.Tables["empresas"].Rows[0][12].ToString();
            txtEmailCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][13].ToString();
            txtPresidenteCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][14].ToString(); 
            txtTesoreroCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][15].ToString();
            txtSecretarioCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][16].ToString();
            txtPrimerVocalCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][17].ToString();
            txtSegVocalCoop.Text= dsEmpresas.Tables["empresas"].Rows[0][18].ToString();
            dtpFechaEleccion.Text = dsEmpresas.Tables["empresas"].Rows[0][19].ToString(); 


        
        
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
            int iva = Convert.ToInt32(txtIVACoop.Text);
            //int id_departamento = Convert.ToInt32(dsDepartamentos.Tables["departamentos"].Rows[this.cmbDepartamentoCoop.SelectedIndex][0].ToString());
            DateTime fechaEleccion = Convert.ToDateTime(dtpFechaEleccion.Value);
            empresa.AltaEmpresa(txtNombreCoop.Text, txtSiglaCoop.Text, txtDirecciónCoop.Text, txtDeptoCoop.Text, txtCodPostal.Text, txtTelCoop.Text, txtFaxCoop.Text, txtRUTCoop.Text, Convert.ToInt32(txtAporteCoop.Text), Convert.ToInt32(txtMaxUnidCoop.Text), Convert.ToInt32(txtIVACoop.Text), Convert.ToInt32(txtInteresMoraCoop.Text), txtEmailCoop.Text, txtPresidenteCoop.Text, txtTesoreroCoop.Text, txtSecretarioCoop.Text, txtPrimerVocalCoop.Text, txtSegVocalCoop.Text, fechaEleccion);
        
        }
    }
}
