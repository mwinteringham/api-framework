using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payloads
{
    public class BookingPayload
    {
        private string firstname { get; set; }
        private string lastname { get; set; }
        private int totalprice { get; set; } //declared an int in the java files
        private bool depositpaid { get; set; }
        private BookingDatesPayload bookingdates { get; set; }
        private string additionalneeds { get; set; }

        public string getFirstname()
        {
            return firstname;
        }

        public string getLastname()
        {
            return lastname;
        }

        public int getTotalprice()
        {
            return totalprice;
        }

        public bool isDepositpaid()
        {
            return depositpaid;
        }

        public BookingDatesPayload getBookingdates()
        {
            return bookingdates;
        }

        public string getAdditionalneeds()
        {
            return additionalneeds;
        }

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

        public BookingPayload build()
        {
            BookingDatesPayload bookingDates = new BookingDatesPayload(checkin, checkout);
            return new BookingPayload(firstname, lastname, totalprice, depositpaid, bookingDates, additionalneeds);
        }
    }
   }
