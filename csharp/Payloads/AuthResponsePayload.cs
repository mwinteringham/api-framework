namespace Payloads
{
    public class AuthResponsePayload
    {
        private string token;

        public string getToken()
        {
            return token;
        }

        public void setToken(string token)
        {
            this.token = token;
        }
    }
}
