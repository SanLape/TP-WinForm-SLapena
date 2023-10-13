using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmCategoriaMarca : Form
    {
        private bool categoria = false;

        private List<Categoria> listaCat;
        private List<Marcar> listaMarcas;

        private categoriaNegocio datosCat;
        private marcaNegocio datosMarca;

        public frmCategoriaMarca(bool categoria)
        {
            InitializeComponent();
            configurar(categoria);
            cargar();
        }
        private void configurar(bool cat)
        {
            if (cat)
            {
                this.categoria = cat;
                lblTitulo.Text = "CATEGORIA ";
                lblAgregar.Text = "CATEGORIA: ";
                this.Text = "CATEGORIAS";
            }
            else
            {
                lblTitulo.Text = "MARCAS";
                lblAgregar.Text = "MARCA: ";
                this.Text = "MARCAS";
            }
        }
        private void cargar()
        {

            if (categoria)
            {
                datosCat = new categoriaNegocio();
                listaCat = datosCat.listar();
                dgwCatMarca.DataSource = listaCat;
                dgwCatMarca.Columns["id"].Visible = false;
            }
            else
            {
                datosMarca = new marcaNegocio();
                listaMarcas = datosMarca.listar();
                dgwCatMarca.DataSource = listaMarcas;
                dgwCatMarca.Columns["id"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (categoria)
            {
                Categoria catNueva = new Categoria();
                catNueva.nombre = txtAgregar.Text;

                try
                {
                    datosCat.agregar(catNueva);
                    MessageBox.Show("AGREGADA");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                Marcar marNueva = new Marcar();
                marNueva.nombre = txtAgregar.Text;

                try
                {
                    datosMarca.agregar(marNueva);
                    MessageBox.Show("AGREGADA");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            txtAgregar.Text = "";
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (categoria)
            {
                Categoria auxCat;
                auxCat = (Categoria)dgwCatMarca.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("ELIMINAR CATEGORIA", "ELIMINAR", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    datosCat.eliminar(auxCat.id);
                    MessageBox.Show("ELIMINADA");
                }
                else
                {
                    return;
                }
            }
            else
            {
                Marcar auxMar;
                auxMar = (Marcar)dgwCatMarca.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("ELIMINAR CATEGORIA", "ELIMINAR", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    datosMarca.eliminar(auxMar.id);
                    MessageBox.Show("ELIMINADO");
                }
                else
                {
                    return;
                }
            }
            cargar();
        }
    }
}
