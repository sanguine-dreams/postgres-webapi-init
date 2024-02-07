using PostGresAPI.Models;

namespace PostGresAPI.DTOS;

public class SubjectDTO
{
    public string Name { get; set; }
    public int? teacherId  { get; set; }
}