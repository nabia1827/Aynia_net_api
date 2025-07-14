using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Wrapper
{
    public class ReporteLeadWrapper
    {
        public int LeadId { get; set; }
        public string LeadNombre { get; set;}
        public string ProductosTxt { get; set; }
        public float MontoTotal { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
    }
}
