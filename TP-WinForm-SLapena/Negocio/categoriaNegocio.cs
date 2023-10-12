using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class categoriaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Categoria> lista = new List<Categoria>();
        private string consulta;

        public List<Categoria> listar()
        {
            string consulta = "SELECT id, Descripcion FROM CATEGORIAS";
            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria auxCat = new Categoria();

                    auxCat.id = (int)datos.Lector["id"];
                    auxCat.nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(auxCat);
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
        public void agregar(Categoria nueva)
        {
            consulta = "INSERT INTO CATEGORIAS(Descripcion) VALUES (@Descripcion)";

            try
            {
                datos.setConsulta(consulta);

                datos.setParametro("@Descripcion", nueva.nombre);

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
            consulta = "DELETE FROM CATEGORIAS WHERE id = @id";

            try
            {
                datos.setConsulta(consulta);
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
