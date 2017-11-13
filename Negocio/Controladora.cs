using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Utilidades;
using System.Globalization;
using Microsoft.VisualBasic;

namespace Negocio
{
    public sealed class Controladora
    {
        private static readonly Controladora instance = new Controladora();

        private Controladora() { }

        public static Controladora Instance
        {
            get
            {
                return instance;
            }
        }

        public bool controlarLicencia()
        {
            if (FuncionesSeguridad.GetMacAddress().ToString() == VariablesGlobales.Licencia.ToString())
            {
                return true;
            };
            return false;
        }

        public string validoCedula(string cedula)
        {
            int[] digitos = new int[7];
            int[] multipli = new int[7];
            int calculo = 0;
            int controldigito;
            int compara = 0;

            multipli[0] = 2;
            multipli[1] = 9;
            multipli[2] = 8;
            multipli[3] = 7;
            multipli[4] = 6;
            multipli[5] = 3;
            multipli[6] = 4;

            for (int i = 0; i < 7; i++)
            {
                digitos[i] = Convert.ToInt32(cedula.Substring(i, 1));
                calculo = calculo + digitos[i] * multipli[i];
            }

            controldigito = (calculo - (calculo / 10) * 10);

            if (controldigito == 0)
            {
                compara = controldigito;
            }
            else
            {
                compara = 10 - controldigito;
            }

            return compara.ToString();
        }

        public bool controlarVencimiento()
        {
            DateTime fechaVencimiento;
            DateTime fechaActual = DateTime.Today;

            fechaVencimiento = DateTime.ParseExact(VariablesGlobales.Vencimiento, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            fechaActual = DateTime.ParseExact(fechaActual.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);

            if (fechaVencimiento < fechaActual)
            {
                return false;
            }
            return true;
        }

        public void LoguearUsuario(string usuario, string clave)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Alias = usuario;
            tmpUsuario.Clave = clave;
            tmpUsuario.LoguearUsuario();
        }

        public DataSet DevolverAcciones()
        {
            Accion tmpAccion = new Accion();
            DataSet acciones = tmpAccion.DevolverTodos();
            return acciones;
        }

        public DataSet DevolverAccionesXUsuario(int idUsuario)
        {
            Accion tmpAccion = new Accion();
            DataSet acciones = tmpAccion.DevolverAccionesXUsuario(idUsuario);
            return acciones;
        }

        public void AltaUsuario(string alias, string clave, string correo, string telefono, ArrayList acciones)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Alias = alias;
            tmpUsuario.Clave = clave;
            tmpUsuario.Correo = correo;
            tmpUsuario.Telefono = telefono;
            tmpUsuario.AccionesPermitidas = acciones;
            tmpUsuario.Guardar();
        }

        public void AltaInciso(string Codigo, string Nombre, string Abreviatura)
        {
            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_codigo = Codigo;
            tmpInciso.Inciso_nombre = Nombre;
            tmpInciso.Inciso_abreviatura = Abreviatura;
            tmpInciso.Guardar();
        }

        public void AltaOficina(string codigo, string nombre, string abreviatura, string direccion, int idInciso, int idDepartamento, string codigoPostal, string telefono, string email, string nombreContacto)
        {
            Oficina tmpOficina = new Oficina();

            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_id = idInciso;

            Departamento tmpDepartamento = new Departamento();
            tmpDepartamento.Departamento_id = idDepartamento;

            tmpOficina.Oficina_codigo = codigo;
            tmpOficina.Oficina_nombre = nombre;
            tmpOficina.Oficina_abreviatura = abreviatura;
            tmpOficina.Oficina_direccion = direccion;
            tmpOficina.Oficina_inciso = tmpInciso;
            tmpOficina.Departamento = tmpDepartamento;
            tmpOficina.Oficina_codigopostal = codigoPostal;
            tmpOficina.Oficina_telefono = telefono;
            tmpOficina.Oficina_email = email;
            tmpOficina.Oficina_nombrecontacto = nombreContacto;
            tmpOficina.Guardar();
        }

        public void AltaEmpresa(String empresa_nombre, String empresa_sigla, String empresa_direccion, String empresa_departamento,
            String empresa_codigoPostal, string empresa__telefono, string empresa_fax, String empresa_rut,
            int empresa_aporte, int empresa_MaxUnidad, int empresa_iva, int empresa_intMora,
            string empresa_mail, string empresa_presidente, string empresa__tesorero, string empresa_secretario,
            string empresa_primerVocal, string empresa_segundoVocal, DateTime empresa_fechaEleccion)
        {
            Empresa tmpEmpresa = new Empresa();

            tmpEmpresa.Empresa_nombre = empresa_nombre;
            tmpEmpresa.Empresa_sigla = empresa_sigla;
            tmpEmpresa.Empresa_direccion = empresa_direccion;
            tmpEmpresa.Empresa_departamento = empresa_departamento;
            tmpEmpresa.Empresa_codigoPostal = empresa_codigoPostal;
            tmpEmpresa.Empresa__telefono = empresa__telefono;
            tmpEmpresa.Empresa_fax = empresa_fax;
            tmpEmpresa.Empresa_rut = empresa_rut;
            tmpEmpresa.Empresa_aporte = empresa_aporte;
            tmpEmpresa.Empresa_MaxUnidad = empresa_MaxUnidad;

            tmpEmpresa.Empresa_iva = empresa_iva;
            tmpEmpresa.Empresa_intMora = empresa_intMora;
            tmpEmpresa.Empresa_mail = empresa_mail;
            tmpEmpresa.Empresa_presidente = empresa_presidente;
            tmpEmpresa.Empresa__tesorero = empresa__tesorero;
            tmpEmpresa.Empresa_secretario = empresa_secretario;
            tmpEmpresa.Empresa_primerVocal = empresa_primerVocal;
            tmpEmpresa.Empresa_segundoVocal = empresa_segundoVocal;
            tmpEmpresa.Empresa_fechaEleccion = empresa_fechaEleccion;

            tmpEmpresa.Guardar();
        }

