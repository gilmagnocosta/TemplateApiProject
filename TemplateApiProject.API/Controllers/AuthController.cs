using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateApiProject.API.Controllers.Base;
using TemplateApiProject.Application.Requests;
using TemplateApiProject.Domain.Interface.Service;

namespace TemplateApiProject.API.Controllers
{
    /// <summary>
    /// API for Users Authentication
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _authenticatedUser;

        /// <summary>
        /// Deafult constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="authenticatedUser"></param>
        public AuthController(IMediator mediator, ICurrentUserService authenticatedUser)
        {
            _mediator = mediator;
            _authenticatedUser = authenticatedUser;
        }

        /// <summary>
        /// Authenticate a user and get a Token API
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A Token API to use on the entire private routes</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest command)
        {
            var response = await _mediator.Send(command);

            return Ok(response.Content);
        }

        /// <summary>
        /// Gets the status if the user is logged in
        /// </summary>
        /// <returns></returns>
        [HttpGet("loggedIn")]
        public async Task<IActionResult> LoggedIn()
        {
            return await Task.FromResult(Ok(new { authenticated = _authenticatedUser.LoggedIn }));
        }
    }
}
