namespace TicketBookingCore
{
    public class TicketBookingResponse : TicketBookingBase
    {
        public bool Success { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}