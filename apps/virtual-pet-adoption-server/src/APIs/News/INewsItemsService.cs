using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;

namespace VirtualPetAdoption.APIs;

public interface INewsItemsService
{
    /// <summary>
    /// Create one News
    /// </summary>
    public Task<News> CreateNews(NewsCreateInput news);

    /// <summary>
    /// Delete one News
    /// </summary>
    public Task DeleteNews(NewsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many NewsItems
    /// </summary>
    public Task<List<News>> NewsItems(NewsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about News records
    /// </summary>
    public Task<MetadataDto> NewsItemsMeta(NewsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one News
    /// </summary>
    public Task<News> News(NewsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one News
    /// </summary>
    public Task UpdateNews(NewsWhereUniqueInput uniqueId, NewsUpdateInput updateDto);
}
