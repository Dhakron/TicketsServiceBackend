using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsService.Componentes
{
    public class BandejaEntrada
    {
        #region Prodpiedades
        public List<Tickets> listaTickets;
        public Paginacion paginacion;
        #endregion

        #region Constructor y desconstructor
        public BandejaEntrada() { }
        ~BandejaEntrada() { }
        #endregion
    }
}