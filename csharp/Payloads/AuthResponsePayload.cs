namespace Payloads
{
    public class AuthResponsePayload
    {
        public string token { get; set; }

        public void SetToken(string token)
        {
            this.token = token;
        }
    }
}
