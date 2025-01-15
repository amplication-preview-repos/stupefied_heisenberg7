namespace VirtualPetAdoption.APIs.Dtos;

public class NewsWhereInput
{
    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? Title { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
