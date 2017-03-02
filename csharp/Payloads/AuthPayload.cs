namespace Payloads
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


        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
        
        }
}
