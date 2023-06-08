using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectsController(IProjectService projectService) {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get(string query) {
        var projects = _projectService.GetAll(query);

        if (projects == null)
            return NotFound();

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        var project = _projectService.GetById(id);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewsProjectInputModel createProjectModel) {
        if (createProjectModel.Title.Length > 50) {
            return BadRequest();
        }

        _projectService.Create(createProjectModel);

        return Ok("" );
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentsModel) {
        return NoContent();
    }

    [HttpPut]
    public IActionResult Put([FromBody] UpdateProjectModel updateProjectModel) {
        if (updateProjectModel.Description.Length > 200) {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id) {
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id) {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        return NoContent();
    }
}

