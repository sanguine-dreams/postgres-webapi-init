namespace PostGresAPI.DTOS;
using PostGresAPI.Models;

public class GetAllSubjectDTO
{
    public string Name { get; set; }
    public string TaughtBy { get; set; }
    public string[] StudentName { get; set; }

}