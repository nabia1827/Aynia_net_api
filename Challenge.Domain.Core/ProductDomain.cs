using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using Challenge.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> InsertProducts(List<Product> products)
        {
            return await _unitOfWork.Product.InsertProducts(products);
        }
    }
}
