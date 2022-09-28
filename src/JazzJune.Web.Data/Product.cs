using System.ComponentModel.DataAnnotations.Schema;

namespace JazzJune.Web.Data;
public class Product
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
}
