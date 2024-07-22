using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

[Table("Courses")]
public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }

    public List<StudentCourse> StudentsCourses { get; set; } = new List<StudentCourse>();
    public List<Homework> Homeworks { get; set; } = new List<Homework>();
    public List<Resource> Resources { get; set; } = new List<Resource>();
}