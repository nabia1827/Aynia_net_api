namespace Challenge.Services.WebApi.Models.Requests
{
    public class EmpresaRequest
    {
        public int EmpresaId { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string ZonaEntrega { get; set; }
    }
}
