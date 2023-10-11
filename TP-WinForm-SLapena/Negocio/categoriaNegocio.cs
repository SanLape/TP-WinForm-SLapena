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
    }
}
