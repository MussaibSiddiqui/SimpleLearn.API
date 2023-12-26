using Microsoft.EntityFrameworkCore;
using SimpleLearn.API.Data;
using SimpleLearn.API.Models.Domain;
using SimpleLearn.API.Repositories.Interface;

namespace SimpleLearn.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext dBContext;

        public CategoryRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dBContext.Categories.AddAsync(category);
            await dBContext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
           return await dBContext.Categories.ToListAsync(); ;
        }

        public async Task<Category> SelectCategoryAsync(Guid id)
        {
            return await dBContext.Categories.SingleAsync(c=> c.Id == id);
        }

        public async Task UpdateCategory(Category category)
        {
            dBContext.Set<Category>().Update(category);
            await dBContext.SaveChangesAsync();
        }
    }
}
