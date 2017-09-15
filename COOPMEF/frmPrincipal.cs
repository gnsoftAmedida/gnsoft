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
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;


namespace COOPMEF
{
    public partial class frmPrincipal : Form
    {
        private Controladora empresa = Controladora.Instance;
        private DataSet dsAccionesPermitidas;
        DataSet dsSocios;
        DataSet dsPlanes;
        DataSet dsSociosPorCampo;
        DataSet dsIncisos;
        DataSet dsOficinas;
        private int idSocioSeleccionado = 0;
        private bool nuevo = true;
        private int edadDeRiesgo = 58;

        // ############################ VARIABLES PRESTAMO ############################
        int cantidadCuotas = 0;
        double tasaAnualEfectivaSinIVA = 0;
        double iva = 0;
        double totalDeuda = 0;
        double tasaConIva = 0;
        double cuota = 0;
        bool prestamoCorrecto;
        string nro_socio = "";
        //#############################################################################

        public frmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dsAccionesPermitidas = empresa.DevolverAccionesXUsuario(Utilidades.UsuarioLogueado.IdUsuario);

            dsSocios = empresa.DevolverSocios();

            dsIncisos = empresa.DevolverIncisos();

            cmbBusqueda.SelectedIndex = 0;

            pantallaInicialSocio();

            desactivarAltaSocio();

            // Trampa para generar columnas en el datagridview
            socioPorCampo("socio_nro", "A");
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



