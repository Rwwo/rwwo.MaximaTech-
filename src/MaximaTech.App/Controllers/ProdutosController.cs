using System.Security.Claims;

using MaximaTech.api.Models;
using MaximaTech.App.Models;
using MaximaTech.App.Services;

using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.App.Controllers
{
    public class ProdutosController : Controller
    {
        string token = "";

        public IActionResult Index()
        {
            if (PersistirToken())
            {
                var services = new MaximaTechApiServices(token);

                var ret = services.ConsultarProdutos();

                if (ret.Success)
                {
                    List<Produtos> prods = ret.Result;
                    return View(prods);
                }
                else
                {
                    return View("Error", ret.Message);
                }
            }
            else
            {
                return View("Error", new ErroGenericoViewModel() { Mensagem = "Token expirado" });
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

        // Action para exibir o formulário de criação de produto (view Create)
        public IActionResult Create()
        {
            if (PersistirToken())
            {
                var services = new MaximaTechApiServices(token);

                List<Departamentos> dps = services.ConsultarDepartamentos().Result;

                ViewBag.Departamentos = dps;
                return View();
            }
            else
            {
                return View("Error", new ErroGenericoViewModel() { Mensagem = "Token expirado" });
            }
        }

        // Action para salvar um novo produto
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            if (PersistirToken())
            {
                var services = new MaximaTechApiServices(token);
                if (ModelState.IsValid)
                {
                    services.AdicionarProduto(produto);

                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Departamentos = services.ConsultarDepartamentos().Result;
                return View(produto);
            }
            else
            {
                return View("Error", new ErroGenericoViewModel() { Mensagem = "Token expirado" });
            }
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            if (PersistirToken())
            {

                var services = new MaximaTechApiServices(token);

                var produto = services.ConsultarProdutosDetalhes(Id);
                if (produto == null)
                {
                    return NotFound();
                }
                return View(produto.Result);
            }
            else
            {
                return View("Error", new ErroGenericoViewModel() { Mensagem = "Token expirado" });
            }
        }
    }
}