using MaximaTech.api.Models;
using MaximaTech.Application.Command;
using MaximaTech.core.Interfaces;

using Moq;

using Xunit;

namespace MaximaTech.Api.Tests.Application.Commands
{
    public class CriarProdutoCommandHandlerTests
    {

        [Test]
        public async Task InputDataIsOk_Executed_ReturnProductId()
        {
            var uow = new Mock<IUnitOfWork>();
            var produtoRepository = new Mock<IProdutoRepository>();

            uow.SetupGet(uow => uow.ProdutoRepository).Returns(produtoRepository.Object);

            var criarProdutoCommand = new CriarProdutoCommand(
                new api.Models.ProdutoViewModel()
                {
                    Codigo = "0010",
                    DepartamentoId = new Guid("a9efa82f-e596-41e0-a77e-168eac7b2d17"),
                    Descricao = "Meu Teste",
                    Status = true,
                    Preco = 8
                }
                );

            var criarProdutosCommandHandler = new CriarProdutoCommandHandler(uow.Object);

            var produtoCriado = await criarProdutosCommandHandler.Handle(criarProdutoCommand, new CancellationToken());

            Assert.IsNotNull(produtoCriado);

            produtoRepository.Verify(pr => pr.Add(It.IsAny<Produtos>()), Times.Once);

        }
    }
}
