using GeekStore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.Mvc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private static readonly List<Supplier> Store = [];
    private static int _nextId = 1;

    [HttpGet] public IEnumerable<Supplier> GetAll() => Store;

    [HttpGet("{id:int}")]
    public ActionResult<Supplier> Get(int id) =>
        Store.FirstOrDefault(s => s.Id == id) is { } s ? s : NotFound();

    [HttpPost]
    public ActionResult<Supplier> Create(Supplier supplier)
    {
        supplier.Id = _nextId++;
        Store.Add(supplier);
        return CreatedAtAction(nameof(Get), new { id = supplier.Id }, supplier);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Supplier supplier)
    {
        var existing = Store.FirstOrDefault(s => s.Id == id);
        if (existing is null) return NotFound();
        existing.Name = supplier.Name;
        existing.ContactEmail = supplier.ContactEmail;
        existing.Rating = supplier.Rating;
        return Ok(existing);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) =>
        Store.RemoveAll(s => s.Id == id) > 0 ? NoContent() : NotFound();
}
