using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilidades;


namespace COOPMEF
{
    class inicio
    {
        static void Main(string[] args)
        {
            String ruta = "C:\\config.ini";

            setearAccesoBD accesoBd = new setearAccesoBD();
            try
            {
                accesoBd.cargarParametrosConexion(ruta);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder al archivo de configuraciones config.ini");
            }

            frmLogin login = new frmLogin();
            login.ShowDialog();
          

        }
    }
}
