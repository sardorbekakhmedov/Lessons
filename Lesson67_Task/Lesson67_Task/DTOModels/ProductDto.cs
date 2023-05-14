using Lesson67_Task.Models;

namespace Lesson67_Task.DTOModels;

public class ProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } = 0;
    public IFormFile PhotoUrl { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public Guid CategoryId { get; set; }
}