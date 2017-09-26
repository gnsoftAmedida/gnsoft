using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;

namespace Negocio
{
    class Empresa
    {
        private int empresa_id;
        private string empresa_nombre;
        private string empresa_sigla;
        private string empresa_direccion;
        private int empresa_departamento;
        private string empresa_codigoPostal;
        private string empresa__telefono;
        private string empresa_fax;
        private string empresa_rut;
        private int empresa_aporte;
        private int empresa_MaxUnidad;
        private int empresa_iva;
        private int empresa_intMora;
        private string empresa_mail;
        private string empresa_presidente;
        private string empresa__tesorero;
        private string empresa_secretario;
        private string empresa_primerVocal;
        private string empresa_segundoVocal;
        private DateTime empresa_fechaEleccion;

        public int Empresa_id { get; set; }
        public string Empresa_sigla { get; set; }
        public string Empresa_nombre { get; set; }
        public string Empresa_direccion { get; set; }
        public string Empresa_departamento { get; set; }
        public string Empresa_codigoPostal { get; set; }
        public string Empresa__telefono { get; set; }
        public string Empresa_fax { get; set; }
        public string Empresa_rut { get; set; }
        public int Empresa_aporte { get; set; }
        public int Empresa_MaxUnidad { get; set; }
        public int Empresa_iva { get; set; }
        public int Empresa_intMora { get; set; }
        public string Empresa_mail { get; set; }
        public string Empresa_presidente { get; set; }
        public string Empresa__tesorero { get; set; }
        public string Empresa_secretario { get; set; }
        public string Empresa_primerVocal { get; set; }
        public string Empresa_segundoVocal { get; set; }
        public DateTime Empresa_fechaEleccion { get; set; }

        public void Guardar()
        {
            pEmpresa tmpEmpresa = new pEmpresa();
            tmpEmpresa.GuardarEmpresa( Empresa_nombre,  Empresa_sigla,  Empresa_direccion,  Empresa_departamento,  Empresa_codigoPostal,  Empresa__telefono,  Empresa_fax,  Empresa_rut,  Empresa_aporte,  Empresa_MaxUnidad,  Empresa_iva,  Empresa_intMora,  Empresa_mail,  Empresa_presidente,  Empresa__tesorero,
             Empresa_secretario,  Empresa_primerVocal,  Empresa_segundoVocal,  Empresa_fechaEleccion);
        }


    }

    

        
}
