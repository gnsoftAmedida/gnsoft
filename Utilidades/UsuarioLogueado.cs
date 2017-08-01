using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilidades
{
    public static class UsuarioLogueado
    {
        private static string alias = "";
        private static int idUsuario = 0;

        public static int IdUsuario
        {
            get { return UsuarioLogueado.idUsuario; }
            set { UsuarioLogueado.idUsuario = value; }
        }

        public static string Alias
        {
            get { return alias; }
            set { alias = value; }
        }

    }
}
