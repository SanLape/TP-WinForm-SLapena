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
    public partial class frmAgregarArticulo : Form
    {
        private Articulo art = null;
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }
        public frmAgregarArticulo(Articulo art)
        {
            InitializeComponent();
            this.art = art;
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            categoriaNegocio catNeg = new categoriaNegocio();
            marcaNegocio marcNeg = new marcaNegocio();
            try
            {
                cbCategoria.DataSource = catNeg.listar();
                cbCategoria.ValueMember = "id";
                cbCategoria.DisplayMember = "nombre";
                cbMarca.DataSource = marcNeg.listar();
                cbMarca.ValueMember = "id";
                cbMarca.DisplayMember = "nombre";

                if (art != null)
                {
                    txbCodigo.Text = art.codArticulo;
                    txbNombre.Text = art.nombre;
                    txbDescripcion.Text = art.descripcion;
                    txbPrecio.Text = art.precio.ToString();

                    cbCategoria.SelectedValue = art.categoria.id;
                    cbMarca.SelectedValue = art.marca.id;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            articuloNegocio datos = new articuloNegocio();

            try
            {
                if (art == null)
                {
                    art = new Articulo();
                }
                art.codArticulo = txbCodigo.Text;
                art.nombre = txbNombre.Text;
                art.descripcion = txbDescripcion.Text;
                art.marca = (Marcar)cbMarca.SelectedItem;
                art.categoria = (Categoria)cbCategoria.SelectedItem;
                art.precio = decimal.Parse(txbPrecio.Text);

                if (art.id != 0)
                {
                    datos.modificar(art);
                    MessageBox.Show("MODIFICADO");
                }
                else
                {
                    datos.agregar(art);
                    MessageBox.Show("AGREGADO");
                }

                Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCandelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
