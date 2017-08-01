using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using System.Collections;
using System.Text.RegularExpressions;
using Logs;

namespace COOPMEF
{
    public partial class frmModificarUsuario : Form
    {
        private Controladora empresa = Controladora.Instance;
        private DataGridView dgvUsuarios;
        private int indexUsuario;
        private DataSet dsAcciones;
        private DataSet dsAccionesUsuario;

        public frmModificarUsuario()
        {
            InitializeComponent();
        }

        public frmModificarUsuario(DataGridView usuarios, int index)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dgvUsuarios = usuarios;
            this.indexUsuario = index;
        }

        private bool PerteneceAccionesUsuarios(int idAccion)
        {
            foreach (DataRow row in dsAccionesUsuario.Tables["acciones"].Rows)
            {
                if (idAccion == (int)row["accion_id"])
                {
                    return true;
                }
            }
            return false;
        }

        private void frmModificarUsuario_Load(object sender, EventArgs e)
        {
            int idUsuario = (int)dgvUsuarios.Rows[indexUsuario].Cells["usuario_id"].Value;
            dsAccionesUsuario = empresa.DevolverAccionesXUsuario(idUsuario);
            dsAcciones = empresa.DevolverAcciones();

            int contador = 0;
            foreach (DataRow row in dsAcciones.Tables["acciones"].Rows)
            {
                checkedListPermisos.Items.Add(row["accion_descripcion"]);

                {
                    if (PerteneceAccionesUsuarios((int)row["accion_id"]))
                    {
                        checkedListPermisos.SetItemChecked(contador, true);
                    }
                    contador++;
                }

                txtAlias.Text = dgvUsuarios.Rows[indexUsuario].Cells["usuario_alias"].Value.ToString();
                txtCorreo.Text = dgvUsuarios.Rows[indexUsuario].Cells["usuario_correo"].Value.ToString();
                txtTelefono.Text = dgvUsuarios.Rows[indexUsuario].Cells["usuario_telefono"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            int idUsuario = (int)dgvUsuarios.Rows[indexUsuario].Cells["usuario_id"].Value;

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
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            try
            {
                ValidarCamposObligatoriosVacios();
                ValidarFormatoCorreoTelefono();
                empresa.ModificarUsuario(idUsuario, txtAlias.Text, txtCorreo.Text, txtTelefono.Text, acciones);
                mensaje = "Usuario modificado correctamente";
            
                RegistroSLogs registroLogs = new RegistroSLogs();
                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Modifiación de datos del usuario " + alias);
             
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            MessageBox.Show(mensaje);
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

            if (txtAlias.Text == "")
            {
                throw new Exception("Campo/s obligatorio/s vacío/s");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
