using PostGresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PostGresAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set;}
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.SubjectId)
            .WithOne(t => t.Teacher)
            .HasForeignKey<Subject>(t => t.Id)  // Assuming you have TeacherId as the foreign key
            .IsRequired(false);

    }
}  

