using BodegaUDB.Dtos;
using BodegaUDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BodegaUDB.Service
{
    public class ProveedorService: IProveedorService
    {
        private readonly BodegaDspContext _dbContext;
        public ProveedorService(BodegaDspContext dbContext) {
            _dbContext = dbContext;
        
        }
        public async Task<List<ProveedorLoteDto>> GetAllProveedoresLote()
        {
            var ProveedoresLote = await  _dbContext.Proveedors.
                Select(
                p => new ProveedorLoteDto
                {
                    Id = p.IdProveedor,
                    Name = p.Nombre + " " + p.Apellido
                }).ToListAsync();

            return ProveedoresLote;
       
        }
    }
}
