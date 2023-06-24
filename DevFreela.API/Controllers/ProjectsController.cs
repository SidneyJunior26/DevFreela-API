using DevFreela.Application.Commands.Project.CancelProject;
using DevFreela.Application.Commands.Project.CreateComment;
using DevFreela.Application.Commands.Project.CreateProject;
using DevFreela.Application.Commands.Project.DeleteProject;
using DevFreela.Application.Commands.Project.FinishProject;
using DevFreela.Application.Commands.Project.StartProject;
using DevFreela.Application.Commands.Project.UpdateProject;
using DevFreela.Application.Querys.Project.GetAllProjects;
using DevFreela.Application.Querys.Project.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase {

    private readonly IMediator _mediator;
    public ProjectsController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromServices] GetAllProjectsQuery getAllProjectsCommand) {
        var projects = await _mediator.Send(getAllProjectsCommand);

        if (projects == null)
            return NotFound();

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetProjectByIdCommand getProjectByIdCommand) {
        var project = await _mediator.Send(getProjectByIdCommand);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProjectCommand) {
        if (createProjectCommand.Title.Length > 50) {
            return BadRequest();
        }

        var idProject = await _mediator.Send(createProjectCommand);

        return CreatedAtAction(nameof(GetById), new { id = idProject }, createProjectCommand);
    }

    [HttpPost("comments")]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createCommentCommand) {
        await _mediator.Send(createCommentCommand);

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateProjectCommand updateProjectCommand) {
        await _mediator.Send(updateProjectCommand);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start([FromRoute] int id) {
        var startProjectCommand = new StartProjectCommand(id);

        await _mediator.Send(startProjectCommand);

        return Ok();
    }

    [HttpPut("{id}/finish")]
    public async Task<IActionResult> Finish([FromRoute] int id) {
        var finishProjectCommand = new FinishProjectCommand(id);

        await _mediator.Send(finishProjectCommand);

        return Ok();
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> Cancel([FromRoute] int id) {
        var cancelProjectCommand = new CancelProjectCommand(id);

        await _mediator.Send(cancelProjectCommand);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        var deleteProjectCommand = new DeleteProjectCommand(id);

        await _mediator.Send(deleteProjectCommand);

        return Ok();
    }
}

