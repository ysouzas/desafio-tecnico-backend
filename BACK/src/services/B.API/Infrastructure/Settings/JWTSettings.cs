﻿namespace B.API.Infrastructure.Settings;

public class JwtSettings
{
    public string Secret { get; set; } = string.Empty;
    public int ExpirationHours { get; set; }
    public string Audience { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
}