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
    }
}
