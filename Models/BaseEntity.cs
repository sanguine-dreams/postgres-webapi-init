namespace PostGresAPI.Models;

public class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    public DateTime? LastModificationTime { get; set; } = null;
}