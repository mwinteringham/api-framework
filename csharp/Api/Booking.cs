using Payloads;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Api
{
    public class Booking
    {
        private static HttpClient httpClient = new HttpClient();
        private static string baseUrl = "http://localhost:3001";

        public static HttpResponseMessage getBookings()
        {
            var bookingUrl = baseUrl + "/booking/";
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
            {
                return httpClient.SendAsync(request).Result;
            }
        }

        public static HttpResponseMessage getBooking(int id, MediaTypeHeaderValue accept)
        {
            try
            {
                var bookingUrl = baseUrl + "/booking/" + id.ToString();
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    request.Headers.Accept.Equals(accept);
                    return httpClient.SendAsync(request).Result;
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }

        }

        public static BookingResponsePayload postBooking(BookingPayload payload)
        {
            try
            {
                var bookingUrl = baseUrl + "/booking/";
                string requestBody = JsonConvert.SerializeObject(payload);
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Content-Type", "application/json");
                    request.Headers.Add("Accept", "application/json");
                    var response = httpClient.SendAsync(request).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<BookingResponsePayload>(responseString);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }

        }

        public static HttpResponseMessage deleteBooking(int id, string tokenValue)
        {
            try
            {
                var bookingUrl = baseUrl + "/booking/" + id.ToString();

                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Delete })
                {
                    request.Headers.Add("Cookie", "token=" + tokenValue);
                    return httpClient.SendAsync(request).Result;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }
    }
}
