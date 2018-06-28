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
    public partial class frmPadronEdades : Form
    {
        private Controladora empresa = Controladora.Instance;

        public frmPadronEdades()
        {
            InitializeComponent();
        }

        private void frmPadronEdades_Load(object sender, EventArgs e)
        {

        }

        private void btnSalirCobranza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int EdadPersona(DateTime FechaNacimiento)
        {
            int age = DateTime.Today.Year - FechaNacimiento.Year;
            if (DateTime.Today.Month < FechaNacimiento.Month || (DateTime.Today.Month == FechaNacimiento.Month && DateTime.Today.Day < FechaNacimiento.Day))
                age--;
            return age;
        }

        private void btnGuardarPrestamo_Click(object sender, EventArgs e)
        {
            int franjas = Convert.ToInt32(cmbFranjas.SelectedItem.ToString());
            int edadComienzo = Convert.ToInt32(cmbEdadComienzo.SelectedItem.ToString());
            int intervalo = Convert.ToInt32(cmbIntervalo.SelectedItem.ToString());
            DateTime fechaIngreso = Convert.ToDateTime(dtpFechaIng.Value.ToShortDateString());

            DataSet dsSocios = empresa.DevolverSocios();

            for (int i = 0; dsSocios.Tables["socios"].Rows.Count > 0; i++)
            {

                int edad = EdadPersona(Convert.ToDateTime(dsSocios.Tables["socios"].Rows[i][5].ToString()));
                DateTime tempFechaIngreso = Convert.ToDateTime(dsSocios.Tables["socios"].Rows[i][6].ToString());

                if (edad >= edadComienzo && tempFechaIngreso <= fechaIngreso)
                {

                    int contSexoFMontevideo = 0;
                    int contSexoFInterior = 0;
                    int contSexoMMontevideo = 0;
                    int contSexoMInterior = 0;
                    int franjaTemporal = 0;
                    int tempEdad = edadComienzo;
                    string tempSexo;
                    string tempDepto;

                    for (int x = 1; x <= franjas; x++)
                    {

                        if (edad >= tempEdad && edad <= tempEdad + intervalo)
                        {

                            tempSexo = dsSocios.Tables["socios"].Rows[i][8].ToString();
                            tempDepto = dsSocios.Tables["socios"].Rows[i][19].ToString();

                            if (tempSexo == "F" && tempDepto == "Montevideo")
                                contSexoFMontevideo++;

                            if (tempSexo == "F" && tempDepto != "Montevideo")
                                contSexoFInterior++;

                            if (tempSexo == "M" && tempDepto == "Montevideo")
                                contSexoMMontevideo++;

                            if (tempSexo == "M" && tempDepto != "Montevideo")
                                contSexoMInterior++;
                        }

                        //meter en datagrid de alguna forma
                        
                         contSexoFMontevideo = 0;
                         contSexoFInterior = 0;
                         contSexoMMontevideo = 0;
                         contSexoMInterior = 0;

                        tempEdad = tempEdad + intervalo;
                        franjaTemporal++;
                    }
                }
            }
        }

        private void dgvSociosPadron_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
