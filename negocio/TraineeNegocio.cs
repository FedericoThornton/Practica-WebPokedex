using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("update USERS set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha, imagenPerfil = @imagen where id = @id");
                datos.SetearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.SetearParametro("@nombre", user.Nombre);
                datos.SetearParametro("@apellido", user.Apellido);
                datos.SetearParametro("@fecha", user.FechaNacimiento);
                datos.SetearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            } finally
            {
                datos.CerrarConexion();
            }
        }

        public int insertarNuevo (Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.SetearProcedimiento("InsertarNuevo");
                datos.SetearParametro("@email", nuevo.Email);
                datos.SetearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
              
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

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, imagenPerfil, nombre, apellido, fechaNacimiento from USERS where email = @email and pass= @pass");
                datos.SetearParametro("@email", trainee.Email);
                datos.SetearParametro("@pass", trainee.Pass);
                         
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull)) 
                        trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());
                            




                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
