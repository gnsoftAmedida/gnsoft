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
using COOPMEF.CrystalDataSets;
using System.Data;
using System.Collections;

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
        private bool estaVaciaDataGrid = true; // variable para que al hacer clic en el datagrid sin hacer una búsqueda antes, no se caiga.

        // ############################ VARIABLES PRESTAMO ############################
        int cantidadCuotas = 0;
        double ivaSobreIntereses = 0;
        double tasaAnualEfectivaSinIVA = 0;
        double iva = 0;
        double totalDeuda = 0;
        double tasaConIva = 0;
        double cuota = 0;
        bool prestamoCorrecto;
        string nro_socio = "";
        DataSet dsPrestamoActivo;
        double cuotaAnteriorPrestamo;
        double tasaAnteriorPrestamo;
        int nro_prestamoAnterior;
        double montoAnterior;
        bool excedido;
        bool exitiaProvisoria;
        int id_cobranzaProvisoria;
        //#############################################################################

        private System.Data.DataSet eventosDataSet;
        private dsSolicitu DE = new dsSolicitu();
        private dsVale DV = new dsVale();
        private dsExcedidos DEx = new dsExcedidos();

        double tmpMora = 0;
        double tmpSaldo = 0;

        public frmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cargarIncisosOficinas()
        {
            dsIncisos = empresa.DevolverIncisos();
            dsOficinas = empresa.DevolverOficinas();

            this.cmbInciso.DataSource = dsIncisos.Tables["incisos"];
            this.cmbInciso.DisplayMember = "inciso_abreviatura";
            this.cmbInciso.ValueMember = "inciso_id";
            this.cmbInciso.Enabled = true;
            this.cmbInciso.SelectedIndex = 0;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dsAccionesPermitidas = empresa.DevolverAccionesXUsuario(Utilidades.UsuarioLogueado.IdUsuario);

            cargarIncisosOficinas();

            dsSocios = empresa.DevolverSocios();

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
            this.txtMostrarDetalles.ReadOnly = true;
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
            this.txtMostrarDetalles.ReadOnly = false;

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
            verDetalles();
        }

        private void verDetalles()
        {
            if (this.txtMostrarDetalles.Visible == true)
            {
                this.txtMostrarDetalles.Visible = false;
                this.btnVerMasSocio.Text = "  Ver más";
            }
            else
            {
                this.txtMostrarDetalles.Visible = true;
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
            cargarIncisosOficinas();

        }

        private void incisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (VerificarPermisosUsuario("frmInciso"))
            {
                frmMantenimientoInciso minciso = new frmMantenimientoInciso();
                minciso.ShowDialog();
                cargarIncisosOficinas();
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

        private void borrarTextNuevoSocio()
        {
            this.txtNroSocio.Clear();
            this.txtNroCobro.Clear();
            this.txtNombres.Clear();
            this.txtApellidos.Clear();
            this.txtTelefono.Clear();
            this.txtDireccion.Clear();
            this.txtEmail.Clear();
            this.txtMostrarDetalles.Clear();
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


            borrarTextNuevoSocio();


            this.txtNroSocio.Enabled = true;
            this.txtNroCobro.Enabled = true;
            this.txtNombres.Enabled = true;
            this.txtApellidos.Enabled = true;
            this.dtpFechaNac.Enabled = true;
            this.dtpFechaIng.Enabled = true;
            this.cmbEstadoCivil.Enabled = true;
            this.rbtnMasculino.Enabled = true;
            this.rbtnFemenino.Enabled = true;
            this.rBtnActivo.Enabled = true;
            this.rBtnPasivo.Enabled = true;
            this.cmbOficina.Enabled = true;
            this.cmbInciso.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtEmail.Enabled = true;
            this.btnEditarSocio.Enabled = false;
            this.btnEliminarSocio.Enabled = false;
            this.btnVerMasSocio.Enabled = true;
            this.btnGuardarSocio.Enabled = true;
            this.btnCancelarSocio.Enabled = true;
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

            lblEstadoActivo.Visible = false;
            lblEstadoDeBaja.Visible = false;

            //for (int i = 18; i < 100; i++) this.cmbEdad.Items.Add(i);

            //this.cmbEdad.SelectedIndex = 0;

            this.cmbEstadoCivil.SelectedIndex = 0;

            this.rbtnMasculino.Checked = true;
            this.rbtnMasculino.Select();
            //////////////////
            //  txtIncisoCobExcedidos.Text = cmbInciso.SelectedItem.ToString(); 

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
            //  string nro_socio = this.txtNroSocio.Text.Replace(",", "").Replace(".", "").Replace("-", "").Trim();
            string nro_socio = this.txtNroSocio.Text;
            string nro_cobro = this.txtNroCobro.Text;

            borrarErroresNuevoSocio();

            // Control de campos obligatorios 
            obligatoriosOk = camposObligatoriosSocio();

            // Control de duplicado para nroSocio, nroCobro Se hace en memoria y luego a nivel de BD
            //int index = this.cmbBusqueda.SelectedIndex;
            duplicadosOK = controlSociosDuplicados(id_socio, nro_socio, nro_cobro);

            bool formatoCiOK = true;
            int resultado;

            if (int.TryParse(nro_socio.Replace(".", "").Replace(",", "").Replace("-", ""), out resultado))
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

                    empresa.AltaSocio(socioActivo, socioNro.Replace(",", ".").Trim(), nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estado_civil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text, txtMostrarDetalles.Text.Replace("'", ""));
                    //*******
                    actualizarDatosGeneralesDelSocio(estado_civil, edadd);
                    //******
                    MessageBox.Show("Socio creado correctamente");

                    txtBusqueda.Text = socioNro;
                    cmbBusqueda.SelectedItem = "Documento";
                    buscarSocio();
                    seleccionarSocioBotonClick();


                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Alta Socio Nro " + socioNro.Replace(",", "."));


                    desactivarAltaSocio();
                    borrarErroresNuevoSocio();

                    // verDetalles();

                    //Cargo Socios
                    dsSocios = empresa.DevolverSocios();


                    btnGuardarSocio.Enabled = false;
                    btnCancelarSocio.Enabled = false;
                    btnEliminarSocio.Enabled = true;
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

                string nro_socio = this.txtNroSocio.Text;

                bool formatoCiOK = true;
                int resultado;

                if (int.TryParse(nro_socio.Replace(".", "").Replace(",", "").Replace("-", ""), out resultado))
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

                        empresa.EditarSocio(this.idSocioSeleccionado, socioNro.Replace(",", ".").Trim(), nroCobro, txtNombres.Text, txtApellidos.Text, fnac, fing, estado_civil, sexoo, estadoPoA, edadd, of, inc, txtTelefono.Text, txtDireccion.Text, txtEmail.Text, txtMostrarDetalles.Text.Replace("'", ""));


                        //*******

                        actualizarDatosGeneralesDelSocio(estado_civil, edadd);

                        //*****


                        MessageBox.Show("Socio modificado correctamente");

                        RegistroSLogs registroLogs = new RegistroSLogs();
                        registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Edición Socio Nro " + socioNro.Replace(",", "."));

                        this.btnNuevoSocio.Enabled = true;

                        //Cargo Socios
                        dsSocios = empresa.DevolverSocios();
                        borrarErroresNuevoSocio();
                        desactivarAltaSocio();

                        btnGuardarSocio.Enabled = false;
                        btnCancelarSocio.Enabled = false;
                        btnEliminarSocio.Enabled = true;
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
                Boolean puedeDarseDeBaja = true;
                Boolean excedido = true;
                DataSet dsCobranzaProvisoriaSocio = empresa.devolverCobranzaProvisoriaSocio(idSocioSeleccionado);
                DataSet dsCobranzaSocio = empresa.devolverCobranzaSocio(idSocioSeleccionado);
                String mensaje = "El socio no puede darse de baja por";

                excedido = estaExcedido();

                if (excedido)
                {
                    puedeDarseDeBaja = false;
                    mensaje += " estar excedido";
                }

                if (dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows.Count != 0)
                {




                    puedeDarseDeBaja = false;

                    if (excedido)
                    {
                        mensaje += " y tener préstamo pendiente";
                    }
                    else
                    {
                        mensaje += " tener préstamo pendiente";
                    }

                }
                else
                {
                    if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows.Count != 0)
                    {
                        if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][12].ToString() != "0")
                        {
                            puedeDarseDeBaja = false;

                            if (excedido)
                            {
                                mensaje += " y tener préstamo pendiente";
                            }
                            else
                            {
                                mensaje += " tener préstamo pendiente";
                            }
                        }
                    }
                }

                if (puedeDarseDeBaja)
                {
                    string message = "¿Está seguro de que desea cambiar de estado al socio?";
                    string caption = "Estado Socio";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);


                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
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


                            empresa.bajaSocio(idSocioSeleccionado, ref estadoActual);
                            MessageBox.Show("Estado del socio actualizado correctamente");

                            RegistroSLogs registroLogs = new RegistroSLogs();
                            registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Baja Socio Nro " + txtNroSocio.Text.Replace(",", "."));

                            cambiarEstado(estadoActual);
                            cambiarBotonBajaAlta(estadoActual);
                            desactivarAltaSocio();
                            btnEliminarSocio.Enabled = true;
                            btnGuardarSocio.Enabled = false;
                            //se agrega 31/8
                            btnCancelarSocio.Enabled = false;
                            this.btnNuevoSocio.Enabled = true;

                            //Cargo Planes
                            //dsPlanes = empresa.DevolverPlanes();
                            //pantallaInicialSocio();

                            cancelar();
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
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un socio antes de darlo de baja");
            }

        }


        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            buscarSocio();
        }

        private void buscarSocio()
        {
            this.buscarCampo();
            estaVaciaDataGrid = false;
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
                string valor = "";
                if (this.cmbBusqueda.SelectedItem.ToString() == "Documento")
                {
                    campo = "socio_nro";


                    if (this.txtBusqueda.Text.Replace(" ", "").Length == 11)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 11);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 10)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 9);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 9)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 8);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 8)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 7);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 7)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 5);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 6)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 4);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 5)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 3);
                    }

                    else if (this.txtBusqueda.Text.Replace(" ", "").Length == 4)
                    {
                        valor = this.txtBusqueda.Text.Substring(0, 1);
                    }
                    else
                    {
                        valor = this.txtBusqueda.Text;
                    }

                    /*    if (this.txtBusqueda.Text.Replace(" ", "").Length == 11)
                        {
                            valor = this.txtBusqueda.Text;
                        }
                        else if (this.txtBusqueda.Text.Replace(" ", "").Replace("-", "").Replace(",", "").Length == 1)
                        {
                            valor = this.txtBusqueda.Text.Replace("-", "").Replace(" ", "").Replace(",", "");
                        }

                        else
                        {
                            valor = this.txtBusqueda.Text.Replace("-", "").Replace(" ", "");
                        }
    */


                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Apellido")
                {
                    campo = "socio_apellido";
                    valor = this.txtBusqueda.Text.Replace("'", "");
                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Nombre")
                {
                    campo = "socio_nombre";
                    valor = this.txtBusqueda.Text.Replace("'", "");
                }
                else if (this.cmbBusqueda.SelectedItem.ToString() == "Dirección")
                {
                    campo = "socio_direccion";
                    valor = this.txtBusqueda.Text.Replace("'", "");
                }

                socioPorCampo(campo, valor.Replace(",", "."));
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
            dgvSociosCampo.Columns["socio_detalles"].Visible = false;

            dgvSociosCampo.Columns["socio_nro"].HeaderText = "Documento";
            dgvSociosCampo.Columns["socio_nro"].Width = 150;

            dgvSociosCampo.Columns["socio_nombre"].HeaderText = "Nombre";
            dgvSociosCampo.Columns["socio_nombre"].Width = 180;

            dgvSociosCampo.Columns["socio_apellido"].HeaderText = "Apellido";
            dgvSociosCampo.Columns["socio_apellido"].Width = 180;

            dgvSociosCampo.Columns["socio_nroCobro"].HeaderText = "Nro Cobro";
            dgvSociosCampo.Columns["socio_nroCobro"].Width = 100;

            dgvSociosCampo.Columns["socio_fechaNac"].HeaderText = "Fecha Nacimiento";
            dgvSociosCampo.Columns["socio_fechaNac"].Width = 100;

            dgvSociosCampo.Columns["socio_fechaIngreso"].HeaderText = "Ingreso";
            dgvSociosCampo.Columns["socio_fechaIngreso"].Width = 150;

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
            dgvSociosCampo.Columns["oficina_codigo"].Width = 90;

            dgvSociosCampo.Columns["inciso_codigo"].HeaderText = "Inciso";
            dgvSociosCampo.Columns["inciso_codigo"].Width = 90;

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
            if (this.idSocioSeleccionado != 0)
            {
                nuevo = false;
                activarAltaSocio();
                this.btnNuevoSocio.Enabled = false;
                this.btnEliminarSocio.Enabled = false;
                this.btnVerMasSocio.Enabled = true;

                this.btnGuardarSocio.Enabled = true;
                this.btnSalir.Enabled = true;
                this.btnCancelarSocio.Enabled = true;

                this.lblErrorGenerico.Visible = false;

                this.txtMostrarDetalles.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un socio antes de intentar editarlo");
            }
        }

        private void btnCancelarSocio_Click(object sender, EventArgs e)
        {

            cancelar();


        }

        private void cancelar()
        {

            desactivarAltaSocio();

            if (!(dgvSociosCampo.CurrentRow == null))
            {
                //   pantallaInicialSocio();
                //desactivarAltaSocio();

                DataSet tmpsocio = empresa.buscarSociosPorCampo("socio_id", idSocioSeleccionado.ToString());

                cmbBusqueda.SelectedItem = "Documento";
                txtBusqueda.Text = tmpsocio.Tables["socios"].Rows[0][1].ToString();
                buscarSocio();
                seleccionarSocioBotonClick();


                btnNuevoSocio.Enabled = true;
                borrarErroresNuevoSocio();
                //btnNuevoSocio.Enabled = true;


                this.btnEditarSocio.Enabled = true;
                this.btnEliminarSocio.Enabled = true;
                this.btnVerMasSocio.Enabled = true;

                //   this.btnGuardarSocio.Enabled = true;


            }
            else
            {
                borrarTextNuevoSocio();
                pantallaInicialSocio();
                limpiarDatosGralesDeSocio();

                btnNuevoSocio.Enabled = true;


                this.btnEditarSocio.Enabled = false;
                this.btnEliminarSocio.Enabled = false;
                this.btnVerMasSocio.Enabled = false;

            }

            this.btnGuardarSocio.Enabled = false;


        }
        private void marcarExcedido()
        {
            if (this.estaExcedido())
            {
                this.btnExcedido.Visible = true;
            }
            else
            {
                this.btnExcedido.Visible = false;
            }
        }
        private void seleccionarSocio()
        {
            int index = dgvSociosCampo.CurrentRow.Index;
            int idSocio = (int)dgvSociosCampo.Rows[index].Cells["socio_id"].Value;

            this.idSocioSeleccionado = idSocio;

            if (index != -1)
            {

                desactivarAltaSocio();

                btnGuardarSocio.Enabled = false;
                btnCancelarSocio.Enabled = false;
                btnEliminarSocio.Enabled = true;
                btnNuevoSocio.Enabled = true;

                borrarErroresNuevoSocio();

                marcarExcedido();

                this.btnEditarSocio.Enabled = true;
                this.btnEliminarSocio.Enabled = true;
                this.btnVerMasSocio.Enabled = true;
                this.btnCancelarSocio.Enabled = true;

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
                ////////
                txtNroDeCobro.Text = dgvSociosCampo.Rows[index].Cells["socio_nroCobro"].Value.ToString();

                this.dtpFechaNac.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaNac"].Value.ToString();
                this.dtpFechaIng.Text = dgvSociosCampo.Rows[index].Cells["socio_fechaIngreso"].Value.ToString();
                this.cmbEstadoCivil.Text = dgvSociosCampo.Rows[index].Cells["socio_estadoCivil"].Value.ToString();


                if (dgvSociosCampo.Rows[index].Cells["socio_estado"].Value.Equals(0))
                    rBtnActivo.Checked = true;
                else rBtnPasivo.Checked = true;


                int estadoActual = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;
                cambiarEstado(estadoActual);
                cambiarBotonBajaAlta(estadoActual);

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
                        //////

                    }

                }

                this.cmbOficina.Enabled = false;

                this.txtTelefono.Text = dgvSociosCampo.Rows[index].Cells["socio_tel"].Value.ToString();
                this.txtDireccion.Text = dgvSociosCampo.Rows[index].Cells["socio_direccion"].Value.ToString();
                this.txtEmail.Text = dgvSociosCampo.Rows[index].Cells["socio_email"].Value.ToString();
                this.txtMostrarDetalles.Text = dgvSociosCampo.Rows[index].Cells["socio_detalles"].Value.ToString();


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
            if (!estaVaciaDataGrid)
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


                limpiarPantallaDeCobranza();
                limpiarPantallaIngresoDeExcedidos();
            }
            else
            {
                limpiarPantallaIngresoDeExcedidos();
                int index = dgvSociosCampo.CurrentRow.Index;
                int estadoActual = (int)dgvSociosCampo.Rows[index].Cells["socio_activo"].Value;

                //Reseteo los campos de ingreso de excedidos
                txtARetenerIngExc.Text = "";
                txtRetenidoIngExc.Text = "";
                txtPresupuestoIngExc.Text = "";
                txtSaldoIngExc.Text = "";
                txtMoraIngExc.Text = "";
                txtTotalIngExc.Text = "";

                // Resteo variables préstamo
                txtNuevoImporte.Text = "";
                prestamoCorrecto = false;
                txtImporteCuota.Text = "0.00";

                //int estadoActual = definirEstado();
                //dejarPantallaComoAlInicio();
                desactivarAltaSocio();
                cambiarBotonBajaAlta(estadoActual);
                definirEstado();
                borrarErroresNuevoSocio();
                this.btnEditarSocio.Enabled = true;
                this.btnEliminarSocio.Enabled = true;
                this.btnVerMasSocio.Enabled = true;


            }

        }

        private void btnSeleccionarSocio_Click(object sender, EventArgs e)
        {
            seleccionarSocioBotonClick();
        }

        private void seleccionarSocioBotonClick()
        {

            if (!estaVaciaDataGrid)
            {
                cargarPantallas();
            }
        }

        private void cargarPantallas()
        {

            seleccionarSocioYllenarDataGrid();
            //calcularSaldoMorayTotal();
            //llenarCamposDeCobranzaExcedidos();
            txtInciso.Text = dsIncisos.Tables["incisos"].Rows[0][3].ToString();
            txtOficina.Text = dsOficinas.Tables["oficinas"].Rows[0][2].ToString();
            txtIncisoCobExcedidos.Text = dsIncisos.Tables["incisos"].Rows[0][3].ToString();
            txtOficinaCobExcedidos.Text = dsOficinas.Tables["oficinas"].Rows[0][2].ToString();
            txtNroDeCobro.Text = dsSocios.Tables["socio"].Rows[0][4].ToString();
            txtCI.Text = dsSocios.Tables["socio"].Rows[0][3].ToString();
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

        public void cargarPlanPrestamos(object sender, EventArgs e)
        {
            cargarPlanPrestamoSocio();

        }

        private Boolean estaExcedido()
        {

            if (!(idSocioSeleccionado == 0))
            {
                DataSet dsExcedidosSinPago = empresa.devolverExcedidosSinPago(idSocioSeleccionado);
                if (dsExcedidosSinPago.Tables["excedidosSinPago"].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void cargarPlanPrestamoSocio()
        {
            if (tbcPestanas.SelectedTab == tbcPestanas.TabPages["tabPrestamo"])
            {
                //Cargar combo préstamos
                dsPlanes = empresa.DevolverPlanesActivos();
                this.cmbPlanPréstamo.DataSource = dsPlanes.Tables["planprestamo"];
                this.cmbPlanPréstamo.DisplayMember = "plan_nombre";
                this.cmbPlanPréstamo.ValueMember = "plan_id";

                txtNuevoImporte.Clear();
                txtTotalDeuda.Text = "0.00";
                btnSolicitar.Enabled = false;

                if (!(idSocioSeleccionado == 0))
                {
                    excedido = estaExcedido();

                    if (!excedido)
                    {
                        txtNuevoImporte.ReadOnly = false;
                        // busco primero en cobranza provisoria para ver si no tiene ningun
                        // prestamo que haya hecho recien y que no se haya mandado a retener.
                        DataSet dsCobranzaProvisoriaSocio = empresa.devolverCobranzaProvisoriaSocio(idSocioSeleccionado);
                        DataSet dsCobranzaSocio = empresa.devolverCobranzaSocio(idSocioSeleccionado);

                        if (dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows.Count == 0)
                        {
                            exitiaProvisoria = false;
                            //0 si recien ha ingresado es en el que caso en que se le
                            //haga el alta al socio y ya haya operado
                            if (dsCobranzaSocio.Tables["cobranzaSocio"].Rows.Count == 0)
                            {
                                txtNroPréstamo.Text = "0";
                                txtCuotas.Text = "0";
                                txtPagas.Text = "0";
                                txtTasa.Text = "0";
                                txtMonto.Text = "0";
                                txtImporteCuotaPendiente.Text = "0";
                                txtAmortización.Text = "0";
                                txtInteresesAVencer.Text = "0";
                                cuotaAnteriorPrestamo = 0;
                                tasaAnteriorPrestamo = 0;
                                nro_prestamoAnterior = 0;
                                montoAnterior = 0;

                                /* si si tiene pero lo termina ese mes
                                   o puede ser que tampoco haya tenido pero amortizacion
                                   a vencer va a aparecer en 0
                                */
                            }
                            else
                            {
                                txtNroPréstamo.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString();
                                txtCuotas.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString();
                                txtPagas.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString();
                                txtTasa.Text = String.Format(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString(), "##0.00");
                                txtMonto.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString();
                                txtImporteCuotaPendiente.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString();
                                txtAmortización.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][12].ToString();
                                txtInteresesAVencer.Text = dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][13].ToString();

                                cuotaAnteriorPrestamo = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][8].ToString());
                                tasaAnteriorPrestamo = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][3].ToString());
                                nro_prestamoAnterior = Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][1].ToString());
                                montoAnterior = Convert.ToDouble(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][5].ToString());
                                txtTotalDeuda.Text = montoAnterior.ToString();

                                if (Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString()) != 0)
                                {
                                    if (Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][6].ToString()) < Math.Abs(Convert.ToInt32(dsCobranzaSocio.Tables["cobranzaSocio"].Rows[0][7].ToString())) / 2)
                                    {
                                        MessageBox.Show("El prestamo no tiene más del 50% de cuotas pagas.");
                                    }
                                }
                            }
                        }
                        else
                        {

                            cuotaAnteriorPrestamo = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString());
                            tasaAnteriorPrestamo = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString());
                            nro_prestamoAnterior = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString());
                            montoAnterior = Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                            txtTotalDeuda.Text = montoAnterior.ToString();

                            id_cobranzaProvisoria = Convert.ToInt32(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][0].ToString());
                            exitiaProvisoria = true;

                            txtNroPréstamo.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][1].ToString();
                            txtCuotas.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString();
                            txtPagas.Text = 0.ToString();
                            txtTasa.Text = String.Format(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][3].ToString(), "##0.00");
                            txtMonto.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();
                            txtImporteCuotaPendiente.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString();
                            txtAmortización.Text = dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString();

                            double CalculotxtInteresesAVencer = (Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][6].ToString()) * Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][8].ToString())) - Convert.ToDouble(dsCobranzaProvisoriaSocio.Tables["cobranzasProvisoriasSocio"].Rows[0][5].ToString());
                            txtInteresesAVencer.Text = Convert.ToString(CalculotxtInteresesAVencer);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Socio tiene deudas pendientes. No puede operar hasta cancelar la totalidad de la misma.");
                        txtNuevoImporte.ReadOnly = true;
                    }
                }
            }
            else if ((tbcPestanas.SelectedTab == tbcPestanas.TabPages["tabBusqueda"]))
            {
                this.buscarCampo();
            }
            else if ((tbcPestanas.SelectedTab == tbcPestanas.TabPages["tabHistorial"]))
            {
                cargarPantallaHistoria();
            }
            else if ((tbcPestanas.SelectedTab == tbcPestanas.TabPages["tabCobranzaExcedidos"]))
            {
                if (!(idSocioSeleccionado == 0))
                {
                    excedido = estaExcedido();

                    if (excedido)
                    {
                        DataSet socioExcedido = empresa.devolverExcedidosSinPago(idSocioSeleccionado);
                        llenarCamposDeCobranzaExcedidos(socioExcedido, "excedidosSinPago");
                    }
                }
            }
        }


        private void cargarPantallaHistoria()
        {
            DataSet dsHistoria = empresa.devolverHistoriaPorIdSocio(idSocioSeleccionado);

            dgvHistoria.DataSource = dsHistoria.Tables["historiasIdSocio"];

            dgvHistoria.RowHeadersVisible = false;
            dgvHistoria.ReadOnly = true;
            dgvHistoria.MultiSelect = false;
            dgvHistoria.ReadOnly = true;
            dgvHistoria.AllowDrop = false;
            dgvHistoria.AllowUserToAddRows = false;
            dgvHistoria.AllowUserToDeleteRows = false;
            dgvHistoria.AllowUserToResizeColumns = false;
            dgvHistoria.AllowUserToResizeRows = false;
            dgvHistoria.AllowUserToOrderColumns = false;
            dgvHistoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoria.BackgroundColor = BackColor;
            dgvHistoria.BorderStyle = BorderStyle.None;

            dgvHistoria.Columns["Presupuesto"].HeaderText = "Presupuesto";
            dgvHistoria.Columns["Presupuesto"].Width = 120;

            dgvHistoria.Columns["NumeroPrestamo"].HeaderText = "Nº Préstamo";
            dgvHistoria.Columns["NumeroPrestamo"].Width = 120;

            dgvHistoria.Columns["montopedido"].HeaderText = "Monto";
            dgvHistoria.Columns["montopedido"].Width = 120;

            dgvHistoria.Columns["cantidadcuotas"].HeaderText = "Cuotas";
            dgvHistoria.Columns["cantidadcuotas"].Width = 120;

            dgvHistoria.Columns["nrocuotas"].HeaderText = "Nro Cuota";
            dgvHistoria.Columns["nrocuotas"].Width = 120;

            dgvHistoria.Columns["importecuota"].HeaderText = "Importe Cuota";
            dgvHistoria.Columns["importecuota"].Width = 120;

            dgvHistoria.Columns["tasa"].HeaderText = "Tasa";
            dgvHistoria.Columns["tasa"].Width = 120;
        }

        private void dgvSociosCampo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CalcularImporteCuota()
        {
            if (!(idSocioSeleccionado == 0))
            {
                if (!(txtNuevoImporte.Text.Trim() == ""))
                {
                    if (esDecimal(txtNuevoImporte.Text.Replace(".", ",")))
                    {
                        int index = this.cmbPlanPréstamo.SelectedIndex;
                        int idPlanPrestamo = Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString());


                        for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
                        {
                            if (idPlanPrestamo == Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][0].ToString()))
                            {
                                cantidadCuotas = Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][1].ToString());
                                tasaAnualEfectivaSinIVA = Convert.ToDouble(dsPlanes.Tables["planprestamo"].Rows[i][2].ToString());
                                iva = Convert.ToDouble(dsPlanes.Tables["planprestamo"].Rows[i][3].ToString());
                                break;
                            }
                        }

                        for (int i = 0; i < dsSociosPorCampo.Tables["socios"].Rows.Count; i++)
                        {
                            if (this.idSocioSeleccionado == Convert.ToInt32(dsSociosPorCampo.Tables["socios"].Rows[i][0].ToString()))
                            {
                                nro_socio = dsSociosPorCampo.Tables["socios"].Rows[i][1].ToString();
                            }
                        }

                        tasaConIva = empresa.agregarleIvaAtasaAnual(tasaAnualEfectivaSinIVA, iva);

                        txtTotalDeuda.Text = Convert.ToString(Convert.ToDouble(txtNuevoImporte.Text.Replace(".", ",")) + Convert.ToDouble(txtAmortización.Text.Replace(".", ",")));

                        totalDeuda = Convert.ToDouble(txtTotalDeuda.Text.Replace(".", ","));

                        cuota = empresa.Cuota(tasaConIva, cantidadCuotas, totalDeuda);

                        txtImporteCuota.Text = cuota.ToString();

                        prestamoCorrecto = true;

                        btnSolicitar.Enabled = true;

                    }
                    else
                    {
                        txtImporteCuota.Text = "0.00";
                        txtTotalDeuda.Text = montoAnterior.ToString();
                        cantidadCuotas = 0;
                        tasaAnualEfectivaSinIVA = 0;
                        iva = 0;
                        totalDeuda = 0;
                        tasaConIva = 0;
                        cuota = 0;
                        prestamoCorrecto = false;
                        nro_socio = "";
                        btnSolicitar.Enabled = false;
                    }
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

        public bool esCero(string nroPrueba)
        {
            double resultado = 0;
            Boolean esDouble = double.TryParse(nroPrueba, out resultado);

            Boolean esCero = false;

            if (esDouble)
            {

                if (resultado == 0)
                {
                    esCero = true;
                }
            }

            return esDouble && esCero;
        }


        private void cmbPlanPréstamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularImporteCuota();
        }

        private void txtNuevoImporte_Leave(object sender, EventArgs e)
        {
            CalcularImporteCuota();
        }

        private void btnGuardarPrestamo_Click_1(object sender, EventArgs e)
        {
            if (!(idSocioSeleccionado == 0))
            {
                if (prestamoCorrecto)
                {

                    string message = "¿Está seguro de que desea solicitar un nuevo préstamo?";
                    string caption = "Nuevo Préstamo";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        Socio tmpSocio = new Socio();
                        tmpSocio.Socio_id = this.idSocioSeleccionado;

                        double amortizacionVencer = empresa.AmortVencer(tasaConIva, cantidadCuotas, 1, cuota);

                        double interesesVencer = empresa.IntVencer(cuota, cantidadCuotas, 1, amortizacionVencer);


                        int idPrestamo = empresa.AltaPrestamo(tmpSocio, nro_socio, DateTime.Now, DateTime.Now, totalDeuda, tasaConIva, cantidadCuotas, cuota, nro_prestamoAnterior, montoAnterior, Convert.ToDouble(txtAmortización.Text.Replace(".", ",")), Convert.ToDouble(txtInteresesAVencer.Text.Replace(".", ",")), Convert.ToInt32(txtCuotas.Text.Replace(".", ",")), Convert.ToInt32(txtPagas.Text.Replace(".", ",")), cuotaAnteriorPrestamo, tasaAnteriorPrestamo, 0);

                        double amorticacionCuota = empresa.AmortCuota(tasaConIva, 1, cantidadCuotas, totalDeuda);

                        double Wiva = (iva / 100) + 1;

                        double interesCuota = Convert.ToDouble((cuota - amorticacionCuota) / Wiva);
                        double ivaCuota = cuota - amorticacionCuota - interesCuota;

                        empresa.GuardarCobranzaProvisoria(idPrestamo, nro_socio, tasaConIva, tasaAnualEfectivaSinIVA, totalDeuda, cantidadCuotas, 1, cuota, amorticacionCuota, interesCuota, ivaCuota, amortizacionVencer, interesesVencer, idSocioSeleccionado);

                        if (exitiaProvisoria)
                        {
                            empresa.eliminarCobranzaProvisoria(id_cobranzaProvisoria);
                            exitiaProvisoria = false;
                        }


                        ivaSobreIntereses = ((cuota * cantidadCuotas) - totalDeuda) / (1 + (iva / 100)) * (iva / 100);
                        double montoIntereses = ((cuota * cantidadCuotas) - totalDeuda) / (1 + (iva / 100));

                        DataSet dsParametros = empresa.DevolverEmpresa();
                        String FechaPrimerCuota = empresa.VtoPrimerCuota(Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString())).ToString("dd/MM/yyyy");
                        DateTime FechaVto = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()).AddDays(15);

                        cargarPlanPrestamoSocio();

                        // *****************Imprimir Vale
                        DV.vale.Rows.Add(totalDeuda.ToString("###,###,##0.00"), lblNumeroSocio.Text, cantidadCuotas, cuota.ToString("###,###,##0.00"), tasaAnualEfectivaSinIVA, iva + "%", ivaSobreIntereses.ToString("###,###,##0.00"), (cuota * cantidadCuotas).ToString("###,###,##0.00"), montoIntereses.ToString("###,###,##0.00"), empresa.ESCNUM(Convert.ToString(cuota * cantidadCuotas)), txtApellidos.Text.Trim() + ", " + txtNombres.Text.Trim(), txtNroCobro.Text, idPrestamo, txtInciso.Text + " / " + txtOficina.Text, empresa.formatoFechaMid4(FechaVto), "(" + empresa.ESCNUM(cantidadCuotas.ToString()) + ")", empresa.ESCNUM(cuota.ToString()), FechaPrimerCuota, DateTime.Today.ToLongDateString());
                        frmVerReportes reporte = new frmVerReportes(DV, "VALE_PRESTAMO");

                        RegistroSLogs registroLogs = new RegistroSLogs();
                        registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Nuevo Préstamo Socio Nro " + txtNroSocio.Text.Replace(",", "."));

                        reporte.ShowDialog();
                        DE.solicitud.Rows.Clear();
                        //******************************

                        btnSolicitar.Enabled = false;
                        btnGuardarPrestamo.Enabled = false;
                        txtNuevoImporte.Text = "";
                        prestamoCorrecto = false;
                        txtImporteCuota.Text = "0.00";

                    }
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

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBusqueda.SelectedIndex == 0)
            {
                txtBusqueda.Mask = "0.000.000-0";
            }
            else
            {
                txtBusqueda.Mask = "";
            }
        }

        private void parámetrosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParámetrosDelSistema ps = new ParámetrosDelSistema();
            ps.Show();

        }

        private void dgvSociosCampo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardarCobranza_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarPrestamo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmCierreMes frmCierre = new frmCierreMes();
            frmCierre.ShowDialog();


            /*  string tabSeleccionado = tbcPestanas.SelectedTab.Name;

              tbcPestanas.SelectedTab = tbcPestanas.TabPages[tabSeleccionado];
             * 
             * */

            cargarPlanPrestamoSocio();


            limpiarPantallaIngresoDeExcedidos();
            limpiarPantallaDeCobranza();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            int estado = devolverEstadoSocio();
            if (estado == 1)
            {
                DE.solicitud.Rows.Add(txtNroSocio.Text, txtInciso.Text.Trim() + " / " + txtOficina.Text.Trim(), lblNumeroSocio.Text, lblApellidosSocio.Text.Trim() + ", " + lblNombreSocio.Text.Trim(), lblNombreSocio.Text.Trim(), Convert.ToDouble(txtNuevoImporte.Text), cantidadCuotas, montoAnterior, txtInteresesAVencer.Text, cuota, totalDeuda - montoAnterior, totalDeuda, cuotaAnteriorPrestamo);
                frmVerReportes reporte = new frmVerReportes(DE, "SOLICITUD_PRESTAMO");
                reporte.ShowDialog();
                DE.solicitud.Rows.Clear();
                btnGuardarPrestamo.Enabled = true;
            }
            else
            {
                MessageBox.Show("El socio no está dado de alta en el sistema");
            }
        }

        private bool hayCamposVaciosEnIngresoExcedidos()
        {
            return (txtRetenidoIngExc.Text == "" || txtARetenerIngExc.Text == "" || txtPresupuestoIngExc.Text == "");


        }

        private void btnGuardarIngExcedidos_Click(object sender, EventArgs e)
        {

            //bool txtSoloNumeros = true;
            //Regex regex = new Regex("/^[0-9]+$/");
            // Regex regex = new Regex("^[0-9]+([,|.][0-9]+)?$");
            if (!esDecimal(txtARetenerIngExc.Text.Replace(".", ",")) || (!esDecimal(txtRetenidoIngExc.Text.Replace(".", ","))) && (!esCero(txtRetenidoIngExc.Text.Replace(".", ","))))
            {
                MessageBox.Show("Retenido o a_Retener deben ser numéricos");
                calcularSaldoMorayTotal();
            }
            else
                if (!hayCamposVaciosEnIngresoExcedidos())
                {
                    if (Convert.ToDouble(txtARetenerIngExc.Text.Replace(".", ",")) <= Convert.ToDouble(txtRetenidoIngExc.Text.Replace(".", ",")))
                    {
                        MessageBox.Show("El importe Retenido debe ser menor que el de a_Retener.");
                        calcularSaldoMorayTotal();
                    }
                    else
                        if (retenidoActual > Convert.ToDouble(txtRetenidoIngExc.Text.Replace(".", ",")))
                        {
                            MessageBox.Show("El importe Retenido debe ser mayor a lo que ya se habia retenido");
                            calcularSaldoMorayTotal();
                        }

                        else
                        {

                            Excedidos ex = new Excedidos();
                            ex._aretener = Convert.ToDouble(txtARetenerIngExc.Text.Replace(".", ","));
                            ex._retenido = Convert.ToDouble(txtRetenidoIngExc.Text.Replace(".", ","));
                            ex._presupuesto = txtPresupuestoIngExc.Text;
                            ex._cedula = txtNroSocio.Text;
                            ex._socio_id = this.idSocioSeleccionado;

                            DataSet dsExcedidoSocioIdPresupuesto = empresa.devolverExcedidosPorSocioIdyPresupuesto(idSocioSeleccionado, txtPresupuestoIngExc.Text);

                            int filas = dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows.Count;
                            if (filas <= 0)
                            {
                                ex.Guardar();
                                MessageBox.Show("Persona ingresada como 'Excedida' correctamente");
                                marcarExcedido();
                                RegistroSLogs registroLogs = new RegistroSLogs();
                                registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Socio ingresado como excedido " + txtNroSocio.Text.Replace(",", "."));

                            }
                            else
                            {
                                ex._idExcedido = Convert.ToInt32(dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][0].ToString());
                                ex.modificarExcedido();
                                MessageBox.Show("El valor retenido fue actualizado correctamente");
                            }

                            llenarCamposDeCobranzaExcedidos(dsExcedidoSocioIdPresupuesto, "excedidosPorSocioIdyPresupuesto");
                            calcularSaldoMorayTotal();
                        }
                }
                else
                {
                    MessageBox.Show("Debe ingresar los campos requeridos");
                }
        }

        private void tabCobranza_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado > 0)
            {
                frmCancelacionAnticipadaDePrestmos frmCancelacion = new frmCancelacionAnticipadaDePrestmos(idSocioSeleccionado, txtInciso.Text, txtOficina.Text);
                frmCancelacion.ShowDialog();
                cargarPlanPrestamoSocio();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un socio para poder cancelar");
            }
        }

        private Double calcularMoraYSaldos(Double saldo, string _presupuesto)
        {
            DataSet dsParametros = empresa.DevolverEmpresa();
            Double Wmora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][11].ToString());
            Double WIvaMora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][10].ToString());
            Double aporteCapitalExcedido = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][8].ToString());
            //string _Presupuesto = txtPresupuestoIngExc.Text;

            // Double saldo = Convert.ToDouble(txtARetenerIngExc.Text) - Convert.ToDouble(txtRetenidoIngExc.Text);
            //Wmora = RsParametros!Mora * (1 + (RsParametros!Iva / 100))
            Double porcentajeMora = (Wmora * (1 + WIvaMora / 100));
            //Double mora = (saldo - aporteCapital)*porcentajeMora/100;

            DateTime fechaVto = empresa.VtoPto(DateTime.Today);
            Double mora = Convert.ToDouble((empresa.Pago_Mora(saldo - aporteCapitalExcedido, _presupuesto, porcentajeMora, fechaVto.ToString("dd/MM/yyyy"))));

            return mora;

            //txtSaldoIngExc.Text = saldo.ToString();
            //txtMoraIngExc.Text = mora.ToString();
            //txtTotalIngExc.Text = (saldo + mora).ToString();


        }
        //DataSet dsExcedidosPorCI;
        double retenidoActual = 0;

        private void calcularSaldoMorayTotal()
        {


            //   dsExcedidosPorCI = empresa.devolverExcedidosPorCI(txtNroSocio.Text);

            DataSet dsExcedidoSocioIdPresupuesto = empresa.devolverExcedidosPorSocioIdyPresupuesto(idSocioSeleccionado, txtPresupuestoIngExc.Text);

            if (dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows.Count > 0)
            {


                txtARetenerIngExc.Text = dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][3].ToString();
                txtRetenidoIngExc.Text = dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][4].ToString();
                txtPresupuestoIngExc.Text = dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][1].ToString();

                retenidoActual = Convert.ToDouble(txtRetenidoIngExc.Text);

                Double saldo = Convert.ToDouble(txtARetenerIngExc.Text) - Convert.ToDouble(txtRetenidoIngExc.Text);
                string _Presupuesto = txtPresupuestoIngExc.Text;


                txtSaldoIngExc.Text = saldo.ToString();
                Double mora = calcularMoraYSaldos(saldo, _Presupuesto);
                txtMoraIngExc.Text = mora.ToString("###,###,##0.00");
                txtTotalIngExc.Text = (saldo + mora).ToString("###,###,##0.00");
            }
            //else
            //    calcularMoraYSaldos();

            // else
            // {

            //MessageBox.Show("La persona no se encuentra excedida");
            //   limpiarPantallaIngresoDeExcedidos();          }

        }
        private void btnCalcularIngExc_Click(object sender, EventArgs e)
        {

            calcularSaldoMorayTotal();

        }

        private void limpiarPantallaDeCobranza()
        {
            txtARetener.Text = "";
            txtRetenido.Text = "";
            txtPresupuesto.Text = "";
            txtSaldo.Text = "";
            txtMora.Text = "";
            txtTotal.Text = "";
            btnPagarCobranza.Enabled = false;

        }

        private void limpiarPantallaIngresoDeExcedidos()
        {

            txtARetenerIngExc.Text = "";
            txtRetenidoIngExc.Text = "";
            txtPresupuestoIngExc.Text = "";
            txtSaldoIngExc.Text = "";
            txtMoraIngExc.Text = "";
            txtTotalIngExc.Text = "";


        }

        private void llenarCamposDeCobranzaExcedidos(DataSet dsExcedidosSocioIdPresupuesto, string tabla)
        {
            limpiarPantallaDeCobranza();

            if (dsExcedidosSocioIdPresupuesto.Tables[tabla].Rows.Count > 0)
            {

                txtPresupuesto.Text = dsExcedidosSocioIdPresupuesto.Tables[tabla].Rows[0][1].ToString();
                txtARetener.Text = String.Format(dsExcedidosSocioIdPresupuesto.Tables[tabla].Rows[0][3].ToString(), "##0.00");
                txtRetenido.Text = String.Format(dsExcedidosSocioIdPresupuesto.Tables[tabla].Rows[0][4].ToString(), "##0.00");

                Double saldo = Convert.ToDouble(txtARetener.Text) - Convert.ToDouble(txtRetenido.Text);
                Double mora = 0;
                DataSet dsParametros = empresa.DevolverEmpresa();
                Double aporteCapitalExcedido = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][8].ToString());

                string _Presupuesto = txtPresupuesto.Text;

                if (saldo > aporteCapitalExcedido)
                {
                    mora = calcularMoraYSaldos(saldo, _Presupuesto);
                }
                else
                {
                    mora = 0;
                }

                txtSaldo.Text = saldo.ToString("###,###,##0.00");
                txtMora.Text = mora.ToString("###,###,##0.00");
                txtTotal.Text = (saldo + mora).ToString("###,###,##0.00");

                tmpMora = mora;
                tmpSaldo = saldo;

            }
            else
            {
                limpiarPantallaDeCobranza();
            }
        }

        private void btnCalcularCobranza_Click(object sender, EventArgs e)
        {
            // agregar dataset           llenarCamposDeCobranzaExcedidos();
            //btnPagarCobranza.Enabled = true;
            //btnImprimirCobranza.Enabled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblErrorG_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtARetener.Text != "")
            {
                string message = "¿Está seguro que va a pagar la totalidad de la deuda?";
                string caption = "Pago";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Excedidos ex = new Excedidos();
                    ex._aretener = Convert.ToDouble(txtARetener.Text);
                    ex._retenido = Convert.ToDouble(txtRetenido.Text);
                    ex._presupuesto = txtPresupuesto.Text;
                    ex._cedula = txtNroSocio.Text;

                    DataSet dsExcedidoSocioIdPresupuesto = empresa.devolverExcedidosPorSocioIdyPresupuesto(idSocioSeleccionado, txtPresupuesto.Text);

                    if (dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows.Count <= 0)
                    {
                        //ex.Guardar();
                        MessageBox.Show("La persona ingresada no esta Excedida");
                    }
                    else
                    {
                        ex._idExcedido = Convert.ToInt32(dsExcedidoSocioIdPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][0].ToString());
                        ex.eliminar();
                        MessageBox.Show("Deuda saldada");

                        RegistroSLogs registroLogs = new RegistroSLogs();
                        registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Cobranza excedido Socio Nro " + txtNroSocio.Text.Replace(",", "."));

                        //btnPagarCobranza.Enabled = false;
                        //btnImprimirCobranza.Enabled = false;
                        limpiarPantallaIngresoDeExcedidos();
                        limpiarPantallaDeCobranza();
                    }
                }
            }
            else
                MessageBox.Show("No hay deudas pendientes para pagar");
        }

        private void btnSalirCobranza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirCobranza_Click(object sender, EventArgs e)
        {

            if (txtARetener.Text != "")
            {
                // MessageBox.Show("Se manda a imprimir el doc");
                DEx.Clear();
                DEx.Excedido.Rows.Add(txtCI.Text, txtARetener.Text, txtRetenido.Text, txtSaldo.Text, txtMora.Text, txtTotal.Text);
                frmVerReportes reporte = new frmVerReportes(DEx, "EXCEDIDO");
                reporte.ShowDialog();
                this.btnPagarCobranza.Enabled = true;
            }
            else
                MessageBox.Show("No hay deudas para imprimir");
        }

        private void tabPrestamo_Click(object sender, EventArgs e)
        {

        }


        /*Que acepte coma guardar excedido
Agregar condicion si ya fue pagada por el otro lado
Agregar emisión
         * */

        private void cargarARetener()
        {

            DataSet historiaID_Presupuesto = empresa.devolverHistoriaPorIDyPresupuesto(idSocioSeleccionado, this.txtPresupuestoIngExc.Text);
            DataSet excedidoSocioPresupuesto = empresa.devolverExcedidosPorSocioIdyPresupuesto(idSocioSeleccionado, txtPresupuestoIngExc.Text);

            if (historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows.Count > 0)
            {
                double importeCuota = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][9].ToString());
                double aporteCapital = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][15].ToString());
                double excedido = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][19].ToString());
                double mora = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][20].ToString());
                double ivaMora = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][21].ToString());
                double ivaCuota = Convert.ToDouble(historiaID_Presupuesto.Tables["historiasIdyPresupuesto"].Rows[0][12].ToString());
                double total = importeCuota + aporteCapital + excedido + mora + ivaMora + ivaCuota;
                txtARetenerIngExc.Text = total.ToString();

                calcularSaldoMorayTotal();

                if (excedidoSocioPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows.Count > 0)
                {
                    if (Convert.ToDouble(excedidoSocioPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][6].ToString()) > 0)
                    {
                        String presupuestoDelPago = excedidoSocioPresupuesto.Tables["excedidosPorSocioIdyPresupuesto"].Rows[0][7].ToString();
                        MessageBox.Show("La Deuda ya fué Cancelada en el Presupuesto del mes de " + presupuestoDelPago);
                        limpiarPantallaIngresoDeExcedidos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Los Datos no son Correctos");
            }
        }

        private void txtPresupuestoIngExc_Leave(object sender, EventArgs e)
        {
            int anioActual;
            int anioPresup;
            bool anioBien = false;
            retenidoActual = 0;

            if (txtPresupuestoIngExc.Text.Length == 7)
            {
                anioActual = DateTime.Today.Year;
                anioPresup = Convert.ToInt32(this.txtPresupuestoIngExc.Text.Substring(3, 4));

                if (anioActual != anioPresup)
                {
                    string message = "El año ingresado no se corresponde con el año en curso. ¿Continúa?";
                    string caption = "Excedidos";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        anioBien = true;
                    }
                }
                else
                {
                    anioBien = true;
                }

                if (anioBien)
                {
                    txtRetenido.Focus();
                    cargarARetener();
                }
                else
                {
                    txtPresupuesto.Clear();
                }
            }
            else
            {
                MessageBox.Show("Formato de presupuesto incorrecto");
            }
        }



        private void rbtnSI_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnNo.Checked)
            {
                txtMora.Text = Convert.ToDouble("0.00").ToString("###,###,##0.00");
                txtTotal.Text = tmpSaldo.ToString("###,###,##0.00");
            }
            else
            {
                txtMora.Text = tmpMora.ToString("###,###,##0.00");
                txtTotal.Text = (tmpMora + tmpSaldo).ToString("###,###,##0.00");
            }
        }

        private void anulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnulacionPrestamo frmAnulacion = new frmAnulacionPrestamo();
            frmAnulacion.ShowDialog();
            cargarPlanPrestamoSocio();
        }

        private void dgvSociosCampo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSociosCampo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ver si se rompe algo si lo sacamos 29/01/2018
            //cargarDatosGralesDesdeDataGrid();
            cargarPantallas();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanco frmTmpBanco = new frmBanco();
            frmTmpBanco.ShowDialog();
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimientosBancarios frmTmpMovimientos = new frmMovimientosBancarios();
            frmTmpMovimientos.ShowDialog();

        }

        private void rBtnPasivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void consultaRápidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaSaldosBancarios frmConsulta = new frmConsultaSaldosBancarios();
            frmConsulta.ShowDialog();
        }

        private void cantidadYPromedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCantidadMovimientos frmTmpCantidad = new frmCantidadMovimientos();
            frmTmpCantidad.ShowDialog();
        }

        private void cierreMesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En construcción");
        }

        private void resumenDePréstamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformePrestamo frmTmpInformeCierre = new frmInformePrestamo();
            frmTmpInformeCierre.ShowDialog();
        }
    }
}


