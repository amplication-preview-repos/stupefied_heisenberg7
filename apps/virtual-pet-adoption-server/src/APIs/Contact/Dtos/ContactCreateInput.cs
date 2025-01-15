namespace VirtualPetAdoption.APIs.Dtos;

public class ContactCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Id { get; set; }

    public string? Message { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
