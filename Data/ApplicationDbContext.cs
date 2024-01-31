using PostGresAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PostGresAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set;}
    public DbSet<Teacher> Teachers { get; set;}
    public DbSet<Subject> Subjects { get; set; }

}  
