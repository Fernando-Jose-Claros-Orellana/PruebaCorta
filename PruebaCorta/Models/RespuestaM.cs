namespace PruebaCorta.Models
{
    public class RespuestaM
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdPregunta { get; set; }
        public string Nombre { get; set; }
        public string Respuesta { get; set; }
    }
}
