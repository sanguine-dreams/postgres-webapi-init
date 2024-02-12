namespace PostGresAPI.Models;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    public DateTime? LastModificationTime { get; set; } = null;
}