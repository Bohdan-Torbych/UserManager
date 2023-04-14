namespace webapi.Options;

public class JwtConfig
{
    public static string ConfigurationSection = "Jwt";
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string Key { get; set; } = default!;
}