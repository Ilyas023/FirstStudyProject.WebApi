using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreateStudyProjectController : ControllerBase
{
    private readonly ILogger<CreateStudyProjectController> _logger;
    private readonly IStudyProjectService _studyProjectService;

    public CreateStudyProjectController(ILogger<CreateStudyProjectController> logger, 
        IStudyProjectService studyProjectService)
    {
        _logger = logger;
        _studyProjectService = studyProjectService;
    }

    [HttpPost("post-profile-human")]
    public async Task<IActionResult> CreateProfileHumanAsync([FromBody] Human human)
    {
        try
        {
            await _studyProjectService.CreateProfileHumanAsync(human);
            return Ok($"Профиль - {human.Name} добавился в БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
