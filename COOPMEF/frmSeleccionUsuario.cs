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
    public partial class frmSeleccionUsuario : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsUsuarios;
        private bool modificacion;
        private bool resetearClave;

        public frmSeleccionUsuario()
        {
            InitializeComponent();
        }

        public frmSeleccionUsuario(bool modificacion)
        {
            InitializeComponent();
            this.modificacion = modificacion;
            if (modificacion)
            {
                this.Text = "Modificación Usuario";
                this.btnEliminar.Text = "Modificar";
            }
            else
            {
                this.Text = "Resetear clave usuario";
                this.btnEliminar.Text = "Resetear";
                this.resetearClave = true;
            }
        }

        public void cargaInicial()
        {
            dsUsuarios = empresa.DevolverUsuarios();

            dataGridUsuarios.DataSource = dsUsuarios.Tables["usuarios"];
            dataGridUsuarios.RowHeadersVisible = false;
            dataGridUsuarios.ReadOnly = true;
            dataGridUsuarios.MultiSelect = false;
            dataGridUsuarios.ReadOnly = true;
            dataGridUsuarios.AllowDrop = false;
            dataGridUsuarios.AllowUserToAddRows = false;
            dataGridUsuarios.AllowUserToDeleteRows = false;
            dataGridUsuarios.AllowUserToResizeColumns = false;
            dataGridUsuarios.AllowUserToResizeRows = false;
            dataGridUsuarios.AllowUserToOrderColumns = false;
            dataGridUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridUsuarios.BackgroundColor = BackColor;
            dataGridUsuarios.BorderStyle = BorderStyle.None;
            dataGridUsuarios.Columns["usuario_alias"].HeaderText = "Alias";
            dataGridUsuarios.Columns["usuario_alias"].Width = 150;
            dataGridUsuarios.Columns["usuario_id"].Visible = false;
            dataGridUsuarios.Columns["usuario_telefono"].HeaderText = "Teléfono";
            dataGridUsuarios.Columns["usuario_telefono"].Width = 110;
            dataGridUsuarios.Columns["usuario_correo"].HeaderText = "Correo";
            dataGridUsuarios.Columns["usuario_correo"].Width = 150;
        }


        private void frmBajaUsuario_Load(object sender, EventArgs e)
        {
            this.cargaInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool salir = false;
            if (modificacion)
            {
                if (!(dataGridUsuarios.CurrentRow == null))
                {
                    int index = dataGridUsuarios.CurrentRow.Index;
                    frmModificarUsuario frmModifUsuario = new frmModificarUsuario(dataGridUsuarios, index);
                    frmModifUsuario.ShowDialog();
                    this.cargaInicial();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un usuario");
                }
            }
            else if (resetearClave)
            {
                if (dsUsuarios != null)
                {
                    string mensaje = "";
                    int index = dataGridUsuarios.CurrentRow.Index;
                    int idUsuario = (int)dataGridUsuarios.Rows[index].Cells["usuario_id"].Value;
                    string alias = dataGridUsuarios.Rows[index].Cells["usuario_alias"].Value.ToString();

                    string message = "¿Está seguro de que desea resetear la contraseña de " + alias + "?";
                    string caption = "Reseteo de Contraseña";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            if (dataGridUsuarios.SelectedRows.Count > 0)
                            {
                                string claveNueva = empresa.ResetearClaveUsuario(idUsuario);

                                mensaje = "Contraseña modificada correctamente. \n" +
                                            "Su nueva contraseña es: " + claveNueva;

                                RegistroSLogs registroLogs = new RegistroSLogs();
                                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Reseteo contraseña Usuario " + dataGridUsuarios.Rows[index].Cells["usuario_alias"].Value);

                            }
                            else
                            {
                                mensaje = "Por favor seleccione un usuario";
                            }
                        }
                        catch (Exception ex)
                        {
                            mensaje = ex.Message;
                        }

                        MessageBox.Show(mensaje);

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No existen usuarios registrados. Por favor ingrese nuevos antes de continuar");
                }
            }
            else
            {
                string message = "¿Está seguro de que desea eliminar el usuario?";
                string caption = "Baja Usuario";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    String mensaje = "";
                    try
                    {
                        if (dataGridUsuarios.SelectedRows.Count > 0)
                        {
                            int index = dataGridUsuarios.CurrentRow.Index;
                            int idUsuario = (int)dataGridUsuarios.Rows[index].Cells["usuario_id"].Value;
                            empresa.BajaUsuario(idUsuario);

                            RegistroSLogs registroLogs = new RegistroSLogs();
                            registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Baja Usuario " + dataGridUsuarios.Rows[index].Cells["usuario_alias"].Value);

                            mensaje = "Usuario eliminado";
                            salir = true;
                        }
                        else
                        {
                            mensaje = "Por favor seleccione un usuario";
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                    }
                    MessageBox.Show(mensaje);
                    if (salir)
                        this.cargaInicial();
                }
            }
        }
    }
}
