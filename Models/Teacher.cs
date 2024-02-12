namespace PostGresAPI.Models;

public class Teacher: BaseEntity
{
    public string Name { get; set; }
    public int? SubjectId { get; set; } = null;
    public Subject? Subject { get; set; } = null;
}