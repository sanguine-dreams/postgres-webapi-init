namespace PostGresAPI.Models;

public class Student: BaseEntity<int>
{
    public string Name { get; set; }
    public List<Subject>? Subjects { get; set; } = [];
}