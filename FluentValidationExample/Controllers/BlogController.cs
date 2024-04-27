using FluentValidation.Results;
using FluentValidationExample.Data;
using FluentValidationExample.Models;
using FluentValidationExample.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly BlogValidator _blogValidator;

        public BlogController(BlogValidator blogValidator, AppDbContext appDbContext)
        {
            _blogValidator = blogValidator;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogDataModel blogDataModel)
        {
            try
            {
                ValidationResult validationResult = _blogValidator.Validate(blogDataModel);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                await _appDbContext.Blogs.AddAsync(blogDataModel);
                int result = await _appDbContext.SaveChangesAsync();

                return result > 0 ? StatusCode(201, "Blog Created.") : BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.Message);
            }
        }

        private IActionResult InternalServerError(string message)
        {
            return StatusCode(500, message);
        }
    }
}
