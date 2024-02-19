namespace PostGresAPI.DTOS;

public class GetReturn<type>
{
    public List<type> Items { get; set; }
    public int TotalCount { get; set; }
}