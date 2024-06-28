namespace Pin.Liveports.Console.Domain;

public class TeamModel(string name,List<FencerModel> players){
    
    public string Name{ get; } = name;
    public List<FencerModel>? Players {get; set; } = players;
    public Guid Id {get;} = Guid.NewGuid();
}