using BodegaUDB.Dtos;
using BodegaUDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace BodegaUDB.Service
{
    public class AuthService : IAuthService
    {
        private BodegaDspContext _dbContext;
        public AuthService(BodegaDspContext dbContext) { 
            
            _dbContext = dbContext;
        }

        //Metodo encargado de consultar el usuario en la base de datos y devolver su rol.
        public async Task<string> AuthenticateUser(UserLoginDto userLoginDto)
        {
            string roleName = null;

            using(var command = _dbContext.Database.GetDbConnection().CreateCommand())
        {
                command.CommandText = "sp_AuthenticateUser";
                command.CommandType = CommandType.StoredProcedure;

                var usernameParam = new SqlParameter("@Username", SqlDbType.NVarChar, 100) { Value = userLoginDto.UserName};
                var passwordParam = new SqlParameter("@Password", SqlDbType.NVarChar, 100) { Value = userLoginDto.Password };
                var roleParam = new SqlParameter("@RoleName", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };


                command.Parameters.Add(usernameParam);
                command.Parameters.Add(passwordParam);
                command.Parameters.Add(roleParam);

          
                await _dbContext.Database.OpenConnectionAsync();
                await command.ExecuteNonQueryAsync();

            
                roleName = roleParam.Value?.ToString();
            }

            return roleName; 
        }
    }
    
}
