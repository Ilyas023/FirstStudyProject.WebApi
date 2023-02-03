using StudyProject.DAL.Models;

namespace StudyProject.DAL.Service;

public interface IStudyProjectService
{
    public Task CreateProfileHumanAsync(Human human);
    public Task<HumanResult> GetProfileHumanByIdAsync(int id);
    public Task<List<HumanResult>> GetAllProfileHumansAsync();
    public Task PutProfileHumanByIdAsync(int id, Human humanUpd);
    public Task DeleteProfileHumanByIdAsync(int id);
    public Task DeleteAllProfileHumanAsync();
}
