using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateStudyProjectController : ControllerBase
{
    private readonly ILogger<UpdateStudyProjectController> _logger;
    private StudyProjectService projectService = new StudyProjectService();

    public UpdateStudyProjectController(ILogger<UpdateStudyProjectController> logger)
    {
        _logger = logger;
    }

    [HttpPut("update-profile-human/{id}")]
    public async Task<IActionResult> UpdateProfileHumanAsync(int id, [FromBody] Human human)
    {
        try
        {
            await projectService.PutProfileHumanById(id, human);
            return Ok($"Пользователь - {human.Name} обновлен в БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
