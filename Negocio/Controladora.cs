using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Utilidades;
using System.Globalization;

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

        public DataSet DevolverIncisos()
        {
            Inciso tmpInciso = new Inciso();
            DataSet incisos = tmpInciso.devolverIncisos();
            return incisos;
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

        public void bajaPlan(int idPlan)
        {
            Plan tmpPlan = new Plan();
            //if (idPlan == 0)
            //    throw new Exception("Id del usuario no puede ser 0");

            tmpPlan.Plan_id = idPlan;
            tmpPlan.eliminar();
        }

        public void bajaSocio(string socioNro)
        {
            Socio tmpSocio = new Socio();
            //revisar que el socio no tenga prestamos activos  (pendiente)
            tmpSocio.Socio_nro = socioNro;
            tmpSocio.eliminar();

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

        public void AltaPlan(string Plan_codigo, string Plan_descripcion, int Plan_cantCuotas, double Plan_interes)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_codigo = Plan_codigo;
            tmpPlan.Plan_descripcion = Plan_descripcion;
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_interes = Plan_interes;
            tmpPlan.Guardar();
        }

        public void ModificarPlan(string Plan_descripcion, int Plan_cantCuotas, double Plan_interes, int idPlan)
        {
            Plan tmpPlan = new Plan();
            tmpPlan.Plan_descripcion = Plan_descripcion;
            tmpPlan.Plan_cantCuotas = Plan_cantCuotas;
            tmpPlan.Plan_interes = Plan_interes;
            tmpPlan.Plan_id = idPlan;
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


        public void AltaSocio(int socioActivo,string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
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

        public void EditarSocio(string NroSocio, string NroCobro, string Nombres, string Apellidos, DateTime FechaNacimiento, DateTime FechaIngreso,
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
            tmpSocio.ModificarSocio();
        }
    }
}
