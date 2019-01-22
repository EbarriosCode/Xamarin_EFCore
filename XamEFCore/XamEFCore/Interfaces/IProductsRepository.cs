using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamEFCore.Models;

namespace XamEFCore.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync();
        Task<bool> AddProductAsync(Product model);
        Task<bool> UpdateProductAsync(Product model);
        Task<bool> DeleteProductAsync(int ProductId);
        Task<IEnumerable<Product>> QueryProductsAsync(Func<Product, bool> where);
    }
}
