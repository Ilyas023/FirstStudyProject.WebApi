using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadStudyProjectController : ControllerBase
{
    private readonly ILogger<ReadStudyProjectController> _logger;
    private StudyProjectService _projectService = new StudyProjectService();

    public ReadStudyProjectController(ILogger<ReadStudyProjectController> logger)
    {
        _logger = logger;
    }
        
    [HttpGet("get-all-profiles-human")]
    public async Task<IActionResult> GetAllProfileHumansAsync()
    {
        var man = await _projectService.GetAllProfileHumansAsync();

        if (man != null)
            return Ok(man);

        return NoContent();
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
