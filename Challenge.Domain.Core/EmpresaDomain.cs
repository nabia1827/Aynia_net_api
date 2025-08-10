using Challenge.Application.Wrapper;
using Challenge.Domain.Entity;
using Challenge.Domain.Interface;
using Challenge.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Core
{
    public class EmpresaDomain : IEmpresaDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmpresaDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> EditDatosEmpresaById(Empresa empresa)
        {
            return await _unitOfWork.Empresa.EditDatosEmpresaById(empresa);
        }

        public async Task<Empresa> GetDatosEmpresaById(int empresaId)
        {
            return await _unitOfWork.Empresa.GetDatosEmpresaById(empresaId);
        }
    }
}
