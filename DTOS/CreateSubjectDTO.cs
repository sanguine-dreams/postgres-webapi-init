using PostGresAPI.Models;

namespace PostGresAPI.DTOS;

public class CreateSubjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string TaughtBy { get; set; }
}