namespace PostGresAPI.Models;

public class Student: BaseEntity<int>
{
    public string Name { get; set; }
    public int? SubjectId { get; set; }

    public ICollection<Subject> Subjects { get; set; }
}