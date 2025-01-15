using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoption.APIs;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.APIs.Errors;

namespace VirtualPetAdoption.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PetsControllerBase : ControllerBase
{
    protected readonly IPetsService _service;

    public PetsControllerBase(IPetsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Pet
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Pet>> CreatePet(PetCreateInput input)
    {
        var pet = await _service.CreatePet(input);

        return CreatedAtAction(nameof(Pet), new { id = pet.Id }, pet);
    }

    /// <summary>
    /// Delete one Pet
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePet([FromRoute()] PetWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePet(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Pets
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Pet>>> Pets([FromQuery()] PetFindManyArgs filter)
    {
        return Ok(await _service.Pets(filter));
    }

    /// <summary>
    /// Meta data about Pet records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PetsMeta([FromQuery()] PetFindManyArgs filter)
    {
        return Ok(await _service.PetsMeta(filter));
    }

    /// <summary>
    /// Get one Pet
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Pet>> Pet([FromRoute()] PetWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Pet(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Pet
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePet(
        [FromRoute()] PetWhereUniqueInput uniqueId,
        [FromQuery()] PetUpdateInput petUpdateDto
    )
    {
        try
        {
            await _service.UpdatePet(uniqueId, petUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Subscriptions records to Pet
    /// </summary>
    [HttpPost("{Id}/subscriptions")]
    public async Task<ActionResult> ConnectSubscriptions(
        [FromRoute()] PetWhereUniqueInput uniqueId,
        [FromQuery()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.ConnectSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Subscriptions records from Pet
    /// </summary>
    [HttpDelete("{Id}/subscriptions")]
    public async Task<ActionResult> DisconnectSubscriptions(
        [FromRoute()] PetWhereUniqueInput uniqueId,
        [FromBody()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.DisconnectSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Subscriptions records for Pet
    /// </summary>
    [HttpGet("{Id}/subscriptions")]
    public async Task<ActionResult<List<Subscription>>> FindSubscriptions(
        [FromRoute()] PetWhereUniqueInput uniqueId,
        [FromQuery()] SubscriptionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSubscriptions(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Subscriptions records for Pet
    /// </summary>
    [HttpPatch("{Id}/subscriptions")]
    public async Task<ActionResult> UpdateSubscriptions(
        [FromRoute()] PetWhereUniqueInput uniqueId,
        [FromBody()] SubscriptionWhereUniqueInput[] subscriptionsId
    )
    {
        try
        {
            await _service.UpdateSubscriptions(uniqueId, subscriptionsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
