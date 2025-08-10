using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        IAuthRepository Auth { get; }
        IDashboardRepository Dashboard { get; }
        IEmpresaRepository Empresa { get; }

        IProductRepository Product { get; }

        ILeadRepository Lead { get; }

    }
}
