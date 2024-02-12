namespace PostGresAPI.DTOS;

public class StudentUpdateInput
{
    public string? Name { get; set; }
    public List<int> SubjectIds { get; set; }
}