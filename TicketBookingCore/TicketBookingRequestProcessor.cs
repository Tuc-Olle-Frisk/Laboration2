
namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        //suggesting that _ticketBookingRepository will hold a reference to an object that implements this interface.
        private readonly ITicketBookingRepository _ticketBookingRepository;
        public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!IsValidEmail(request.Email))
            {
                return new TicketBookingResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid email address."
                };
            }

            _ticketBookingRepository.Save(Create<TicketBooking>(request));
            return Create<TicketBookingResponse>(request);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method creates a new instance of the specified type 
        /// and sets the properties from the request object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private static T Create<T>(TicketBookingRequest request) where T : TicketBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
        }
    }
}