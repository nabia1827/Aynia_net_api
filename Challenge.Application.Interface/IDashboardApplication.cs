using Challenge.Application.DTO;
using Challenge.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Interface
{
    public interface IDashboardApplication
    {

        Task<Response<int>> CountLeadsCurrentMonth();
        Task<Response<int>> GetLeadCountByPlan(int empresaId);
    }
}
