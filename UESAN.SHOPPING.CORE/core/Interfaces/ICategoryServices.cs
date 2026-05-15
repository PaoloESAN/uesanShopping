using UESAN.SHOPPING.CORE.core.DTOs;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface ICategoryServices
    {
        Task AddCategory(CategoryCreateDTO categoryCreateDTO);
        Task DeleteCategory(CategoryDeleteDTO categoryDeleteDTO);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryDTO> GetCategoriesById(int id);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
    }
}