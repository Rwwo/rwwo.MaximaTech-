using System.Security.Claims;

using MaximaTech.api.Models;
using MaximaTech.App.Models;
using MaximaTech.App.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.App.Controllers
{
    public class ContaController : Controller
    {
        MaximaTechApiServices service;
        public ContaController()
        {
            service = new MaximaTechApiServices(null);
        }
        public IActionResult Registro()
        {
            return View();
        }


        // GET: /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Conta/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ret = service.Registrar(model);

                if (ret.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("authToken", ret.Result.ToString().Replace("\"", ""));
                }
                else
                {
                    return View("Error", new ErroGenericoViewModel { Mensagem = $"Erro ao efetuar login. Por favor, tente novamente. {ret.Result}" });
                }

                // Lógica de registro aqui
                return RedirectToAction("Login", "Conta");
            }
            return View(model);
        }



        // POST: /Conta/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ret = service.Login(model);

                if (ret.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim("token", ret.Result)
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    var principal = new ClaimsPrincipal(userIdentity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Error", new ErroGenericoViewModel { Mensagem = $"Erro ao efetuar login. Por favor, tente novamente. {ret.Result}" });
                }
            }
            return View(model);
        }
    }
}
