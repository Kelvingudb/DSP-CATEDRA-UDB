using BodegaUDB.Dtos;

namespace BodegaUDB.Service
{
    public interface ICategoriaProductoService
    {
        Task<List<CategoriaProductoInfoDto>> GetAllCategoriasProductos();
    }
}
