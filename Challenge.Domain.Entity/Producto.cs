using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionJSON { get; set; }
        public List<string> Categorias { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; } = 0;

        public int EmpresaId { get; set; } = 0;
    }
}