        private void desactivarAltaSocio()
        {
            this.txtNroSocio.Enabled = false;
            this.txtNombres.Enabled = false;
            this.txtApellidos.Enabled = false;
            this.txtNroCobro.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtEmail.Enabled = false;
            this.dtpFechaIng.Enabled = false;
            this.dtpFechaNac.Enabled = false;
            this.cmbOficina.Enabled = false;
            this.cmbInciso.Enabled = false;
            this.cmbEstadoCivil.Enabled = false;
            this.gBoxEstado.Enabled = false;
            this.gBoxSexo.Enabled = false;

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
            //this.cmbEdad.Enabled = true;
            this.cmbOficina.Enabled = true;
            this.cmbInciso.Enabled = true;
            this.cmbEstadoCivil.Enabled = true;
            this.gBoxEstado.Enabled = true;
            this.gBoxSexo.Enabled = true;
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

        private void btnVerMasSocio_Click(object sender, EventArgs e)
        {
            if (this.dataGridView3.Visible == true)
            {
                this.dataGridView3.Visible = false;
                this.btnVerMasSocio.Text = "  Ver más";
            }
            else
            {
                this.dataGridView3.Visible = true;
                this.btnVerMasSocio.Text = "     Ver menos";
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
            limpiarDatosGralesDeSocio();
            activarAltaSocio();
            //se agrega 31/8/2017
            lblEstadoActivo.Visible = true;
            lblEstadoDeBaja.Visible = false;
            //********

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


            //this.cmbEdad.Enabled = true;


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

        public void borrarErroresNuevoSocio()
        {
            lblErrorFechas.Visible = false;
            lblFechaIng.Visible = false;
            lblFechaNac.Visible = false;
            this.lblEmailFormatoInvalido.Visible = false;
            this.lblNroSocioFormatoInvalido.Visible = false;
            this.lblFormatoInvalido.Visible = false;
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
        }

        private void pantallaInicialSocio()
        {
            lblErrorFechas.Visible = false;
            lblFechaIng.Visible = false;
            lblFechaNac.Visible = false;
            this.lblNroSocioFormatoInvalido.Visible = false;
            this.lblEmailFormatoInvalido.Visible = false;
            this.lblFormatoInvalido.Visible = false;
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

            //for (int i = 18; i < 100; i++) this.cmbEdad.Items.Add(i);

            //this.cmbEdad.SelectedIndex = 0;

            this.cmbEstadoCivil.SelectedIndex = 0;

            this.cmbInciso.DataSource = dsIncisos.Tables["incisos"];
            this.cmbInciso.DisplayMember = "inciso_abreviatura";
            this.cmbInciso.ValueMember = "inciso_id";
            this.cmbInciso.Enabled = true;
            this.cmbInciso.SelectedIndex = 0;

            this.rbtnMasculino.Checked = true;
            this.rbtnMasculino.Select();

        }

        private bool camposObligatoriosSocio()
        {
            bool valido = true;

            if (this.txtNroSocio.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim() == "")
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

        private bool controlSociosDuplicados(int idSocio, string nroSocio, string nroCobro)
        {
            bool valido = true;
            int f = dsSocios.Tables[0].Rows.Count;

            for (int i = 0; valido == true && i < f; i++)
            {
                //Compruebo que no se esté comparando con el mismo

                if ((idSocio) != Convert.ToInt32(dsSocios.Tables["socio"].Rows[i][0].ToString()))
                {

                    string numSocioTable = dsSocios.Tables["socio"].Rows[i][3].ToString();
                    if (nroSocio == numSocioTable.Replace(",", "").Replace(".", "").Replace("-", "").Trim())
                    {
                        this.lblYaExisteSocio.Visible = true;
                        this.lblYaExisteSocio.Text = "#";
                        valido = false;
                    }

                    if (nroCobro == dsSocios.Tables["socio"].Rows[i][4].ToString())
                    {
                        this.lblYaExisteCobro.Visible = true;
                        this.lblYaExisteCobro.Text = "#";
                        valido = false;
                    };

                    if (valido == false)
                    {
                        lblYaExiste.Visible = true;
                        //lblYaExiste.Text = "Error!! Ya existe";
                    }
                    else
                        lblYaExiste.Visible = false;
                }

            }
            return valido;

        }

        public int EdadPersona(DateTime FechaNacimiento)
        {
            int age = DateTime.Today.Year - FechaNacimiento.Year;
            if (DateTime.Today.Month < FechaNacimiento.Month || (DateTime.Today.Month == FechaNacimiento.Month && DateTime.Today.Day < FechaNacimiento.Day))
                age--;
            return age;
        }

        private bool compararFechas(DateTime fnac, DateTime fing)
        {
            bool valido = true;
            int comparaFechaNacIng = fnac.Date.CompareTo(fing.Date); //1
            int comparaFechaToday = fnac.Date.CompareTo(DateTime.Today.Date); //-1
            int comparaFechaIngMenorHoy = fing.Date.CompareTo(DateTime.Today.Date); //-1

            /*menor que cero: si la primera fecha es menor que la segunda
                cero: si las dos fechas son iguales
             * mayor que cero: si la primera fecha es mayor que la segunda
             */

            if (comparaFechaNacIng >= 0)
            {
                lblFechaNac.Visible = true;
                lblErrorFechas.Visible = true;
                lblErrorFechas.Text = "Fecha de nac >= fecha ing";
                valido = false;
            }


            if (comparaFechaToday >= 0)
            {

                lblFechaIng.Visible = true;
                lblErrorFechas.Visible = true;
                lblErrorFechas.Text = "Fecha de nac >= fecha actual";
                valido = false;
            }

            if (comparaFechaIngMenorHoy > 0)
            {

                lblFechaIng.Visible = true;
                lblErrorFechas.Visible = true;
                lblErrorFechas.Text = "Fecha de ing > fecha actual";
                valido = false;
            }

            return valido;
        }

        private void actualizarDatosGeneralesDelSocio(string estadoCivil, int edadd)
        {
            this.lblNumeroSocio.Text = txtNroSocio.Text;
            this.lblNombreSocio.Text = txtNombres.Text;
            this.lblApellidosSocio.Text = txtApellidos.Text;
            this.lblFechaNacSocio.Text = dtpFechaNac.Value.ToShortDateString();
            this.lblFechaIngresoSocio.Text = dtpFechaIng.Value.ToShortDateString();
            this.lblEstadoCivilSocio.Text = estadoCivil.ToString();
            this.lblEdadSocio.Text = edadd.ToString();
            this.lblTelefonoSocio.Text = txtTelefono.Text;


        }

        private void nuevoSocio()
        {
            bool valido = false;
            bool obligatoriosOk = false;
            bool duplicadosOK = false;

            // si el id de socio es 0 es que se trata de un nuevo socio.
            int id_socio = 0;
            string nro_socio = this.txtNroSocio.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
            string nro_cobro = this.txtNroCobro.Text;

            borrarErroresNuevoSocio();

            // Control de campos obligatorios 
            obligatoriosOk = camposObligatoriosSocio();

            // Control de duplicado para nroSocio, nroCobro Se hace en memoria y luego a nivel de BD
            //int index = this.cmbBusqueda.SelectedIndex;
            duplicadosOK = controlSociosDuplicados(id_socio, nro_socio, nro_cobro);

            bool formatoCiOK = true;
            int resultado;

            if (int.TryParse(nro_socio, out resultado))
            {
                if (resultado.ToString().Length >= 7)
                {
                    if (!(empresa.validoCedula(resultado.ToString()).Equals(resultado.ToString().Substring(resultado.ToString().Length - 1, 1))))
                    {
                        formatoCiOK = false;
                    }
                }
                else
                {
                    formatoCiOK = false;
                }
            }
            else
            {
                formatoCiOK = false;
            }

            if (!(formatoCiOK))
            {
                this.lblNroSocioFormatoInvalido.Visible = true;
                this.lblFormatoInvalido.Visible = true;
            }

            bool formatoMailOK = true;
            Regex regex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (!regex.IsMatch(txtEmail.Text))
            {
                this.lblEmailFormatoInvalido.Visible = true;
                this.lblFormatoInvalido.Visible = true;
                //this.lblEmailFormatoInvalido.Text = "Formato inválido";
                formatoMailOK = false;
            }

            DateTime fnac = Convert.ToDateTime(dtpFechaNac.Value);
            DateTime fing = Convert.ToDateTime(dtpFechaIng.Value);
            bool fechasOK = compararFechas(fnac, fing);

            if (formatoCiOK && formatoMailOK && obligatoriosOk && duplicadosOK && fechasOK)
            {
                valido = true;
            }



            //****************
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
                    string socioNro = txtNroSocio.Text;
                    string nroCobro = txtNroCobro.Text;
                    int edadd = EdadPersona(fnac);
                    //lblEdadSocio.Text = edadd.ToString();
                    if (edadd > edadDeRiesgo)
                        lblEdadSocio.ForeColor = Color.Red;
                    else
                        lblEdadSocio.ForeColor = Color.Blue;

                    int of = Convert.ToInt32(cmbOficina.SelectedValue);
                    int inc = Convert.ToInt32(cmbInciso.SelectedValue);

                    // agregro estado_civil para que guarde el texto y no numeros en la BD
                    string estado_civil = cmbEstadoCivil.SelectedItem.ToString();


                    //si socioActivo = 1 el socio está activo, si es 0 no
                    int socioActivo = 1;

                    empresa.AltaSocio(socioActivo, socioNro, nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estado_civil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text);
                    //*******
                    actualizarDatosGeneralesDelSocio(estado_civil, edadd);
                    //******
                    MessageBox.Show("Socio creado correctamente");
                    desactivarAltaSocio();
                    borrarErroresNuevoSocio();


                    //Cargo Socios
                    dsSocios = empresa.DevolverSocios();

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

            if (this.idSocioSeleccionado != 0)
            {
                //bool valido = true;
                bool duplicadosOK = true;

                borrarErroresNuevoSocio();

                // Control de campos obligatorios 
                bool camposObligatoriosOK = camposObligatoriosSocio();

                // Control de duplicado para nroSocio, nroCobro, tel y mail de socio. Se hace en memoria y luego a nivel de BD
                //int index = this.cmbBusqueda.SelectedIndex;
                // OJOOOOOO  valido = controlSociosDuplicados();

                bool formatoMailOK = true;
                Regex regex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                if (!regex.IsMatch(txtEmail.Text))
                {
                    this.lblEmailFormatoInvalido.Visible = true;
                    this.lblFormatoInvalido.Visible = true;
                    //this.lblEmailFormatoInvalido.Text = "Formato inválido";
                    formatoMailOK = false;
                }

                string nro_socio = this.txtNroSocio.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();

                bool formatoCiOK = true;
                int resultado;

                if (int.TryParse(nro_socio, out resultado))
                {
                    if (resultado.ToString().Length >= 7)
                    {
                        if (!(empresa.validoCedula(resultado.ToString()).Equals(resultado.ToString().Substring(resultado.ToString().Length - 1, 1))))
                        {
                            formatoCiOK = false;
                        }
                    }
                    else
                    {
                        formatoCiOK = false;
                    }
                }
                else
                {
                    formatoCiOK = false;
                }

                if (!(formatoCiOK))
                {
                    this.lblNroSocioFormatoInvalido.Visible = true;
                    this.lblFormatoInvalido.Visible = true;
                    //valido = false;
                }

                int id_socio = this.idSocioSeleccionado;

                string nro_cobro = this.txtNroCobro.Text;

                duplicadosOK = controlSociosDuplicados(id_socio, nro_socio, nro_cobro);

                DateTime fnac = Convert.ToDateTime(dtpFechaNac.Value);
                DateTime fing = Convert.ToDateTime(dtpFechaIng.Value);
                bool fechasOK = compararFechas(fnac, fing);

                if (formatoMailOK && camposObligatoriosOK && formatoCiOK && duplicadosOK && fechasOK)
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

                        //int edaddeee = Convert.ToInt32(this.cmbEdad.SelectedItem.ToString());
                        string socioNro = txtNroSocio.Text;
                        string nroCobro = txtNroCobro.Text;
                        int edadd = EdadPersona(fnac);
                        lblEdadSocio.Text = edadd.ToString();
                        if (edadd > edadDeRiesgo) lblEdadSocio.ForeColor = Color.Red;
                        else lblEdadSocio.ForeColor = Color.Blue;

                        int of = Convert.ToInt32(cmbOficina.SelectedValue);
                        int inc = Convert.ToInt32(cmbInciso.SelectedValue);

                        // agregro estado_civil para que guarde el texto y no numeros en la BD
                        string estado_civil = cmbEstadoCivil.SelectedItem.ToString();

                        empresa.EditarSocio(this.idSocioSeleccionado, socioNro, nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estado_civil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text);


                        //*******

                        actualizarDatosGeneralesDelSocio(estado_civil, edadd);

                        //*****


                        MessageBox.Show("Socio modificado correctamente");

                        this.btnNuevoSocio.Enabled = true;

                        //Cargo Socios
                        dsSocios = empresa.DevolverSocios();
                        borrarErroresNuevoSocio();
                        desactivarAltaSocio();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                }
            }
            else
            {

                MessageBox.Show("Debe seleccionar un socio antes de intentar editarlo");
            }
        }

        private void dejarPantallaComoAlInicio()
        {
            pantallaInicialSocio();
            desactivarAltaSocio();

            this.btnEditarSocio.Enabled = true;
            this.btnEliminarSocio.Enabled = true;
            this.btnVerMasSocio.Enabled = true;
            this.btnNuevoSocio.Enabled = true;
            this.btnGuardarSocio.Enabled = true;
            this.btnSalir.Enabled = true;

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
            this.Close();
        }

        private void btnEliminarSocio_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado != 0)
            {

                int estadoActual = devolverEstadoSocio();
                nuevo = false;
                activarAltaSocio();
                this.btnNuevoSocio.Enabled = false;
                this.btnEditarSocio.Enabled = false;
                this.btnVerMasSocio.Enabled = false;

                this.btnGuardarSocio.Enabled = true;
                this.btnSalir.Enabled = true;

                this.lblErrorGenerico.Visible = false;
                string nroSocio = this.txtNroSocio.Text;


                string message = "¿Está seguro de que desea cambiar de estado al socio?";
                string caption = "Estado Socio";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);


                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {

                        empresa.bajaSocio(idSocioSeleccionado, ref estadoActual);
                        MessageBox.Show("Estado del socio actualizado correctamente");
                        cambiarEstado(estadoActual);
                        cambiarBotonBajaAlta(estadoActual);
                        desactivarAltaSocio();
                        btnEliminarSocio.Enabled = false;
                        btnGuardarSocio.Enabled = false;
                        //se agrega 31/8
                        btnCancelarSocio.Enabled = false;
                        this.btnNuevoSocio.Enabled = true;

                        //Cargo Planes
                        //dsPlanes = empresa.DevolverPlanes();
                        //pantallaInicialSocio();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un socio antes de darlo de baja");
            }

        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.buscarCampo();
        }


        private void buscarCampo()
        {

            String campo = "";

            if (this.txtBusqueda.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un valor de búsqueda");
            }
            else
            {

                if (this.cmbBusqueda.SelectedItem.ToString() == "Documento")
                {
                    campo = "socio_nro";
                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Apellido")
                {
                    campo = "socio_apellido";
                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Nombre")
                {
                    campo = "socio_nombre";
                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Dirección")
                {
                    campo = "socio_direccion";
                }

                string valor = this.txtBusqueda.Text;

                socioPorCampo(campo.Replace(",", "").Replace(".", "").Replace("-", "").Trim(), valor);
            }
        }

        private void socioPorCampo(string campo, string valor)
        {

            dsSociosPorCampo = empresa.buscarSociosPorCampo(campo, valor);


            dgvSociosCampo.DataSource = dsSociosPorCampo.Tables["socios"];

            dgvSociosCampo.RowHeadersVisible = false;
            dgvSociosCampo.ReadOnly = true;
            dgvSociosCampo.MultiSelect = false;
            dgvSociosCampo.ReadOnly = true;
            dgvSociosCampo.AllowDrop = false;
            dgvSociosCampo.AllowUserToAddRows = false;
            dgvSociosCampo.AllowUserToDeleteRows = false;
            dgvSociosCampo.AllowUserToResizeColumns = false;
            dgvSociosCampo.AllowUserToResizeRows = false;
            dgvSociosCampo.AllowUserToOrderColumns = false;
            dgvSociosCampo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSociosCampo.BackgroundColor = BackColor;
            dgvSociosCampo.BorderStyle = BorderStyle.None;


            dgvSociosCampo.Columns["socio_id"].Visible = false;
            dgvSociosCampo.Columns["socio_oficinaId"].Visible = false;
            dgvSociosCampo.Columns["socio_IncisoId"].Visible = false;
            dgvSociosCampo.Columns["socio_fechaNac"].Visible = false;
            dgvSociosCampo.Columns["socio_estadoCivil"].Visible = false;
            dgvSociosCampo.Columns["socio_sexo"].Visible = false;
            dgvSociosCampo.Columns["socio_email"].Visible = false;
            dgvSociosCampo.Columns["socio_estado"].Visible = false;
            dgvSociosCampo.Columns["socio_nroCobro"].Visible = false;
            dgvSociosCampo.Columns["socio_direccion"].Visible = false;
            dgvSociosCampo.Columns["socio_edad"].Visible = false;
            dgvSociosCampo.Columns["socio_activo"].Visible = false;
            dgvSociosCampo.Columns["socio_tel"].Visible = false;

            dgvSociosCampo.Columns["socio_nro"].HeaderText = "Documento";
            dgvSociosCampo.Columns["socio_nro"].Width = 85;

            dgvSociosCampo.Columns["socio_nombre"].HeaderText = "Nombre";
            dgvSociosCampo.Columns["socio_nombre"].Width = 180;

            dgvSociosCampo.Columns["socio_apellido"].HeaderText = "Apellido";
            dgvSociosCampo.Columns["socio_apellido"].Width = 180;

            dgvSociosCampo.Columns["socio_nroCobro"].HeaderText = "Nro Cobro";
            dgvSociosCampo.Columns["socio_nroCobro"].Width = 100;

            dgvSociosCampo.Columns["socio_fechaNac"].HeaderText = "Fecha Nacimiento";
            dgvSociosCampo.Columns["socio_fechaNac"].Width = 100;

            dgvSociosCampo.Columns["socio_fechaIngreso"].HeaderText = "Ingreso";
            dgvSociosCampo.Columns["socio_fechaIngreso"].Width = 100;

            dgvSociosCampo.Columns["socio_estadoCivil"].HeaderText = "Estado Civil";
            dgvSociosCampo.Columns["socio_estadoCivil"].Width = 100;

            dgvSociosCampo.Columns["socio_sexo"].HeaderText = "Sexo";
            dgvSociosCampo.Columns["socio_sexo"].Width = 100;

            dgvSociosCampo.Columns["socio_estado"].HeaderText = "Estado";
            dgvSociosCampo.Columns["socio_estado"].Width = 100;

            dgvSociosCampo.Columns["socio_edad"].HeaderText = "Edad";
            dgvSociosCampo.Columns["socio_edad"].Width = 100;

            dgvSociosCampo.Columns["socio_tel"].HeaderText = "Teléfono";
            dgvSociosCampo.Columns["socio_tel"].Width = 100;

            dgvSociosCampo.Columns["socio_direccion"].HeaderText = "Dirección";
            dgvSociosCampo.Columns["socio_direccion"].Width = 100;

            dgvSociosCampo.Columns["socio_email"].HeaderText = "Email";
            dgvSociosCampo.Columns["socio_email"].Width = 100;

            dgvSociosCampo.Columns["oficina_codigo"].HeaderText = "Oficina";
            dgvSociosCampo.Columns["oficina_codigo"].Width = 50;

            dgvSociosCampo.Columns["inciso_codigo"].HeaderText = "Inciso";
            dgvSociosCampo.Columns["inciso_codigo"].Width = 50;

            dgvSociosCampo.Columns["socio_activo"].HeaderText = "De baja";
            dgvSociosCampo.Columns["socio_activo"].Width = 50;

            this.EstablecerColoresNotificaciones();

            tbcPestanas.SelectedTab = tbcPestanas.TabPages[0];
        }

        public void EstablecerColoresNotificaciones()
        {
            foreach (DataGridViewRow fila in dgvSociosCampo.Rows)
            {
                int activo = (int)fila.Cells["socio_activo"].Value;

                if (activo == 0)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

        }

        public int devolverEstadoSocio()
        {
            //int esta = 0;
            int index = dgvSociosCampo.CurrentRow.Index;
            int esta = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;


            return esta;
        }

        private void cmbSocios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarSocio_Click(object sender, EventArgs e)
        {
            nuevo = false;
            activarAltaSocio();
            this.btnNuevoSocio.Enabled = false;
            this.btnEliminarSocio.Enabled = false;
            this.btnVerMasSocio.Enabled = false;

            this.btnGuardarSocio.Enabled = true;
            this.btnSalir.Enabled = true;
            this.btnCancelarSocio.Enabled = true;

            this.lblErrorGenerico.Visible = false;

        }

        private void btnCancelarSocio_Click(object sender, EventArgs e)
        {
            if (!(dgvSociosCampo.CurrentRow == null))
            {
                seleccionarSocioYllenarDataGrid();
                //btnNuevoSocio.Enabled = true;
            }
            else
            {
                pantallaInicialSocio();
                btnNuevoSocio.Enabled = true;
            }

            activarAltaSocio();
            //this.btnNuevoSocio.Enabled = true;
            //this.btnEditarSocio.Enabled = true;
            //this.btnVerMasSocio.Enabled = true;
            //this.btnEliminarSocio.Enabled = true;
        }

        private void seleccionarSocio()
        {
            int index = dgvSociosCampo.CurrentRow.Index;
            int idSocio = (int)dgvSociosCampo.Rows[index].Cells["socio_id"].Value;

            this.idSocioSeleccionado = idSocio;

            if (index != -1)
            {

                lblNumeroSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_nro"].Value.ToString();
                lblNombreSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_nombre"].Value.ToString();
                lblApellidosSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_apellido"].Value.ToString();
                lblFechaNacSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaNac"].Value.ToString();
                lblFechaIngresoSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaIngreso"].Value.ToString();
                lblEstadoCivilSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_estadoCivil"].Value.ToString();
                lblEdadSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_edad"].Value.ToString();
                lblTelefonoSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_tel"].Value.ToString();

                this.txtNombres.Text = dgvSociosCampo.Rows[index].Cells["socio_nombre"].Value.ToString();
                this.txtApellidos.Text = dgvSociosCampo.Rows[index].Cells["socio_apellido"].Value.ToString();
                this.txtNroSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_nro"].Value.ToString();
                this.txtNroCobro.Text = dgvSociosCampo.Rows[index].Cells["socio_nroCobro"].Value.ToString();
                this.dtpFechaNac.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaNac"].Value.ToString();
                this.dtpFechaIng.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaIngreso"].Value.ToString();
                this.cmbEstadoCivil.Text = dgvSociosCampo.Rows[index].Cells["socio_estadoCivil"].Value.ToString();


                if (dgvSociosCampo.Rows[index].Cells["socio_estado"].Value.Equals(0))
                    rBtnActivo.Checked = true;
                else rBtnPasivo.Checked = true;

                if (dgvSociosCampo.Rows[index].Cells["socio_sexo"].Value.ToString().Equals("M"))
                    rbtnMasculino.Checked = true;
                else rbtnFemenino.Checked = true;

                //this.cmbEdad.Text = dgvSociosCampo.Rows[index].Cells["socio_edad"].Value.ToString();
                int edad = (int)dgvSociosCampo.Rows[index].Cells["socio_edad"].Value;
                if (edad > edadDeRiesgo) lblEdadSocio.ForeColor = Color.Red;
                else lblEdadSocio.ForeColor = Color.Blue;
                this.lblEdadSocio.Text = edad.ToString();

                for (int i = 0; i < dsIncisos.Tables["incisos"].Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvSociosCampo.Rows[index].Cells["socio_incisoId"].Value.ToString()) == Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[i][0].ToString()))
                    {
                        this.cmbInciso.SelectedIndex = i;
                    }

                }

                /*          for (int i = 0; i < dsOficinas.Tables["oficinas"].Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvSociosCampo.Rows[index].Cells["socio_oficinaId"].Value.ToString()) == Convert.ToInt32(dsOficinas.Tables["oficinas"].Rows[i][0].ToString()))
                    {
                        this.cmbOficina.SelectedIndex = i;
                    }

                }
*/


                this.txtTelefono.Text = dgvSociosCampo.Rows[index].Cells["socio_tel"].Value.ToString();
                this.txtDireccion.Text = dgvSociosCampo.Rows[index].Cells["socio_direccion"].Value.ToString();
                this.txtEmail.Text = dgvSociosCampo.Rows[index].Cells["socio_email"].Value.ToString();
            }
            tbcPestanas.SelectedTab = tbcPestanas.TabPages[1];

        }

        private void cambiarEstado(int estado)
        {
            if (estado == 1)
            {
                lblEstadoActivo.Visible = true;
                lblEstadoDeBaja.Visible = false;

            }
            else
            {
                lblEstadoActivo.Visible = false;
                lblEstadoDeBaja.Visible = true;

            }

        }

        private void definirEstado(int estado)
        {
            if (estado == 1)
            {
                lblEstadoActivo.Visible = true;
                lblEstadoDeBaja.Visible = false;

            }
            else
            {
                lblEstadoActivo.Visible = false;
                lblEstadoDeBaja.Visible = true;

            }

        }

        private int definirEstado()
        {
            int estado = devolverEstadoSocio();
            if (estado == 1)
            {
                lblEstadoActivo.Visible = true;
                lblEstadoDeBaja.Visible = false;

            }
            else
            {
                lblEstadoActivo.Visible = false;
                lblEstadoDeBaja.Visible = true;

            }
            return estado;

        }

        private void cambiarBotonBajaAlta(int estado)
        {
            if (estado == 1)
                this.btnEliminarSocio.Text = "Baja";
            else
                this.btnEliminarSocio.Text = "Alta";

        }

        private void cargarDatosGralesDesdeDataGrid()
        {
            int index = dgvSociosCampo.CurrentRow.Index;
            //int index = 0;
            if (index != -1)
            {

                lblNumeroSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_nro"].Value.ToString();
                lblNombreSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_nombre"].Value.ToString();
                lblApellidosSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_apellido"].Value.ToString();
                lblFechaNacSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaNac"].Value.ToString();
                lblFechaIngresoSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaIngreso"].Value.ToString();
                lblEstadoCivilSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_estadoCivil"].Value.ToString();
                lblEdadSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_edad"].Value.ToString();
                lblTelefonoSocio.Text = dgvSociosCampo.Rows[index].Cells["socio_tel"].Value.ToString();
            }

        }

        private void limpiarDatosGralesDeSocio()
        {
            lblNumeroSocio.Text = "";
            lblNombreSocio.Text = "";
            lblApellidosSocio.Text = "";
            lblFechaNacSocio.Text = "";
            lblFechaIngresoSocio.Text = "";
            lblEstadoCivilSocio.Text = "";
            lblEdadSocio.Text = "";
            lblTelefonoSocio.Text = "";


        }

        private void seleccionarSocioYllenarDataGrid()
        {
            if (!(dgvSociosCampo.CurrentRow == null))
            {
                seleccionarSocio();
                //int index = dgvSociosCampo.CurrentRow.Index;
                //int estadoActual = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;
                //cambiarBotonBajaAlta(estadoActual);


            }

            int index = dgvSociosCampo.CurrentRow.Index;
            int estadoActual = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;


            //int estadoActual = definirEstado();
            //dejarPantallaComoAlInicio();
            desactivarAltaSocio();
            cambiarBotonBajaAlta(estadoActual);
            definirEstado();
            borrarErroresNuevoSocio();
            this.btnEditarSocio.Enabled = true;
            this.btnEliminarSocio.Enabled = true;
            this.btnVerMasSocio.Enabled = true;
            this.btnCancelarSocio.Enabled = true;



        }

        private void btnSeleccionarSocio_Click(object sender, EventArgs e)
        {

            seleccionarSocioYllenarDataGrid();
            //if (!(dgvSociosCampo.CurrentRow == null))
            //{
            //    seleccionarSocio();


            //}

            //int index = dgvSociosCampo.CurrentRow.Index;
            //int estadoActual = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;


            ////int estadoActual = definirEstado();
            ////dejarPantallaComoAlInicio();
            //desactivarAltaSocio();
            //cambiarBotonBajaAlta(estadoActual);
            //definirEstado();
            //borrarErroresNuevoSocio();
            //this.btnEditarSocio.Enabled = true;
            //this.btnEliminarSocio.Enabled = true;
            //this.btnVerMasSocio.Enabled = true;
            //this.btnCancelarSocio.Enabled = true;

        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            lblNumeroSocio.Text = "...";
            lblNombreSocio.Text = "...";
            lblApellidosSocio.Text = "...";
            lblFechaNacSocio.Text = "...";
            lblFechaIngresoSocio.Text = "...";
            lblEstadoCivilSocio.Text = "...";
            lblEdadSocio.Text = "...";
            lblTelefonoSocio.Text = "...";

            // Trampa para generar columnas en el datagridview
            socioPorCampo("socio_nro", "-1");

        }

        private void cmbInciso_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsOficinasDelInciso = null;
            int index = this.cmbInciso.SelectedIndex;
            int idInciso = Convert.ToInt32(dsIncisos.Tables["incisos"].Rows[index][0].ToString());

            dsOficinasDelInciso = empresa.DevolverOficinasPorInciso(idInciso);

            if (dsOficinasDelInciso.Tables["oficinas"].Rows.Count > 0)
            {
                this.cmbOficina.DataSource = dsOficinasDelInciso.Tables["oficinas"];
                this.cmbOficina.DisplayMember = "oficina_abreviatura";
                this.cmbOficina.ValueMember = "oficina_id";
                this.cmbOficina.Enabled = true;
            }
            else
            {
                this.cmbOficina.DataSource = null;
                this.cmbOficina.Items.Clear();
                this.cmbOficina.Refresh();
            }
        }

        private void dgvSociosCampo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.EstablecerColoresNotificaciones();
        }

