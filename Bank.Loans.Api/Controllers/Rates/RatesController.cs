using Bank.Loans.Application.Features.Rates.Commands;
using Bank.Loans.Application.Features.Rates.Dtos;
using Bank.Loans.Application.Features.Rates.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Api.Controllers.Rates
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<RateDto>> GetAll()
        {
            return await _mediator.Send(new FindAllRatesQuery());
        }

        /// <summary>
        /// Get Rate by Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<RateDto> Get(Guid id)
        {
            return await _mediator.Send(request: new FindByIdRatesQuery(id));
        }

        /// <summary>
        /// Add a rate
        /// </summary>
        /// <param name="request">Add rate command.</param>
        /// <returns>id</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRateCommand request)
        {
            var result = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id });
        }

        /// <summary>
        /// Delete a rate
        /// </summary>
        /// <param name="request">Delete rate command. Id is the only parameter</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteRateCommand { Id = id });
            return new NoContentResult();
        }
    }
}