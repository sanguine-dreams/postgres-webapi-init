using PostGresAPI.Models;

namespace PostGresAPI.DTOS;

public class SubjectDTO
{
    public string Name { get; set; }
    public int? TeacherId  { get; set; }
    
    public int? StudentId { get; set; } 

}