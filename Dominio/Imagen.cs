namespace Dominio
{
    public class Imagen
    {        
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public string ImagenUrl { get; set; }        
    }
}
