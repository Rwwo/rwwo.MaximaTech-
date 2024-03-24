using MaximaTech.api.Data;
using MaximaTech.api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MaximaTech.Application.Queries;

namespace MaximaTech.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Departamentos>>> Get()
        {
            var getDepartamentos = new GetAllDepartamentosQuery();
            var result = await _mediator.Send(getDepartamentos);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }
    }
}
