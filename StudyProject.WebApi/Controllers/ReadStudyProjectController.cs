using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadStudyProjectController : ControllerBase
{
    private readonly ILogger<ReadStudyProjectController> _logger;
    private readonly IStudyProjectService _studyProjectService;

    public ReadStudyProjectController(ILogger<ReadStudyProjectController> logger,
        IStudyProjectService studyProjectService)
    {
        _logger = logger;
        _studyProjectService = studyProjectService;
    }

    [HttpGet("read-all-profiles-human")]
    public async Task<IActionResult> GetAllProfileHumansAsync()
    {
        var man = await _studyProjectService.GetAllProfileHumansAsync();

        if (man != null)
            return Ok(man);

        return NoContent();
    }

    [HttpGet("read-profile-human/{id}")]
    public async Task<IActionResult> GetProfileHumanByIdAsync(int id)
    {
        var man = await _studyProjectService.GetProfileHumanByIdAsync(id);

        if (man != null)
            return Ok(man);

        return NoContent();
    }

}
