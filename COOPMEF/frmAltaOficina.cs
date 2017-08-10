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

namespace COOPMEF
{
    public partial class frmMantOficinas : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsOficinas;
        DataSet dsIncisos;
        DataSet dsDepartamentos;
        private bool nuevo = true;
        private bool yaHizoLoad = false;

        public frmMantOficinas()
        {
            InitializeComponent();
        }

        private void btnSalirCobranza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMantOficinas_Load(object sender, EventArgs e)
        {
            //Cargar oficinas
            dsOficinas = empresa.DevolverOficinas();

            //Cargo Incisos
            dsIncisos = empresa.DevolverIncisos();

            //Cargo Departamentos
            dsDepartamentos = empresa.DevolverDepartamentos();

            pantallaInicial();

            yaHizoLoad = true;
        }

        public void pantallaInicial()
        {
            // Cargo combos de oficinas, departamentos e incisos
            this.cmbTodosIncisos.DataSource = dsIncisos.Tables["incisos"];
            this.cmbTodosIncisos.DisplayMember = "inciso_nombre";
            this.cmbTodosIncisos.ValueMember = "inciso_id";
            this.cmbTodosIncisos.SelectedIndex = -1;

            this.cmbOficinas.DataSource = dsOficinas.Tables["oficinas"];
            this.cmbOficinas.DisplayMember = "oficina_nombre";
            this.cmbOficinas.ValueMember = "oficina_id";
            this.cmbOficinas.SelectedIndex = -1;

            this.cmbIncisos.DataSource = dsIncisos.Tables["incisos"];
            this.cmbIncisos.DisplayMember = "inciso_nombre";
            this.cmbIncisos.ValueMember = "inciso_id";
            this.cmbIncisos.SelectedIndex = -1;

            this.cmbDepartamento.DataSource = dsDepartamentos.Tables["departamentos"];
            this.cmbDepartamento.DisplayMember = "departamento_nombre";
            this.cmbDepartamento.ValueMember = "departamento_id";
            this.cmbDepartamento.SelectedIndex = -1;

            //Deshabilito cajas de texto
            this.cmbOficinas.Enabled = true;
            this.cmbIncisos.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtAbreviatura.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCodigoPostal.Enabled = false;
            this.cmbDepartamento.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtNombreContacto.Enabled = false;

            //Borro las cajas de texto
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtAbreviatura.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.txtTelefono.Clear();
            this.txtEmail.Clear();
            this.txtNombreContacto.Clear();

            //Borrar errores
            this.borrarErrores();

            this.btnEliminar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnNuevaOficina.Enabled = true;
        }

        private void btnNuevaOficina_Click(object sender, EventArgs e)
        {
            this.nuevo = true;

            this.cmbOficinas.Enabled = false;
            this.cmbOficinas.SelectedIndex = -1;

            this.cmbIncisos.Enabled = true;
            this.cmbIncisos.SelectedIndex = -1;
            this.txtCodigo.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtAbreviatura.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtCodigoPostal.Enabled = true;
            this.cmbDepartamento.Enabled = true;
            this.cmbDepartamento.SelectedIndex = -1;
            this.txtTelefono.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtNombreContacto.Enabled = true;

            //Borro las cajas de texto
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtAbreviatura.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.txtTelefono.Clear();
            this.txtEmail.Clear();
            this.txtNombreContacto.Clear();

            this.btnEliminar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.pantallaInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message = "¿Está seguro de que desea eliminar la oficina?";
            string caption = "Baja Oficina";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int index = this.cmbOficinas.SelectedIndex;

                try
                {
                    empresa.bajaOficina(Convert.ToInt32(dsOficinas.Tables["oficinas"].Rows[index][0].ToString()));

                    MessageBox.Show("Oficina eliminada correctamente");

                    //Cargo Oficinas
                    dsOficinas = empresa.DevolverOficinas();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void cmbOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbOficinas.SelectedIndex;
            //Como en el load se pasa por este método, sino lo controlo los combos de departamento e inciso se caen
            if (yaHizoLoad)
            {
                if (index != -1)
                {
                    this.cmbIncisos.Enabled = true;
                    this.txtCodigo.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtAbreviatura.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.txtCodigoPostal.Enabled = true;
                    this.cmbDepartamento.Enabled = true;
                    this.txtTelefono.Enabled = true;
                    this.txtEmail.Enabled = true;
                    this.txtNombreContacto.Enabled = true;

                    this.btnEliminar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnGuardar.Enabled = false;
                    this.btnCancelar.Enabled = true;

                    this.txtCodigo.Text = dsOficinas.Tables["oficinas"].Rows[index][1].ToString();
                    this.txtNombre.Text = dsOficinas.Tables["oficinas"].Rows[index][2].ToString();
                    this.txtAbreviatura.Text = dsOficinas.Tables["oficinas"].Rows[index][3].ToString();
                    this.txtDireccion.Text = dsOficinas.Tables["oficinas"].Rows[index][4].ToString();
                    this.txtCodigoPostal.Text = dsOficinas.Tables["oficinas"].Rows[index][7].ToString();
                    this.txtTelefono.Text = dsOficinas.Tables["oficinas"].Rows[index][8].ToString();
                    this.txtEmail.Text = dsOficinas.Tables["oficinas"].Rows[index][9].ToString();
                    this.txtNombreContacto.Text = dsOficinas.Tables["oficinas"].Rows[index][10].ToString();

                    //Elijo el departamento de la oficina seleccionada
                    for (int i = 0; i < dsDepartamentos.Tables["departamentos"].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dsOficinas.Tables["oficinas"].Rows[index][6].ToString()) == Convert.ToInt32(dsDepartamentos.Tables["departamentos"].Rows[i][0].ToString()))
                        {
                            this.cmbDepartamento.SelectedIndex = i;
                        }
                    }

                    //Elijo el inciso de la oficina seleccionada
                    for (int i = 0; i < dsIncisos.Tables["incisos"].Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dsOficinas.Tables["oficinas"].Rows[index][5].ToString()) == Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[i][0].ToString()))
                        {
                            this.cmbIncisos.SelectedIndex = i;
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.borrarErrores();

            if (nuevo)
            {
                this.nuevaOficina();
            }
            else
            {
                //   this.editarInciso();
            }
        }

