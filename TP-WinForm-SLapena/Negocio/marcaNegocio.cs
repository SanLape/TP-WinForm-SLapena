using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class marcaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Marcar> lista = new List<Marcar>();
        private string consulta; 

        public List<Marcar> listar()
        {
            string consulta = "SELECT id, Descripcion FROM MARCAS";
            try
            {
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcar auxMarca = new Marcar();

                    auxMarca.id = (int)datos.Lector["id"];
                    auxMarca.nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(auxMarca);
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
        public void agregar(Marcar nueva)
        {
            consulta = "INSERT INTO MARCAS(Descripcion) VALUES (@Descripcion)";
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
            consulta = "DELETE FROM MARCAS WHERE id = @id";

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