        public void modificarInciso(string Codigo, string Nombre, string Abreviatura, int idInciso)
        {
            Inciso tmpInciso = new Inciso();
            if (idInciso == 0)
                throw new Exception("Id del inciso no puede ser 0");

            tmpInciso.Inciso_codigo = Codigo;
            tmpInciso.Inciso_nombre = Nombre;
            tmpInciso.Inciso_abreviatura = Abreviatura;
            tmpInciso.Inciso_id = idInciso;
            tmpInciso.modificarInciso();
        }

        public void modificarOficina(string codigo, string nombre, string abreviatura, string direccion, int idInciso, int idDepartamento, string codigoPostal, string telefono, string email, string nombreContacto, int idOficina)
        {
            Oficina tmpOficina = new Oficina();

            Inciso tmpInciso = new Inciso();
            tmpInciso.Inciso_id = idInciso;

            Departamento tmpDepartamento = new Departamento();
            tmpDepartamento.Departamento_id = idDepartamento;

            tmpOficina.Oficina_codigo = codigo;
            tmpOficina.Oficina_nombre = nombre;
            tmpOficina.Oficina_abreviatura = abreviatura;
            tmpOficina.Oficina_direccion = direccion;
            tmpOficina.Oficina_inciso = tmpInciso;
            tmpOficina.Departamento = tmpDepartamento;
            tmpOficina.Oficina_codigopostal = codigoPostal;
            tmpOficina.Oficina_telefono = telefono;
            tmpOficina.Oficina_email = email;
            tmpOficina.Oficina_nombrecontacto = nombreContacto;
            tmpOficina.Oficina_id = idOficina;
            tmpOficina.modificarOficina();
        }

        public DataSet DevolverUsuarios()
        {
            Usuario tmpUsuario = new Usuario();
            DataSet usuarios = tmpUsuario.devolverUsuarios();
            return usuarios;
        }

        public DataSet DevolverHistoria()
        {
            Historia tmpHistoria = new Historia();
            DataSet historias = tmpHistoria.devolverHistoria();
            return historias;
        }

        public DataSet DevolverIncisos()
        {
            Inciso tmpInciso = new Inciso();
            DataSet incisos = tmpInciso.devolverIncisos();
            return incisos;
        }


        public DataSet DevolverCobranzas()
        {
            Cobranza tmpCobranza = new Cobranza();
            DataSet cobranzas = tmpCobranza.devolverCobranzas();
            return cobranzas;
        }

        public DataSet DevolverCobranzasProvisorias()
        {
            CobranzaProvisoria tmpCobranzaProvisoria = new CobranzaProvisoria();
            DataSet cobranzasProvisoria = tmpCobranzaProvisoria.devolverCobranzasProvisorias();
            return cobranzasProvisoria;
        }

        public DataSet DevolverEmpresa()
        {
            Empresa tmpInciso = new Empresa();
            DataSet empresas = tmpInciso.devolverEmpresa();
            return empresas;
        }

        public DataSet DevolverDepartamentos()
        {
            Departamento tmpDepartamento = new Departamento();
            DataSet departamentos = tmpDepartamento.devolverDepartamentos();
            return departamentos;
        }

        public DataSet DevolverOficinas()
        {
            Oficina tmpOficina = new Oficina();
            DataSet oficinas = tmpOficina.devolverOficinas();
            return oficinas;
        }

        public DataSet DevolverOficinasPorInciso(int idInciso)
        {
            Oficina tmpOficina = new Oficina();
            DataSet oficinasInciso = tmpOficina.devolverOficinasPorInciso(idInciso);
            return oficinasInciso;
        }

