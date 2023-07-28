using ContactsApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly DatabaseContext _databaseContext;

    public ContactsController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var items = await _databaseContext.Contacts.ToListAsync();
        return Ok(items);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var item = await _databaseContext.Contacts.FindAsync(id);

        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Contact item)
    {
        await _databaseContext.AddAsync(item);
        await _databaseContext.SaveChangesAsync();
        return Created($"/{item.Id}", item);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Contact item)
    {
        _databaseContext.Contacts.Update(item);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var entity = await _databaseContext.Contacts.FindAsync(id);
        if (entity == null)
            return NotFound();

        _databaseContext.Contacts.Remove(entity);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
