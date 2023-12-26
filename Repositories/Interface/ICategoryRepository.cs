using Microsoft.EntityFrameworkCore.Update.Internal;
using SimpleLearn.API.Models.Domain;

namespace SimpleLearn.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> SelectCategoryAsync(Guid id);
        Task<List<Category>> GetAllCategoriesAsync();

        Task UpdateCategory(Category category);
    }
}
