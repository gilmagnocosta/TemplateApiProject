using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateApiProject.API.Controllers.Base;
using TemplateApiProject.Application.Requests;

namespace TemplateApiProject.API.Controllers
{
    /// <summary>
    /// Users API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets an User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new FindUserRequest(id));

            return Ok(response.Content);
        }

        /// <summary>
        /// Post a new user
        /// </summary>
        /// <param name="request">User's information to post</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = response.Content}, null);
        }
    }
}
