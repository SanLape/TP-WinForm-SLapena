using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        private List<imagen> listaImagen;
        public frmPrincipal()
        {
            InitializeComponent();
            cargarArticulos();
        }
        public void cargarArticulos()
        {
            articuloNegocio articulo = new articuloNegocio();
            imagenNegocio imgNeg = new imagenNegocio();

            try
            {
                listaArticulos = articulo.listar();
                dgwArticulos.DataSource = listaArticulos;

                cargarImagen(listaArticulos[0]);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargarArticulos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo nuevoArticulo = new frmAgregarArticulo();
            nuevoArticulo.ShowDialog();
            cargarArticulos();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategoriaMarca categoria = new frmCategoriaMarca(true);
            categoria.ShowDialog();
            cargarArticulos();

        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmCategoriaMarca marca = new frmCategoriaMarca(false);
            marca.ShowDialog();
            cargarArticulos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio datos = new articuloNegocio();
            Articulo artAux;

            try
            {
                DialogResult respuesta = MessageBox.Show("ELIMINAR ARTICULO", "ELIMINAR", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    artAux = (Articulo)dgwArticulos.CurrentRow.DataBoundItem;
                    datos.eliminar(artAux.id);
                    cargarArticulos();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo artAux;
            artAux = (Articulo)dgwArticulos.CurrentRow.DataBoundItem;

            frmAgregarArticulo modificar = new frmAgregarArticulo(artAux);
            modificar.ShowDialog();
            cargarArticulos();
        }

        private void dgwArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo art = (Articulo)dgwArticulos.CurrentRow.DataBoundItem;
            cargarImagen(art);
        }
        private void cargarImagen(Articulo art)
        {
            imagenNegocio imgNeg = new imagenNegocio();
            
            try
            {
                 
                listaImagen = imgNeg.listar(art);
                int n = listaImagen.Count;
                
                for (int i = 0; i < n; i++)
                {
                    pBoxArticulo.Load(listaImagen[i].urlImagen);
                }
            }
            catch (Exception)
            {

                pBoxArticulo.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }

        }
    }
}
