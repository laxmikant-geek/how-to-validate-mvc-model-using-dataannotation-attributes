using System.ComponentModel.DataAnnotations;

namespace GeekStore.Mvc.Models;

public class Supplier
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Supplier name is required")]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string? ContactEmail { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    [RegularExpression(@"^[A-Z]{2}-\d{4}$", ErrorMessage = "Code looks like XX-0000")]
    public string? Code { get; set; }

    [Url]
    public string? Website { get; set; }
}
