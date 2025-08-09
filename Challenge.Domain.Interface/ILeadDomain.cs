using Challenge.Application.Wrapper;
using Challenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interface
{
    public interface ILeadDomain
    {
        Task<List<ArrayLeadWrapper>> ArrayLeads(int empresaId, int mes, int anio, string valorBusqueda);
    }
}
