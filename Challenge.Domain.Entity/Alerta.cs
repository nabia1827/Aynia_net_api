using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Entity
{
    public class Alerta
    {
        public int AlertaId { get; set; }
		public string Mensaje { get; set; }
		public string Descripcion { get; set; }
		public string Tipo { get; set; }
		public string Fecha { get; set; }
		public int RolId { get; set; }
		public bool IsDeleted { get; set; }
    }
}
