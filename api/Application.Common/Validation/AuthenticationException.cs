namespace App.Common.Validation
{
    public class AuthenticationException:ValidationException
    {
        public AuthenticationException(AuthenticationType authType, string key):base(key)
        {
            this.Type = authType;
        }

        public AuthenticationType Type { get; set; }
    }
}
