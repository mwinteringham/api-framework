using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payloads
{
    public class BookingResponsePayload
    {
        private int bookingid { get; set; }
        private BookingPayload booking { get; set; }

        public void setBookingid(int bookingid)
        {
            this.bookingid = bookingid;
        }

        public void setBooking(BookingPayload booking)
        {
            this.booking = booking;
        }

        public int getBookingid()
        {
            return bookingid;
        }

        public BookingPayload getBooking()
        {
            return booking;
        }
    }
}