        private void nuevaOficina()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.cmbIncisos.SelectedIndex == -1)
            {
                this.lblErrInciso.Visible = true;
                this.lblErrInciso.Text = "Campo obligatorio";
            }

            if (this.txtCodigo.Text.Trim() == "")
            {
                this.lblErrCodigo.Visible = true;
                this.lblErrCodigo.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombre.Text.Trim() == "")
            {
                this.lblErrNombre.Visible = true;
                this.lblErrNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtAbreviatura.Text.Trim() == "")
            {
                this.lblErrAbreviatura.Visible = true;
                this.lblErrAbreviatura.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtDireccion.Text.Trim() == "")
            {
                this.lblErrDireccion.Visible = true;
                this.lblErrDireccion.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtCodigoPostal.Text.Trim() == "")
            {
                this.lblErrCodigoPostal.Visible = true;
                this.lblErrCodigoPostal.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.cmbDepartamento.SelectedIndex == -1)
            {
                this.lblErrDepartamento.Visible = true;
                this.lblErrDepartamento.Text = "Campo obligatorio";
            }

            if (this.txtTelefono.Text.Trim() == "")
            {
                this.lblErrTelefono.Visible = true;
                this.lblErrTelefono.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtEmail.Text.Trim() == "")
            {
                this.lblErrMail.Visible = true;
                this.lblErrMail.Text = "Campo obligatorio";
                valido = false;
            }
            else
            {
                Regex regex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                if (!regex.IsMatch(txtEmail.Text))
                {
                    this.lblErrMail.Visible = true;
                    this.lblErrMail.Text = "Formato inválido";
                    valido = false;
                }
            }

            if (this.txtNombreContacto.Text.Trim() == "")
            {
                this.lblErrContacto.Visible = true;
                this.lblErrContacto.Text = "Campo obligatorio";
                valido = false;
            }

            if (valido)
            {
                try
                {
                    int id_inciso = Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[this.cmbIncisos.SelectedIndex][0].ToString());
                    int id_departamento = Convert.ToInt32(dsDepartamentos.Tables["departamentos"].Rows[this.cmbDepartamento.SelectedIndex][0].ToString());

                    empresa.AltaOficina(txtCodigo.Text, txtNombre.Text, txtAbreviatura.Text, txtDireccion.Text, id_inciso, id_departamento, txtCodigoPostal.Text, txtTelefono.Text, txtEmail.Text, txtNombreContacto.Text);

                    MessageBox.Show("Inciso creado correctamente");

                    //Cargo Incisos
                    dsOficinas = empresa.DevolverOficinas();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void borrarErrores()
        {
            this.lblErrAbreviatura.Visible = false;
            this.lblErrCodigo.Visible = false;
            this.lblErrContacto.Visible = false;
            this.lblErrDepartamento.Visible = false;
            this.lblErrDireccion.Visible = false;
            this.lblErrInciso.Visible = false;
            this.lblErrMail.Visible = false;
            this.lblErrNombre.Visible = false;
            this.lblErrCodigoPostal.Visible = false;
            this.lblErrTelefono.Visible = false;
            this.lblErrorGenerico.Visible = false;

            this.lblErrAbreviatura.Text = "";
            this.lblErrCodigo.Text = "";
            this.lblErrContacto.Text = "";
            this.lblErrDepartamento.Text = "";
            this.lblErrDireccion.Text = "";
            this.lblErrInciso.Text = "";
            this.lblErrMail.Text = "";
            this.lblErrNombre.Text = "";
            this.lblErrCodigoPostal.Text = "";
            this.lblErrTelefono.Text = "";
            this.lblErrorGenerico.Text = "";
        }
    }
}
