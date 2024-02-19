using System.ComponentModel.DataAnnotations.Schema;

namespace PostGresAPI.Models;

public class Subject: BaseEntity
{
    public string Name { get; set; }
    public Guid? TeacherId { get; set; } = null;

    public Teacher? Teacher { get; set; } = null;
    // public ICollection<Student> Students { get; set; }
}