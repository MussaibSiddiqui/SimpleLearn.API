using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleLearn.API.Data;
using SimpleLearn.API.Models.Domain;
using SimpleLearn.API.Models.DTO;
using SimpleLearn.API.Repositories.Interface;

namespace SimpleLearn.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [HttpPost, Authorize]
        public async Task<IActionResult> CreateCategories(CreateCategoryRequestDTO request)
        {
            //Map dto to domain model
            var category = new Category
            {
                Name = request.Name,
                URLHandle = request.URLHandle
            };

            await categoryRepository.CreateAsync(category);
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle = category.URLHandle
            };
              
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategories(CategoryDTO request)
        {
            //Map dto to domain model
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                URLHandle = request.URLHandle
            };

            await categoryRepository.UpdateCategory(category);
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle = category.URLHandle
            };

            return Ok(response);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllCategories()
        {

           List<Category> categories =  await categoryRepository.GetAllCategoriesAsync();


            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> SelectCategory(Guid id)
        {

            Category category = await categoryRepository.SelectCategoryAsync(id);


            return Ok(category);
        }
    }
}
