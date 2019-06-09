namespace MyApp.Jwt.Models
{
    public class JwtToken
    {
        public string Value { get; }
        public int ExpiresIn { get; }

        public JwtToken(string value, int expiresIn)
        {
            Value = value;
            ExpiresIn = expiresIn;
        }
    }
}
