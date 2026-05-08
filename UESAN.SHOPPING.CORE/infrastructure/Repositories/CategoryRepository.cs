using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDBContext _context;

        public CategoryRepository(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _context.Categories.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCategory(int id)
        {
            var existingCategory = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (existingCategory != null)
            {
                existingCategory.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
