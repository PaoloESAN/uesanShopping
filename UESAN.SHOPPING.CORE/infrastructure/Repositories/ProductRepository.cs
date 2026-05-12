using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _context;

        public ProductRepository(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _context.Products.Where(c => c.Id == product.Id).FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.IsActive = product.IsActive;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteProduct(int id)
        {
            var existingProduct = await _context.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
