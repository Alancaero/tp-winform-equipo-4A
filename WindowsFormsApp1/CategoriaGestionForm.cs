using Dominio;
using LogicaNegocio;
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
    public partial class CategoriaGestionForm : Form
    {

        private Categoria _categoriaSeleccionada;
        public CategoriaGestionForm()
        {
            InitializeComponent();
            dgvCategorias.AutoGenerateColumns = false;            
            CargarGrilla();
        }        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _categoriaSeleccionada = null;
            txtCategoria.Clear(); 
            txtCategoria.Enabled = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoriaSeleccionada == null)
                {            
                    CategoriaBL.Agregar(txtCategoria.Text);
                    MessageBox.Show("Categoria creada correctamente");
                    txtCategoria.Enabled = false;
                }
                else
                {
                    CategoriaBL.Modificar(_categoriaSeleccionada.Id, txtCategoria.Text);
                    MessageBox.Show("Categoria modificada correctamente");
                }

                CargarGrilla();
                txtCategoria.Clear();
                _categoriaSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrilla()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = CategoriaBL.GetCategorias();
        }
       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una Categoria para modificar.");
                return;
            }
            txtCategoria.Enabled = true;
            _categoriaSeleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

            txtCategoria.Text = _categoriaSeleccionada.Descripcion;            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una Categoria para eliminar.");
                return;
            }

            Categoria categoria = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

            DialogResult resp = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta Categoria?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    CategoriaBL.Eliminar(categoria.Id);
                    MessageBox.Show("Categoria eliminada correctamente");

                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
