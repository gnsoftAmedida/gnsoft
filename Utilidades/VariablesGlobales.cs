using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public static class VariablesGlobales
    {
        private static string usuario = "";
        private static string clave = "";
        private static string nombreBD = "";
        private static string servidor = "";
        private static string licencia = "";
        private static string vencimiento = "";

        public static string Usuario
        {
            get { return VariablesGlobales.usuario; }
            set { VariablesGlobales.usuario = value; }
        }

        public static string Clave
        {
            get { return VariablesGlobales.clave; }
            set { VariablesGlobales.clave = value; }
        }

        public static string NombreBD
        {
            get { return VariablesGlobales.nombreBD; }
            set { VariablesGlobales.nombreBD = value; }
        }

        public static string Servidor
        {
            get { return VariablesGlobales.servidor; }
            set { VariablesGlobales.servidor = value; }
        }

        public static string Licencia
        {
            get { return VariablesGlobales.licencia; }
            set { VariablesGlobales.licencia = value; }
        }

        public static string Vencimiento
        {
            get { return VariablesGlobales.vencimiento; }
            set { VariablesGlobales.vencimiento = value; }
        }
    }
}
