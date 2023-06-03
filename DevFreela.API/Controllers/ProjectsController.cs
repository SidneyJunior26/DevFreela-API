using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevFreela.API.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly OpeningTimeOption _option;
    public ProjectsController(IOptions<OpeningTimeOption> option) {
        _option = option.Value;
    }

    [HttpGet]
    public IActionResult Get(string query) {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel createProjectModel) {
        if (createProjectModel.Title.Length > 50) {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new { id = createProjectModel.Id }, createProjectModel);
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

