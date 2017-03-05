using Payloads;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using System.Net;

namespace Api
{
    public class Booking
    {
        private static string _baseUrl = "http://localhost:3001";

        public static HttpResponseMessage GetBookings()
        {
            var bookingUrl = _baseUrl + "/booking/";
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    var response = httpClient.SendAsync(request).Result;
                    CheckFor200Response(response);
                    return response;
                }
            }
        }

        public static HttpResponseMessage GetBooking(int id, MediaTypeHeaderValue accept)
        {
            var bookingUrl = _baseUrl + "/booking/" + id.ToString();
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Get })
                {
                    request.Headers.Add("Accept", accept.ToString());
                    var response = httpClient.SendAsync(request).Result;
                    CheckFor200Response(response);
                    return response;
                }
            }
        }

        public static HttpResponseMessage PostBooking(BookingPayload payload)
        {
            var bookingUrl = _baseUrl + "/booking/";
            string requestBody = JsonConvert.SerializeObject(payload);
            using (var httpClient = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    //request.Headers.Add("Content-Type", "application/json");
                    request.Headers.Add("Accept", "application/json");
                    var response = httpClient.SendAsync(request).Result;
                    CheckFor200Response(response);
                    return response;
                }
            }
        }

        public static HttpResponseMessage DeleteBooking(int id, string tokenValue)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler())
                {
                    handler.CookieContainer = cookieContainer;
                    var bookingUrl = _baseUrl + "/booking/" + id.ToString();
                    using (var httpClient = new HttpClient(handler))
                    {
                        using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(bookingUrl), Method = HttpMethod.Delete })
                        {
                            cookieContainer.Add(new Uri(bookingUrl), new Cookie("token", tokenValue));
                            return httpClient.SendAsync(request).Result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: " + e);
                return null;
            }
        }

        public static void CheckFor200Response(HttpResponseMessage response)
        {
            if ((int)response.StatusCode != 200)
            {
                throw new HttpException((int)response.StatusCode, "Request returned a non-200 response:" + response.RequestMessage);
            }
        }
    }
}
