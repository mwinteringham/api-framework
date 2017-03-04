using Payloads;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Web;

namespace Api
{
    public class Booking
    {
        private static HttpClient _httpClient = new HttpClient();
        private static string _baseUrl = "http://localhost:3001";

        public static HttpResponseMessage GetBookings()
        {
            var bookingUrl = _baseUrl + "/booking/";
            using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
            {
                return _httpClient.SendAsync(request).Result;
            }
        }

        public static HttpResponseMessage GetBooking(int id, MediaTypeHeaderValue accept)
        {
            try
            {
                var bookingUrl = _baseUrl + "/booking/" + id.ToString();
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    request.Headers.Accept.Equals(accept);
                    return _httpClient.SendAsync(request).Result;
                }

            }
            catch (HttpException e)
            {
                throw e;
            }

        }

        public static HttpResponseMessage PostBooking(BookingPayload payload)
        {
            try
            {
                var bookingUrl = _baseUrl + "/booking/";
                string requestBody = JsonConvert.SerializeObject(payload);
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    //request.Headers.Add("Content-Type", "application/json");
                    request.Headers.Add("Accept", "application/json");
                    return _httpClient.SendAsync(request).Result;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }

        }

        public static HttpResponseMessage DeleteBooking(int id, string tokenValue)
        {
            try
            {
                var bookingUrl = _baseUrl + "/booking/" + id.ToString();

                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Delete })
                {
                    request.Headers.Add("Cookie", "token=" + tokenValue);
                    return _httpClient.SendAsync(request).Result;
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
