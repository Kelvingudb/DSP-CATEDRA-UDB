using BodegaUDB.Models;

namespace BodegaUDB.Dtos
{
    public class LotesProveedoresDto
    {
        public List<LoteInfoDto> Lotes { get; set; }
        public List<ProveedorLoteDto> Proveedores { get; set; }
    }
}
