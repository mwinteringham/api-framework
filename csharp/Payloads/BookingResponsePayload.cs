namespace Payloads
{
    public class BookingResponsePayload
    {
        public int bookingid { get; set; }
        public BookingPayload booking { get; set; }

        public void SetBookingiId(int bookingid)
        {
            this.bookingid = bookingid;
        }

        public void SetBooking(BookingPayload booking)
        {
            this.booking = booking;
        }
    }
}
