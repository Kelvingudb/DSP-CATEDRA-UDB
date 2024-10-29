using BodegaUDB.Dtos;

namespace BodegaUDB.Service
{
    public interface ILoteService
    {
        Task<string> InsertLote(LoteRegisterDto loteRegisterDto);

        Task<List<LoteInfoDto>> GetAllLotes();

        Task UpdateLote(LoteUpdateDto loteUpdate);

        Task DeleteLote(LoteDeleteDto loteDeleteDto);
    }
}

