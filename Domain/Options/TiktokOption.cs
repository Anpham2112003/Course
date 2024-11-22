namespace Domain.Options;

public class TiktokOption
{
    public const string Tiktok = "Authentication:Tiktok";
    public string? Client_id { get; set; }
    public string? Client_secret { get; set; }
    public string? Url { get; set; }
    public string? Redirect_uri { get; set; }
    public string? ResponseType { get; set; }
    public string? Scope { get; set; }
}