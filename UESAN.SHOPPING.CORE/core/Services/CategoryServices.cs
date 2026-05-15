using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            var categoriesDTOs = new List<CategoryListDTO>();

            foreach (var category in categories)
            {
                var categoryDTO = new CategoryListDTO
                {
                    Id = category.Id,
                    Description = category.Description,
                };
                categoriesDTOs.Add(categoryDTO);
            }
            return categoriesDTOs;
        }
        public async Task<CategoryDTO> GetCategoriesById(int id)
        {
            var categories = await _categoryRepository.GetCategoryById(id);
            if (categories == null)
            {
                return null;
            }
            var categoriesDTO = new CategoryDTO
            {
                Id = categories.Id,
                Description = categories.Description
            };
            return categoriesDTO;
        }
        public async Task AddCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category
            {
                Description = categoryCreateDTO.Description,
                IsActive = true
            };
            await _categoryRepository.CreateCategory(category);
        }
        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(categoryUpdateDTO.Id);
            if (existingCategory == null)
            {
                existingCategory.Description = categoryUpdateDTO.Description;
                await _categoryRepository.UpdateCategory(existingCategory);
            }
        }
        public async Task DeleteCategory(CategoryDeleteDTO categoryDeleteDTO)
        {
            await _categoryRepository.DeleteCategory(categoryDeleteDTO.Id);
        }
    }
}
