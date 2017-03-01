namespace Payloads
{
    public class AuthPayload
    {
        private string username;
        private string password;

        private AuthPayload(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public AuthPayload()
        {
        }

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
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
