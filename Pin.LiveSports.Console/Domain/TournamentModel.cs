namespace Pin.Liveports.Console.Domain;

public class TournamentModel{
    
    public Guid Id { get; set; }
    public List<FencerModel> Participants { get; set; }
}