        public DataSet DevolverSocios()
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverSocios();
            return socios;
        }

        public DataSet DevolverSociosActivos()
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.devolverSociosActivos();
            return socios;
        }

        public void bajaPlan(int idPlan)
        {
            Plan tmpPlan = new Plan();
            //if (idPlan == 0)
            //    throw new Exception("Id del usuario no puede ser 0");

            tmpPlan.Plan_id = idPlan;
            tmpPlan.eliminar();
        }

        public void eliminarAmortizacionVencerCeroCobranza()
        {
            Cobranza tmpCobranza = new Cobranza();
            tmpCobranza.eliminarAmortizacionVencerCero();
        }




        public void bajaSocio(int idSocio, ref int estadoActual)
        {
            Socio tmpSocio = new Socio();
            //revisar que el socio no tenga prestamos activos  (pendiente)
            tmpSocio.Socio_id = idSocio;
            tmpSocio.eliminar(ref estadoActual);

        }

        public void buscarSocio(string socioNro)
        {
            Socio tmpSocio = new Socio();
            //revisar que el socio no tenga prestamos activos  (pendiente)
            tmpSocio.Socio_nro = socioNro;
            tmpSocio.buscar();

        }

        public DataSet buscarSociosPorCampo(string campo, string valor)
        {
            Socio tmpSocio = new Socio();
            DataSet socios = tmpSocio.buscarSociosPorCampo(campo, valor);
            return socios;
        }

        public void bajaInciso(int idInciso)
        {
            Inciso tmpInciso = new Inciso();
            if (idInciso == 0)
                throw new Exception("Id del usuario no puede ser 0");

            tmpInciso.Inciso_id = idInciso;
            tmpInciso.eliminar();
        }

        public void bajaOficina(int idOficina)
        {
            Oficina tmpOficina = new Oficina();
            if (idOficina == 0)
                throw new Exception("Id de oficina no puede ser 0");

            tmpOficina.Oficina_id = idOficina;
            tmpOficina.eliminar();
        }

        public DataSet DevolverPlanes()
        {
            Plan tmpPlan = new Plan();
            DataSet planes = tmpPlan.devolverPlanes();
            return planes;
        }

        public DataSet DevolverFechasCierres()
        {
            FechaCierre tmpFechaCierre = new FechaCierre();
            DataSet fechasCierres = tmpFechaCierre.devolverTodos();
            return fechasCierres;
        }

        public DataSet DevolverPlanesActivos()
        {
            Plan tmpPlan = new Plan();
            DataSet planes = tmpPlan.devolverActivos();
            return planes;
        }
        public void AltaPlan(int Plan_cantCuotas, double Plan_TasaAnualEfectiva, double Plan_IvaSobreIntereses, int Plan_vigencia, string Plan_nombre, double Plan_CuotaCada1000)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_TasaAnualEfectiva = Plan_TasaAnualEfectiva;
            tmpPlan.Plan_IvaSobreIntereses = Plan_IvaSobreIntereses;
            tmpPlan.Plan_vigencia = Plan_vigencia;
            tmpPlan.Plan_nombre = Plan_nombre;
            tmpPlan.Plan_CuotaCada1000 = Plan_CuotaCada1000;
            tmpPlan.Guardar();
        }

        public void ModificarPlan(int id_plan, int Plan_cantCuotas, double Plan_TasaAnualEfectiva, double Plan_IvaSobreIntereses, int Plan_vigencia, string Plan_nombre, double Plan_CuotaCada1000)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_id = id_plan;
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_TasaAnualEfectiva = Plan_TasaAnualEfectiva;
            tmpPlan.Plan_IvaSobreIntereses = Plan_IvaSobreIntereses;
            tmpPlan.Plan_vigencia = Plan_vigencia;
            tmpPlan.Plan_nombre = Plan_nombre;
            tmpPlan.Plan_CuotaCada1000 = Plan_CuotaCada1000;
            tmpPlan.modificarPlan();
        }

        public void BajaUsuario(int idUsuario)
        {
            Usuario tmpUsuario = new Usuario();
            if (idUsuario == 0)
                throw new Exception("Id del usuario no puede ser 0");

            tmpUsuario.Id = idUsuario;
            tmpUsuario.eliminarUsuario();
        }

        public void BajaEvento(int idEvento)
        {
            Evento tmpEvento = new Evento();
            if (idEvento == 0)
                throw new Exception("Id del evento no puede ser 0");

            tmpEvento.Id = idEvento;
            tmpEvento.eliminarEvento();
        }

        public void modificarEvento(DateTime fecha, string descripcion, int idEvento)
        {
            Evento tmpEvento = new Evento();
            if (idEvento == 0)
                throw new Exception("Id del evento no puede ser 0");

            tmpEvento.Id = idEvento;
            tmpEvento.Fecha = fecha;
            tmpEvento.Descripcion = descripcion;
            tmpEvento.modificarEvento();
        }

        public void ModificarClaveUsuario(int idUsuario, string claveAnterior, string claveNueva)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            tmpUsuario.Clave = claveNueva;
            tmpUsuario.ModificarClave(claveAnterior);
        }

        public string ResetearClaveUsuario(int idUsuario)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            string claveNueva = tmpUsuario.ResetearClave();
            return claveNueva;
        }

        public void ModificarUsuario(int idUsuario, string alias, string correo, string telefono, ArrayList acciones)
        {
            Usuario tmpUsuario = new Usuario();
            tmpUsuario.Id = idUsuario;
            tmpUsuario.Alias = alias;
            tmpUsuario.Correo = correo;
            tmpUsuario.Telefono = telefono;
            tmpUsuario.AccionesPermitidas = acciones;

            tmpUsuario.Modificar();
        }

        public void guardarEvento(DateTime fecha, string descripcion)
        {
            Evento tmpEvento = new Evento();
            tmpEvento.Descripcion = descripcion;
            tmpEvento.Fecha = fecha;
            tmpEvento.Guardar();
        }

        public DataSet DevolverEventos(DateTime fecha)
        {
            Evento tmpEvento = new Evento();
            DataSet eventos = tmpEvento.devolverEventos(fecha);
            return eventos;
        }

        public DataSet DevolverEvento(int idEvento)
        {
            Evento tmpEvento = new Evento();
            DataSet evento = tmpEvento.devolverEvento(idEvento);
            return evento;
        }

        public DataSet devolverEventosEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            Evento tmpEvento = new Evento();
            return tmpEvento.devolverEventosEntreFechas(fechaDesde, fechaHasta);
        }


        public void AltaSocio(int socioActivo, string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
            string EstadoCivil, char sexo, string estado, int edad, int OficinaId, int IncisoId, string tel, string direccion, string email)
        {
            Socio tmpSocio = new Socio();
            tmpSocio.Socio_nro = NroSocio;
            tmpSocio.Socio_nroCobro = NroCobro;
            tmpSocio.Socio_nombre = Nombres;
            tmpSocio.Socio_apellido = Apellidos;
            tmpSocio.Socio_fechaNac = FechaNacimiento;
            tmpSocio.Socio_fechaIngreso = FechaIngreso;
            tmpSocio.Socio_estadoCivil = EstadoCivil;
            tmpSocio.Socio_sexo = sexo;
            tmpSocio.Socio_estado = estado;
            tmpSocio.Socio_edad = edad;
            tmpSocio.Socio_oficinaId = OficinaId;
            tmpSocio.Socio_incisoId = IncisoId;
            tmpSocio.Socio_tel = tel;
            tmpSocio.Socio_direccion = direccion;
            tmpSocio.Socio_email = email;
            tmpSocio.Socio_activo = socioActivo;
            tmpSocio.Guardar();
        }

        public void EditarSocio(int Tsocio_id, string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
            string EstadoCivil, char sexo, string estado, int edad, int OficinaId, int IncisoId, string tel, string direccion, string email)
        {
            Socio tmpSocio = new Socio();
            tmpSocio.Socio_nro = NroSocio;
            tmpSocio.Socio_nroCobro = NroCobro;
            tmpSocio.Socio_nombre = Nombres;
            tmpSocio.Socio_apellido = Apellidos;
            tmpSocio.Socio_fechaNac = FechaNacimiento;
            tmpSocio.Socio_fechaIngreso = FechaIngreso;
            tmpSocio.Socio_estadoCivil = EstadoCivil;
            tmpSocio.Socio_sexo = sexo;
            tmpSocio.Socio_estado = estado;
            tmpSocio.Socio_edad = edad;
            tmpSocio.Socio_oficinaId = OficinaId;
            tmpSocio.Socio_incisoId = IncisoId;
            tmpSocio.Socio_tel = tel;
            tmpSocio.Socio_direccion = direccion;
            tmpSocio.Socio_email = email;
            tmpSocio.Socio_id = Tsocio_id;
            tmpSocio.ModificarSocio();
        }

        //********************************************* PRESTAMOS***********************************
        public void AltaPrestamo(Socio socio,
                                 string socio_nro,
                                 DateTime fecha,
                                 DateTime hora,
                                 double monteopedido,
                                 double tasa,
                                 int cantidadcuotas,
                                 double importecuota,
                                 int numeroPrestamoAnt,
                                 double montopedidoAnt,
                                 double amortizacionVencer,
                                 double interesesVencer,
                                 int cuotasPactadas,
                                 int cuotasPagadas,
                                 double cuotaAnt,
                                 double tasaanterior,
                                 int anulado)
        {

            Prestamo tmpPrestamo = new Prestamo();
            tmpPrestamo.Socio = socio;
            tmpPrestamo.Socio_nro = socio_nro;
            tmpPrestamo.Fecha = fecha;
            tmpPrestamo.Hora = hora;
            tmpPrestamo.Monteopedido = monteopedido;
            tmpPrestamo.Tasa = tasa;
            tmpPrestamo.Cantidadcuotas = cantidadcuotas;
            tmpPrestamo.Importecuota = importecuota;
            tmpPrestamo.NumeroPrestamoAnt = numeroPrestamoAnt;
            tmpPrestamo.MontopedidoAnt = montopedidoAnt;
            tmpPrestamo.AmortizacionVencer = amortizacionVencer;
            tmpPrestamo.InteresesVencer = interesesVencer;
            tmpPrestamo.CuotasPactadas = cuotasPactadas;
            tmpPrestamo.CuotasPagadas = cuotasPagadas;
            tmpPrestamo.CuotaAnt = cuotaAnt;
            tmpPrestamo.Tasaanterior = tasaanterior;
            tmpPrestamo.Anulado = anulado;


            if (!(tmpPrestamo.NumeroPrestamoAnt == 0))
            {
                tmpPrestamo.anularPrestamo(tmpPrestamo.NumeroPrestamoAnt);
            }

            tmpPrestamo.Guardar();
        }

        public DateTime VtoPrimerCuota(DateTime Fecha)
        {
            DateTime VtoPrimerCuota;
            DateTime FechaNueva;

            FechaNueva = DateTime.Today.AddDays(15);

            // VEEER porque en la original se llamaba a la función UltimoDiaMes que Leo no la pasó
            VtoPrimerCuota = Convert.ToDateTime(DateTime.DaysInMonth(FechaNueva.Year, FechaNueva.Month) + "/" + FechaNueva.Month + "/" + FechaNueva.Year);

            return VtoPrimerCuota;
        }

        public DateTime VtoPto(DateTime Fecha)
        {
            DateTime VtoPto;
            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Day) <= 10))
            { //Fecha tope dentro del mes para cierre de presupuesto
                if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) != 2))
                {
                    VtoPto = Convert.ToDateTime("30" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
                else
                {
                    VtoPto = Convert.ToDateTime("28" + "/" + Fecha.Month + "/" + Fecha.Year);
                }
            }

            if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 12))
            { // Si mes es igual a 12 y día mayor a 10 debe cerrar 

                VtoPto = Convert.ToDateTime("30" + "/01/" + (Fecha.Year + 1)); // El mes siguiente del año siguiente
            }
            else if ((Microsoft.VisualBasic.Conversion.Val(Fecha.Month) == 1))
            {
                VtoPto = Convert.ToDateTime("28" + "/02/" + (Fecha.Year));
            }
            else
            {
                VtoPto = Convert.ToDateTime("30" + "/" + (Fecha.Month + 1) + "/" + Fecha.Year);
            }
            return VtoPto;
        }

        public double IntVencer(double ImpCuota, int CantidadCuotas, int NroCuota, double AmoVencer)
        {

            double IntVencer;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                IntVencer = 0;
            }
            else
            {
                IntVencer = Convert.ToDouble(Strings.Format(((ImpCuota * (CantidadCuotas - NroCuota)) - AmoVencer), "##########.00"));
            }
            return IntVencer;
        }

        public double Pago_Mora(double Importe, string Presupuesto, double Xmora, string QueFecha)
        {
            double Pago_Mora;

            // Importe es la base de cálculo que quedó debiendo
            // Presupuesto es el mes en que no se le pudo descontar
            // Xmora  es la tasa para cobro de mora seteado en parametros

            string Mes; // * 2;  VEEERRR
            string Año; //* 4;   VEEERRR
            DateTime FechasDesde;
            DateTime QueFechaResultado;
            int CantidadDias;
            double TasaDeCobro;

            Mes = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 1, 2);
            Año = Microsoft.VisualBasic.Strings.Mid(Presupuesto, 4);
            TasaDeCobro = 0;

            if (Microsoft.VisualBasic.Conversion.Val(Mes) == 12)
            {
                FechasDesde = Convert.ToDateTime("01/01/" + (Microsoft.VisualBasic.Conversion.Val(Año) + 1));
            }
            else
            {
                FechasDesde = Convert.ToDateTime("01/" + (Microsoft.VisualBasic.Conversion.Val(Mes) + 1) + "/" + Año);
            }

            if (QueFecha != "")
            {
                QueFechaResultado = Convert.ToDateTime(QueFecha);
            }

            if (QueFecha == "") //cobranza por caja
            {
                TimeSpan ts = DateTime.Today - FechasDesde;
                CantidadDias = ts.Days;
            }
            else
            {
                TimeSpan ts = Convert.ToDateTime(QueFecha) - FechasDesde;
                CantidadDias = ts.Days;
            }

            // tasa = tasa + 100; //ejemp. 60 + 100 = 160
            // tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            // tasa = Math.Pow(tasa, (1 / 12)) - 1; //esta es la tasa mensual;

            TasaDeCobro = Math.Pow(TasaDeCobro, CantidadDias / 360);
            TasaDeCobro = TasaDeCobro - 1;
            Pago_Mora = Importe * TasaDeCobro;

            return Pago_Mora;
        }

        public double AmortVencer(double tasa, int CantidadCuotas, int NroCuota, double ImpCuota)
        {
            double AmortVencer;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            if ((CantidadCuotas - NroCuota) == 0)
            {
                AmortVencer = 0;
            }

            AmortVencer = Convert.ToDouble(Strings.Format(ImpCuota * ((1 - Math.Pow(1 / (1 + (tasa)), (CantidadCuotas - NroCuota))) / tasa), "##########.00"));

            return AmortVencer;
        }

        public double AmortCuota(double tasa, int NroCuota, int CantidadCuotas, double Capital)
        {
            double AmortCuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            AmortCuota = Convert.ToDouble(Strings.Format(Financial.PPmt(tasa, NroCuota, CantidadCuotas, -Capital, 0, 0), "##########.00"));

            return AmortCuota;
        }

        public double Cuota(double tasa, int CantidadCuotas, double Capital)
        {
            double Cuota;

            tasa = tasa + 100; //ejemp. 60 + 100 = 160
            tasa = tasa / 100; //ejemp. 160 / 100 = 1.60
            tasa = Math.Pow(tasa, Convert.ToDouble(Decimal.Divide(1, 12))) - 1; //esta es la tasa mensual;

            Cuota = Convert.ToDouble(Strings.Format(Financial.Pmt(tasa, CantidadCuotas, -Capital), "##########.00"));

            return Cuota;
        }

        public double CalculoInteres(int Dias, int NroCuotas, double tasa, double Iva)
        {
            double Wiva;
            double Wtasa;
            double InteresMensual;
            double Wdias;
            double CalculoInteres;

            Wtasa = (tasa + 100) / 100;
            Wiva = (Iva + 100) / 100;
            Wdias = Dias / 30;

            /*aclaración de parámetros
             * días días al primer vencimiento
             * Nrocuota para saber si es la primera o las consecutivas
             * tasa interes anual iva incluido
             * iva porcentaje de iva componente de la cuota 
            */

            InteresMensual = Math.Pow(Wtasa, Convert.ToDouble(Decimal.Divide(1, 12)));

            if (NroCuotas == 1)
            {
                CalculoInteres = Math.Pow(InteresMensual, Wdias);
                CalculoInteres = CalculoInteres - 1;
                CalculoInteres = (CalculoInteres / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
            else
            {
                CalculoInteres = ((InteresMensual - 1) / Wiva);
                return Convert.ToDouble(Strings.Format(CalculoInteres, "##.#000000"));
            }
        }

        public double agregarleIvaAtasaAnual(double tasaAnualEfectivaSinIVA, double iva)
        {
            return (tasaAnualEfectivaSinIVA * ((iva + 100) / 100));
        }

        public DataSet devolverPrestamoActivoSocio(int idSocio)
        {
            Prestamo tmpPrestamo = new Prestamo();
            DataSet prestamoActivo = tmpPrestamo.devolverPrestamoActivoSocio(idSocio);
            return prestamoActivo;
        }

        public string presupuesto()
        {
            return Microsoft.VisualBasic.Strings.Mid(VtoPto(DateTime.Today).Date.ToString("dd/MM/yyyy"), 4);
        }

        public void agregarAporteCapitalCobranza(int parCobranza_id, double parAporteCapital)
        {
            Cobranza tmpCobranza = new Cobranza();
            if (parCobranza_id == 0)
                throw new Exception("Id del cobranza no puede ser 0");

            tmpCobranza.Cobranza_ID = parCobranza_id;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.agregarAporteCapitalCobranza();
        }

        public void modificarCobranza(int parCobranza_id, int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            Cobranza tmpCobranza = new Cobranza();
            if (parCobranza_id == 0)
                throw new Exception("Id del cobranza no puede ser 0");

            tmpCobranza.Cobranza_ID = parCobranza_id;
            tmpCobranza.Prestamo_id = parPrestamo_id;
            tmpCobranza.Socio_nro = parCedula;
            tmpCobranza.Tasa = parTasa;
            tmpCobranza.Porcentajeiva = parPorcentajeiva;
            tmpCobranza.Monteopedido = parMontopedido;
            tmpCobranza.Cantidadcuotas = parCantidadcuotas;
            tmpCobranza.NroDeCuotas = parNrodecuotas;
            tmpCobranza.Importecuota = parImportecuota;
            tmpCobranza.AmortizacionCuota = parAmortizacioncuota;
            tmpCobranza.InteresCuota = parInteresCuota;
            tmpCobranza.IvaCuota = parIvaCuota;
            tmpCobranza.AmortizacionVencer = parAmortizacionVencer;
            tmpCobranza.InteresesVencer = parInteresVencer;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.Socio_id = parSocio_id;

            tmpCobranza.modificarCobranza();
        }

        public void guardarCobranza(int parPrestamo_id, String parCedula, double parTasa, double parPorcentajeiva, double parMontopedido, int parCantidadcuotas, int parNrodecuotas, double parImportecuota, double parAmortizacioncuota, double parInteresCuota, double parIvaCuota, double parAmortizacionVencer, double parInteresVencer, double parAporteCapital, int parSocio_id)
        {
            Cobranza tmpCobranza = new Cobranza();

            tmpCobranza.Prestamo_id = parPrestamo_id;
            tmpCobranza.Socio_nro = parCedula;
            tmpCobranza.Tasa = parTasa;
            tmpCobranza.Porcentajeiva = parPorcentajeiva;
            tmpCobranza.Monteopedido = parMontopedido;
            tmpCobranza.Cantidadcuotas = parCantidadcuotas;
            tmpCobranza.NroDeCuotas = parNrodecuotas;
            tmpCobranza.Importecuota = parImportecuota;
            tmpCobranza.AmortizacionCuota = parAmortizacioncuota;
            tmpCobranza.InteresCuota = parInteresCuota;
            tmpCobranza.IvaCuota = parIvaCuota;
            tmpCobranza.AmortizacionVencer = parAmortizacionVencer;
            tmpCobranza.InteresesVencer = parInteresVencer;
            tmpCobranza.AporteCapital = parAporteCapital;
            tmpCobranza.Socio_id = parSocio_id;

            tmpCobranza.GuardarCobranza();
        }

        public void GuardarFechaCierre(String Presupuesto, DateTime FechaDesde, DateTime HoraDesde, DateTime FechaHasta, DateTime HoraHasta, Double TotalImporte, Double AmortizacionAVencer, Double InteresesAVencer)
        {
            FechaCierre tmpFechaCierre = new FechaCierre();
            tmpFechaCierre.Presupuesto = Presupuesto;
            tmpFechaCierre.FechaDesde = FechaDesde;
            tmpFechaCierre.HoraDesde = HoraDesde;
            tmpFechaCierre.FechaHasta = FechaHasta;
            tmpFechaCierre.HoraHasta = HoraHasta;
            tmpFechaCierre.TotalImporte = TotalImporte;
            tmpFechaCierre.AmortizacionAVencer = AmortizacionAVencer;
            tmpFechaCierre.InteresesAVencer = InteresesAVencer;

            tmpFechaCierre.GuardarFechaCierre();
        }

        public void modificarParametrosCierreEmpresa(DateTime empresa_cierrePresupuestoAnterior, DateTime empresa_horaCierreAnterior, DateTime empresa_cierrePresupuestoActual, DateTime empresa_horacierreactual, DateTime empresa_vtoPresupuestoActual, String empresa_usuarioCierre)
        {
            Empresa tmpEmpresa = new Empresa();

            tmpEmpresa.Empresa_cierrePresupuestoAnterior = empresa_cierrePresupuestoAnterior;
            tmpEmpresa.Empresa_horaCierreAnterior = empresa_horaCierreAnterior;
            tmpEmpresa.Empresa_cierrePresupuestoActual = empresa_cierrePresupuestoActual;
            tmpEmpresa.Empresa_horacierreactual = empresa_horacierreactual;
            tmpEmpresa.Empresa_vtoPresupuestoActual = empresa_vtoPresupuestoActual;
            tmpEmpresa.Empresa_usuarioCierre = empresa_usuarioCierre;

            tmpEmpresa.modificarParametrosCierreEmpresa();
        }

        public DataSet devolverTotalesCobranzas()
        {
            Cobranza tmpCobranza = new Cobranza();
            DataSet totalesCobranza = tmpCobranza.devolverCobranzas();
            return totalesCobranza;
        }

        public void cierre()
        {
            double CuotaCapital;
            double amo_cuota;
            double int_cuota;
            double amo_vencer;
            double int_vencer;
            int CuotasVan;
            DateTime FechaVto;
            DateTime FechaCierre;
            DateTime HoraCierre;
            double ImporteTotal;
            double TotalAmortizacion;
            double TotalIntereses;
            int ProgresoBarra;
            double Wmora;
            double Wiva;
            double InteresCuota;
            double IvaCuota;
            double Mora;

            double WIvaMora; //contiene el porcentaje
            double IvaMora; //va a contener el resultado del iva sobre la mora

            // AGREGADOS POR NICO
            double tasa;
            int cantidadCuotas;
            double montoPedido;
            int id_cobranza;
            int id_prestamo;
            int socio_id;
            String cedula;
            double importeCuota;
            bool estaEnCobranza = false;
            DataSet dsCobranzasActualizadas;
            double aporteCapital;

            DateTime fechaVto = this.VtoPto(DateTime.Today);
            DateTime fechaCierre = DateTime.Today;
            DateTime horaCierre = DateTime.Now;

            DataSet dsParametros = DevolverEmpresa();
            DataSet dsSociosActivos = DevolverSociosActivos();
            DataSet dsFechasCierres = DevolverFechasCierres();
            DataSet dsCobranzasProvisorias = DevolverCobranzasProvisorias();
            DataSet dsCobranzas = DevolverCobranzas();


            //*****************************
            // Traer Historia y Excedidos
            //*****************************

            CuotaCapital = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][22].ToString());
            Wmora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][11].ToString());
            WIvaMora = Convert.ToDouble(dsParametros.Tables["empresas"].Rows[0][10].ToString());

            this.eliminarAmortizacionVencerCeroCobranza();

            if (dsCobranzas.Tables["cobranzas"].Rows.Count > 0)
            {
                for (int i = 0; i < dsCobranzas.Tables["cobranzas"].Rows.Count; i++)
                {
                    id_cobranza = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][0].ToString());
                    id_prestamo = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][1].ToString());
                    cedula = dsCobranzas.Tables["cobranzas"].Rows[i][2].ToString();
                    tasa = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][3].ToString());
                    Wiva = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][4].ToString()); // Porcentaje ivaç
                    montoPedido = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][5].ToString());
                    CuotasVan = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][6].ToString()) + 1;
                    cantidadCuotas = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][7].ToString());
                    importeCuota = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][8].ToString());
                    aporteCapital = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][14].ToString());
                    socio_id = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString());

                    amo_cuota = AmortCuota(tasa, CuotasVan, cantidadCuotas, montoPedido);

                    if (Wiva != 0)
                    {
                        InteresCuota = Convert.ToDouble(Strings.Format(((importeCuota - amo_cuota) / ((Wiva / 100) + 1)), "##,##0.00"));
                        IvaCuota = Convert.ToDouble(Strings.Format(importeCuota - amo_cuota - InteresCuota, "##,##0.00"));
                    }
                    else
                    {
                        InteresCuota = importeCuota - amo_cuota;
                        IvaCuota = 0;
                    }
                    amo_vencer = AmortVencer(tasa, cantidadCuotas, CuotasVan, importeCuota);
                    int_vencer = IntVencer(importeCuota, cantidadCuotas, CuotasVan, amo_vencer);

                    modificarCobranza(id_cobranza, id_prestamo, cedula, tasa, Wiva, montoPedido, CuotasVan, cantidadCuotas, importeCuota, amo_cuota, InteresCuota, IvaCuota, amo_vencer, int_vencer, aporteCapital, socio_id);
                }

                //Incorporando los nuevos préstamos
                if (dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows.Count; i++)
                    {
                        int id_cobranzaProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][0].ToString());
                        int id_prestamoProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][1].ToString());
                        String cedulaProvisorio = Convert.ToString(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][2].ToString());
                        double tasaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][3].ToString());
                        double WivaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][4].ToString());
                        double montoPedidoProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][5].ToString());
                        int CuotasVanProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][6].ToString());
                        int cantidadCuotasProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][7].ToString());
                        double importeCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][8].ToString());
                        double amo_cuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][9].ToString());
                        double InteresCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][10].ToString());
                        double IvaCuotaProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][11].ToString());
                        double amo_vencerProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][12].ToString());
                        double int_vencerProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][13].ToString());
                        double aporteCapitalProvisorio = Convert.ToDouble(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][14].ToString());
                        int socio_idProvisorio = Convert.ToInt32(dsCobranzasProvisorias.Tables["cobranzasProvisorias"].Rows[i][15].ToString());


                        for (int j = 0; !estaEnCobranza && j < dsCobranzas.Tables["cobranzas"].Rows.Count; j++)
                        {
                            if (Convert.ToInt32(dsCobranzas.Tables["cobranzasProvisorias"].Rows[i][15].ToString()) == Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString()))
                            {
                                modificarCobranza(id_cobranzaProvisorio, id_prestamoProvisorio, cedulaProvisorio, tasaProvisorio, WivaProvisorio, montoPedidoProvisorio, CuotasVanProvisorio, cantidadCuotasProvisorio, importeCuotaProvisorio, amo_cuotaProvisorio, InteresCuotaProvisorio, IvaCuotaProvisorio, amo_vencerProvisorio, int_vencerProvisorio, aporteCapitalProvisorio, socio_idProvisorio);
                                estaEnCobranza = true;
                            }
                        }

                        if (!estaEnCobranza)
                        {
                            guardarCobranza(id_prestamoProvisorio, cedulaProvisorio, tasaProvisorio, WivaProvisorio, montoPedidoProvisorio, CuotasVanProvisorio, cantidadCuotasProvisorio, importeCuotaProvisorio, amo_cuotaProvisorio, InteresCuotaProvisorio, IvaCuotaProvisorio, amo_vencerProvisorio, int_vencerProvisorio, aporteCapitalProvisorio, socio_idProvisorio);
                        }
                    }
                }

                //agrego todos los socios tengan o no prestamos que no
                //hayan sido dados de baja
                estaEnCobranza = false;

                if (dsSociosActivos.Tables["socio"].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSociosActivos.Tables["socio"].Rows.Count; i++)
                    {

                        for (int j = 0; !estaEnCobranza && j < dsCobranzas.Tables["cobranzas"].Rows.Count; j++)
                        {
                            if (dsSociosActivos.Tables["socio"].Rows[i][0].ToString() == dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString())
                            {
                                agregarAporteCapitalCobranza(Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString()), CuotaCapital);
                                estaEnCobranza = true;
                            }
                        }

                        if (!estaEnCobranza)
                        {
                            guardarCobranza(0, dsSociosActivos.Tables["cobranzas"].Rows[i][3].ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, CuotaCapital, Convert.ToInt32(dsSociosActivos.Tables["cobranzas"].Rows[i][0].ToString()));
                        }
                    }
                }

                DateTime empresa_cierrePresupuestoAnterior = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][26].ToString()); // Cierre fecha presupuesto actual
                DateTime empresa_horaCierreAnterior = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString()); // Cierre hora presupuesto actual
                DateTime empresa_cierrePresupuestoActual = fechaCierre;
                DateTime empresa_horacierreactual = horaCierre;
                DateTime empresa_vtoPresupuestoActual = fechaVto;
                String empresa_usuarioCierre = Utilidades.UsuarioLogueado.Alias;

                
                modificarParametrosCierreEmpresa(empresa_cierrePresupuestoAnterior, empresa_horaCierreAnterior, empresa_cierrePresupuestoActual, empresa_horacierreactual, empresa_vtoPresupuestoActual, empresa_usuarioCierre);

                //***************************************************
                // ACTUALIZO FECHAS CIERRES  ( HACER Sum(importecuota+aportecapital) )
                //***************************************************


                DateTime fecha_desde = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][26].ToString());
                DateTime hora_desde = Convert.ToDateTime(dsParametros.Tables["empresas"].Rows[0][27].ToString());
                String presupuesto_ = presupuesto();
                              
                DataSet totalesCobranza = devolverTotalesCobranzas();
          
                Double totalImporteCobranzas = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][1].ToString());
                Double totalAmortizacionVencer = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][2].ToString());
                Double interesesVencer = Convert.ToDouble(totalesCobranza.Tables["totalesCobranzas"].Rows[0][3].ToString());

                GuardarFechaCierre(presupuesto_, fecha_desde, hora_desde, empresa_cierrePresupuestoActual, empresa_horacierreactual, totalImporteCobranzas, totalAmortizacionVencer, interesesVencer);


                // *************
                // ACTUALIZAR HISTORIA
                //

                dsCobranzasActualizadas = DevolverCobranzas();

                if (dsCobranzasActualizadas.Tables["cobranzas"].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCobranzasActualizadas.Tables["cobranzas"].Rows.Count; i++)
                    {
                        // Por cada cobranza agrego un registro en el histórico

/*

                        id_cobranza = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][0].ToString());
                        id_prestamo = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][1].ToString());
                        cedula = dsCobranzas.Tables["cobranzas"].Rows[i][2].ToString();
                        tasa = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][3].ToString());
                        Wiva = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][4].ToString()); // Porcentaje ivaç
                        montoPedido = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][5].ToString());
                        CuotasVan = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][6].ToString()) + 1;
                        cantidadCuotas = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][7].ToString());
                        importeCuota = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][8].ToString());
                        aporteCapital = Convert.ToDouble(dsCobranzas.Tables["cobranzas"].Rows[i][14].ToString());
                        socio_id = Convert.ToInt32(dsCobranzas.Tables["cobranzas"].Rows[i][15].ToString());
*/



                        /*     RsHistoria.AddNew
                                 RsHistoria!Presupuesto = Mid(FechaVto, 4)
                                 RsHistoria!numeroprestamo = RsCobranza!numeroprestamo
                                 RsHistoria!cedula = RsCobranza!cedula
                                 RsHistoria!tasa = RsCobranza!tasa
                                 RsHistoria!porcentajeiva = RsCobranza!porcentajeiva
                                 RsHistoria!montopedido = RsCobranza!montopedido
                                 RsHistoria!CantidadCuotas = RsCobranza!CantidadCuotas
                                 RsHistoria!nrodecuotas = RsCobranza!nrodecuotas
                                 RsHistoria!ImporteCuota = RsCobranza!ImporteCuota
                                 RsHistoria!amortizacioncuota = RsCobranza!amortizacioncuota
                                 RsHistoria!InteresCuota = RsCobranza!InteresCuota
                                 RsHistoria!IvaCuota = RsCobranza!IvaCuota
                                 RsHistoria!amortizacionvencer = RsCobranza!amortizacionvencer
                                 RsHistoria!interesvencer = RsCobranza!interesvencer
                                 RsHistoria!aportecapital = RsCobranza!aportecapital
                         
                                  RsHistoria!numerocobro = RsSocios!numerocobro
                              
                                  RsHistoria!inciso = RsSocios!inciso
                                  RsHistoria!Oficina = RsSocios!Oficina
                                                  */

                        //******
                        // En la misma recorrida del histórico actualizo los excedidos.
                        //*************************************

                        /*     Busqueda = "select * from excedidos where cedula=" & "'" & RsCobranza!cedula & "'"
                           Busqueda = Busqueda & "and importepagado=0"
             
                             
                           If RsExcedidos.RecordCount > 0 Then
                              RsHistoria!Excedido = RsExcedidos!aretener - RsExcedidos!retenido
                  
                    
                  
                              If (RsExcedidos!aretener - RsExcedidos!retenido) > RsExcedidos!aportecapital Then
                                 'Modificado 14/10/09 redondeo a dos decimales
                     
                                 Mora = Format(Pago_Mora(RsExcedidos!aretener - RsExcedidos!retenido - RsExcedidos!aportecapital, RsExcedidos!Presupuesto, Wmora, FechaVto), "###,###,##0.00")
                                 ' Agregado 14/10/09 iva sobre la mora
                                 IvaMora = Format(Mora * (WIvaMora / 100), "###,###,##0.00")
                              Else
                                 Mora = 0
                              End If
                  
                              RsHistoria!Mora = Mora
                  
                              'agregado 14/10/09 grabar el iva de la mora en historia
                              If Mora <> 0 Then
                                RsHistoria!IvaMora = IvaMora
                              End If
                  
                              RsExcedidos.Edit
                              RsExcedidos!fechadepago = Date
                              RsExcedidos!importepagado = (RsExcedidos!aretener - RsExcedidos!retenido) + Mora
                              RsExcedidos!presupuestodelpago = Mid(FechaVto, 4)

                              RsExcedidos.Update

                           End If
               
                           RsHistoria.Update
               
               
                           RsCobranza.MoveNext
                           PrgBarCierre.Value = PrgBarCierre.Value + 1
               
                        Wend
                      End If
                     */


                        // **************Vaciar la tabla cobranza privosoria*****************
                        // BaseDatos.Execute "DELETE * FROM  cobranzaprovisoria;"


                    }
                }

            }
        }
    }
}
