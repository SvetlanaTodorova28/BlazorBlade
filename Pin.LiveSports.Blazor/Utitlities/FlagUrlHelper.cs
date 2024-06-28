namespace Pin.LiveSports.Blazor.Utitlities;

public static class FlagUrlHelper
{
    public static string GetFlagUrl(string countryCode)
    {
        string baseUrl = "https://flagsapi.com/";
        string flagUrl = $"{baseUrl}{countryCode}/shiny/64.png";
        return flagUrl;
    }
}
