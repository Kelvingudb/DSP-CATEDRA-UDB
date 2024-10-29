using BodegaUDB.Dtos;

namespace BodegaUDB.Service
{
    public interface IProveedorService
    {

        Task<List<ProveedorLoteDto>> GetAllProveedoresLote();
    }
}
