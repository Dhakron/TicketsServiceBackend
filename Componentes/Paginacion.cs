using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsService.Componentes
{
    public class Paginacion
    {
        #region Prodpiedades
        public int elementosPorPagina;
        public int paginaActual;
        public int paginasTotales;
        public int ElementosTotales;

        #endregion

        #region Constructor y desconstructor
        public Paginacion() { }
        ~Paginacion() { }
        #endregion
    }
}