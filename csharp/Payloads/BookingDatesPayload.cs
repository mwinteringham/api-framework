using System;

namespace Payloads
{
    public class BookingDatesPayload
    {
        private DateTime checkin { get; set; }
        private DateTime checkout { get; set; }

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