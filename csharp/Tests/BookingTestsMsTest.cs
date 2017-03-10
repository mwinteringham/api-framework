using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using Payloads.Requests;
using Payloads.Responses;

namespace Tests
{
    [TestClass]
    public class BookingTestsMsTest
    {
        [TestMethod]
        public void GetBookingShouldReturn200()
        {
            var response = Booking.GetBookings();
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void GetBookingIdShouldReturn200()
        {
            var response = Booking.GetBooking(1,new MediaTypeHeaderValue("application/json"));
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void GetBookingIdWithBadAcceptShouldReturn418()
        {
            try
            {
               var response = Booking.GetBooking(1, new MediaTypeHeaderValue("text/plain"));
                Assert.Fail("HttpException not thrown");
            }
            catch (HttpException e)
            {
                Assert.AreEqual(418, (int)e.GetHttpCode());
            }
        }

        [TestMethod]
        public void PostBookingReturns200()
        {
            BookingPayload payload = new BookingPayload();
            payload.SetFirstname("Mary");
            payload.SetLastname("White");
            payload.SetTotalPrice(200);
            payload.SetDepositPaid(true);
            payload.SetBookingDates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
            payload.SetAdditionalNeeds("None");

            var response = Booking.PostBooking(payload);
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void DeleteBookingReturns201()
        {
            BookingPayload payload = new BookingPayload();
            payload.SetFirstname("Mary");
            payload.SetLastname("White");
            payload.SetTotalPrice(200);
            payload.SetDepositPaid(true);
            payload.SetBookingDates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
            payload.SetAdditionalNeeds("None");

            var response = Booking.PostBooking(payload);
            string responsePayload = response.Content.ReadAsStringAsync().Result;
            BookingResponsePayload bookingResponse = JsonConvert.DeserializeObject<BookingResponsePayload>(responsePayload);

            AuthPayload authPayload = new AuthPayload();
            authPayload.SetUsername("admin");
            authPayload.SetPassword("password123");

            AuthResponsePayload authResponse = Auth.PostAuth(authPayload);

            var deleteResponse = Booking.DeleteBooking(bookingResponse.bookingid, authResponse.token);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.Created, "Http Status Code is not 201");
        }
    }
}
