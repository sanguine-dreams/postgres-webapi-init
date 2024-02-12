namespace PostGresAPI.Models;

public class Student: BaseEntity
{
    public string Name { get; set; }
    public List<Subject>? Subjects { get; set; } = [];
}