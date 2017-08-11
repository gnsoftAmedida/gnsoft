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
    public partial class frmPrincipal : Form
    {
        private Controladora empresa = Controladora.Instance;
        private DataSet dsAccionesPermitidas;
        DataSet dsSocios;
        DataSet dsIncisos;
        DataSet dsOficinas;
        private bool nuevo = true;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tbcPestanas.SelectedIndex = 0;
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            tbcPestanas.SelectedIndex = 4;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemAgenda_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmAgenda"))
            {
                frmAgenda a = new frmAgenda();
                a.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void btnOtrosDatos_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Visible == true)
            {
                this.dataGridView3.Visible = false;
                this.btnOtrosDatos.Text = "  Ver más";
            }
            else
            {
                this.dataGridView3.Visible = true;
                this.btnOtrosDatos.Text = "     Ver menos";
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "¿Está seguro que desea salir de la aplicación?";
            string caption = "Gestión COOPMEF";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmAltaUsuario"))
            {
                frmAltaUsuario a = new frmAltaUsuario();
                a.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmBajaUsuario"))
            {
                frmSeleccionUsuario b = new frmSeleccionUsuario();
                b.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmModificarClaveUsuario"))
            {
                frmModificarClaveUsuario frmModificarClave = new frmModificarClaveUsuario(Utilidades.UsuarioLogueado.IdUsuario);
                frmModificarClave.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        public bool VerificarPermisosUsuario(string menuItemAccion)
        {
            foreach (DataRow accion in dsAccionesPermitidas.Tables["acciones"].Rows)
            {
                if (accion["accion_nombre"].ToString() == menuItemAccion)
                    return true;
            }
            return false;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dsAccionesPermitidas = empresa.DevolverAccionesXUsuario(Utilidades.UsuarioLogueado.IdUsuario);
            dsSocios = empresa.DevolverSocios();
            dsIncisos = empresa.DevolverIncisos();
            dsOficinas = empresa.DevolverOficinas();
            
            pantallaInicialSocio();
            desactivarAltaSocio();
        }

        private void desactivarAltaSocio() {
            this.txtNroSocio.Enabled = false;
            this.txtNombres.Enabled = false;
            this.txtApellidos.Enabled = false;
            this.txtNroCobro.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtEmail.Enabled = false;
            this.dtpFechaIng.Enabled = false;
            this.dtpFechaNac.Enabled = false;
            this.cmbEdad.Enabled = false;
            this.cmbOficina.Enabled = false;
            this.cmbInciso.Enabled = false;
            this.cmbEstadoCivil.Enabled = false;
        
        
        }

        private void activarAltaSocio()
        {
            this.txtNroSocio.Enabled = true;
            this.txtNombres.Enabled = true;
            this.txtApellidos.Enabled = true;
            this.txtNroCobro.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtEmail.Enabled = true;
            this.dtpFechaIng.Enabled = true;
            this.dtpFechaNac.Enabled = true;
            this.cmbEdad.Enabled = true;
            this.cmbOficina.Enabled = true;
            this.cmbInciso.Enabled = true;
            this.cmbEstadoCivil.Enabled = true;


        }
        private void resetearContraseñasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmResetearClaveUsuario"))
            {
                frmSeleccionUsuario frmResetClaveUsuario = new frmSeleccionUsuario(false);
                frmResetClaveUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmModificacionUsuario"))
            {
                frmSeleccionUsuario frmBajaUsuario = new frmSeleccionUsuario(true);
                frmBajaUsuario.ShowDialog();
                //Actualiza la lista de acciones permitidas del usuario
                dsAccionesPermitidas = empresa.DevolverAccionesXUsuario(Utilidades.UsuarioLogueado.IdUsuario);
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmConsultaLogs"))
            {
                frmConsultaLogs consulta = new frmConsultaLogs();
                consulta.Show();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VerificarPermisosUsuario("frmReporteEvento"))
            {
                frmReporteEventos frmReportes = new frmReporteEventos();
                frmReportes.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            }
        }

        private void frmPrincipal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            string message = "¿Está seguro que desea salir de la aplicación?";
            string caption = "COOPMEF";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            RegistroSLogs registroLogs = new RegistroSLogs();
            registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Cierre de Sesión");
        }

        private void tabEstado_Click(object sender, EventArgs e)
        {

        }

        private void tabSocio_Click(object sender, EventArgs e)
        {

        }

        private void btnVerMasSocio_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Visible == true)
            {
                this.dataGridView3.Visible = false;
                this.btnOtrosDatos.Text = "  Ver más";
            }
            else
            {
                this.dataGridView3.Visible = true;
                this.btnOtrosDatos.Text = "     Ver menos";
            }
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoPrestamo_Click_1(object sender, EventArgs e)
        {
            tbcPestanas.SelectedIndex = 4;
        }


        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoInciso incisoModEli = new frmMantenimientoInciso();
            incisoModEli.ShowDialog();
        }

        private void oficinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantOficinas mantOficina = new frmMantOficinas();
            mantOficina.ShowDialog();

        }

        private void incisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (VerificarPermisosUsuario("frmInciso"))
            {
                frmMantenimientoInciso minciso = new frmMantenimientoInciso();
                minciso.ShowDialog();
            }
            //else
            //{
            //    MessageBox.Show("Usted no tiene permisos para realizar esta acción");
            //}
        }

        private void planDePréstamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlanDePrestamo plan = new frmPlanDePrestamo();
            plan.Show();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirPlan_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnNuevoSocio_Click(object sender, EventArgs e)
        {
            activarAltaSocio();
            pantallaInicialSocio();
            this.nuevo = true;

        

            this.txtNroSocio.Clear();
            this.txtNroSocio.Enabled = true;

            this.txtNroCobro.Clear();
            this.txtNroCobro.Enabled = true;

            this.txtNombres.Clear();
            this.txtNombres.Enabled = true;

            this.txtApellidos.Clear();
            this.txtApellidos.Enabled = true;

            
            this.dtpFechaNac.Enabled = true;

            this.dtpFechaIng.Enabled = true;


            this.cmbEstadoCivil.Enabled = true;

            this.rbtnMasculino.Enabled = true;
            this.rbtnFemenino.Enabled = true;

            this.rBtnActivo.Enabled = true;
            this.rBtnPasivo.Enabled = true;

            
            this.cmbEdad.Enabled = true;

            
            this.cmbOficina.Enabled = true;
            this.cmbInciso.Enabled = true;


            this.txtTelefono.Clear();
            this.txtTelefono.Enabled = true;

            this.txtDireccion.Clear();
            this.txtDireccion.Enabled = true;

            this.txtEmail.Clear();
            this.txtEmail.Enabled = true;
            

            this.btnEditarSocio.Enabled = false;
            this.btnEliminarSocio.Enabled = false;
            this.btnVerMasSocio.Enabled = false;

            this.btnGuardarSocio.Enabled = true;
            this.btnSalir.Enabled = true;

            this.lblErrorGenerico.Visible = false;
        }

        private void pantallaInicialSocio() {
            this.lblNroCo.Visible = false;
            this.lblNombre.Visible = false;
            this.lblApellido.Visible = false;
            this.lblDir.Visible = false;
            this.lblEmail.Visible = false;
            this.lblErrorGenerico.Visible = false;
            this.lblReferenciaError.Visible = false;
            this.lblNroS.Visible = false;
            this.lblTel.Visible = false;
            lblYaExiste.Visible = false;
            lblYaExisteCobro.Visible = false;
            lblYaExisteMail.Visible = false;
            lblYaExisteSocio.Visible = false;
            lblYaExisteTel.Visible = false;
            //this.lblErrorEdad.Visible = false;
            //this.lblErrorOficina.Visible = false;
            //this.lblErrorInciso.Visible = false;


            for (int i = 18; i < 100; i++) this.cmbEdad.Items.Add(i);
            this.cmbEdad.SelectedIndex = 0;

            this.cmbEstadoCivil.Items.Add("Soltero/a");
            this.cmbEstadoCivil.Items.Add("Casado/a");
            this.cmbEstadoCivil.Items.Add("Divorciado/a");
            this.cmbEstadoCivil.Items.Add("Viudo/a");
            this.cmbEstadoCivil.SelectedIndex = 0;

            this.cmbInciso.DataSource = dsIncisos.Tables["incisos"];
            this.cmbInciso.DisplayMember = "inciso_abreviatura";
            this.cmbInciso.ValueMember = "inciso_id";
            this.cmbInciso.SelectedIndex = 0;
            this.cmbInciso.Enabled = true;

            this.cmbOficina.DataSource = dsOficinas.Tables["oficinas"];
            this.cmbOficina.DisplayMember = "oficina_abreviatura";
            this.cmbOficina.ValueMember = "oficina_id";
            this.cmbOficina.SelectedIndex = 0;
            this.cmbOficina.Enabled = true;

            this.rbtnMasculino.Checked = true;
            this.rbtnMasculino.Select();
        
        }

        private bool camposObligatoriosSocio() {
            bool valido = true;
            if (this.txtNroSocio.Text.Trim() == "")
            {
                this.lblNroS.Visible = true;
                this.lblNroS.Text = "*";
                valido = false;
            }

            if (this.txtNroCobro.Text.Trim() == "")
            {
                this.lblNroCo.Visible = true;
                this.lblNroCo.Text = "*";
                valido = false;
            }

            if (this.txtNombres.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "*";
                valido = false;
            }

            if (this.txtApellidos.Text.Trim() == "")
            {
                this.lblApellido.Visible = true;
                this.lblApellido.Text = "*";
                valido = false;
            }

            if (this.txtTelefono.Text.Trim() == "")
            {
                this.lblTel.Visible = true;
                this.lblTel.Text = "*";
                valido = false;
            }

            if (this.txtDireccion.Text.Trim() == "")
            {
                this.lblDir.Visible = true;
                this.lblDir.Text = "*";
                valido = false;
            }

            if (this.txtEmail.Text.Trim() == "")
            {
                this.lblEmail.Visible = true;
                this.lblEmail.Text = "*";
                valido = false;
            }
            this.lblReferenciaError.Text = "* Campo obligatorio";
            if (!valido) this.lblReferenciaError.Visible = true;

            return valido;
        }

        private bool controlSociosDuplicados() {
            bool valido = true;
            int f = dsSocios.Tables[0].Rows.Count;


            for (int i = 0; i < f; i++)
            {
                string numSocio = this.txtNroSocio.Text.Trim();
                string numSocioTable = dsSocios.Tables["socio"].Rows[i][3].ToString();
                if (numSocio == numSocioTable)
                {
                    this.lblYaExisteSocio.Visible = true;
                    this.lblYaExisteSocio.Text = "#";
                    valido = false;
                }

                if (this.txtNroCobro.Text.Trim() == dsSocios.Tables["socio"].Rows[i][4].ToString())
                {
                    this.lblYaExisteCobro.Visible = true;
                    this.lblYaExisteCobro.Text = "#";
                    valido = false;
                };

                if (this.txtTelefono.Text.Trim() == dsSocios.Tables["socio"].Rows[i][13].ToString())
                {
                    this.lblYaExisteTel.Visible = true;
                    this.lblYaExisteTel.Text = "#";
                    valido = false;
                };

                if (this.txtEmail.Text.Trim() == dsSocios.Tables["socio"].Rows[i][15].ToString())
                {
                    this.lblYaExisteMail.Visible = true;
                    this.lblYaExisteMail.Text = "#";
                    valido = false;
                };
                if (valido == false)
                {
                    lblYaExiste.Visible = true;
                    lblYaExiste.Text = "Error!! Ya existe";
                }
                else
                    lblYaExiste.Visible = false;
            }

            return valido;
        
        }

        private void nuevoSocio()
        {
            bool valido = true;
            pantallaInicialSocio();
           

            // Control de campos obligatorios 
            valido = camposObligatoriosSocio();
            
            // Control de duplicado para nroSocio, nroCobro, tel y mail de socio. Se hace en memoria y luego a nivel de BD
            //int index = this.cmbBusqueda.SelectedIndex;
            valido = controlSociosDuplicados();
            
            if (valido)
            {
                try
                {
                    string estadoCivil = this.cmbEstadoCivil.SelectedIndex.ToString();
                    char sexoo = 'F';
                    if (rbtnMasculino.Checked)
                        sexoo = 'M';
                    string estadoPoA = "Pasivo";
                    if (rBtnActivo.Checked)
                        estadoPoA = "Activo";

                    int edadd = Convert.ToInt32(this.cmbEdad.SelectedItem.ToString());
                    int socioNro = Convert.ToInt32(txtNroSocio.Text);
                    int nroCobro = Convert.ToInt32(txtNroCobro.Text);


                    DateTime fnac = Convert.ToDateTime(dtpFechaNac.Value);
                    DateTime fing = Convert.ToDateTime(dtpFechaIng.Value);
                     
                     int of = Convert.ToInt32(cmbOficina.SelectedValue);
                     int inc = Convert.ToInt32(cmbInciso.SelectedValue);

                    empresa.AltaSocio(socioNro, nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estadoCivil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text);

                    MessageBox.Show("Socio creado correctamente");

                    //Cargo Socios
                    dsSocios = empresa.DevolverSocios();
                    pantallaInicialSocio();
                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
            }
        }

        private void editarSocio()
        {
            bool valido = true;
            pantallaInicialSocio();


            // Control de campos obligatorios 
            valido = camposObligatoriosSocio();

            // Control de duplicado para nroSocio, nroCobro, tel y mail de socio. Se hace en memoria y luego a nivel de BD
            //int index = this.cmbBusqueda.SelectedIndex;
            valido = controlSociosDuplicados();

            if (valido)
            {
                try
                {
                    string estadoCivil = this.cmbEstadoCivil.SelectedIndex.ToString();
                    char sexoo = 'F';
                    if (rbtnMasculino.Checked)
                        sexoo = 'M';
                    string estadoPoA = "Pasivo";
                    if (rBtnActivo.Checked)
                        estadoPoA = "Activo";

                    int edadd = Convert.ToInt32(this.cmbEdad.SelectedItem.ToString());
                    int socioNro = Convert.ToInt32(txtNroSocio.Text);
                    int nroCobro = Convert.ToInt32(txtNroCobro.Text);


                    DateTime fnac = Convert.ToDateTime(dtpFechaNac.Value);
                    DateTime fing = Convert.ToDateTime(dtpFechaIng.Value);

                    int of = Convert.ToInt32(cmbOficina.SelectedValue);
                    int inc = Convert.ToInt32(cmbInciso.SelectedValue);

                    empresa.AltaSocio(socioNro, nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estadoCivil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text);

                    MessageBox.Show("Socio creado correctamente");

                    //Cargo Socios
                    dsSocios = empresa.DevolverSocios();
                    pantallaInicialSocio();
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
            if (nuevo)
            {
                this.nuevoSocio();
            }
            else
            {
                this.editarSocio();
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminarSocio_Click(object sender, EventArgs e)
        {
            int nroSocio = Convert.ToInt32(this.txtNroSocio.Text);

            
                string message = "¿Está seguro de que desea eliminar el socio?";
                string caption = "Eliminar Socio";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);



                if (result == System.Windows.Forms.DialogResult.Yes)
                {


                    try
                    {
                        empresa.bajaSocio(nroSocio);

                        MessageBox.Show("Socio eliminado correctamente");

                        //Cargo Planes
                        //dsPlanes = empresa.DevolverPlanes();
                        pantallaInicialSocio();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                }
            }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            int nroSocio = Convert.ToInt32(txtBusqueda.Text);
            empresa.buscarSocio(nroSocio);
        }

        
        }
    }

