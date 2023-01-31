using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyProject.DAL.Models;

public partial class Human
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Age { get; set; }

    [Phone]
    public string Phone { get; set; } = null!;

    public int StatusId { get; set; }

    public string Description { get; set; } = null!;
}
