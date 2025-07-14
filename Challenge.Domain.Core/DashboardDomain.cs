using Challenge.Application.Wrapper;
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
    public class DashboardDomain : IDashboardDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Alerta>> ListAlertas(int rolId)
        {
            return await _unitOfWork.Dashboard.ListAlertas(rolId);
        }

        public async Task<List<IngresoWrapper>> ListIncomes(int empresaId)
        {
            return await _unitOfWork.Dashboard.ListIncomes(empresaId);
        }

        public async Task<List<ReporteLeadWrapper>> ListLeads(int empresaId, int productoId, string estado)
        {
            return await _unitOfWork.Dashboard.ListLeads(empresaId, productoId, estado);
        }
    }
}
