using Challenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Interface
{
    public interface IEmpresaDomain
    {
        Task<bool> EditDatosEmpresaById(Empresa empresa);
        Task<Empresa> GetDatosEmpresaById(int empresaId);
    }
}
