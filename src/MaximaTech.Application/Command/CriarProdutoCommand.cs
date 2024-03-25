using MaximaTech.api.Models;

using MediatR;

namespace MaximaTech.Application.Command
{
    public class CriarProdutoCommand : IRequest<Produtos>
    {
        public Produtos Produtos { get; private set; }
        public CriarProdutoCommand(ProdutoViewModel p)
        {
            Produtos = new Produtos() { 
                Codigo = p.Codigo,
                DepartamentoId = p.DepartamentoId,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Status = p.Status                
            };
        }

    }
}
