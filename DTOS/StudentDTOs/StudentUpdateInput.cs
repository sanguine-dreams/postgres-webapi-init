namespace PostGresAPI.DTOS;

public class StudentUpdateInput
{
    public string? Name { get; set; }
    public List<Guid> SubjectIds { get; set; }
}