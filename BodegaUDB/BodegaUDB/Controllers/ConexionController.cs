using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace BodegaUDB.Controllers
{
    public class ConexionController : Controller
    {
        private readonly IConfiguration configuration;

        public ConexionController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");

            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                try
                {
                    conexion.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la conexión: {ex.Message}");
                }
            }

            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
