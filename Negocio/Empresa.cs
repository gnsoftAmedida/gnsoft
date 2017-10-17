using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

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

        private DateTime empresa_cierrePresupuestoAnterior;
        private DateTime empresa_horaCierreAnterior;
        private DateTime empresa_cierrePresupuestoActual;
        private DateTime empresa_horacierreactual;
        private DateTime empresa_vtoPresupuestoActual;
        private String empresa_usuarioCierre;

        public DateTime Empresa_cierrePresupuestoAnterior
        {
            get { return empresa_cierrePresupuestoAnterior; }
            set { empresa_cierrePresupuestoAnterior = value; }
        }

        public DateTime Empresa_horaCierreAnterior
        {
            get { return empresa_horaCierreAnterior; }
            set { empresa_horaCierreAnterior = value; }
        }

        public DateTime Empresa_cierrePresupuestoActual
        {
            get { return empresa_cierrePresupuestoActual; }
            set { empresa_cierrePresupuestoActual = value; }
        }

        public DateTime Empresa_horacierreactual
        {
            get { return empresa_horacierreactual; }
            set { empresa_horacierreactual = value; }
        }

        public DateTime Empresa_vtoPresupuestoActual
        {
            get { return empresa_vtoPresupuestoActual; }
            set { empresa_vtoPresupuestoActual = value; }
        }

        public String Empresa_usuarioCierre
        {
            get { return empresa_usuarioCierre; }
            set { empresa_usuarioCierre = value; }
        }

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
            tmpEmpresa.GuardarEmpresa(Empresa_nombre, Empresa_sigla, Empresa_direccion, Empresa_departamento, Empresa_codigoPostal, Empresa__telefono, Empresa_fax, Empresa_rut, Empresa_aporte, Empresa_MaxUnidad, Empresa_iva, Empresa_intMora, Empresa_mail, Empresa_presidente, Empresa__tesorero,
             Empresa_secretario, Empresa_primerVocal, Empresa_segundoVocal, Empresa_fechaEleccion);
        }

        public DataSet devolverEmpresa()
        {
            pEmpresa tmpEmpresa = new pEmpresa();
            DataSet empresas = tmpEmpresa.devolverTodos();
            return empresas;
        }

        public void modificarParametrosCierreEmpresa()
        {
            pEmpresa tmpEmpresa = new pEmpresa();
            tmpEmpresa.modificarParametrosCierreEmpresa(Empresa_cierrePresupuestoAnterior, Empresa_horaCierreAnterior, Empresa_cierrePresupuestoActual, Empresa_horacierreactual, Empresa_vtoPresupuestoActual, Empresa_usuarioCierre);
        }
    }
}
