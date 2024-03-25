using System.Security.Claims;

using MaximaTech.api.Models;
using MaximaTech.App.Models;
using MaximaTech.App.Services;

using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.App.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            string token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);

            var ret = _apiServices.ConsultarDepartamentos();
            if (ret.Success)
                return View(ret.Result);

            return View("Error", ret.Message);

        }

        private string ObterToken()
        {
            if (User.Identity.IsAuthenticated)
                return User.FindFirstValue("Token")?.RemoveQuotes();

            return null;
        }
    }
}
