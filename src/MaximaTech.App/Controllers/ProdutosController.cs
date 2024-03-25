using System.Security.Claims;

using MaximaTech.api.Models;
using MaximaTech.App.Models;
using MaximaTech.App.Services;
using MaximaTech.Application.Command;

using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.App.Controllers
{
    public class ProdutosController : Controller
    {
        string token = "";

        public IActionResult Index()
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            var ret = _apiServices.ConsultarProdutos();
            if (ret.Success)
                return View(ret.Result);

            return View("Error", ret.Message);
        }
        public string ObterToken()
        {
            if (User.Identity.IsAuthenticated)
                return User.FindFirstValue("Token")?.RemoveQuotes();

            return null;
        }

        // Action para exibir o formulário de criação de produto (view Create)
        public IActionResult Create()
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            ViewBag.Departamentos = _apiServices.ConsultarDepartamentos().Result;
            return View();
        }

        // Action para salvar um novo produto
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            if (ModelState.IsValid)
            {
                _apiServices.AdicionarProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departamentos = _apiServices.ConsultarDepartamentos().Result;
            return View(produto);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            var produto = _apiServices.ConsultarProdutoDetalhes(Id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto.Result);
        }

        public IActionResult Deletar(Guid Id)
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            var produto = _apiServices.ConsultarProdutoDetalhes(Id).Result;
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            _apiServices.DeletarProduto(Id);
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Editar(Guid Id, Produtos? prd)
        {
            var token = ObterToken();
            if (token == null)
                return View("Error", new ErroGenericoViewModel { Mensagem = "Token expirado ou inválido" });

            var _apiServices = new MaximaTechApiServices(token);
            var produto = _apiServices.ConsultarProdutoDetalhes(Id).Result;
            if (produto == null)
                return NotFound();

            if (prd == null || prd.Codigo == null)
            {
                ViewBag.Departamentos = _apiServices.ConsultarDepartamentos().Result;
                return View(produto);
            }

            if (ModelState.IsValid)
            {
                var produtoEdit = new EditarProdutoCommand()
                {
                    Id = prd.Id,
                    Codigo = prd.Codigo,
                    Preco = prd.Preco,
                    DepartamentoId = prd.DepartamentoId,
                    Descricao = prd.Descricao,
                    Status = true // Altere conforme necessário
                };

                _apiServices.AtualizarProduto(produtoEdit);
                return RedirectToAction(nameof(Index));
            }

            // Se ModelState.IsValid for falso, retorna a mesma view com os dados do produto
            ViewBag.Departamentos = _apiServices.ConsultarDepartamentos().Result;
            return View(produto);
        }



    }
}