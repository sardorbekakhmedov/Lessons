using Lesson67_Task.DbContext;
using Lesson67_Task.DTOModels;
using Lesson67_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson67_Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CategoryController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _appDbContext.Categories.ToListAsync();
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById(Guid categoryId)
    {
        var category = await _appDbContext.Categories.FindAsync(categoryId);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
    {
        if (categoryDto.ParentId != null &&
            !await _appDbContext.Categories.AnyAsync(id => id.ParentId == categoryDto.ParentId))
        {
            return NotFound();
        }

        var category = new Category
        {
            Name = categoryDto.Name,
            ParentId = categoryDto.ParentId,
        };

        await _appDbContext.Categories.AddAsync(category);
        await _appDbContext.SaveChangesAsync();

        return Ok(category);
    }

}