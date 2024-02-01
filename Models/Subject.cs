namespace PostGresAPI.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int TeacherId { get; set; }

    // Navigation property for Teachers
    public Teacher Teacher { get; set; }
    
    public ICollection<Subject> Subjects { get; set; }
}