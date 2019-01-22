using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamEFCore.Interfaces;
using XamEFCore.Models;

namespace XamEFCore.Repository
{
    public class ProductService : IProductsRepository
    {
        private readonly ProductsDbContext _context;

        public ProductService()
        {
            _context = App.GetContext();
        }

        public Task<bool> AddProductAsync(Product model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var result = new List<Product>();

            try
            {
                result =  await _context.Products.ToListAsync();   
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public Task<IEnumerable<Product>> QueryProductsAsync(Func<Product, bool> where)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
