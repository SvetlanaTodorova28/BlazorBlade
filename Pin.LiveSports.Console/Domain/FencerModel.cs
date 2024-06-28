using Pin.LiveSports.Core.Entities;

namespace Pin.Liveports.Console.Domain;

public class FencerModel(string name, int rating, Guid teamId, string gender){

    public Guid Id{ get; } = Guid.NewGuid();
    public string Name{ get; } = name;
    public int Rating { get; } = rating;
    public Guid TeamId { get; set; } = teamId;
    
    public string? Gender { get; } = gender;
    
}