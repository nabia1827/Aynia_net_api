namespace Challenge.Services.WebApi.Models.Requests
{
    public class ReporteLeadsRequest
    {
        public int empresaId { get; set; } = 0;
        public int? productoId { get; set; } = 0;
        public string? estado {  get; set; } = string.Empty;
    }
}
