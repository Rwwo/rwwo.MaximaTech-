using System.Security.Claims;

using MaximaTech.api.Models;
using MaximaTech.App.Models;
using MaximaTech.App.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NuGet.Common;

namespace MaximaTech.App.Controllers
{
    public class DepartamentoController : Controller
    {
        string token = "";
        public IActionResult Index()
        {
            if (PersistirToken())
            {
                var services = new MaximaTechApiServices(token);

                var ret = services.ConsultarDepartamentos();

                if (ret.Success)
                {
                    List<Departamentos> dps = services.ConsultarDepartamentos().Result;

                    return View(dps);
                }
                else
                {
                    return View("Error", ret.Message);
                }
            }
            else
            {
                return View("Error", new ErroGenericoViewModel() { Mensagem = "Token expirado"});
            }
        }

        private bool PersistirToken()
        {
            if (User.Identity.IsAuthenticated)
            {
                token = User.FindFirstValue("token").RemoveQuotes();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
