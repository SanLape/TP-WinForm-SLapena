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
        public frmPrincipal()
        {
            InitializeComponent();
            cargarArticulos();
        }
        public void cargarArticulos()
        {
            articuloNegocio articulo = new articuloNegocio();
            listaArticulos = articulo.listar();
            dgwArticulos.DataSource = listaArticulos;
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
    }
}
