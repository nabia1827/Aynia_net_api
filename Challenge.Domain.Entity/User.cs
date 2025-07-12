using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Entity
{
    public class User
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string ContrasenaHash { get; set; }
        public bool IsDeleted { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
