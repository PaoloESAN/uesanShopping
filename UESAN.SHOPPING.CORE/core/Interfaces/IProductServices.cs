using UESAN.SHOPPING.CORE.core.DTOs;

namespace UESAN.SHOPPING.CORE.core.Interfaces
{
    public interface IProductServices
    {
        Task AddProduct(ProductCreateDTO productCreateDTO);
        Task DeleteProduct(ProductDeleteDTO productDeleteDTO);
        Task<IEnumerable<ProductListDTO>> GetProducts();
        Task<ProductDTO> GetProductsById(int id);
        Task UpdateProduct(ProductUpdateDTO productUpdateDTO);
    }
}
