using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        await projectService.DeleteProfileHumanById(id);
        return Ok("qweqw");
    }

}
