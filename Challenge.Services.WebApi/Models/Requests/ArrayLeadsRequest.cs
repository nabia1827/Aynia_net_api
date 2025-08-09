namespace Challenge.Services.WebApi.Models.Requests
{
    public class ArrayLeadsRequest
    {
        public int empresaId { get; set; } = 0;
        public int? mes { get; set; } = 0;
        public int? anio { get; set; } = 0;
        public string? valorBusqueda {  get; set; } = string.Empty;
    }
}
