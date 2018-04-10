using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using System.Text.RegularExpressions;
using System.Collections;
using Logs;

namespace COOPMEF
{
    public partial class frmAltaUsuario : Form
    {
        private Controladora empresa = Controladora.Instance;
        private System.Data.DataSet dsAcciones;

        public frmAltaUsuario()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            //Carga las acciones posibles de la aplicacion
            dsAcciones = empresa.DevolverAcciones();
            foreach (DataRow row in dsAcciones.Tables["acciones"].Rows)
            {
                checkedListPermisos.Items.Add(row["accion_descripcion"]);
            }
        }

        private void ValidarFormatoCorreoTelefono()
        {
            if (txtCorreo.Text != "")
            {
                Regex regex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                if (!regex.IsMatch(txtCorreo.Text))
                {
                    throw new Exception("Formato de correo electrónico no válido. \n Formato válido ejemplo@proveedor.com");
                }
            }

            if (txtTelefono.Text != "")
            {
                Regex regex2 = new Regex("^[(0-9]{3}-?[0-9]{3}-?[0-9]{3}$");
                if (!regex2.IsMatch(txtTelefono.Text))
                {
                    throw new Exception("Formato de número de celular no válido. \n Debe contener 9 dígitos");
                }
            }
        }

        private void ValidarCamposObligatoriosVacios()
        {

            if (txtAlias.Text == "" || txtClave.Text == "" || txtConfirmacionClave.Text == "")
            {
                throw new Exception("Campo/s obligatorio/s vacío/s");
            }
        }

        private void ValidarClave()
        {
            if (!txtClave.Text.Equals(txtConfirmacionClave.Text))
            {
                throw new Exception("Los campos contraseña y confirmar contraseña son diferentes. Deben ser iguales");
            }
            for (byte i = 0; i < txtClave.Text.Length; i++)
            {
                if (txtClave.Text.Substring(i, 1) == " ")
                    throw new Exception("La contraseña contiene espacios en blanco.");
            }
            if (txtClave.Text.Length < 8)
            {
                throw new Exception("La contraseña debe contener por lo menos 8 caracteres.");
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
            DataTable tablaAcciones = dsAcciones.Tables["acciones"];
            ArrayList acciones = new ArrayList();
            for (int indexChecked = 0; indexChecked < checkedListPermisos.Items.Count; indexChecked++)
            {
                if (checkedListPermisos.GetItemChecked(indexChecked))
                {
                    acciones.Add(tablaAcciones.Rows[indexChecked].Field<int>("accion_id"));
                }
            }

            string alias = txtAlias.Text;
            string clave = txtClave.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            try
            {
                ValidarCamposObligatoriosVacios();
                ValidarClave();
                ValidarFormatoCorreoTelefono();

                empresa.AltaUsuario(txtAlias.Text, txtClave.Text, txtCorreo.Text, txtTelefono.Text, acciones);
                mensaje = "Usuario ingresado correctamente";

                RegistroSLogs registroLogs = new RegistroSLogs();
                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Alta de usuario " + txtAlias.Text.Replace("'", ""));

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

        private void checkBoxSeleccionarTodo_CheckedChanged_1(object sender, EventArgs e)
        {
            bool check = checkBoxSeleccionarTodo.Checked;
            for (int index = 0; index < checkedListPermisos.Items.Count; index++)
            {
                checkedListPermisos.SetItemChecked(index, check);
            }
        }
    }
}
