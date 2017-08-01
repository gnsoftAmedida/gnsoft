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
    public partial class frmModificarClaveUsuario : Form
    {
        private Controladora empresa = Controladora.Instance;
        private DataGridView dgvUsuarios;
        private int indexUsuario;
        private int idUsuario;

        public frmModificarClaveUsuario()
        {
            InitializeComponent();
        }

        public frmModificarClaveUsuario(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dgvUsuarios = null;
            this.indexUsuario = 0;
            this.idUsuario = idUsuario;
        }

        public frmModificarClaveUsuario(DataGridView usuarios, int index)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dgvUsuarios = usuarios;
            this.indexUsuario = index;
            this.idUsuario = (int)dgvUsuarios.Rows[index].Cells["usuario_id"].Value;
        }

        private void ValidarClave()
        {
            if (!txtClaveNueva.Text.Equals(txtConfirmacionClave.Text))
            {
                throw new Exception("Los campos contraseña nueva y confirmar contraseña son diferentes. Deben ser iguales");
            }

            if (txtClaveNueva.Text.Equals(txtClaveAnterior.Text))
            {
                throw new Exception("Los campos contraseña nueva y contraseña anterior no pueden ser iguales");
            }

            for (byte i = 0; i < txtClaveNueva.Text.Length; i++)
            {
                if (txtClaveNueva.Text.Substring(i, 1) == " ")
                    throw new Exception("La contraseña contiene espacios en blanco.");
            }
            if (txtClaveNueva.Text.Length < 8)
            {
                throw new Exception("La contraseña debe contener por lo menos 8 caracteres.");
            }
        }

        private void ValidarCamposObligatoriosVacios()
        {
            if (txtClaveAnterior.Text == "" || txtClaveNueva.Text == "" || txtConfirmacionClave.Text == "")
            {
                throw new Exception("Campo/s obligatorio/s vacío/s");
            }
        }

        private void borrarPantalla()
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            borrarPantalla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            bool salir = false;
            try
            {
                ValidarClave();
                ValidarCamposObligatoriosVacios();
                empresa.ModificarClaveUsuario(idUsuario, txtClaveAnterior.Text, txtClaveNueva.Text);
                mensaje = "Contraseña modificada correctamente";
                salir = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            MessageBox.Show(mensaje);
            if (salir)
                borrarPantalla();
        }

        private void frmModificarClaveUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
