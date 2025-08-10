using Challenge.Domain.Entity;
using Challenge.Transversal.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Interface
{
    public interface IProductApplication
    {
        Task<Response<bool>> ImportProducts(IFormFile file, int empresaId);
    }
}
