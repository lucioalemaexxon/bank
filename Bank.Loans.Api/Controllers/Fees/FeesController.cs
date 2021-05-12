using Bank.Loans.Application.Features.Fees.Commands;
using Bank.Loans.Application.Features.Fees.Dtos;
using Bank.Loans.Application.Features.Fees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Api.Controllers.Fees
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<FeeDto>> GetAll()
        {
            return await _mediator.Send(new FindAllFeesQuery());
        }

        /// <summary>
        /// Get Fee by Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<FeeDto> Get(Guid id)
        {
            return await _mediator.Send(new FindByIdFeesQuery() { Id = id });
        }

        /// <summary>
        /// Add a rate
        /// </summary>
        /// <param name="request">Add fee command.</param>
        /// <returns>id</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFeeCommand request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id });
        }

        /// <summary>
        /// Delete a rate
        /// </summary>
        /// <param name="request">Delete fee command. Id is the only parameter</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteFeeCommand { Id = id });
            return new NoContentResult();
        }
    }
}
