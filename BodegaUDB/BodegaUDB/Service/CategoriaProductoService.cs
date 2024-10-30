using BodegaUDB.Dtos;
using BodegaUDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BodegaUDB.Service
{
    public class CategoriaProductoService : ICategoriaProductoService
    {
        private readonly BodegaDspContext _dbContext;
        public CategoriaProductoService(BodegaDspContext dbContext) {
            _dbContext = dbContext;
        
        }
        public async Task<List<CategoriaProductoInfoDto>> GetAllCategoriasProductos()
        {
            var Categorias = await _dbContext.CategoriaProductos.Select(

                c => new CategoriaProductoInfoDto
                {
                    Id = c.IdCategoria,
                    Name = c.Nombre
                }).ToListAsync();

            return Categorias;
        }
    }
}
