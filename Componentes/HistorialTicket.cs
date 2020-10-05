using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsService.Componentes
{
    public class HistorialTicket
    {
        #region Prodpiedades
        public int Id;
        public int TicketId;
        public string Nombre;
        public string Estado;
        public string Responsable;
        public string Categoria;
        public string Prioridad;
        public DateTime FechaCreacion;
        public int Version;
        public DateTime FechaAccion;
        public string Cambios;
        public string TipoAccion;
        public string Usuario;

        #endregion

        #region Constructor y desconstructor
        public HistorialTicket() { }
        ~HistorialTicket() { }
        #endregion
    }
}