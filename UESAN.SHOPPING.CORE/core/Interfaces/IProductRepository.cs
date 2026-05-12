using UESAN.SHOPPING.CORE.core.Entities;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
    }
}
