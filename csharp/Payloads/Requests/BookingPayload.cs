namespace Payloads.Requests
{
    public class BookingPayload
    {
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public int totalprice { get; private set; }
        public bool depositpaid { get; private set; }
        public BookingDatesPayload bookingdates { get; private set; }
        public string additionalneeds { get; private set; }

        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void SetTotalPrice(int totalprice)
        {
            this.totalprice = totalprice;
        }

        public void SetDepositPaid(bool depositpaid)
        {
            this.depositpaid = depositpaid;
        }

        public void SetBookingDates(BookingDatesPayload bookingdates)
        {
            this.bookingdates = bookingdates;
        }

        public void SetAdditionalNeeds(string additionalneeds)
        {
            this.additionalneeds = additionalneeds;
        }

        private BookingPayload(string firstname, string lastname, int totalprice, bool depositpaid, BookingDatesPayload bookingdates, string additionalneeds)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.totalprice = totalprice;
            this.depositpaid = depositpaid;
            this.bookingdates = bookingdates;
            this.additionalneeds = additionalneeds;
        }

        public BookingPayload()
        {
        }

    }
}
