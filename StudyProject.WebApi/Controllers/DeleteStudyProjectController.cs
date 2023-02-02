using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyProject.DAL.Models;
using StudyProject.DAL.Service;

namespace StudyProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeleteStudyProjectController : ControllerBase
{
    private readonly ILogger<DeleteStudyProjectController> _logger;
    private readonly IStudyProjectService _studyProjectService;

    public DeleteStudyProjectController(ILogger<DeleteStudyProjectController> logger,
        IStudyProjectService studyProjectService)
    {
        _logger = logger;
        _studyProjectService = studyProjectService;
    }

    [HttpDelete("delete-profile-human/{id}")]
    public async Task<IActionResult> DeleteProfileHuman(int id)
    {
        try
        {
            await _studyProjectService.DeleteProfileHumanByIdAsync(id);
            return Ok($"Пользователь удален с БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete-all-profiles")]
    public async Task<IActionResult> DeleteAllProfileHumansAsync()
    {
        try
        {
            await _studyProjectService.DeleteAllProfileHumanAsync();
            return Ok("Все пользователи удалены с БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
