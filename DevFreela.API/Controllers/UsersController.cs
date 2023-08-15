using DevFreela.API.Models;
using DevFreela.Application.Commands.User.CreateUser;
using DevFreela.Application.Commands.User.Login;
using DevFreela.Application.Querys.User.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevFreela.API.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase {
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id) {
        var getUserByIdQuery = new GetUserByIdQuery(id);

        var user = _mediator.Send(getUserByIdQuery);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand) {
        var userId = await _mediator.Send(createUserCommand);

        return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserCommand);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login([FromRoute] int id, [FromBody] LoginCommand loginCommand) {
        var login = new LoginCommand(id);

        _mediator.Send(login);

        return NoContent();
    }
}

