using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Repository
{
    public class DashboardRepository :IDashboardRepository
    {
        private readonly DapperContext _context;
        public DashboardRepository(DapperContext context)
        {
            _context = context;
        }
    }
}
