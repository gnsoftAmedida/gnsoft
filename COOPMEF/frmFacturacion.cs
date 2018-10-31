using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using COOPMEF.CrystalDataSets;
using System.IO;

namespace COOPMEF
{
    public partial class frmFacturacion : Form
    {
        private Controladora empresa = Controladora.Instance;
        private dsFactura tmpDsFactura = new dsFactura();

        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void btnSalirPrestamo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            int anio = 2018;
            int posAnio = 38;
            int anioActual = DateTime.Today.Year;

            posAnio = anioActual - anio + posAnio;

            try
            {
                cmbAnios.SelectedIndex = posAnio;
                cmbMeses.SelectedIndex = DateTime.Today.Month - 1;
            }
            catch
            {
                MessageBox.Show("Verifique que la fecha de su ordenador sea correcta");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int mes = Convert.ToInt32(this.cmbMeses.SelectedIndex + 1);
            string mesNombre = cmbMeses.SelectedItem.ToString(); ;
            string anio = cmbAnios.SelectedItem.ToString();

            string presupuesto;

            if (mes < 10)
            {
                presupuesto = "0" + mes + "/" + anio;
            }
            else
            {
                presupuesto = mes + "/" + anio;
            }

            DataSet facturasPresupuesto = empresa.facturacion(presupuesto);

            if (facturasPresupuesto.Tables["facturacion"].Rows.Count > 0)
            {

                StreamWriter swd = new StreamWriter("C:\\Facturas\\facturacion_"  + DateTime.Today.ToString("dd_MM_yyyy") + ".TXT", true);
                String r="";

                for (int n = 0; n <= facturasPresupuesto.Tables["facturacion"].Rows.Count - 1; n++)
                {
                    string socio_apellido = facturasPresupuesto.Tables["facturacion"].Rows[n][0].ToString();
                    string socio_nombre = facturasPresupuesto.Tables["facturacion"].Rows[n][1].ToString();
                    string inciso_codigo = facturasPresupuesto.Tables["facturacion"].Rows[n][2].ToString();
                    string oficina_codigo = facturasPresupuesto.Tables["facturacion"].Rows[n][3].ToString();
                    string InteresCuota = facturasPresupuesto.Tables["facturacion"].Rows[n][4].ToString();
                    string ivaCuota = facturasPresupuesto.Tables["facturacion"].Rows[n][5].ToString();
                    string mora = facturasPresupuesto.Tables["facturacion"].Rows[n][6].ToString();
                    string ivaMora = facturasPresupuesto.Tables["facturacion"].Rows[n][7].ToString();

                    string vale = facturasPresupuesto.Tables["facturacion"].Rows[n][10].ToString();
                    string cedula = facturasPresupuesto.Tables["facturacion"].Rows[n][11].ToString();

                    cedula = cedula.Replace(".", "").Replace(",", "").Replace("-", "");
                    
                    Double descartoCeros = Convert.ToDouble(InteresCuota) + Convert.ToDouble(ivaCuota) + Convert.ToDouble(mora) + Convert.ToDouble(ivaMora);

                    if (!(descartoCeros == 0))
                    {
                        string nombre_apellido_inciso_oficina = socio_apellido + "," + socio_nombre + "(" + inciso_codigo + "/" + oficina_codigo + ")";

                        Double subtotal_1 = Convert.ToDouble(InteresCuota) + Convert.ToDouble(mora);
                        Double subtotal_2 = Convert.ToDouble(ivaCuota) + Convert.ToDouble(ivaMora);
                        Double total = subtotal_1 + subtotal_2;
                        String iva1 = "";
                        String iva2 = "";
                        String fecha = DateTime.Today.ToShortDateString();

                        if (InteresCuota == "0")
                        {
                            InteresCuota = "00,0";
                        }
                        else
                        {
                            InteresCuota = Convert.ToDouble(InteresCuota).ToString("##########.00");
                        }

                        if (ivaCuota == "0")
                        {
                            ivaCuota = "00,0";
                            iva1 = "0";
                        }
                        else
                        {
                            ivaCuota = Convert.ToDouble(ivaCuota).ToString("##########.00");
                            iva1 = ((Convert.ToDouble(ivaCuota) * 100) / Convert.ToDouble(InteresCuota)).ToString("##########.00"); ;

                        }

                        if (mora == "0")
                        {
                            mora = "00,0";
                        }
                        else
                        {
                            mora = Convert.ToDouble(mora).ToString("##########.00");
                        }

                        if (ivaMora == "0")
                        {
                            ivaMora = "00,0";
                            iva2 = "0";
                        }
                        else
                        {
                            ivaMora = Convert.ToDouble(ivaMora).ToString("##########.00");
                            iva2 = ((Convert.ToDouble(ivaMora) * 100) / Convert.ToDouble(mora)).ToString("##########.00"); ;
                        }

                        String subtotal_1_string;

                        if (subtotal_1 == 0)
                        {
                            subtotal_1_string = "0,00";

                        }
                        else
                        {
                            subtotal_1_string = subtotal_1.ToString("##########.00");

                        }

                        String subtotal_2_string;

                        if (subtotal_2 == 0)
                        {
                            subtotal_2_string = "0,00";

                        }
                        else
                        {
                            subtotal_2_string = subtotal_2.ToString("##########.00");
                        }

                        String total_string;
                        if (total == 0)
                        {
                            total_string = "0,00";
                        }
                        else
                        {
                            total_string = total.ToString("##########.00");
                        }

                        r = cedula + "|" + socio_nombre + "|" + socio_apellido + "|" + "(" + inciso_codigo + "/" + oficina_codigo + ")" + "|" + vale + "|" + DateTime.Today.ToString("dd-MM-yyyy") + "|" + "interes_cuota" + ":" + InteresCuota + "|" + "iva_cuota:" + ivaCuota + "|" + "mora" + ":" + mora + "|" + "iva_mora" + ":" + ivaMora + "|" + "subtotal" + ":" + subtotal_1_string + "|" + "iva" + ":" + subtotal_2_string + "|" + "total" + ":" + total_string;

                        swd.WriteLine(r);

                        tmpDsFactura.factura.Rows.Add(nombre_apellido_inciso_oficina, InteresCuota, ivaCuota, mora, ivaMora, fecha, subtotal_1_string, subtotal_2_string, total_string, iva1, iva2);
                    }
                }

                swd.Flush();
                swd.Dispose();

                string message = "Facturas generadas correctamente, ¿desea ver los comprobantes?";
                string caption = "Gestión COOPMEF";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    frmVerReportes reporte = new frmVerReportes(tmpDsFactura, "FACTURAS");
                    reporte.ShowDialog();
                    tmpDsFactura.factura.Rows.Clear();    
                }                
            }
            else
            {
                MessageBox.Show("No se encuentran facturas para emitir");
            }
        }
    }
}
