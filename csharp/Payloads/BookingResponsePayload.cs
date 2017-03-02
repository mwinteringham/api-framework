namespace Payloads
{
    public class BookingResponsePayload
    {
        public int bookingid { get; private set; }
        public BookingPayload booking { get; private set; }

        public void setBookingid(int bookingid)
        {
            this.bookingid = bookingid;
        }

        public void setBooking(BookingPayload booking)
        {
            this.booking = booking;
        }
    }
}
