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
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            categoriaNegocio catNeg = new categoriaNegocio();
            marcaNegocio marcNeg = new marcaNegocio();
            try
            {
                cbCategoria.DataSource = catNeg.listar();
                cbMarca.DataSource = marcNeg.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            articuloNegocio datos = new articuloNegocio();

            try
            {
                nuevo.codArticulo = txbCodigo.Text;
                nuevo.nombre = txtNombre.Text;
                nuevo.descripcion = txbDescripcion.Text;
                nuevo.marca = (Marcar)cbMarca.SelectedItem;
                nuevo.categoria = (Categoria)cbCategoria.SelectedItem;
                nuevo.precio = decimal.Parse(txbPrecio.Text);

                datos.agregar(nuevo);
                MessageBox.Show("AGREGADO");
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
