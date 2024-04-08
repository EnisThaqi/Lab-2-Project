namespace Lab2.DTOs
{
    public class RoutesDTO
    {
        public int RouteId { get; set; }
        public decimal Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public bool optimal { get; set; }
    }
}
