using BodegaUDB.Dtos;
using BodegaUDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BodegaUDB.Service
{
    public class ProductoService : IProductoService
    {
        private readonly BodegaDspContext _dbContext;

        public ProductoService(BodegaDspContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertarProductoConDetalle(ProductoDto dto)
        {       
            using (var connection = _dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_InsertarProductoConDetalle";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@IdCategoria", dto.IdCategoria));
                    command.Parameters.Add(new SqlParameter("@SerieLote", dto.SerieLote));
                    command.Parameters.Add(new SqlParameter("@NombreProducto", dto.NombreProducto));
                    command.Parameters.Add(new SqlParameter("@FechaCaducidad", dto.FechaCaducidad.HasValue ? (object)dto.FechaCaducidad.Value : DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@DescripcionProducto", dto.DescripcionProducto));

                   
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0; 
                }
            }
        }

        public async Task<List<ProductoInfoDto>> GetProductosInfoAsync()
        {
            var productosInfo = await _dbContext.Productos
                .Join(
                    _dbContext.DetalleProductos,
                    producto => producto.IdProducto,
                    detalle => detalle.IdProducto,
                    (producto, detalle) => new { producto, detalle })
                .Join(
                    _dbContext.CategoriaProductos,
                    combined => combined.producto.CategoriaProducto,
                    categoria => categoria.IdCategoria,
                    (combined, categoria) => new { combined, categoria })
                .Join(
                    _dbContext.Lotes,
                    combined => combined.combined.producto.SerieLote, // Suponiendo que tienes un campo que relaciona productos con lotes
                    lote => lote.IdLote, // Asegúrate de que esta sea la clave correcta
                    (combined, lote) => new ProductoInfoDto
                    {
                        Id = combined.combined.detalle.IdDetalle,
                        Name = combined.combined.detalle.Nombre,
                        Fecha_caducidad = (DateOnly)combined.combined.detalle.FechaCaducidad,
                        Categoria_Producto = combined.categoria.Nombre,
                        ID_CATEGORIA = combined.combined.producto.CategoriaProducto,
                        NUM_SERIE = lote.NumSerie, // Asegúrate de que el campo existe en Lotes
                        ID_SERIE = lote.IdLote
                    })
                .ToListAsync();

            return productosInfo;
        }






    }
}
