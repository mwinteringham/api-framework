namespace Payloads
{
    public class AuthResponsePayload
    {
        public string token { get; private set; }

        public void setToken(string token)
        {
            this.token = token;
        }
    }
}
