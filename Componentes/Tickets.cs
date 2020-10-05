using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsService.Componentes
{
    public class Tickets
    {
        #region Prodpiedades
        public int Id;
        public string Nombre;
        public string Estado;
        public string Responsable;
        public string Categoria;
        public string Prioridad;
        public DateTime FechaCreacion;
        public int Version;
        public String Usuario;

        #endregion

        #region Constructor y desconstructor
        public Tickets() { }
        ~Tickets() { }
        #endregion
    }
}