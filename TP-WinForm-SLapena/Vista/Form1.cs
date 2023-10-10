using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Vista
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulo;
        public Form1()
        {
            InitializeComponent();
        }
        public void cargar()
        {
            articuloNegocio articulo = new articuloNegocio();
            listaArticulo = articulo.listar();
            dgwArticulo.DataSource = listaArticulo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
