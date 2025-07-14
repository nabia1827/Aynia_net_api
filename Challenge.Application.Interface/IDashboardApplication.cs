using Challenge.Application.Wrapper;
using Challenge.Domain.Entity;
using Challenge.Transversal.Common;
using Challenge.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Interface
{
    public interface IDashboardApplication
    {
        Task<Response<List<ReporteLeadWrapper>>> ListLeads(int empresaId, int productoId, string estado);
        Task<Response<List<AlertaDto>>> ListAlertas(int rolId);
        Task<Response<byte[]>> ExportMonthlyLeads(int empresaId, string estado, int productoId);

        Task<Response<List<IngresoWrapper>>> ListIncomes(int empresaId);
    }
}
