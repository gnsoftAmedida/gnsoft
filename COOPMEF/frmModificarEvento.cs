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
    public partial class frmModificarEvento : Form
    {
        private int id;
        private Controladora empresa = Controladora.Instance;

        public frmModificarEvento(int idEvento)
        {
            this.id = idEvento;
            InitializeComponent();
        }

        private void frmModificarEvento_Load(object sender, EventArgs e)
        {
            DataSet evento = empresa.DevolverEvento(this.id);
            dtpFecha.Value = evento.Tables["evento"].Rows[0].Field<DateTime>("fecha");
            txtDescripcion.Text = evento.Tables["evento"].Rows[0].Field<String>("descripcion");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string mensaje;
            DateTime fecha;
            try
            {
                if (txtDescripcion.Text == "")
                {
                    throw new Exception("Ingrese decripción de evento");
                }
                else
                {
                    fecha = dtpFecha.Value;
                    empresa.modificarEvento(fecha, txtDescripcion.Text, this.id);
                    mensaje = "Evento modificado correctamente";

                    RegistroSLogs registroLogs = new RegistroSLogs();
                    registroLogs.grabarLog(DateTime.Now, Utilidades.UsuarioLogueado.Alias, "Evento modificado");

              
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
}
