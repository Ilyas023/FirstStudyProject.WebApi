using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetStudyProjectController : ControllerBase
{
    private readonly ILogger<GetStudyProjectController> _logger;
    private StudyProjectService _projectService = new StudyProjectService();

    public GetStudyProjectController(ILogger<GetStudyProjectController> logger)
    {
        _logger = logger;
    }
        
    [HttpGet("get-profile-human/{id}")]
    public async Task<IActionResult> GetProfileHumanByIdAsync(int id)
    {
        var man = await _projectService.GetProfileHumanByIdAsync(id);

        if (man != null)
            return Ok(man);

        return NoContent();
    }
}
