using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class articuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Articulo> lista = new List<Articulo>();

        public List<Articulo> listar()
        {
            try
            {
                // corregit la consulta 
                string select = "SELECT A.Id, A.Codigo, A.Descripcion, A.IdMarca, M.Descripcion MARCA, A.IdCategoria, C.Descripcion CATEGORIA, A.Precio";
                string from = " FROM ARTICULOS A, CATEGORIAS C, MARCAS M";
                string where = " WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                string consutla = select + from + where;

                datos.setConsulta(consutla);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo artAux = new Articulo();

                    artAux.id = (int)datos.Lector["Id"];
                    artAux.codArticulo = (string)datos.Lector["Codigo"];
                    artAux.descripcion = (string)datos.Lector["Descripcion"];

                    artAux.marca = new Marcar();
                    artAux.marca.id = (int)datos.Lector["IdMarca"];
                    artAux.marca.nombre = (string)datos.Lector["MARCA"];

                    artAux.categoria = new Categoria();
                    artAux.categoria.id = (int)datos.Lector["IdCategoria"];
                    artAux.categoria.nombre = (string)datos.Lector["CATEGORIA"];

                    artAux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(artAux);
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
