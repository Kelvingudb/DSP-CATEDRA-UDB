using BodegaUDB.Dtos;
using BodegaUDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BodegaUDB.Service
{
    public class LoteService : ILoteService
    {
        private readonly BodegaDspContext _dbContext;
        public LoteService(BodegaDspContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<string> InsertLote(LoteRegisterDto loteRegisterDto)
        {
            string Message = string.Empty;
            try
            {
                var Lote = new Lote()
                {
                    NumSerie = loteRegisterDto.NUM_SERIE,
                    FechaProduccion = loteRegisterDto.FECHA_PRODUCCION,
                    FechaIngreso = loteRegisterDto.FECHA_INGRESO,
                    Precio = loteRegisterDto.PRECIO,
                    IdProveedor = loteRegisterDto.ID_PROVEEDOR
                };
                await _dbContext.Lotes.AddAsync(Lote);
                await _dbContext.SaveChangesAsync();

                Message = "Se ha registrado correctamente";
                return Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Message;
            }
           
        }

        public async Task<List<LoteInfoDto>> GetAllLotes()
        {
            var lotes = await _dbContext.Lotes
                .Join(
                    _dbContext.Proveedors,
                    lote => lote.IdProveedor,
                    proveedor => proveedor.IdProveedor,
                    (lote, proveedor) => new LoteInfoDto
                    {   
                        Id = lote.IdLote,
                        NUM_SERIE = lote.NumSerie,
                        FECHA_PRODUCCION = lote.FechaProduccion,
                        FECHA_INGRESO = lote.FechaIngreso,
                        PRECIO = lote.Precio,
                        NOMBRE_PROVEEDOR = $"{proveedor.Nombre} {proveedor.Apellido}",
                        ID_PROVEEDOR = proveedor.IdProveedor
                    })
                .ToListAsync();

            return lotes;
        }
        public async Task UpdateLote(LoteUpdateDto loteDto)
        {
            var lote = await _dbContext.Lotes.FindAsync(loteDto.Id);
            if (lote != null)
            {
                lote.FechaProduccion = loteDto.FECHA_INGRESO;
                lote.FechaIngreso = loteDto.FECHA_INGRESO;
                lote.Precio = loteDto.Precio;
                lote.IdProveedor = loteDto.ID_PROVEEDOR;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteLote(LoteDeleteDto loteDeleteDto)
        {
            var lote = await _dbContext.Lotes.FindAsync(loteDeleteDto.ID);
            if (lote != null)
            {
                _dbContext.Lotes.Remove(lote);
                await _dbContext.SaveChangesAsync();
            }
        }

      
    }
}
