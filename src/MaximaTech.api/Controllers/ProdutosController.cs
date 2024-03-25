using MaximaTech.api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MaximaTech.Application.Queries;
using MediatR;
using MaximaTech.Application.Command;
using Microsoft.AspNetCore.Http;

namespace MaximaTech.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Produtos>>> Get()
        {
            var getProdutos = new GetAllProdutosQuery();
            var result = await _mediator.Send(getProdutos);

            if (result == null)
                return NotFound();
            else
                return Ok(result);

        }

        [HttpGet]
        [Route("{id:Guid}/Detalhes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produtos>> Detalhes(Guid id)
        {
            var getProdutos = new GetProdutosByIdQuery(id);
            var result = await _mediator.Send(getProdutos);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Produtos>> PostProduto(ProdutoViewModel produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prod = new CriarProdutoCommand(produto);
            var result = await _mediator.Send(prod);

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(EditarProdutoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeletarProdutoCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
