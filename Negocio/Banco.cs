using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Banco
    {
        private int codigobanco;
        private string nombrebanco;
        private string agenciabanco;
        private string direccionbanco;
        private string telefonobanco;
        private string faxbanco;
        private string numerocta;
        private string moneda;
        private Double saldo;

        public int Codigobanco
        {
            get { return codigobanco; }
            set { codigobanco = value; }
        }

        public string Nombrebanco
        {
            get { return nombrebanco; }
            set { nombrebanco = value; }
        }

        public string Agenciabanco
        {
            get { return agenciabanco; }
            set { agenciabanco = value; }
        }

        public string Direccionbanco
        {
            get { return direccionbanco; }
            set { direccionbanco = value; }
        }

        public string Telefonobanco
        {
            get { return telefonobanco; }
            set { telefonobanco = value; }
        }

        public string Faxbanco
        {
            get { return faxbanco; }
            set { faxbanco = value; }
        }

        public string Numerocta
        {
            get { return numerocta; }
            set { numerocta = value; }
        }

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public Double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }


        public DataSet devolverBancos()
        {
            pBanco tmpBanco = new pBanco();
            DataSet bancos = tmpBanco.devolverTodos();
            return bancos;
        }

        public void actualizarSaldo()
        {
            pBanco tmpBanco = new pBanco();
            tmpBanco.actualizarSaldo(Codigobanco, Saldo);
        }

        public void Guardar()
        {
            pBanco tmpBanco = new pBanco();
            tmpBanco.GuardarBanco(Nombrebanco, Agenciabanco, Direccionbanco, Telefonobanco, Faxbanco, Numerocta, Moneda);
        }

        public void eliminar()
        {
            pBanco tmpBanco = new pBanco();
            tmpBanco.eliminarBanco(this.Codigobanco);
        }

        public void modificarBanco()
        {
            pBanco tmpBanco = new pBanco();
            tmpBanco.modificarBanco(Codigobanco, Nombrebanco, Agenciabanco, Direccionbanco, Telefonobanco, Faxbanco, Numerocta, Moneda);
        }
    }
}
