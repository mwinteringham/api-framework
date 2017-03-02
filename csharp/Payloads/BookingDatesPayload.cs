using System;

namespace Payloads
{
    public class BookingDatesPayload
    {
        public  DateTime checkin { get; private set; }
        public  DateTime checkout { get; private set; }

        public BookingDatesPayload(DateTime checkin, DateTime checkout)
        {
            this.checkin = checkin;
            this.checkout = checkout;
        }
    }
}