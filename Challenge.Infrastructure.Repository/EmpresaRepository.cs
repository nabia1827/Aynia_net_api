using Challenge.Domain.Entity;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Interface;
using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DapperContext _context;
        public EmpresaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> EditDatosEmpresaById(Empresa empresa)
        {
            var sql = "sp_EditDatosEmpresaById";

            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@empresaId", empresa.EmpresaId);
            parameters.Add("@direccion", empresa.Direccion);
            parameters.Add("@telefono", empresa.Telefono);
            parameters.Add("@correo", empresa.Correo);
            parameters.Add("@zonaEntrega", empresa.ZonaEntrega);

            var result = await connection.ExecuteAsync(sql, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<Empresa> GetDatosEmpresaById(int empresaId)
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_GetDatosEmpresaById";
            var parameters = new DynamicParameters();
            parameters.Add("@empresaId", empresaId);

            var empresa = await connection.QuerySingleOrDefaultAsync<Empresa>(sql, parameters, commandType: CommandType.StoredProcedure);
            return empresa;
        }


    }
}
