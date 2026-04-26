using AccesoADatos;
using Dominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class CategoriaBL
    {
        public static List<Categoria> GetCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();            
            return dao.GetCategorias();
        }

        public static void Agregar(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new Exception("La descripción es obligatoria");

            ValidarExistencia(descripcion);

            CategoriaDAO dao = new CategoriaDAO();
            dao.Agregar(descripcion);
        }

        public static void Modificar(int id, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new Exception("La descripción es obligatoria");

            ValidarExistencia(descripcion);

            CategoriaDAO dao = new CategoriaDAO();
            dao.Modificar(id, descripcion.Trim());
        }

        public static void Eliminar(int id)
        {
            CategoriaDAO dao = new CategoriaDAO();
            dao.Eliminar(id);
        }

        private static void ValidarExistencia(string descripcion)
        {
            var auxDescripcion = descripcion.Trim().ToUpper();

            List<Categoria> Categorias = GetCategorias();
            foreach (Categoria Categoria in Categorias)
            {
                if (Categoria.Descripcion.Trim().ToUpper() == auxDescripcion)
                    throw new Exception("La Categoria ya existe");
            }
        }

    }
}
