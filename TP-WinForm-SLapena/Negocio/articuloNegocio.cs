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
                // cambiar la consulta
                string select = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion MARCA, A.IdCategoria, C.Descripcion CATEGORIA, A.Precio";
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
                    artAux.nombre = (string)datos.Lector["Nombre"];
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
        public void agregar(Articulo nuevo)
        {
            string consutla = "INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)";

            try
            {
                datos.setConsulta(consutla);

                datos.setParametro("@Codigo", nuevo.codArticulo);
                datos.setParametro("@Nombre", nuevo.nombre);
                datos.setParametro("@Descripcion", nuevo.descripcion);
                datos.setParametro("@IdMarca", nuevo.marca.id);
                datos.setParametro("@IdCategoria", nuevo.categoria.id);
                datos.setParametro("@Precio", nuevo.precio);

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
            string consulta = "DELETE FROM ARTICULOS WHERE id = @id";

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
        public void modificar(Articulo modificar)
        {
            string consulta = "UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCat, Precio = @precio WHERE id = @id";
            try
            {
                datos.setConsulta(consulta);
                datos.setParametro("@codigo", modificar.codArticulo);
                datos.setParametro("@nombre", modificar.nombre);
                datos.setParametro("@descripcion", modificar.descripcion);
                datos.setParametro("@idMarca", modificar.marca.id);
                datos.setParametro("@idCat", modificar.categoria.id);
                datos.setParametro("@precio", modificar.precio);
                datos.setParametro("@id", modificar.id);

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
