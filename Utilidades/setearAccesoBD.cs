using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Encriptador;

namespace Utilidades
{
    public class setearAccesoBD
    {
        public void cargarParametrosConexion(String ruta)
        {

            char[] delimitador = { ' ' };

            CCryptorEngine crypto = new CCryptorEngine();

            StreamReader osR = null;

            try
            {

                osR = new StreamReader(ruta);

                string txt = osR.ReadToEnd();

                string Linea = crypto.Desencriptar(txt);

                ruta = Linea;

                ruta = ruta.Replace("\r\n", " ");

                string[] words = ruta.Split(delimitador);

                for (int i = 0; i < words.Length; i++)
                {

                    string[] linea = words[i].Split('=');

                    if (linea[0] == "usuario")
                    {
                        VariablesGlobales.Usuario = linea[1];
                    }

                    if (linea[0] == "clave")
                    {
                        VariablesGlobales.Clave = linea[1];
                    }

                    if (linea[0] == "nombreBD")
                    {
                        VariablesGlobales.NombreBD = linea[1];
                    }

                    if (linea[0] == "servidor")
                    {
                        VariablesGlobales.Servidor = linea[1];
                    }

                    if (linea[0] == "licencia")
                    {
                        VariablesGlobales.Licencia = linea[1];
                    }

                    if (linea[0] == "vencimiento")
                    {
                        VariablesGlobales.Vencimiento = linea[1];
                    }
                }

                osR.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
