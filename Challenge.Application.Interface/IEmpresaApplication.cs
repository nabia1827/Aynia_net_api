using Challenge.Domain.Entity;
using System;
using Challenge.Transversal.Common;
using Challenge.Application.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Interface
{
    public interface IEmpresaApplication
    {
        Task<Response<bool>> EditDatosEmpresaById(Empresa empresa);
        Task<Response<EmpresaDto>> GetDatosEmpresaById(int empresaId);
    }
}
