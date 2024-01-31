using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Tracing;

namespace negocio
{



    public class PokemonNegocio
    {
        // metodo de acceso a datos
        public List<Pokemon> Listar( string id= "")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdDebilidad, P.IdTipo, P.Id, P.Activo from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and  D.Id = P.IdDebilidad  ";
                if (id != "")
                {
                    comando.CommandText += " and P.Id =" + id;
                }
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon pokemon = new Pokemon();
                    Pokemon aux = pokemon;
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    // if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))));  para validar si es null pero si la columna es not null no va
                    // {
                    //     aux.UrlImagen = (string)lector["UrlImagen"];
                    // }
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    Elemento elemento = new Elemento();
                    aux.Tipo = elemento;
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    Elemento elemento1 = new Elemento();
                    aux.Debilidad = elemento1;
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Activo = (bool)lector["Activo"];
                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Pokemon> ListarConSP()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //  string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdDebilidad, P.IdTipo, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and  D.Id = P.IdDebilidad and P.Activo = 1";

                // datos.setearConsulta(consulta);
                datos.SetearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon pokemon = new Pokemon();
                    Pokemon aux = pokemon;
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    Elemento elemento = new Elemento();
                    aux.Tipo = elemento;
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    Elemento elemento1 = new Elemento();
                    aux.Debilidad = elemento1;
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    


        public void Agregar(Pokemon nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen) values ("+ nuevo.Numero +", '"+ nuevo.Nombre +"', '"+ nuevo.Descripcion +"', 1, @IdTipo, @IdDebilidad, @UrlImagen)");
                datos.SetearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.SetearParametro("@IdDebilidad", nuevo.Debilidad.Id);
                datos.SetearParametro("@UrlImagen", nuevo.UrlImagen);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            } 
            finally
            {
                datos.CerrarConexion();
            }
                      
        }

        public void AgregarConSP(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("StoredAltaPokemon");
                datos.SetearParametro("@Numero", nuevo.Numero);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.SetearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.SetearParametro("@IdDebilidad", nuevo.Debilidad.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }


        public void Modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @id");
                datos.SetearParametro("@numero", poke.Numero);
                datos.SetearParametro("@nombre", poke.Nombre);
                datos.SetearParametro("@desc", poke.Descripcion);
                datos.SetearParametro("@img", poke.UrlImagen);
                datos.SetearParametro("@idTipo", poke.Tipo.Id);
                datos.SetearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.SetearParametro("@id", poke.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            } 
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void ModificarConSP(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("StoredModificarPokemon");
                datos.SetearParametro("@Numero", nuevo.Numero);
                datos.SetearParametro("@Nombre", nuevo.Nombre);
                datos.SetearParametro("@Descripcion", nuevo.Descripcion);
                datos.SetearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.SetearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.SetearParametro("@IdDebilidad", nuevo.Debilidad.Id);
                datos.SetearParametro("@id", nuevo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where id = @Id ");
                datos.SetearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminarlogico( int id, bool activo = false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = @activo where Id = @id");
                datos.SetearParametro("@id", id);
                datos.SetearParametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> Filtrar(string campo, string criterio, string filtro, string estado)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdDebilidad, P.IdTipo, P.Id, P.Activo from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and  D.Id = P.IdDebilidad and ";
                switch (campo)
                {

                    case "Número":
                    
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Numero > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Numero < " + filtro;
                                break;
                           
                            default:
                                consulta += "Numero = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '"+ filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            
                            default:
                                consulta += "Nombre like '%" +filtro + "%'";
                                break;
                        }
                        break;

                    case "Tipo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "E.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "E.Descripcion like '%'" + filtro + "'"; 
                                break;

                            default:
                                consulta += "E.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Debilidad":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "D.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "D.Descripcion like '%'" + filtro + "'";
                                break;

                            default:
                                consulta += "D.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;


                }


                if (estado == "Activo")
                {
                    consulta += " and P.Activo = 1";
                }
                else if (estado == "Inactivo")
                {
                    consulta += " and P.Activo = 0";
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon pokemon = new Pokemon();
                    Pokemon aux = pokemon;
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                 
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    Elemento elemento = new Elemento();
                    aux.Tipo = elemento;
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    Elemento elemento1 = new Elemento();
                    aux.Debilidad = elemento1;
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

     
    }

}



