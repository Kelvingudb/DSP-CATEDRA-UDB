namespace BodegaUDB.Dtos
{
    public class ProductoFormDto
    {
        public List<CategoriaProductoInfoDto> Categorias { get; set; }

        public List<LoteProductoDto> LoteProductos { get; set; }
    }
}
