using Challenge.Application.Wrapper;
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
    public class DashboardRepository :IDashboardRepository
    {
        private readonly DapperContext _context;
        public DashboardRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CountLeadsCurrentMonth()
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_CountCurrentMonthLeads";
            var parameters = new DynamicParameters();

            var CountCurrentMonthLeads = await connection.QuerySingleOrDefaultAsync<int>(sql, parameters, commandType: CommandType.StoredProcedure);
            return CountCurrentMonthLeads;
        }

        public async Task<int> GetLeadCountByPlan(int empresaId)
        {
       
            var sp = "sp_GetLeadCountByPlan";
            var parameters = new DynamicParameters();
            parameters.Add("@empresaId", empresaId);

            using var connection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync <int> (sp, parameters, commandType: CommandType.StoredProcedure);

            return result;
        
    }

        public async Task<List<Alerta>> ListAlertas(int rolId)
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_ListAlertas";
            var parameters = new DynamicParameters();
            parameters.Add("@rolId", rolId);

            var items = await connection.QueryAsync<Alerta>(sql, parameters, commandType: CommandType.StoredProcedure);
            return items.ToList();
        }

        public async Task<List<ReporteLeadWrapper>> ListLeads(int empresaId, int productoId, string estado)
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_ListLeads";
            var parameters = new DynamicParameters();
            parameters.Add("@empresaId", empresaId);
            parameters.Add("@productoId", productoId);
            parameters.Add("@estado", estado);

            var items = await connection.QueryAsync<ReporteLeadWrapper>(sql, parameters, commandType: CommandType.StoredProcedure);
            return items.ToList();
        }
    }
}
