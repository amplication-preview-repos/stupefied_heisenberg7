using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoption.APIs;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.APIs.Errors;

namespace VirtualPetAdoption.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class NewsItemsControllerBase : ControllerBase
{
    protected readonly INewsItemsService _service;

    public NewsItemsControllerBase(INewsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one News
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<News>> CreateNews(NewsCreateInput input)
    {
        var news = await _service.CreateNews(input);

        return CreatedAtAction(nameof(News), new { id = news.Id }, news);
    }

    /// <summary>
    /// Delete one News
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteNews([FromRoute()] NewsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteNews(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many NewsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<News>>> NewsItems([FromQuery()] NewsFindManyArgs filter)
    {
        return Ok(await _service.NewsItems(filter));
    }

    /// <summary>
    /// Meta data about News records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> NewsItemsMeta(
        [FromQuery()] NewsFindManyArgs filter
    )
    {
        return Ok(await _service.NewsItemsMeta(filter));
    }

    /// <summary>
    /// Get one News
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<News>> News([FromRoute()] NewsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.News(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one News
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateNews(
        [FromRoute()] NewsWhereUniqueInput uniqueId,
        [FromQuery()] NewsUpdateInput newsUpdateDto
    )
    {
        try
        {
            await _service.UpdateNews(uniqueId, newsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
