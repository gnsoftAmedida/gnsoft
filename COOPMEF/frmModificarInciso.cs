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
    public partial class frmMantenimientoInciso : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsIncisos;
        private bool nuevo = true;

        public frmMantenimientoInciso()
        {
            InitializeComponent();
        }

        private void btnCancelarPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMantenimientoInciso_Load(object sender, EventArgs e)
        {
            //Cargo Incisos
            dsIncisos = empresa.DevolverIncisos();
            pantallaInicial();
        }

        public void pantallaInicial()
        {
            this.cmbBusqueda.DataSource = dsIncisos.Tables["incisos"];
            this.cmbBusqueda.DisplayMember = "inciso_nombre";
            this.cmbBusqueda.ValueMember = "inciso_id";
            this.cmbBusqueda.SelectedIndex = -1;
            this.cmbBusqueda.Enabled = true;

            this.btnNuevoInciso.Enabled = true;

            this.txtCodigoInciso.Clear();
            this.txtCodigoInciso.Enabled = false;
            this.lblCodigo.Visible = false;

            this.txtNombreInciso.Clear();
            this.txtNombreInciso.Enabled = false;
            this.lblNombre.Visible = false;

            this.txtRefInciso.Clear();
            this.txtRefInciso.Enabled = false;
            this.lblAbreviatura.Visible = false;

            this.btnEliminarInciso.Enabled = false;
            this.btnEditarInciso.Enabled = false;
            this.btnGuardarInciso.Enabled = false;
            this.btnCancelarInciso.Enabled = false;

            this.lblErrorGenerico.Visible = false;
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbBusqueda.SelectedIndex;
            if (index != -1)
            {
                this.txtCodigoInciso.Enabled = false;
                this.txtNombreInciso.Enabled = false;
                this.txtRefInciso.Enabled = false;

                this.btnEliminarInciso.Enabled = true;
                this.btnEditarInciso.Enabled = true;
                this.btnGuardarInciso.Enabled = false;
                this.btnCancelarInciso.Enabled = true;

                this.txtCodigoInciso.Text = dsIncisos.Tables["incisos"].Rows[index][1].ToString();
                this.txtNombreInciso.Text = dsIncisos.Tables["incisos"].Rows[index][2].ToString();
                this.txtRefInciso.Text = dsIncisos.Tables["incisos"].Rows[index][3].ToString();
            }
        }

        private void btnNuevoSocio_Click(object sender, EventArgs e)
        {
            this.nuevo = true;

            this.cmbBusqueda.Enabled = false;
            this.cmbBusqueda.SelectedIndex = -1;

            this.txtCodigoInciso.Clear();
            this.txtCodigoInciso.Enabled = true;

            this.txtNombreInciso.Clear();
            this.txtNombreInciso.Enabled = true;

            this.txtRefInciso.Clear();
            this.txtRefInciso.Enabled = true;

            this.btnEditarInciso.Enabled = false;
            this.btnEliminarInciso.Enabled = false;
            this.btnCancelarInciso.Enabled = true;
            this.btnGuardarInciso.Enabled = true;
            this.lblErrorGenerico.Visible = false;

        }

        private void editarInciso()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.txtCodigoInciso.Text.Trim() == "")
            {
                this.lblCodigo.Visible = true;
                this.lblCodigo.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombreInciso.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtRefInciso.Text.Trim() == "")
            {
                this.lblAbreviatura.Visible = true;
                this.lblAbreviatura.Text = "Campo obligatorio";
                valido = false;
            }

            int index = this.cmbBusqueda.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsIncisos.Tables["incisos"].Rows.Count; i++)
            {
                if (Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString()) != Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[i][0].ToString()))
                {
                    if (this.txtCodigoInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][1].ToString())
                    {
                        this.lblCodigo.Visible = true;
                        this.lblCodigo.Text = "Ya exíste";
                        valido = false;
                    }

                    if (this.txtNombreInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][2].ToString())
                    {
                        this.lblNombre.Visible = true;
                        this.lblNombre.Text = "Ya exíste";
                        valido = false;
                    };

                    if (this.txtRefInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][3].ToString())
                    {
                        this.lblAbreviatura.Visible = true;
                        this.lblAbreviatura.Text = "Ya exíste";
                        valido = false;
                    };
                }
            }

            if (valido)
            {

                string message = "¿Está seguro de que desea modificar el Inciso?";
                string caption = "Modificar Inciso";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        empresa.modificarInciso(txtCodigoInciso.Text, txtNombreInciso.Text, txtRefInciso.Text, Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString()));

                        MessageBox.Show("Inciso modificado correctamente");

                        RegistroSLogs registroLogs = new RegistroSLogs();
                        registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Modificar Inciso " + this.txtNombreInciso.Text);

              

                        //Cargo Incisos
                        dsIncisos = empresa.DevolverIncisos();
                        pantallaInicial();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                }
            }
        }

        private void nuevoInciso()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.txtCodigoInciso.Text.Trim() == "")
            {
                this.lblCodigo.Visible = true;
                this.lblCodigo.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombreInciso.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtRefInciso.Text.Trim() == "")
            {
                this.lblAbreviatura.Visible = true;
                this.lblAbreviatura.Text = "Campo obligatorio";
                valido = false;
            }

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsIncisos.Tables["incisos"].Rows.Count; i++)
            {
                if (this.txtCodigoInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][1].ToString())
                {
                    this.lblCodigo.Visible = true;
                    this.lblCodigo.Text = "Ya exíste";
                    valido = false;
                }

                if (this.txtNombreInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][2].ToString())
                {
                    this.lblNombre.Visible = true;
                    this.lblNombre.Text = "Ya exíste";
                    valido = false;
                };

                if (this.txtRefInciso.Text.Trim() == dsIncisos.Tables["incisos"].Rows[i][3].ToString())
                {
                    this.lblAbreviatura.Visible = true;
                    this.lblAbreviatura.Text = "Ya exíste";
                    valido = false;
                };
            }

            if (valido)
            {
                try
                {
                    empresa.AltaInciso(txtCodigoInciso.Text, txtNombreInciso.Text, txtRefInciso.Text);

                    MessageBox.Show("Inciso creado correctamente");


                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Nuevo Inciso " + this.txtNombreInciso.Text);

                    //Cargo Incisos
                    dsIncisos = empresa.DevolverIncisos();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void btnGuardarSocio_Click(object sender, EventArgs e)
        {
            this.lblNombre.Text = "";
            this.lblNombre.Visible = false;

            this.lblCodigo.Text = "";
            this.lblCodigo.Visible = false;

            this.lblAbreviatura.Text = "";
            this.lblAbreviatura.Visible = false;

            this.lblErrorGenerico.Text = "";
            this.lblErrorGenerico.Visible = false;

            if (nuevo)
            {
                this.nuevoInciso();
            }
            else
            {
                this.editarInciso();
            }
        }

        private void btnEliminarInciso_Click(object sender, EventArgs e)
        {
            string message = "¿Está seguro de que desea eliminar al Inciso?";
            string caption = "Baja Inciso";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int index = this.cmbBusqueda.SelectedIndex;

                try
                {
                    empresa.bajaInciso(Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString()));

                    MessageBox.Show("Inciso eliminado correctamente");


                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Eliminar Inciso " + this.txtNombreInciso.Text);

                    //Cargo Incisos
                    dsIncisos = empresa.DevolverIncisos();
                    pantallaInicial();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void btnEditarInciso_Click(object sender, EventArgs e)
        {
            this.nuevo = false;

            this.cmbBusqueda.Enabled = false;

            this.txtCodigoInciso.Enabled = true;

            this.txtNombreInciso.Enabled = true;

            this.txtRefInciso.Enabled = true;

            this.btnNuevoInciso.Enabled = false;
            this.btnEditarInciso.Enabled = true;
            this.btnEliminarInciso.Enabled = false;
            this.btnCancelarInciso.Enabled = true;
            this.btnGuardarInciso.Enabled = true;
            this.lblErrorGenerico.Visible = false;
        }

        private void btnCancelarInciso_Click_1(object sender, EventArgs e)
        {
               this.pantallaInicial();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}
