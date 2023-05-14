namespace Lesson67_Task.DTOModels;

public class CategoryDto
{
    public string Name { get; set; }

    public Guid? ParentId { get; set; }
}