using MaximaTech.api.Models;
using MaximaTech.Application.Queries;
using MaximaTech.core.Interfaces;

using Moq;

namespace MaximaTech.Api.Tests.Application.Queries
{
    public class GetAllDepartamentosQueryHandlerTests
    {
        [Test]
        public async Task DadoQuatroDepartamentosExistestes_Executa_RetornaQuatroDepartamentos()
        {
            //arrange
            var deptos = new List<Departamentos>()
            {
                new Departamentos(){Codigo = "010", Descricao = "BEBIDAS"},
                new Departamentos(){Codigo = "020", Descricao = "CONGELADOS"},
                new Departamentos(){Codigo = "030", Descricao = "LATICINIOS"},
                new Departamentos(){Codigo = "040", Descricao = "VEGETAIS"}
            };

            var uowMock = new Mock<IUnitOfWork>();
            var departamentosRepositoryMock = new Mock<IDepartamentoRepository>();
            departamentosRepositoryMock.Setup(pr => pr.GetAll().Result).Returns(deptos);

            uowMock.SetupGet(uow => uow.DepartamentoRepository).Returns(departamentosRepositoryMock.Object);

            var getAllDepartamentosQuery = new GetAllDepartamentosQuery();
            var getAllDepartamentosQueryHandler = new GetAllDepartamentosQueryHandler(uowMock.Object);

            //act
            var departamentos = await getAllDepartamentosQueryHandler.Handle(getAllDepartamentosQuery, new CancellationToken());

            // Assert
            Assert.NotNull(departamentos);
            Assert.IsNotEmpty(departamentos);
            Assert.That(departamentos.Count, Is.EqualTo(deptos.Count));

            departamentosRepositoryMock.Verify(pr => pr.GetAll().Result, Times.Once);


        }
    }
}
