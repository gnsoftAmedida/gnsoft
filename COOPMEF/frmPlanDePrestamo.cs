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

        public frmPlanDePrestamo()
        {
            InitializeComponent();
        }

       
        private void frmPlanDePrestamo_Load(object sender, EventArgs e)
        {
            //Cargo planes
            dsPlanes = empresa.DevolverPlanes();
            pantallaInicial();
        }

        public void pantallaInicial()
        {
            this.cmbPlan.DataSource = dsPlanes.Tables["planprestamo"];
            this.cmbPlan.ValueMember = "plan_descripcion";
            this.cmbPlan.SelectedIndex = -1;
            this.cmbPlan.Enabled = true;
            this.cmbPlan.Text = "";
            this.btnEditarPlan.Enabled = false;
            this.btnNuevoPlan.Enabled = true;
            this.btnEliminarPlan.Enabled = false;
            this.texBoxDescripcion.Enabled = false;
            this.txtBoxCantCuotas.Enabled = false;
            this.txtBoxInteres.Enabled = false;
            this.texBoxDescripcion.Clear();
            this.txtBoxCantCuotas.Clear();
            this.txtBoxInteres.Clear();
            this.lblCantCuotas.Visible = false;
            this.lblDescripcion.Visible = false;
            this.lblInteres.Visible = false;
            this.lblErrorGenerico.Visible = false;

        }

        private void cmbPLan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbPlan.SelectedIndex;
            if (index != -1)
            {
                this.texBoxDescripcion.Enabled = false;
                this.txtBoxCantCuotas.Enabled = false;
                this.txtBoxInteres.Enabled = false;

                this.btnEliminarPlan.Enabled = true;
                this.btnEditarPlan.Enabled = true;
                this.btnGuardarPlan.Enabled = false;
                this.btnCancelarPlan.Enabled = true;

                this.texBoxDescripcion.Text = dsPlanes.Tables["planprestamo"].Rows[index][2].ToString();
                this.txtBoxCantCuotas.Text = dsPlanes.Tables["planprestamo"].Rows[index][3].ToString();
                this.txtBoxInteres.Text = dsPlanes.Tables["planprestamo"].Rows[index][4].ToString();
            }
        }
        
        private void btnNuevoPlan_Click(object sender, EventArgs e)
        {
            {
                this.nuevo = true;

                this.cmbPlan.Enabled = false;
                this.cmbPlan.SelectedIndex = -1;

                this.texBoxDescripcion.Clear();
                this.texBoxDescripcion.Enabled = true;

                this.txtBoxCantCuotas.Clear();
                this.txtBoxCantCuotas.Enabled = true;

                this.txtBoxInteres.Clear();
                this.txtBoxInteres.Enabled = true;

                this.btnEditarPlan.Enabled = false;
                this.btnEliminarPlan.Enabled = false;
                this.btnCancelarPlan.Enabled = true;
                this.btnGuardarPlan.Enabled = true;

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

        private void editarPlan()
        {
            bool valido = true;

            this.lblCantCuotas.Visible = false;
            this.lblDescripcion.Visible = false;
            this.lblInteres.Visible = false;
            this.lblErrorGenerico.Visible = false;

            // Control de campos obligatorios 
            if (this.texBoxDescripcion.Text.Trim() == "")
            {
                this.lblDescripcion.Visible = true;
                this.lblDescripcion.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxCantCuotas.Text.Trim() == "")
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxInteres.Text.Trim() == "")
            {
                this.lblInteres.Visible = true;
                this.lblInteres.Text = "Campo obligatorio";
                valido = false;
            }

            int index = this.cmbPlan.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
            {
                if (Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString()) != Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[i][0].ToString()))
                {
                    if (this.texBoxDescripcion.Text.Trim() == dsPlanes.Tables["planprestamo"].Rows[i][1].ToString())
                    {
                        this.lblDescripcion.Visible = true;
                        this.lblDescripcion.Text = "Ya exíste";
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
                        empresa.ModificarPlan(texBoxDescripcion.Text, Convert.ToInt32(txtBoxCantCuotas.Text), Convert.ToInt32(txtBoxInteres.Text), Convert.ToInt32(dsPlanes.Tables["planprestamo"].Rows[index][0].ToString()));
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
                    this.lblDescripcion.Visible = false;
                    this.lblInteres.Visible = false;

                }
            }
        }

        private void nuevoPlan()
        {
            bool valido = true;

            this.lblCantCuotas.Visible = false;
            this.lblDescripcion.Visible = false;
            this.lblInteres.Visible = false;
            this.lblErrorGenerico.Visible = false;

            // Control de campos obligatorios 
            if (this.texBoxDescripcion.Text.Trim() == "")
            {
                this.lblDescripcion.Visible = true;
                this.lblDescripcion.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxCantCuotas.Text.Trim() == "")
            {
                this.lblCantCuotas.Visible = true;
                this.lblCantCuotas.Text = "Campo obligatorio";
                valido = false;
            }

            if (this.txtBoxInteres.Text.Trim() == "")
            {
                this.lblInteres.Visible = true;
                this.lblInteres.Text = "Campo obligatorio";
                valido = false;
            }

            int index = this.cmbPlan.SelectedIndex;

            // Control de duplicado para código, nombre e inciso. Se hace en memoria y luego a nivel de BD
            for (int i = 0; i < dsPlanes.Tables["planprestamo"].Rows.Count; i++)
            {
                if (this.texBoxDescripcion.Text.Trim() == dsPlanes.Tables["planprestamo"].Rows[i][1].ToString())
                {
                    this.lblDescripcion.Visible = true;
                    this.lblDescripcion.Text = "Ya exíste";
                    valido = false;
                }

            }


            if (valido)
            {
                try
                {
                    empresa.AltaPlan(texBoxDescripcion.Text, texBoxDescripcion.Text, Convert.ToInt32(txtBoxCantCuotas.Text), Convert.ToInt32(txtBoxInteres.Text));

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
                this.lblDescripcion.Visible = false;
                this.lblInteres.Visible = false;
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

            this.texBoxDescripcion.Enabled = true;

            this.txtBoxCantCuotas.Enabled = true;

            this.txtBoxInteres.Enabled = true;

            this.btnGuardarPlan.Enabled = true;
            this.btnEditarPlan.Enabled = true;
            this.btnCancelarPlan.Enabled = true;
            this.btnEliminarPlan.Enabled = false;
            this.btnNuevoPlan.Enabled = false;

        }
    }
}
