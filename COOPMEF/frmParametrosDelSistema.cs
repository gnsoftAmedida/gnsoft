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

        public ParámetrosDelSistema()
        {
            InitializeComponent();
        }

        private void frmParametrosSistema_Load(object sender, EventArgs e) {

            dsDepartamentos = empresa.DevolverDepartamentos();
            this.cmbDepartamentoCoop.DataSource = dsDepartamentos.Tables["departamentos"];
            this.cmbDepartamentoCoop.DisplayMember = "departamento_nombre";
            this.cmbDepartamentoCoop.ValueMember = "departamento_id";
            this.cmbDepartamentoCoop.SelectedIndex = -1;
        
        }

        private void btnSalirParametrosSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
