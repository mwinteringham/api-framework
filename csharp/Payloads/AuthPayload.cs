namespace Payloads
{
    public class AuthPayload
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        private AuthPayload(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public AuthPayload()
        {
        }


        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

    }
}
