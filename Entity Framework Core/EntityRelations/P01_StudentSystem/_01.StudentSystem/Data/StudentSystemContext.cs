using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Configurations;
using P01_StudentSystem.Data.Models;
using ContentType = System.Net.Mime.ContentType;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
        
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            string connectionString = "Server=.;Database=StudentSystem;User Id=sa;Password=VeryStr0ngP@ssw0rd;";
            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<StudentCourse> StudentsCourses { get; set; }
}