using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class CategoriaDAO
    {
        private AccesoADatosDAO _accesoADatos = new AccesoADatosDAO();

        public List<Categoria> GetCategorias()
        {
            try
            {
                List<Categoria> lista = new List<Categoria>();
                _accesoADatos.setearConsulta("Select * From Categorias");
                _accesoADatos.ejecutarLectura();

                while (_accesoADatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)_accesoADatos.Lector["Id"];
                    aux.Descripcion =(string)_accesoADatos.Lector["Descripcion"];
                    lista.Add(aux);
            }
                return lista;
            } catch (Exception) {
                throw;
            } finally { _accesoADatos.cerrarConexion(); }
        }
        public void Agregar(string descripcion)
        {
            AccesoADatosDAO datos = new AccesoADatosDAO();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Categorias (Descripcion) VALUES ('" + descripcion + "')"
                );

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la Categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(int id, string descripcion)
        {
            AccesoADatosDAO datos = new AccesoADatosDAO();

            try
            {
                datos.setearConsulta(
                    "UPDATE Categorias SET Descripcion = '" + descripcion + "' WHERE Id = " + id
                );

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoADatosDAO datos = new AccesoADatosDAO();

            try
            {
                datos.setearConsulta(
                    "DELETE FROM Categorias WHERE Id = " + id
                );

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Categoria: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
