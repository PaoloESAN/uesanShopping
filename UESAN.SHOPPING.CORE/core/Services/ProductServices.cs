using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;

namespace UESAN.SHOPPING.CORE.core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            var productsDTOs = new List<ProductListDTO>();

            foreach (var product in products)
            {
                var productDTO = new ProductListDTO
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Stock = product.Stock,
                    CategoryId = product.CategoryId
                };
                productsDTOs.Add(productDTO);
            }
            return productsDTOs;
        }
        public async Task<ProductDTO> GetProductsById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Stock = product.Stock,
                Price = product.Price,
                Discount = product.Discount,
                CategoryId = product.CategoryId,
                IsActive = product.IsActive ?? false
            };
            return productDTO;
        }
        public async Task AddProduct(ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                Description = productCreateDTO.Description,
                ImageUrl = productCreateDTO.ImageUrl,
                Stock = productCreateDTO.Stock,
                Price = productCreateDTO.Price,
                Discount = productCreateDTO.Discount,
                CategoryId = productCreateDTO.CategoryId,
                IsActive = true
            };
            await _productRepository.CreateProduct(product);
        }
        public async Task UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            var existingProduct = await _productRepository.GetProductById(productUpdateDTO.Id);
            if (existingProduct != null)
            {
                existingProduct.Description = productUpdateDTO.Description;
                existingProduct.ImageUrl = productUpdateDTO.ImageUrl;
                existingProduct.Stock = productUpdateDTO.Stock;
                existingProduct.Price = productUpdateDTO.Price;
                existingProduct.Discount = productUpdateDTO.Discount;
                existingProduct.CategoryId = productUpdateDTO.CategoryId;
                await _productRepository.UpdateProduct(existingProduct);
            }
        }
        public async Task DeleteProduct(ProductDeleteDTO productDeleteDTO)
        {
            await _productRepository.DeleteProduct(productDeleteDTO.Id);
        }
    }
}
