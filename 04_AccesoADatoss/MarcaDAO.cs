using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatoss
{
    public class MarcaDAO
    {
        private AccesoADatosDAO _accesoADatos = new AccesoADatosDAO();

        public List<Marca> GetMarcas()
        {
            try
            {
                List<Marca> lista = new List<Marca>();
                _accesoADatos.setearConsulta("Select * From Marcas");
                _accesoADatos.ejecutarLectura();

                while (_accesoADatos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)_accesoADatos.Lector["Id"];
                    aux.Descripcion =(string)_accesoADatos.Lector["Descripcion"];
                    lista.Add(aux);
            }
                return lista;
            } catch (Exception) {
                throw;
            } finally { _accesoADatos.cerrarConexion(); }
        }
    }
}
