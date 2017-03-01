using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Payloads;

namespace Tests
{
    [TestClass]
    public class BookingTestsMsTest
    {
        [TestMethod]
        public void getBookingShouldReturn200()
        {
            var response = Booking.getBookings();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void getBookingIdShouldReturn200()
        {
            var response = Booking.getBooking(1,new MediaTypeHeaderValue("application/json"));
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void getBookingIdWithBadAcceptShouldReturn418()
        {
            try
            {
                Booking.getBooking(1, new MediaTypeHeaderValue("text/plain"));
                Assert.Fail("HttpRequestException not thrown");
            }
            catch (HttpRequestException e)
            {
                var response = e.Message;
                var property = response.GetType().GetProperty("StatusCode");
                //need to figure out how to get the 418 status code here, and how it looks, then create a new enum and cast it
               // Assert.IsTrue((HttpStatusCode)property.GetValue(response) = )
            }
        }

        [TestMethod]
        public void postBookingReturns200()
        {
            BookingPayload payload = new BookingPayload();
            payload.setFirstname("Mary");
            payload.setLastname("White");
            payload.setTotalprice(200);
            payload.setDepositpaid(true);
            payload.setBookingdates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
            payload.setAdditionalneeds("None");

            BookingResponsePayload response = Booking.postBooking(payload);
            Assert.

            AuthPayload authPayload = new AuthPayload();
            authPayload.setUsername("admin");
            authPayload.setPassword("password123");

            AuthResponsePayload authResponse = Auth.postAuth(authPayload);
        }
    }
}
