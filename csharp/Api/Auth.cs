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
    }
}
