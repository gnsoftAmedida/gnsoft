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
    public partial class frmAgenda : Form
    {
        private Controladora empresa = Controladora.Instance;
        DataSet dsEventos;

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            DateTime hoy;
            hoy = DateTime.Today;
            this.cargarEventos(hoy);
        }

        private void cargarEventos(DateTime fecha)
        {

            dsEventos = empresa.DevolverEventos(fecha);
            this.dgvEventos.DataSource = dsEventos.Tables["eventos"];

            dgvEventos.RowHeadersVisible = false;
            dgvEventos.ReadOnly = true;
            dgvEventos.MultiSelect = false;
            dgvEventos.ReadOnly = true;
            dgvEventos.AllowDrop = false;
            dgvEventos.AllowUserToAddRows = false;
            dgvEventos.AllowUserToDeleteRows = false;
            dgvEventos.AllowUserToResizeColumns = false;
            dgvEventos.AllowUserToResizeRows = false;
            dgvEventos.AllowUserToOrderColumns = false;
            dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEventos.BackgroundColor = BackColor;
            dgvEventos.BorderStyle = BorderStyle.None;
            dgvEventos.Columns["evento_id"].Visible = false;
            dgvEventos.Columns["fecha"].HeaderText = "Fecha";
            dgvEventos.Columns["fecha"].Width = 90;
            dgvEventos.Columns["descripcion"].HeaderText = "Descripcion";
            dgvEventos.Columns["descripcion"].Width = 300;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje;
            DateTime fecha;
            try
            {
                if (txtDescripcion.Text.Trim() == "")
                {
                    throw new Exception("Ingrese decripción de evento");
                }
                else
                {
                    fecha = dtpFecha.Value;
                    empresa.guardarEvento(fecha, txtDescripcion.Text);
                    mensaje = "Evento ingresado correctamente";

                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Ingreso evento en agenda");

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            MessageBox.Show(mensaje);
            this.txtDescripcion.Clear();
            cargarEventos(dtpFecha.Value);

        }

        private void cloEventos_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fecha = cloEventos.SelectionEnd.Date;
            this.cargarEventos(fecha);
            this.tabControl1.SelectedTab = this.tabControl1.TabPages[0];
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String mensaje = "";

            if (dgvEventos.SelectedRows.Count > 0)
            {

                string message = "¿Está seguro de que desea eliminar el evento?";
                string caption = "Eliminar evento";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    try
                    {
                        if (dgvEventos.SelectedRows.Count > 0)
                        {
                            int index = dgvEventos.CurrentRow.Index;
                            int idEvento = (int)dgvEventos.Rows[index].Cells["evento_id"].Value;
                            empresa.BajaEvento(idEvento);

                              RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Eliminar evento en agenda");

                            DateTime fecha = cloEventos.SelectionEnd.Date;
                            this.cargarEventos(fecha);
                        }
                    }
                    catch (Exception ex)
                    {
                        mensaje = ex.Message;
                        MessageBox.Show(mensaje);
                    }
                }
            }
            else
            {
                mensaje = "Seleccione un evento";
                MessageBox.Show(mensaje);
            }
        }

        private void dgvEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mensaje = "";
            if (!(dgvEventos.CurrentRow == null))
            {
                int index = (int)dgvEventos.CurrentRow.Cells[0].Value;
                frmModificarEvento frmModificarEvento = new frmModificarEvento(index);
                frmModificarEvento.ShowDialog();
           
                DateTime fecha = cloEventos.SelectionEnd.Date;
                this.cargarEventos(fecha);
            }
            else
            {
                mensaje = "Debe seleccionar un evento";
                MessageBox.Show(mensaje);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.tabControl1.SelectedTab == this.tabControl1.TabPages[0])
            {
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = true;
            }
            else {
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = false;            
            };         
        }
    }
}
