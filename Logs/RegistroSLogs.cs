using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Persistencia;
using System.Data;

namespace Logs
{
    public class RegistroSLogs
    {
        //prueba
        delegate string DType(DateTime dia, String usuario, String registro); 

        public void invocarLogAsincronico(DateTime dia, String usuario, String registro)
        {
            DType method = new DType(grabarLog);
            IAsyncResult a = method.BeginInvoke(dia, usuario, registro, null, null);  
        }

        public DataSet devolverLogsSegunFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            pLog tmpLog = new pLog();
            return tmpLog.devolverLogsSegunFecha(fechaDesde, fechaHasta);
        }

        public String grabarLog(DateTime dia, String usuario, String registro)
        {

            String fecha = DateTime.Today.ToString("yyyyMMdd");
            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists("c:\\log\\log" + fecha + ".txt"))
            {
                log = new StreamWriter("c:\\log\\log" + fecha + ".txt");
                log.WriteLine("=====================================================");
                log.WriteLine("Día y Hora       " + "         Usuario     " + "   Registro    ");
                log.WriteLine("=====================================================");
                log.WriteLine();
            }
            else
            {
                log = File.AppendText("c:\\log\\log" + fecha + ".txt");
            }


            log.WriteLine(dia + "   " + usuario + "   " + registro);
            log.WriteLine();

            log.Close();

            pLog tmpLog = new pLog();
            tmpLog.guardarLog(dia, usuario, registro);

            return "log ok";
        }
    }
}