        private void btnGuardarPrestamo_Click(object sender, EventArgs e)
        {
            if (!(idSocioSeleccionado == 0))
            {
                if (prestamoCorrecto)
                {
                    Socio tmpSocio = new Socio();
                    tmpSocio.Socio_id = this.idSocioSeleccionado;

                    double amortizacionVencer = empresa.AmortVencer(tasaConIva, cantidadCuotas, 0, cuota);

                    double interesesVencer = empresa.IntVencer(cuota, cantidadCuotas, 0, amortizacionVencer);

                    //(Socio.Socio_id,  Socio_nro, Fecha, Hora, Monteopedido, Tasa,Cantidadcuotas, Importecuota, NumeroPrestamoAnt, MontopedidoAnt, AmortizacionVencer, InteresesVencer, CuotasPactadas, CuotasPagadas, CuotaAnt, Tasaanterior, Anulado);
                    empresa.AltaPrestamo(tmpSocio, nro_socio, DateTime.Now, DateTime.Now, totalDeuda, tasaConIva, cantidadCuotas, cuota, 0, 0, amortizacionVencer, interesesVencer, cantidadCuotas, 0, 0, 0, 0);

                    MessageBox.Show("Préstamo Ingresado Correctamente");

                }
                else
                {
                    MessageBox.Show("Verifique el monto solicitado para poder hacer el préstamo");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un socio");
            }
        }


        public void cargarPlanPrestamos(object sender, EventArgs e)
        {

            //Cargar combo préstamos
            dsPlanes = empresa.DevolverPlanesActivos();
            this.cmbPlanPréstamo.DataSource = dsPlanes.Tables["planprestamo"];
            this.cmbPlanPréstamo.DisplayMember = "plan_nombre";
            this.cmbPlanPréstamo.ValueMember = "plan_id";
        }

        private void dgvSociosCampo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosGralesDesdeDataGrid();
        }

