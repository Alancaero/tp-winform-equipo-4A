using Dominio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class ArticuloDetalleForm : Form
    {
        private Articulo _articulo;
        public ArticuloDetalleForm(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
            CargarArticulo();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarArticulo()
        {
            if (_articulo == null)
                return;

            txtCodigo.Text = _articulo.Codigo;
            txtNombre.Text = _articulo.Nombre;
            txtPrecio.Text = _articulo.Precio.ToString();
            txtDescripcion.Text = _articulo.Descripcion;
            txtMarca.Text = _articulo.Marca?.Descripcion;
            txtCategoria.Text = _articulo.Categoria?.Descripcion;

            var listaImagenes = ImagenBL.GetImagenesByIdArticulo(_articulo.Id);
            
            foreach (Imagen item in listaImagenes)
            {
                pbxImagen.Load(listaImagenes[0].ImagenUrl);
            }
        }
    }
}
