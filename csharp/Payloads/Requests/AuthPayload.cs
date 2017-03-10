namespace Payloads.Requests
{
    public class AuthPayload
    {
        public string username { get; private set; }
        public string password { get; private set; }

        private AuthPayload(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public AuthPayload()
        {
        }


        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

    }
}
