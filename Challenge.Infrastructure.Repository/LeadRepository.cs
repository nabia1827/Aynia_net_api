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
    public class LeadRepository : ILeadRepository
    {
        private readonly DapperContext _context;
        public LeadRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ArrayLeadWrapper>> ArrayLeads(int empresaId, int mes, int anio, string valorBusqueda)
        {
            using var connection = _context.CreateConnection();

            var sql = "sp_GetArrayCardLead";
            var parameters = new DynamicParameters();
            parameters.Add("@empresaId", empresaId);
            parameters.Add("@mes", mes);
            parameters.Add("@anio", anio);
            parameters.Add("@valorBusqueda", valorBusqueda);

            var items = await connection.QueryAsync<ArrayLeadWrapper>(sql, parameters, commandType: CommandType.StoredProcedure);
            return items.ToList();
        }
    }
}
