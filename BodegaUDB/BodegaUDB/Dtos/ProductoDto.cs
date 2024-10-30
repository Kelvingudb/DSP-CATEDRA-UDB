namespace BodegaUDB.Dtos
{
    public class ProductoDto
    {
        public int IdCategoria { get; set; }
        public int SerieLote { get; set; }
        public string NombreProducto { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string DescripcionProducto { get; set; }
    }

}
