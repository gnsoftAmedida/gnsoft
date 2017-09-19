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
    public partial class frmPlanDePrestamo : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsPlanes;
        private bool nuevo = true;
        private bool yaHizoLoad = false;

        public frmPlanDePrestamo()
        {
            InitializeComponent();
        }


        private void frmPlanDePrestamo_Load(object sender, EventArgs e)
        {
            //Cargo planes
            dsPlanes = empresa.DevolverPlanes();
            pantallaInicial();
            yaHizoLoad = true;
        }

        public void pantallaInicial()
        {
            this.cmbPlan.DataSource = dsPlanes.Tables["planprestamo"];
            this.cmbPlan.ValueMember = "plan_nombre";
            this.cmbPlan.SelectedIndex = -1;
            this.cmbPlan.Enabled = true;
            this.cmbPlan.Text = "";
            this.chkVigencia.Enabled = false;
            this.btnEditarPlan.Enabled = false;
            this.btnGuardarPlan.Enabled = false;
            this.btnNuevoPlan.Enabled = true;
            this.btnEliminarPlan.Enabled = false;
            this.texBoxNombrePlan.Enabled = false;
            this.txtBoxCantCuotas.Enabled = false;
            this.txtBoxTasaAnualSinIVA.Enabled = false;
            this.txtBoxIVA.Enabled = false;
            this.txtBoxIVA.Clear();
            this.texBoxNombrePlan.Clear();
            this.txtBoxCantCuotas.Clear();
            this.txtBoxTasaAnualSinIVA.Clear();
            this.lblCantCuotas.Visible = false;
            this.lblNombre.Visible = false;
            this.lblTasaAnual.Visible = false;
            this.lblErrorGenerico.Visible = false;

        }

        private void cmbPLan_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (yaHizoLoad)
            {
                int index = this.cmbPlan.SelectedIndex;
                if (index != -1)
                {
                    this.texBoxNombrePlan.Enabled = false;
                    this.txtBoxCantCuotas.Enabled = false;
                    this.txtBoxTasaAnualSinIVA.Enabled = false;
                    this.txtBoxIVA.Enabled = false;

                    this.btnEliminarPlan.Enabled = true;
                    this.btnEditarPlan.Enabled = true;
                    this.btnGuardarPlan.Enabled = false;
                    this.btnCancelarPlan.Enabled = true;

                    this.texBoxNombrePlan.Text = dsPlanes.Tables["planprestamo"].Rows[index][5].ToString();
                    this.txtBoxCantCuotas.Text = dsPlanes.Tables["planprestamo"].Rows[index][1].ToString();
                    this.txtBoxTasaAnualSinIVA.Text = dsPlanes.Tables["planprestamo"].Rows[index][2].ToString();
                    this.txtBoxIVA.Text = dsPlanes.Tables["planprestamo"].Rows[index][3].ToString();

                    if (Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][4].ToString()) == 1)
                    {
                        this.chkVigencia.Checked = true;
                    }
                    else
                    {
                        this.chkVigencia.Checked = false;
                    }
                }
            }
        }

        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            {
                this.nuevo = true;

                this.cmbPlan.Enabled = false;
                this.cmbPlan.SelectedIndex = -1;

                this.texBoxNombrePlan.Clear();
                this.texBoxNombrePlan.Enabled = true;

                this.txtBoxCantCuotas.Clear();
                this.txtBoxCantCuotas.Enabled = true;

                this.txtBoxTasaAnualSinIVA.Clear();
                this.txtBoxTasaAnualSinIVA.Enabled = true;

                this.txtBoxIVA.Clear();
                this.txtBoxIVA.Enabled = true;

                this.btnEditarPlan.Enabled = false;
                this.btnEliminarPlan.Enabled = false;
                this.btnCancelarPlan.Enabled = true;
                this.btnGuardarPlan.Enabled = true;
                this.chkVigencia.Enabled = true;

            }
        }

        private void btnSalirPlan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarPlan_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.pantallaInicial();
        }

        private void btnGuardarPlan_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                this.nuevoPlan();
            }
            else
            {
                this.editarPlan();
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

        public bool esEntero(string nroPrueba)
        {
            int resultado = 0;
            Boolean esEntero = int.TryParse(nroPrueba, out resultado);

            Boolean esPositivo = false;

            if (esEntero)
            {

                if (resultado > 0)
                {
                    esPositivo = true;
                }
            }

            return esEntero && esPositivo;
        }

        private void editarPlan()
        {
            bool valido = true;

            this.lblCantCuotas.Visible = false;
            this.lblNombre.Visible = false;
            this.lblTasaAnual.Visible = false;
            this.lblErrorGenerico.Visible = false;

            // Control de campos obligatorios 
            if (this.texBoxNombrePlan.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxCantCuotas.Text.Trim() == "")
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esEntero(txtBoxCantCuotas.Text)))
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Ingrese Nro Entero";
                valido = false;
            }

            if (this.txtBoxTasaAnualSinIVA.Text.Trim() == "")
            {
                this.lblTasaAnual.Visible = true;
                this.lblTasaAnual.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esDecimal(txtBoxTasaAnualSinIVA.Text)))
            {
                this.lblTasaAnual.Visible = true;
                this.lblTasaAnual.Text = "Ingrese número válido";
                valido = false;
            }

            if (this.txtBoxIVA.Text.Trim() == "")
            {
                this.lblIva.Visible = true;
                this.lblIva.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esDecimal(txtBoxIVA.Text)))
            {
                this.lblIva.Visible = true;
                this.lblIva.Text = "Ingrese número válido";
                valido = false;
            }

            int index = this.cmbPlan.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
            {
                if (Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString()) != Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][0].ToString()))
                {
                    if (this.texBoxNombrePlan.Text.Trim() == dsPlanes.Tables["planprestamo"].Rows[i][1].ToString())
                    {
                        this.lblNombre.Visible = true;
                        this.lblNombre.Text = "Ya exíste";
                        valido = false;
                    }

                }
            }

            if (valido)
            {

                string message = "¿Está seguro de que desea modificar el plan?";
                string caption = "Modificar plan";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int vigencia;

                        if (chkVigencia.Checked)
                        {
                            vigencia = 1;
                        }
                        else
                        {
                            vigencia = 0;
                        }

                        double CuotaCada1000 = 0; // Calcular luego de hablar con la coop

                        empresa.ModificarPlan(Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString()), Convert.ToInt32(txtBoxCantCuotas.Text), Convert.ToDouble(txtBoxTasaAnualSinIVA.Text.Replace(".", ",")), Convert.ToDouble(txtBoxIVA.Text.Replace(".", ",")), vigencia, texBoxNombrePlan.Text, CuotaCada1000);
                        MessageBox.Show("Plan modificado correctamente");

                        //Cargo Planes
                        dsPlanes = empresa.DevolverPlanes();
                        pantallaInicial();
                    }
                    catch (Exception ex)
                    {
                        this.lblErrorGenerico.Visible = true;
                        this.lblErrorGenerico.Text = ex.Message;
                    }
                    this.lblCantCuotas.Visible = false;
                    this.lblNombre.Visible = false;
                    this.lblTasaAnual.Visible = false;

                }
            }
        }

        private void nuevoPlan()
        {
            bool valido = true;

            this.lblNombre.Visible = false;
            this.lblCantCuotas.Visible = false;
            this.lblTasaAnual.Visible = false;
            this.lblIva.Visible = false;
            this.lblErrorGenerico.Visible = false;

            // Control de campos obligatorios 
            if (this.texBoxNombrePlan.Text.Trim() == "")
            {
                this.lblNombre.Visible = true;
                this.lblNombre.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxCantCuotas.Text.Trim() == "")
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esEntero(txtBoxCantCuotas.Text)))
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Ingrese Nro Entero";
                valido = false;
            }

            if (this.txtBoxTasaAnualSinIVA.Text.Trim() == "")
            {
                this.lblTasaAnual.Visible = true;
                this.lblTasaAnual.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esDecimal(txtBoxTasaAnualSinIVA.Text)))
            {
                this.lblTasaAnual.Visible = true;
                this.lblTasaAnual.Text = "Ingrese número válido";
                valido = false;
            }

            if (this.txtBoxIVA.Text.Trim() == "")
            {
                this.lblIva.Visible = true;
                this.lblIva.Text = "Campo obligatorio";
                valido = false;
            }
            else if (!(esDecimal(txtBoxIVA.Text)))
            {
                this.lblIva.Visible = true;
                this.lblIva.Text = "Ingrese número válido";
                valido = false;
            }

            int index = this.cmbPlan.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
            {
                if (this.texBoxNombrePlan.Text.Trim() == dsPlanes.Tables["planprestamo"].Rows[i][5].ToString())
                {
                    this.lblNombre.Visible = true;
                    this.lblNombre.Text = "Ya exíste";
                    valido = false;
                }

            }

            if (valido)
            {
                try
                {
                    int vigencia;

                    if (chkVigencia.Checked)
                    {
                        vigencia = 1;
                    }
                    else
                    {
                        vigencia = 0;
                    }

                    double CuotaCada1000 = 0; // Calcular luego de hablar con la coop

                    empresa.AltaPlan(Convert.ToInt32(txtBoxCantCuotas.Text), Convert.ToDouble(txtBoxTasaAnualSinIVA.Text.Replace(".", ",")), Convert.ToDouble(txtBoxIVA.Text.Replace(".", ",")), vigencia, texBoxNombrePlan.Text, CuotaCada1000);

                    MessageBox.Show("Plan creado correctamente");

                    //Cargo planes
                    dsPlanes = empresa.DevolverPlanes();
                    pantallaInicial();


                }
                catch (Exception ex)
                {
                    this.lblErrorGenerico.Visible = true;
                    this.lblErrorGenerico.Text = ex.Message;
                }
                this.lblCantCuotas.Visible = false;
                this.lblNombre.Visible = false;
                this.lblTasaAnual.Visible = false;
            }

        }

        private void btnEliminarPlan_Click(object sender, EventArgs e)
        {
            int index = this.cmbPlan.SelectedIndex;

            if (index == -1) MessageBox.Show("Debe seleccionar un plan");
            else
            {
                string message = "¿Está seguro de que desea eliminar el plan?";
                string caption = "Baja Plan de Préstamos";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);



                if (result == System.Windows.Forms.DialogResult.Yes)
                {


                    try
                    {
                        empresa.bajaPlan(Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString()));

                        MessageBox.Show("Plan eliminado correctamente");

                        //Cargo Planes
                        dsPlanes = empresa.DevolverPlanes();
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

        private void btnEditarPlan_Click(object sender, EventArgs e)
        {
            this.nuevo = false;

            this.cmbPlan.Enabled = false;

            this.texBoxNombrePlan.Enabled = true;

            this.txtBoxCantCuotas.Enabled = true;

            this.txtBoxTasaAnualSinIVA.Enabled = true;

            this.txtBoxIVA.Enabled = true;

            this.btnGuardarPlan.Enabled = true;
            this.btnEditarPlan.Enabled = true;
            this.btnCancelarPlan.Enabled = true;
            this.btnEliminarPlan.Enabled = false;
            this.btnNuevoPlan.Enabled = false;
            this.chkVigencia.Enabled = true;

            this.btnEditarPlan.Enabled = false;

        }
    }
}
