using Payloads;
using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Api
{
    public class Auth
    {
        private static HttpClient httpClient = new HttpClient();
 
        public static AuthResponsePayload postAuth(AuthPayload payload)
        {
            try
            {              
                string requestBody = JsonConvert.SerializeObject(payload);
                using (HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri("http://localhost:3001/auth"), Method = HttpMethod.Post })
                {
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Content-Type", "application/json");
                    var response = httpClient.SendAsync(request).Result;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<AuthResponsePayload>(responseString);
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
