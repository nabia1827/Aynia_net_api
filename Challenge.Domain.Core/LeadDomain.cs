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
    public class LeadDomain : ILeadDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeadDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ArrayLeadWrapper>> ArrayLeads(int empresaId, int mes, int anio, string valorBusqueda)
        {
            return await _unitOfWork.Lead.ArrayLeads(empresaId, mes, anio, valorBusqueda);
        }
    }
}
