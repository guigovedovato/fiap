namespace StoreApi.Clients;

public class ClientModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
}