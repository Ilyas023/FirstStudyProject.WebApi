using System;
using System.Collections.Generic;

namespace StudyProject.DAL.Models;

public partial class Status
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public string Description { get; set; } = null!;
}
