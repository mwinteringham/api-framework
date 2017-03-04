using System;

namespace Payloads
{
    public class BookingDatesPayload
    {
        public  DateTime Checkin { get; private set; }
        public  DateTime Checkout { get; private set; }

        public BookingDatesPayload(DateTime checkin, DateTime checkout)
        {
            Checkin = checkin;
            Checkout = checkout;
        }
    }
}