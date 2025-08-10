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
    public interface ILeadApplication
    {
        Task<Response<List<ArrayLeadWrapper>>> ArrayLeads(int empresaId, int mes, int anio, string valorBusqueda);
    }
}
