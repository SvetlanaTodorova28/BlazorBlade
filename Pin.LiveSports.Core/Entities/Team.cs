namespace Pin.LiveSports.Core.Entities;

public class Team:BaseEntity{
    
    public List<Fencer> Players { get; set; }
    public List<Tournament> Tournaments { get; set; }
    public string CountryCode { get; set; }
    public string Flag { get; set; }
}