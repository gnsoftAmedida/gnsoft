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
        // https://stackoverflow.com/questions/1366436/how-can-merge-a-particular-column-header-in-datagridview-c
        private Controladora empresa = Controladora.Instance;

        public frmPadronEdades()
        {
            InitializeComponent();
        }


        private void frmPadronEdades_Load(object sender, EventArgs e)
        {
            cmbFranjas.SelectedIndex = 3;
            cmbIntervalo.SelectedIndex = 9;
            cmbEdadComienzo.SelectedIndex = 17;
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
            dgvSociosPadron.Rows.Clear();

            int franjas = Convert.ToInt32(cmbFranjas.SelectedItem.ToString());
            int edadComienzo = Convert.ToInt32(cmbEdadComienzo.SelectedItem.ToString());
            int intervalo = Convert.ToInt32(cmbIntervalo.SelectedItem.ToString());
            DateTime fechaIngreso = Convert.ToDateTime(dtpFechaIng.Value.ToShortDateString());
            int estadoElegido = 1;

            if (radioButton1.Checked)
            {
                estadoElegido = 1;
            }
            else
            {
                estadoElegido = 0;
            }

            DataSet dsSocios = empresa.DevolverSocios();

            int cantidadSocios = dsSocios.Tables["socios"].Rows.Count;


            int contSexoFMontevideo = 0;
            int contSexoFInterior = 0;
            int contSexoMMontevideo = 0;
            int contSexoMInterior = 0;
            int franjaTemporal = 0;
            int totalFranja = 0;
            int tempEdad = edadComienzo;
            string tempSexo;
            string tempDepto;
            int contSexoFMontevideoTotal = 0;
            int contSexoFInteriorTotal = 0;
            int contSexoMMontevideoTotal = 0;
            int contSexoMInteriorTotal = 0;
            int totalFranjaTotal = 0;
            int totalSexoFem = 0;
            int totalSexoMasc = 0;




            for (int x = 1; x <= franjas; x++)
            {
                for (int i = 0; i < cantidadSocios; i++)
                {

                    int edad = EdadPersona(Convert.ToDateTime(dsSocios.Tables["socios"].Rows[i][5].ToString()));
                    DateTime tempFechaIngreso = Convert.ToDateTime(dsSocios.Tables["socios"].Rows[i][6].ToString());
                    int estado = Convert.ToInt32(dsSocios.Tables["socios"].Rows[i][19].ToString());

                    if (edad >= edadComienzo && tempFechaIngreso <= fechaIngreso && estadoElegido == estado)
                    {

                        //for (int x = 1; x <= franjas; x++)
                        // {

                        if (edad >= tempEdad && edad < tempEdad + intervalo)
                        {

                            tempSexo = dsSocios.Tables["socios"].Rows[i][8].ToString();
                            tempDepto = dsSocios.Tables["socios"].Rows[i][18].ToString();

                            if (tempSexo == "F" && tempDepto == "Montevideo")
                                contSexoFMontevideo++;

                            if (tempSexo == "F" && tempDepto != "Montevideo")
                                contSexoFInterior++;

                            if (tempSexo == "M" && tempDepto == "Montevideo")
                                contSexoMMontevideo++;

                            if (tempSexo == "M" && tempDepto != "Montevideo")
                                contSexoMInterior++;
                        }
                    }
                }

                totalFranja = contSexoFMontevideo + contSexoMMontevideo + contSexoFInterior + contSexoMInterior;

                int tempEdadMasIntervalo = tempEdad + intervalo;

                dgvSociosPadron.Rows.Add(">" + tempEdad + " <= " + tempEdadMasIntervalo, contSexoFMontevideo, contSexoMMontevideo, contSexoFInterior, contSexoMInterior, totalFranja);

                contSexoFMontevideoTotal = contSexoFMontevideoTotal + contSexoFMontevideo;
                contSexoFInteriorTotal = contSexoFInteriorTotal + contSexoFInterior;
                contSexoMMontevideoTotal = contSexoMMontevideoTotal + contSexoMMontevideo;
                contSexoMInteriorTotal = contSexoMInteriorTotal + contSexoMInterior;
                totalFranjaTotal = totalFranjaTotal + totalFranja;
                contSexoFMontevideo = 0;
                contSexoFInterior = 0;
                contSexoMMontevideo = 0;
                contSexoMInterior = 0;
                totalFranja = 0;
                tempEdad = tempEdad + intervalo;

            }
            lblTotalSexFMdeo.Text = contSexoFMontevideoTotal.ToString();
            lblTotalSexoMMdeo.Text = contSexoMMontevideoTotal.ToString();
            lblTotalSexoFINterior.Text = contSexoFInteriorTotal.ToString();
            lblTotalSexoMInterior.Text = contSexoMInteriorTotal.ToString();
            lblSumaTotales.Text = Convert.ToString(contSexoFMontevideoTotal + contSexoFInteriorTotal + contSexoMMontevideoTotal + contSexoMInteriorTotal);
            totalSexoFem = contSexoFMontevideoTotal + contSexoFInteriorTotal;
            totalSexoMasc = contSexoMMontevideoTotal + contSexoMInteriorTotal;
            lblTotalSexoFem.Text = totalSexoFem.ToString();
            lblTotalSexoMasc.Text = totalSexoMasc.ToString();

        }


        private void dgvSociosPadron_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
