using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Evento
    {
        private int id;
        private DateTime fecha;
        private string descripcion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public void Guardar()
        {
            pEvento tmpEvento = new pEvento();
            tmpEvento.GuardarEvento(Fecha, Descripcion);
        }

        public DataSet devolverEventos(DateTime fecha)
        {
            pEvento tmpEvento = new pEvento();
            DataSet eventos = tmpEvento.devolverEventos(fecha);
            return eventos;
        }

        public DataSet devolverEvento(int idEvento)
        {
            pEvento tmpEvento = new pEvento();
            DataSet eventos = tmpEvento.devolverEvento(idEvento);
            return eventos;
        }

        public DataSet devolverEventosEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            pEvento tmpEvento = new pEvento();
            DataSet eventos = tmpEvento.devolverEventosEntreFechas(fechaDesde, fechaHasta);
            return eventos;
        }

        public void eliminarEvento()
        {
            pEvento tmpEvento = new pEvento();
            tmpEvento.EliminarEvento(Id);
        }

        public void modificarEvento()
        {
            pEvento tmpEvento = new pEvento();
            tmpEvento.modificarEvento(Id,Fecha, Descripcion);
        }
    }
}
