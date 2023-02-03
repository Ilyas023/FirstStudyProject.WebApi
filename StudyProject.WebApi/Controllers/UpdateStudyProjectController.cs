using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateStudyProjectController : ControllerBase
{
    private readonly ILogger<UpdateStudyProjectController> _logger;
    private readonly IStudyProjectService _studyProjectService;

    public UpdateStudyProjectController(ILogger<UpdateStudyProjectController> logger,
        IStudyProjectService studyProjectService)
    {
        _logger = logger;
        _studyProjectService = studyProjectService;
    }


    [HttpPut("update-profile-human/{id}")]
    public async Task<IActionResult> UpdateProfileHumanAsync(int id, [FromBody] Human human)
    {
        try
        {
            await _studyProjectService.PutProfileHumanByIdAsync(id, human);
            return Ok($"Пользователь - {human.Name} обновлен в БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
