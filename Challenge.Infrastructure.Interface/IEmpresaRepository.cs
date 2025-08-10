using System;
using Challenge.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Interface
{
    public interface IEmpresaRepository
    {
        Task<bool> EditDatosEmpresaById(Empresa empresa);
        Task<Empresa> GetDatosEmpresaById(int empresaId);
    }
}
