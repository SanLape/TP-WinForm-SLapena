using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class imagenNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<imagen> lista = new List<imagen>();
        private string consutla;
        public List<imagen> listar(Articulo art)
        {
            consutla = "select Id, IdArticulo, ImagenUrl from IMAGENES WHERE IdArticulo = @idArt";
            try
            {
                datos.setConsulta(consutla);
                datos.setParametro("@idArt", art.id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    imagen imgAux = new imagen();

                    imgAux.id = (int)datos.Lector["Id"];
                    imgAux.idArticulo = (int)datos.Lector["IdArticulo"];
                    imgAux.urlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(imgAux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(imagen nuevo)
        {
            consutla = "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)";

            try
            {
                datos.setConsulta(consutla);

                datos.setParametro("@IdArticulo", nuevo.idArticulo);
                datos.setParametro("@ImagenUrl", nuevo.urlImagen);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void eliminar(int id)
        {
            consutla = "DELETE FROM IMAGENES WHERE ID = @id";

            try
            {
                datos.setConsulta(consutla);
                datos.setParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
