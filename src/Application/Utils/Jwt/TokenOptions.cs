namespace Application.Utils.Jwt;

public class TokenOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int Expires { get; set; }
    public string SecurityKey { get; set; }
}