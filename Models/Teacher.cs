namespace PostGresAPI.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    // Navigation property for Students
    public ICollection<Student> Students { get; set; }
}