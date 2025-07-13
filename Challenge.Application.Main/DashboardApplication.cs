using AutoMapper;
using Challenge.Application.Interface;
using Challenge.Domain.Interface;
using Challenge.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Main
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IDashboardDomain _domain;
        private readonly IMapper _mapper;

        public DashboardApplication(IDashboardDomain domain, IMapper iMapper)
        {
            _domain = domain;
            _mapper = iMapper;
        }

    }
}
