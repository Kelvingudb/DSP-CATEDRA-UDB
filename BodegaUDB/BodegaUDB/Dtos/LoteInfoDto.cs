namespace BodegaUDB.Dtos
{
    public class LoteInfoDto
    {
        public int Id { get; set; }
        public int NUM_SERIE { get; set; }
        public DateOnly FECHA_PRODUCCION { get; set; }
        public DateOnly FECHA_INGRESO { get; set; }
        public decimal PRECIO { get; set; }
        public string NOMBRE_PROVEEDOR{ get; set; }

        public int ID_PROVEEDOR {  get; set; }
    }
}
