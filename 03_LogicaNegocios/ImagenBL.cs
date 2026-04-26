using AccesoADatos;
using Dominio;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class ImagenBL
    {
        public static List <Imagen> GetImagenesByIdArticulo(int articuloId)
        {
            ImagenDAO dao = new ImagenDAO();

            List<Imagen> resultado = dao.GetImagenesByIdArticulo(articuloId);

            return resultado;
        }
    }
}

