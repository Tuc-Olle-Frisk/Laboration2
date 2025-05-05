namespace TicketBookingCore
{
    public class TicketBookingResponse : TicketBookingBase
    {
        public bool Success = true;
        public string? ErrorMessage { get; set; }
    }
}