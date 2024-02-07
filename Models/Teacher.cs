namespace PostGresAPI.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Subject? SubjectId { get; set; }

}