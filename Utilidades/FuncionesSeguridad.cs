using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Utilidades
{
    public class FuncionesSeguridad
    {
        public static string encriptar(string laCadena)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] vectoBytes = System.Text.Encoding.UTF8.GetBytes(laCadena);
            byte[] inArray = sha1.ComputeHash(vectoBytes);
            sha1.Clear();
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Gets the MAC address of the current PC.
        /// </summary>
        /// <returns></returns>
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        public static string generarClave(int l)
        {
            Random aleatorio = new Random();
            string res = "";
            string[] vals = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "usuario", "mant", "usu", "net", DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Day.ToString(), "empleado", "emp", "sector", "clave", "contraseña", "password", "pass", "secreta", "secreto", "nico", "guille", "A", "B", "Cin", "Eje", "Dos", "Eje", "Ojo", "Paz", "Ramo", "Usu", "Xo", "Ya" };
            for (int i = 0; i <= l; i++)
            {
                res = res + vals[aleatorio.Next(vals.GetUpperBound(0) + 1)];
            }
            if (res.Length < 8)
            {
                res = generarClave(3);
            }
            return res;
        }
    }
}
