using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.DTO
{
    public class EmpresaDto
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string LogoURL { get; set; }
        public string Correo { get; set; }
        public string ZonaEntrega { get; set; }
    }
}
