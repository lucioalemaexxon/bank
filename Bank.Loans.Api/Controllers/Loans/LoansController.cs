using Bank.Loans.Application.Features.Loans.Commands;
using Bank.Loans.Application.Features.Loans.Dtos;
using Bank.Loans.Application.Features.Loans.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Api.Controllers.Loans
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<LoanDto>> GetAll()
        {
            return await _mediator.Send(new FindAllLoansQuery());
        }

        /// <summary>
        /// Get Loan by Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<LoanDto> Get(Guid id)
        {
            return await _mediator.Send(new FindByIdLoansQuery() { Id = id });
        }

        // POST api/loans
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLoanCommand request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result);
        }

        // POST api/loans
        [HttpPut("/approve")]
        public async Task<ActionResult> Approve([FromBody] ApproveLoanCommand request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result);
        }
    }
}
