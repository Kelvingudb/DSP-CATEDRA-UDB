using BodegaUDB.Dtos;

namespace BodegaUDB.Service
{
    public interface IProductoService
    {

        Task<bool> InsertarProductoConDetalle(ProductoDto dto);
        Task<List<ProductoInfoDto>> GetProductosInfoAsync();
    }
}
