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
    StudyProjectService projectService = new StudyProjectService();

    public DeleteStudyProjectController(ILogger<DeleteStudyProjectController> logger)
    {
        _logger = logger;
    }


    [HttpDelete("delete-profile-human/{id}")]
    public async Task<IActionResult> DeleteProfileHuman(int id)
    {
        try
        {
            await projectService.DeleteProfileHumanById(id);
            return Ok($"Пользователь удален с БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete-all-profiles")]
    public async Task<IActionResult> DeleteAllProfileHumans()
    {
        try
        {
            await projectService.DeleteAllProfileHumans();
            return Ok("Все пользователи удалены с БД");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
