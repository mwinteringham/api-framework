using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using System.Net.Http.Headers;
using System.Net;
using Payloads;
using Newtonsoft.Json;
using System.Web;

namespace Tests
{
    [TestClass]
    public class BookingTestsMsTest
    {
        [TestMethod]
        public void getBookingShouldReturn200()
        {
            var response = Booking.getBookings();
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void getBookingIdShouldReturn200()
        {
            var response = Booking.getBooking(1,new MediaTypeHeaderValue("application/json"));
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void getBookingIdWithBadAcceptShouldReturn418()
        {
            try
            {
                Booking.getBooking(1, new MediaTypeHeaderValue("text/plain"));
                Assert.Fail("HttpException not thrown");
            }
            catch (HttpException e)
            {
                Assert.AreEqual(418, (int)e.GetHttpCode());
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

            var response = Booking.postBooking(payload);
            Assert.IsTrue(response.IsSuccessStatusCode, "Status Code is not 200");
        }

        [TestMethod]
        public void deleteBookingReturns201()
        {
            BookingPayload payload = new BookingPayload();
            payload.setFirstname("Mary");
            payload.setLastname("White");
            payload.setTotalprice(200);
            payload.setDepositpaid(true);
            payload.setBookingdates(new BookingDatesPayload(new DateTime(2017, 3, 31), new DateTime(2017, 4, 3)));
            payload.setAdditionalneeds("None");

            var response = Booking.postBooking(payload);
            string responsePayload = response.Content.ReadAsStringAsync().Result;
            BookingResponsePayload bookingResponse = JsonConvert.DeserializeObject<BookingResponsePayload>(responsePayload);

            AuthPayload authPayload = new AuthPayload();
            authPayload.setUsername("admin");
            authPayload.setPassword("password123");

            AuthResponsePayload authResponse = Auth.postAuth(authPayload);

            var deleteResponse = Booking.deleteBooking(bookingResponse.bookingid, authResponse.token);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.Created, "Http Status Code is not 201");
        }
    }
}