        private void CalcularImporteCuota()
        {
            if (!(txtNuevoImporte.Text.Trim() == ""))
            {
                if (esDecimal(txtNuevoImporte.Text.Replace(".", ",")))
                {
                    int index = this.cmbPlanPréstamo.SelectedIndex;
                    int idPrestamo = Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString());


                    for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
                    {
                        if (idPrestamo == Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][0].ToString()))
                        {
                            cantidadCuotas = Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][1].ToString());
                            tasaAnualEfectivaSinIVA = Convert.ToDouble(dsPlanes.Tables["planprestamo"].Rows[i][2].ToString());
                            iva = Convert.ToDouble(dsPlanes.Tables["planprestamo"].Rows[i][3].ToString());
                        }
                    }

                    for (int i = 0; i < dsSociosPorCampo.Tables["socios"].Rows.Count; i++)
                    {
                        if (this.idSocioSeleccionado == Convert.ToInt32(dsSociosPorCampo.Tables["socios"].Rows[i][0].ToString()))
                        {
                            nro_socio = dsSociosPorCampo.Tables["socios"].Rows[i][2].ToString();
                        }
                    }


                    tasaConIva = empresa.agregarleIvaAtasaAnual(tasaAnualEfectivaSinIVA, iva);

                    txtTotalDeuda.Text = txtNuevoImporte.Text;

                    totalDeuda = Convert.ToDouble(txtTotalDeuda.Text.Replace(".", ","));

                    cuota = empresa.Cuota(tasaConIva, cantidadCuotas, totalDeuda);

                    txtImporteCuota.Text = cuota.ToString();

                    prestamoCorrecto = true;


                }
                else
                {
                    txtImporteCuota.Text = "0.00";
                    txtTotalDeuda.Text = "0.00";
                    cantidadCuotas = 0;
                    tasaAnualEfectivaSinIVA = 0;
                    iva = 0;
                    totalDeuda = 0;
                    tasaConIva = 0;
                    cuota = 0;
                    prestamoCorrecto = false;
                    nro_socio = "";
                }
            }
        }


        public bool esDecimal(string nroPrueba)
        {
            double resultado = 0;
            Boolean esDouble = double.TryParse(nroPrueba, out resultado);

            Boolean esPositivo = false;

            if (esDouble)
            {

                if (resultado > 0)
                {
                    esPositivo = true;
                }
            }

            return esDouble && esPositivo;
        }

        private void cmbPlanPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularImporteCuota();
        }

        private void txtNuevoImporte_Leave(object sender, EventArgs e)
        {
            CalcularImporteCuota();
        }
    }
}


