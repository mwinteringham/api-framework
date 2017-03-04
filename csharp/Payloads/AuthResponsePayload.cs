namespace Payloads
{
    public class AuthResponsePayload
    {
        public string Token { get; private set; }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
