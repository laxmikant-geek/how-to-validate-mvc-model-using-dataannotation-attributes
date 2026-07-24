using GeekStore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GeekStore.Mvc.Controllers;

public class DemoController : Controller
{
    // --- action result types ---
    public JsonResult AsJson() => Json(new { id = 1, name = "Galaxy A15" });
    public ContentResult AsText() => Content("plain text response", "text/plain");
    public IActionResult Missing() => NotFound();
    public IActionResult Invalid() => BadRequest(new { error = "price must be positive" });
    public IActionResult Moved() => RedirectToAction("AsJson");
    public IActionResult NoBody() => NoContent();
    public StatusCodeResult Teapot() => StatusCode(418);

    // --- FileResult variants ---
    public FileResult DownloadBytes()
    {
        var bytes = Encoding.UTF8.GetBytes("ProductId,Name\n1,Galaxy A15\n");
        return File(bytes, "text/csv", "products.csv");
    }
    public FileResult DownloadStream()
    {
        var stream = new MemoryStream(Encoding.UTF8.GetBytes("streamed content"));
        return File(stream, "application/octet-stream", "data.bin");
    }

    // --- model binding ---
    public IActionResult FromQuery(int id, string? name) => Json(new { id, name });
    [HttpPost] public IActionResult PostForm([FromForm] Product product) => Json(product);
    [HttpPost] public IActionResult PostBody([FromBody] Product product) => Json(product);
    [Route("demo/route-bind/{id:int}")]
    public IActionResult RouteBind(int id) => Json(new { boundFromRoute = id });
}
