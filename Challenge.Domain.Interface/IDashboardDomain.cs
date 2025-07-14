using Challenge.Application.Wrapper;
using Challenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interface
{
    public interface IDashboardDomain
    {
        Task<int> CountLeadsCurrentMonth();

        Task<int> GetLeadCountByPlan(int empresaId);
        Task<List<ReporteLeadWrapper>> ListLeads(int empresaId, int productoId, string estado);
        Task<List<Alerta>> ListAlertas(int rolId);
    }
}
