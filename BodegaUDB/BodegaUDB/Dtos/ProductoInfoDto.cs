namespace BodegaUDB.Dtos
{
    public class ProductoInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly Fecha_caducidad { get; set; }

        public string Categoria_Producto { get; set; }


        public int ID_CATEGORIA { get; set; }


        public int NUM_SERIE {  get; set; }

        public int ID_SERIE { get; set; }
    }
}
