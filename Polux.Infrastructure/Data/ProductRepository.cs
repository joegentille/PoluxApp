using Polux.Core.Entities;
using Polux.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polux.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
