namespace Pin.LiveSports.Core.Entities;

public class Tournament:BaseEntity{
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Duel>? Games { get; set; }
    public List<Team> Teams { get; set; }
}