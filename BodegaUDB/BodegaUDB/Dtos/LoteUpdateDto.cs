
namespace BodegaUDB.Dtos
{
    public class LoteUpdateDto
    {
        public int Id { get; set; }
        public int numSerie { get; set; }
        public DateOnly FECHA_PRODUCCION { get; set; }
        public DateOnly FECHA_INGRESO { get; set; }
        public decimal Precio { get; set; }
        public int ID_PROVEEDOR { get; set; }
    }
}

