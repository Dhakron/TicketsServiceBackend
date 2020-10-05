using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using TicketsService.Componentes;

namespace TicketsService
{
    /// <summary>
    /// Descripción breve de wsTickes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsTickes : System.Web.Services.WebService
    {

        [WebMethod]
        public Tickets getTicket(int id)
        {
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_TicketSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@TicketId", SqlDbType.Int).Value = id;

                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            return new Tickets()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null,
                                Estado = reader["Estado"] != DBNull.Value ? (string)reader["Estado"] : null,
                                Responsable = reader["Responsable"] != DBNull.Value ? (string)reader["Responsable"] : null,
                                Categoria = reader["Categoria"] != DBNull.Value ? (string)reader["Categoria"] : null,
                                Prioridad = reader["Prioridad"] != DBNull.Value ? (string)reader["Prioridad"] : null,
                                FechaCreacion = reader["FechaCreacion"] != DBNull.Value ? (DateTime)reader["FechaCreacion"] : new DateTime(),
                                Version = reader["Version"] != DBNull.Value ? (int)reader["Version"] : 0,
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [WebMethod]
        public List<Tickets> getTicketList()
        {
            SqlDataReader reader = null;
            List<Tickets> list = new List<Tickets>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_TicketsSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Tickets()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null,
                                Estado = reader["Estado"] != DBNull.Value ? (string)reader["Estado"] : null,
                                Responsable = reader["Responsable"] != DBNull.Value ? (string)reader["Responsable"] : null,
                                Categoria = reader["Categoria"] != DBNull.Value ? (string)reader["Categoria"] : null,
                                Prioridad = reader["Prioridad"] != DBNull.Value ? (string)reader["Prioridad"] : null,
                                FechaCreacion = reader["FechaCreacion"] != DBNull.Value ? (DateTime)reader["FechaCreacion"] : new DateTime(),
                                Version = reader["Version"] != DBNull.Value ? (int)reader["Version"] : 0
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [WebMethod]
        public List<HistorialTicket> getHistorialTicketList(int ticketId)
        {
            SqlDataReader reader = null;
            List<HistorialTicket> list = new List<HistorialTicket>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_HistorialTicketSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@TicketId", SqlDbType.Int).Value = ticketId;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new HistorialTicket()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                TicketId = reader["TicketId"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null,
                                Estado = reader["Estado"] != DBNull.Value ? (string)reader["Estado"] : null,
                                Responsable = reader["Responsable"] != DBNull.Value ? (string)reader["Responsable"] : null,
                                Categoria = reader["Categoria"] != DBNull.Value ? (string)reader["Categoria"] : null,
                                Prioridad = reader["Prioridad"] != DBNull.Value ? (string)reader["Prioridad"] : null,
                                FechaCreacion = reader["FechaCreacion"] != DBNull.Value ? (DateTime)reader["FechaCreacion"] : new DateTime(),
                                Version = reader["Version"] != DBNull.Value ? (int)reader["Version"] : 0,
                                Usuario = reader["Usuario"] != DBNull.Value ? (string)reader["Usuario"] : null,
                                FechaAccion = reader["FechaAccion"] != DBNull.Value ? (DateTime)reader["FechaAccion"] : new DateTime(),
                                Cambios = reader["Cambios"] != DBNull.Value ? (string)reader["Cambios"] : null,
                                TipoAccion = reader["TipoAccion"] != DBNull.Value ? (string)reader["TipoAccion"] : null,
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public Tickets updateTicket(int id, string nombre, string estado, string responsable, string categoria, string prioridad, int version,int usuarioId)
        {
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    if (id != 0)
                    {
                        using (SqlCommand comando = new SqlCommand("AAA_TicketUPD", conexion))
                        {
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                            comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
                            comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;
                            comando.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = responsable;
                            comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = categoria;
                            comando.Parameters.Add("@Prioridad", SqlDbType.VarChar).Value = prioridad;
                            comando.Parameters.Add("@Version", SqlDbType.Int).Value = version;
                            comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = usuarioId;
                            conexion.Open();
                            reader = comando.ExecuteReader();
                            while (reader.Read())
                            {
                                return getTicket(id);
                            }
                            return null;
                        }
                    }
                    else
                    {
                        using (SqlCommand comando = new SqlCommand("AAA_TicketINS", conexion))
                        {
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nombre;
                            comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = estado;
                            comando.Parameters.Add("@Responsable", SqlDbType.VarChar).Value = responsable;
                            comando.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = categoria;
                            comando.Parameters.Add("@Prioridad", SqlDbType.VarChar).Value = prioridad;
                            comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = usuarioId;
                            conexion.Open();
                            reader = comando.ExecuteReader();
                            return new Tickets();
                        }
                    }

                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public List<Estado> getEstadosList()
        {
            SqlDataReader reader = null;
            List<Estado> list = new List<Estado>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_EstadosSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Estado()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public List<Responsable> getResponsablesList()
        {
            SqlDataReader reader = null;
            List<Responsable> list = new List<Responsable>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_ResponsablesSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Responsable()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public List<Categoria> getCategoriasList()
        {
            SqlDataReader reader = null;
            List<Categoria> list = new List<Categoria>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_CategoriasSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Categoria()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public List<Usuario> getUsuariosList()
        {
            SqlDataReader reader = null;
            List<Usuario> list = new List<Usuario>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_UsuariosSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Usuario()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        [WebMethod]
        public List<Prioridad> getPrioridadesList()
        {
            SqlDataReader reader = null;
            List<Prioridad> list = new List<Prioridad>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_PrioridadesSel", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new Prioridad()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null
                            });
                        }
                        return list;
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [WebMethod]
        public BandejaEntrada getBandejaEntrada(String titulo, int prioridadId, int estadoId, int responsableId, int categoriaId,
	        int elementosPorPagina, int paginaActual, String ordenamiento, String ascendenteDescendente)
        {
            BandejaEntrada bandejaEntrada = new BandejaEntrada();
            bandejaEntrada.listaTickets = new List<Tickets>();
            Paginacion paginacion = new Paginacion()
            {
                elementosPorPagina=elementosPorPagina,
                paginaActual=paginaActual
            };
            SqlDataReader reader;

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand("AAA_BETicketsSEL", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = titulo;
                        comando.Parameters.Add("@PrioridadId", SqlDbType.Int).Value = prioridadId;
                        comando.Parameters.Add("@EstadoId", SqlDbType.Int).Value = estadoId;
                        comando.Parameters.Add("@ResponsableId", SqlDbType.Int).Value = responsableId;
                        comando.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = categoriaId;
                        comando.Parameters.Add("@ElementosPorPagina", SqlDbType.Int).Value = elementosPorPagina;
                        comando.Parameters.Add("@PaginaActual", SqlDbType.Int).Value = paginaActual;
                        comando.Parameters.Add("@Ordenamiento", SqlDbType.VarChar).Value = ordenamiento;
                        comando.Parameters.Add("AscendenteDescendente", SqlDbType.NVarChar).Value = ascendenteDescendente;
                        comando.Parameters.Add("@ElementosTotales", SqlDbType.Int).Direction = ParameterDirection.Output;
                        comando.Parameters.Add("@PaginasTotales", SqlDbType.Int).Direction = ParameterDirection.Output;

                        conexion.Open();
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            bandejaEntrada.listaTickets.Add(new Tickets()
                            {
                                Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                Nombre = reader["Nombre"] != DBNull.Value ? (string)reader["Nombre"] : null,
                                Estado = reader["Estado"] != DBNull.Value ? (string)reader["Estado"] : null,
                                Prioridad = reader["Prioridad"] != DBNull.Value ? (string)reader["Prioridad"] : null,
                                Categoria = reader["Categoria"] != DBNull.Value ? (string)reader["Categoria"] : null,
                                Responsable = reader["Responsable"] != DBNull.Value ? (string)reader["Responsable"] : null,
                                FechaCreacion = reader["FechaCreacion"] != DBNull.Value ? (DateTime)reader["FechaCreacion"] : new DateTime(),
                                Version = reader["Version"] != DBNull.Value ? (int)reader["Version"] : 0
                            });
                        }
                        reader.Close();

                        paginacion.ElementosTotales = comando.Parameters["@ElementosTotales"].Value == null ? 0 : int.Parse(comando.Parameters["@ElementosTotales"].Value.ToString());
                        paginacion.paginasTotales = comando.Parameters["@PaginasTotales"].Value == null ? 0 : int.Parse(comando.Parameters["@PaginasTotales"].Value.ToString());
                        bandejaEntrada.paginacion = paginacion;
                    }
                }

                return bandejaEntrada;
            }
            finally
            {
                bandejaEntrada = null;
                reader = null;
            }
        }
    }
}