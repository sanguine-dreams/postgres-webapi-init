using PostGresAPI.Models;

namespace PostGresAPI.DTOS;

public class SubjectDTO
{
    public string Name { get; set; }
    public Guid? TeacherId { get; set; } = null;

    public Guid? StudentId { get; set; } = null;

}