using Bank.Auth.Application.Features.Users.Commands;
using Bank.Auth.Application.Features.Users.Dtos;
using Bank.Auth.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Auth.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _mediator.Send(new FindAllUsersQuery());
        }

        /// <summary>
        /// Get User by Id
        [HttpGet("{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<UserDto> Get(string userName)
        {
            return await _mediator.Send(request: new FindByUserNameUsersQuery(userName));
        }

        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="request">Add user command.</param>
        /// <returns>id</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticateUserCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        ///// <summary>
        ///// Add a user
        ///// </summary>
        ///// <param name="request">Add user command.</param>
        ///// <returns>id</returns>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        //{
        //    var result = await _mediator.Send(request);
        //    return CreatedAtAction(nameof(Get), new { id = result.Id });
        //}

        ///// <summary>
        ///// Delete a user
        ///// </summary>
        ///// <param name="request">Delete user command. Id is the only parameter</param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    await _mediator.Send(new DeleteUserCommand { Id = id });
        //    return new NoContentResult();
        //}
    }
}