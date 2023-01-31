using Microsoft.EntityFrameworkCore;
using StudyProject.DAL.Context;
using StudyProject.DAL.Models;

namespace StudyProject.DAL.Service;

public class StudyProjectService
{
    public async Task CreateProfileHumanAsync(Human human)
    {
        using(StudyProjectDbContext db = new StudyProjectDbContext())
        {
            await db.Humans.AddAsync(human);
            await db.SaveChangesAsync();
        }
    }
    public async Task<HumanResult> GetProfileHumanByIdAsync(int id)
    {
        try
        {
            using(StudyProjectDbContext db = new StudyProjectDbContext())
            {
                Human human = await db.Humans.FirstOrDefaultAsync(h => h.Id == id);
                Status status = await db.Statuses.FirstOrDefaultAsync(s => s.StatusId == human.StatusId);

                HumanResult humanResult = new HumanResult()
                {
                    Name = human.Name,
                    Surname = human.Surname,
                    Age = human.Age,
                    Phone = human.Phone,
                    StatusId = human.StatusId,
                    Description = human.Description,
                    DescriptionStatus = status.Description
                };
                return humanResult;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }


}
