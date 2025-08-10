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
        public IProductRepository Product { get; }
        public IEmpresaRepository Empresa { get; }
        public ILeadRepository Lead { get; }

        public UnitOfWork(
            IAuthRepository authRepository, 
            IDashboardRepository dashboard, 
            IProductRepository products,
            ILeadRepository leads,
            IEmpresaRepository empresa
        )
        {
            Auth = authRepository;
            Dashboard = dashboard;
            Product = products;
            Lead = leads;
            Empresa = empresa;
        }

    }
}
