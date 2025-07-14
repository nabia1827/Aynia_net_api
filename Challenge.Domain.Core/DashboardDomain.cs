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
        public async Task<int> CountLeadsCurrentMonth()
        {
            return await _unitOfWork.Dashboard.CountLeadsCurrentMonth();
        }
        public async Task<int> GetLeadCountByPlan(int empresaId)
        {
            return await _unitOfWork.Dashboard.GetLeadCountByPlan(empresaId);
        }
    }
}
