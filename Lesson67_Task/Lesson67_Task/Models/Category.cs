namespace Lesson67_Task.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid? ParentId { get; set; }
    public Category? CategoryParent { get; set; }

    public IEnumerable<Category> Childrens { get; set; }
    public IEnumerable<Product> Products { get; set; }
}