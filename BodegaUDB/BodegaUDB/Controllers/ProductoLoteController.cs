using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // Asegúrate de usar el espacio de nombres correcto
using Microsoft.Extensions.Configuration;
using BodegaUDB.Models;
using System.Collections.Generic;

namespace BodegaUDB.Controllers
{
    public class ProductoLoteController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductoLoteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CrearProducto()
        {
            List<Lote> lotes = ObtenerLoteDB();
            ViewBag.Lotes = lotes;

            return View("~/Views/Home/CrearProducto.cshtml");
        }

        [HttpPost]
        public IActionResult CrearProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("BodegaDspContext");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO PRODUCTO (SERIE_LOTE, CATEGORIA_PRODUCTO) VALUES (@SerieLote, @CategoriaProducto)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SerieLote", producto.SerieLote);
                        cmd.Parameters.AddWithValue("@CategoriaProducto", producto.CategoriaProducto);
                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = "Producto guardado con éxito.";
                return RedirectToAction("ListaProductos", "ProductoLote");
            }

            ViewBag.Lotes = ObtenerLoteDB();
            return View("~/Views/Home/CrearProducto.cshtml", producto);
        }

        private List<Lote> ObtenerLoteDB()
        {
            List<Lote> lotes = new List<Lote>();
            string connectionString = _configuration.GetConnectionString("BodegaDspContext");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID_LOTE, NUM_SERIE FROM LOTE"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lote lote = new Lote
                            {
                                IdLote = reader.GetInt32(0), 
                                NumSerie = reader.GetInt32(1) 
                            };
                            lotes.Add(lote);
                        }
                    }
                }
            }

            return lotes;
        }
        //***************************************************************************************************************************************************************************

        [HttpGet]
        public IActionResult CrearLote()
        {
            List<Proveedor> proveedores = ObtenerProveedoresDesdeLaBaseDeDatos();
            ViewBag.Proveedores = proveedores;

            return View("~/Views/Home/CrearLote.cshtml");
        }

        [HttpPost]
        public IActionResult CrearLote(Lote lote)
        {
            if (ModelState.IsValid)
            {
                string connectionString = _configuration.GetConnectionString("BodegaDspContext");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO LOTE (NUM_SERIE, FECHA_PRODUCCION, FECHA_INGRESO, PRECIO, ID_PROVEEDOR) VALUES (@NumSerie, @FechaProduccion, @FechaIngreso, @Precio, @IdProveedor)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NumSerie", lote.NumSerie);
                        cmd.Parameters.AddWithValue("@FechaProduccion", lote.FechaProduccion);
                        cmd.Parameters.AddWithValue("@FechaIngreso", lote.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Precio", lote.Precio);
                        cmd.Parameters.AddWithValue("@IdProveedor", lote.IdProveedor);
                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = "Lote creado con éxito.";
                return RedirectToAction("ListaLotes", "Lote"); 
            }

            List<Proveedor> proveedores = ObtenerProveedoresDesdeLaBaseDeDatos();
            ViewBag.Proveedores = proveedores;
            return View("~/Views/Home/CrearLote.cshtml", lote);
        }

        private List<Proveedor> ObtenerProveedoresDesdeLaBaseDeDatos()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            string connectionString = _configuration.GetConnectionString("BodegaDspContext");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM PROVEEDOR";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            IdProveedor = (int)reader["IdProveedor"],
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }

            return proveedores;
        }

        //*******************************************************************************************************************************************************************************************
        public IActionResult ListaProductos()
        {
            var productos = ObtenerProductosDB();
            return View("~/Views/Home/ListaProductos.cshtml", productos);
        }

        private IEnumerable<Producto> ObtenerProductosDB()
        {
            List<Producto> productos = new List<Producto>();
            string connectionString = _configuration.GetConnectionString("BodegaDspContext");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT p.*, 
                   l.Num_Serie AS NumSerie, 
                   cp.Nombre AS NombreCategoria 
            FROM PRODUCTO p
            JOIN LOTE l ON p.SERIE_LOTE = l.ID_LOTE
            JOIN CATEGORIA_PRODUCTO cp ON p.CATEGORIA_PRODUCTO = cp.ID_CATEGORIA"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto
                        {
                            IdProducto = (int)reader["ID_PRODUCTO"],
                            SerieLote = (int)reader["SERIE_LOTE"],
                            CategoriaProducto = (int)reader["CATEGORIA_PRODUCTO"],
                            DetalleProducto = new DetalleProducto
                            {
                                Nombre = reader["NombreDetalle"] != DBNull.Value ? reader["NombreDetalle"].ToString() : null 
                            },
                            SerieLoteNavigation = new Lote
                            {
                                NumSerie = (int)reader["NumSerie"] 
                            },
                            CategoriaProductoNavigation = new CategoriaProducto
                            {
                                Nombre = reader["NombreCategoria"] != DBNull.Value ? reader["NombreCategoria"].ToString() : null // Maneja posibles valores nulos
                            }
                        };
                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        //********************************************************************************************************************************************************************************
                [HttpGet]
        [HttpGet]
        public IActionResult ListaLotes()
        {
            IEnumerable<Lote> lotes = ObtenerLotesDB();

            return View("~/Views/Home/ListaLotes.cshtml", lotes);
        }

        // metodo para obtener lotes de la base de datos
        private IEnumerable<Lote> ObtenerLotesDB()
        {
            List<Lote> lotes = new List<Lote>();
            string connectionString = _configuration.GetConnectionString("BodegaDspContext");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT L.*, P.Nombre, P.Apellido, P.Correo, P.Telefono FROM LOTE L JOIN PROVEEDOR P ON L.ID_PROVEEDOR = P.ID_PROVEEDOR";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lote lote = new Lote
                            {
                                IdLote = (int)reader["ID_LOTE"],
                                NumSerie = (int)reader["NUM_SERIE"],
                                FechaProduccion = (DateOnly)reader["FECHA_PRODUCCION"],
                                FechaIngreso = (DateOnly)reader["FECHA_INGRESO"],
                                Precio = (decimal)reader["PRECIO"],
                                IdProveedor = (int)reader["ID_PROVEEDOR"],
                                IdProveedorNavigation = new Proveedor
                                {
                                    IdProveedor = (int)reader["ID_PROVEEDOR"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Correo = reader["Correo"].ToString(),
                                    Telefono = reader["Telefono"].ToString()
                                }
                            };
                            lotes.Add(lote);
                        }
                    }
                }
            }

            return lotes;
        }

    }//fin class controller
}
