namespace Payloads
{
    public class BookingPayload
    {
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public int totalprice { get; private set; }
        public bool depositpaid { get; private set; }
        public BookingDatesPayload bookingdates { get; private set; }
        public string additionalneeds { get; private set; }

        public void setFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void setLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void setTotalprice(int totalprice)
        {
            this.totalprice = totalprice;
        }

        public void setDepositpaid(bool depositpaid)
        {
            this.depositpaid = depositpaid;
        }

        public void setBookingdates(BookingDatesPayload bookingdates)
        {
            this.bookingdates = bookingdates;
        }

        public void setAdditionalneeds(string additionalneeds)
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

        //public BookingPayload build()
        //{
        //    BookingDatesPayload bookingDates = new BookingDatesPayload(checkin, checkout);
        //    return new BookingPayload(firstname, lastname, totalprice, depositpaid, bookingDates, additionalneeds);
        //}
    }
   }
