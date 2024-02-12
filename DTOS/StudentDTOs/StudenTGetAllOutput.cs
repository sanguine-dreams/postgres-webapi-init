namespace PostGresAPI.DTOS;

public class StudentGetAllOutput
{
    public string Name { get; set; }
    public List<string> SubjectsTaken { get; set; }
}