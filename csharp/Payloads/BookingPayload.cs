namespace Payloads
{
    public class BookingPayload
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public int TotalPrice { get; private set; }
        public bool DepositPaid { get; private set; }
        public BookingDatesPayload BookingDates { get; private set; }
        public string AdditionalNeeds { get; private set; }

        public void SetFirstname(string firstname)
        {
            Firstname = firstname;
        }

        public void SetLastname(string lastname)
        {
            Lastname = lastname;
        }

        public void SetTotalPrice(int totalprice)
        {
            TotalPrice = totalprice;
        }

        public void SetDepositPaid(bool depositpaid)
        {
            DepositPaid = depositpaid;
        }

        public void SetBookingDates(BookingDatesPayload bookingdates)
        {
            BookingDates = bookingdates;
        }

        public void SetAdditionalNeeds(string additionalneeds)
        {
            AdditionalNeeds = additionalneeds;
        }

        private BookingPayload(string firstname, string lastname, int totalprice, bool depositpaid, BookingDatesPayload bookingdates, string additionalneeds)
        {
            Firstname = firstname;
            Lastname = lastname;
            TotalPrice = totalprice;
            DepositPaid = depositpaid;
            BookingDates = bookingdates;
            AdditionalNeeds = additionalneeds;
        }

        public BookingPayload()
        {
        }

    }
}
