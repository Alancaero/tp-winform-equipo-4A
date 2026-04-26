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
using LogicaNegocio;

namespace Vista
{
    public partial class ArticuloListadoForm : Form
    {
        public ArticuloListadoForm()
        {
            InitializeComponent();
            fillCombos();
            dgvArticulos.AutoGenerateColumns = false;
        }

        private void fillCombos()
        {
            var listaMarcas = MarcaBL.GetMarcas();

            foreach (Marca marca in listaMarcas)
            {
                cboMarca.Items.Add(marca.Descripcion);
            }

            var listaCategorias = CategoriaBL.GetCategorias();
            foreach (Categoria categoria in listaCategorias)
            {
                cboCategoria.Items.Add(categoria.Descripcion);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var articulos = ArticuloBL.GetByFilter(txtCodigo.Text, txtNombre.Text, cboMarca.Text, cboCategoria.Text);
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = articulos;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }                         
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            cboMarca.SelectedIndex = -1;
            cboCategoria.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Form formAlta = new ArticuloAltaForm();
            formAlta.MdiParent = MdiParent;
            formAlta.Dock = DockStyle.Fill;
            formAlta.Show();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un artículo para ver su detalle.");
            }

            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            Form formDetalle = new ArticuloDetalleForm(articulo);
            formDetalle.MdiParent = MdiParent;
            formDetalle.Dock = DockStyle.Fill;
            formDetalle.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un artículo para eliminar.");
                return;
            }

            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            
            DialogResult advertencia = MessageBox.Show(
            "¿Estás seguro de que deseas eliminar este artículo?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (advertencia == DialogResult.Yes)
            {
                try
                {
                    ArticuloBL.Eliminar(articulo.Id);
                    MessageBox.Show("Artículo eliminado exitosamente.");

                    // actualiza la grilla
                    btnBuscar_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if(dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un artículo para modificar.");
            }

            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            Form formAlta = new ArticuloAltaForm(articulo);
            formAlta.MdiParent = MdiParent;
            formAlta.Dock = DockStyle.Fill;
            formAlta.Show();
        }
    }
}
