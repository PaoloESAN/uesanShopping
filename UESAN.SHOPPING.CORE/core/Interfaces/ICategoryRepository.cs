using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
    }
}