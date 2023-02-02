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
    public async Task<List<HumanResult>> GetAllProfileHumansAsync()
    {
        List<HumanResult> humanList = new List<HumanResult>();
        try
        {
            using(StudyProjectDbContext db = new StudyProjectDbContext())
            {
                List<Human> humans = await db.Humans.ToListAsync();
                List<Status> statusList = await db.Statuses.ToListAsync();

                foreach(Human human in humans)
                {
                    foreach(Status status in statusList)
                    {
                        if (human.StatusId == status.StatusId)
                        {
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
                            humanList.Add(humanResult);
                        }
                    }
                }

                return humanList;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task PutProfileHumanById(int id, Human humanUpd)
    {
        try
        {
            using(StudyProjectDbContext db = new StudyProjectDbContext())
            {
                Human? human = await db.Humans.FirstOrDefaultAsync(h => h.Id == id);

                if (human != null)
                {
                    human.Name = humanUpd.Name;
                    human.Surname = humanUpd.Surname;
                    human.Phone = humanUpd.Phone;
                    human.StatusId = humanUpd.StatusId;
                    human.Age = humanUpd.Age;
                    human.Description = humanUpd.Description;

                    await db.SaveChangesAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);   
        }
    }

    public async Task DeleteProfileHumanById(int id)
    {
        try
        {
            using(StudyProjectDbContext db = new StudyProjectDbContext())
            {
                db.Humans.Remove(await db.Humans.FirstOrDefaultAsync(h => h.Id == id));
                await db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public async Task DeleteAllProfileHumans()
    {
        try
        {
            using(StudyProjectDbContext db = new StudyProjectDbContext())
            {
                List<Human> humanList = await db.Humans.ToListAsync();

                db.Humans.RemoveRange(humanList);
                await db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
