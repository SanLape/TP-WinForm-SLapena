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
    }
}
