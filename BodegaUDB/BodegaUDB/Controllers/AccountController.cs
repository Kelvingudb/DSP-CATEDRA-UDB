using BodegaUDB.Dtos;
using BodegaUDB.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BodegaUDB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService) {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
           
                // Llamar al servicio de autenticación
                string roleName = await _authService.AuthenticateUser(userLoginDto);

                if (roleName != null) // Autenticación exitosa
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userLoginDto.UserName),
                    new Claim(ClaimTypes.Role, roleName) // Agregar el rol
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    
                    if(roleName == "Administrador")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (roleName == "Empleado")
                    {
                    return RedirectToAction("Index", "Admin");
                     }
                }
                    ModelState.AddModelError("", "Credenciales inválidas.");
                 return View(userLoginDto);
        }
    }
}
