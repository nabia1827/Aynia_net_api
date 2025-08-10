using Challenge.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthRepository Auth { get; }
        public IDashboardRepository Dashboard { get; }

        public IEmpresaRepository Empresa { get; }

        public UnitOfWork(IAuthRepository authRepository, IDashboardRepository dashboard, IEmpresaRepository empresa)
        {
            Auth = authRepository;

            Dashboard = dashboard;

            Empresa = empresa;

        }
    }
}
