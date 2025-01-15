using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Extensions;

public static class NewsItemsExtensions
{
    public static News ToDto(this NewsDbModel model)
    {
        return new News
        {
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PublishDate = model.PublishDate,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static NewsDbModel ToModel(this NewsUpdateInput updateDto, NewsWhereUniqueInput uniqueId)
    {
        var news = new NewsDbModel
        {
            Id = uniqueId.Id,
            Content = updateDto.Content,
            PublishDate = updateDto.PublishDate,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            news.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            news.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return news;
    }
}
