using System.ComponentModel.DataAnnotations.Schema;

namespace PostGresAPI.Models;

public class Subject: BaseEntity<int>
{
    public string Name { get; set; }
    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    // public ICollection<Student> Students { get; set; }
}