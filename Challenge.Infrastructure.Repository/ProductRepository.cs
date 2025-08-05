using Challenge.Domain.Entity;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertProducts(List<Product> products)
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_InsertProduct";

            int result = 0;
            foreach (var product in products)
            {
                var parameters = new DynamicParameters();

                parameters.Add("@empresaId", product.EmpresaId);
                parameters.Add("@nombre", product.Nombre);
                parameters.Add("@descripcionJSON", product.DescripcionJSON);
                parameters.Add("@precio", product.Precio);
                parameters.Add("@stock", product.Stock);


                result = await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            }
            
            return result>0;
        }
    }
}
