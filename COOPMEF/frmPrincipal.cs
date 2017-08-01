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
            dsSocios = empresa.DevolverSocios();//************************
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
            this.nuevo = true;

           

            this.txtNroSocio.Clear();
            this.txtNroSocio.Enabled = true;

            this.txtNroCobro.Clear();
            this.txtNroCobro.Enabled = true;

            this.txtNombres.Clear();
            this.txtNombres.Enabled = true;

            this.txtApellidos.Clear();
            this.txtApellidos.Enabled = true;

            
            this.dtpFechaNacimiento.Enabled = true;

            this.dtpFechaIngreso.Enabled = true;


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

            //this.lblErrorGenerico.Visible = false;
        }

        private void nuevoSocio()
        {
            bool valido = true;

            // Control de campos obligatorios 
            if (this.txtNroSocio.Text.Trim() == "")
            {
                this.lblNroS.Visible = true;
                this.lblNroS.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNroCobro.Text.Trim() == "")
            {
                this.lblNroDeCobro.Visible = true;
                this.lblNroDeCobro.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombres.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtNombres.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtApellidos.Text.Trim() == "")
            {
                this.lblApellido.Visible = true;
                this.lblApellido.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtTelefono.Text.Trim() == "")
            {
                this.lblTel.Visible = true;
                this.lblTel.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtDireccion.Text.Trim() == "")
            {
                this.lblDir.Visible = true;
                this.lblDir.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtEmail.Text.Trim() == "")
            {
                this.lblEmail.Visible = true;
                this.lblEmail.Text = "Campo obligatorio";
                valido = false;
            }
            /*
            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            //int filas = dsSocios.Tables["socios"].Rows.Count;
            int f = dsSocios.Tables[0].Rows.Count;
            //int f = dsSocios.Tables["incisos"].Rows.Count;
            for (int i = 0; i < f ; i++)
            {
                if (this.txtNroSocio.Text.Trim() == dsSocios.Tables["socios"].Rows[i][3].ToString())
                {
                    this.lblNroS.Visible = true;
                    this.lblNroS.Text = "Ya exíste";
                    valido = false;
                }
                
                if (this.txtNroDeCobro.Text.Trim() == dsSocios.Tables["socios"].Rows[i][4].ToString())
                {
                    this.lblNroDeCobro.Visible = true;
                    this.lblNroDeCobro.Text = "Ya existe ese Nro";
                    valido = false;
                };

                if (this.txtTelefono.Text.Trim() == dsSocios.Tables["socios"].Rows[i][13].ToString())
                {
                    this.lblTel.Visible = true;
                    this.lblTel.Text = "Ya exíste ese tel";
                    valido = false;
                };

                if (this.txtEmail.Text.Trim() == dsSocios.Tables["socios"].Rows[i][15].ToString())
                {
                    this.lblEmail.Visible = true;
                    this.lblEmail.Text = "Ya exíste ese Email";
                    valido = false;
                };
            }
            */
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

                    int edadd = Convert.ToInt32(this.cmbEdad.SelectedValue);
                    int socioNro = Convert.ToInt32(txtNroSocio.Text);
                    int nroCobro = Convert.ToInt32(txtNroCobro.Text);

                    //DateTime fnac = dtpFechaNacimiento.Value;
                    //DateTime fing = dtpFechaIngreso.Value;

                    DateTime fnac = Convert.ToDateTime(dtpFechaNac.Value);
                    DateTime fing = Convert.ToDateTime(dtpFechaIng.Value);



                    /*OJOOOOOOOOO  ESTÁ HARDCODEEEEEEEEEEEEEEEEEEEEEEEEEE
                     * 
                     * int of = cmbOficina.SelectedIndex;
                    int inc = cmbInciso.SelectedIndex;
                    */
                     int of = 1;
                    int inc = 1;
                    

                    empresa.AltaSocio(socioNro, nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estadoCivil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text);

                    MessageBox.Show("Socio creado correctamente");

                    //Cargo Socios
                    dsSocios = empresa.DevolverSocios();
                    //pantallaInicial();
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
                //this.editarInciso();
            }
        }
    }
}
