namespace Payloads
{
    public class BookingResponsePayload
    {
        public int BookingId { get; private set; }
        public BookingPayload Booking { get; private set; }

        public void SetBookingiId(int bookingid)
        {
            BookingId = bookingid;
        }

        public void SetBooking(BookingPayload booking)
        {
            Booking = booking;
        }
    }
}
