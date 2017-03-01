using System;

namespace Payloads
{
    public class BookingDatesPayload
    {
        private DateTime checkin { get; set; }
        private DateTime checkout { get; set; }

        public BookingDatesPayload(DateTime checkin, DateTime checkout)
        {
            this.checkin = checkin;
            this.checkout = checkout;
        }

        public DateTime getCheckin()
        {
            return checkin;
        }

        public DateTime getCheckout()
        {
            return checkout;
        }
    }
}