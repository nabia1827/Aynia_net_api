using Challenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interface
{
    public interface IProductDomain
    {
        Task<bool> InsertProducts(List<Product> products);
    }
}
