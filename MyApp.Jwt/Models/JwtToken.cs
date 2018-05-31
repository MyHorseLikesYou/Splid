namespace MyApp.Jwt.Models
{
    public class JwtToken
    {
        public string Value { get; private set; }
        public int ExpiresIn { get; private set; }

        public JwtToken(string value, int expiresIn)
        {
            Value = value;
            ExpiresIn = expiresIn;
        }
    }
}
