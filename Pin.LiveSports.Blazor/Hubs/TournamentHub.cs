using Microsoft.AspNetCore.SignalR;
using Pin.LiveSports.Blazor.Dto_s;
using Pin.LiveSports.Blazor.Services;


namespace Pin.LiveSports.Blazor.Hubs;

public class TournamentHub:Hub{
private readonly IDuelEventManager _duelEventManager;
public DuelDto[] duels;
public Dictionary<string, int> ratingsFencers = new();


    public TournamentHub(IDuelEventManager duelEventManager){
        _duelEventManager = duelEventManager;
    }
    
    public async Task NotifyClientsToEndSession(DuelDto [] duelsOfDtos){
        await _duelEventManager.EndTournament(duelsOfDtos);
        await Clients.All.SendAsync("ReceiveEndSession",duels);
    }

    public async Task  ResetDuels (DuelDto [] duelsOfDtos){
        await _duelEventManager.ResetDuels(duelsOfDtos);
        await Clients.All.SendAsync("ReceiveResetDuels", duels);
    }
    
  
    public async Task SendDuels(){
        duels = await _duelEventManager.GetDuelDtos();
        ratingsFencers = await _duelEventManager.GetFencersForRang();
        await Clients.All.SendAsync("ReceiveDuels", duels,ratingsFencers);
    }
    
    public async Task SendDuelComments(Guid duelId, string comment){
        await _duelEventManager.AddComment(duelId,comment);
        var duelDto = await _duelEventManager.MakeDuel(duelId);
        await Clients.All.SendAsync("ReceiveDuelComments", duelId, duelDto.Comments);
    }
   
    public async Task UpdatePointsA(Guid duelId, int pointsA){
       await _duelEventManager.AddPointsA(duelId, pointsA);
        ratingsFencers = await _duelEventManager.GetFencersForRang();
        var duel =  await _duelEventManager.MakeDuel(duelId);
        var fencerAPoints =  duel.FencerAPoints;
        await Clients.All.SendAsync("ReceivePointsA", duelId, fencerAPoints,ratingsFencers);
    }
    
    public async Task UpdatePointsB(Guid duelId, int pointsB){
        await _duelEventManager.AddPointsB(duelId, pointsB);
        ratingsFencers = await _duelEventManager.GetFencersForRang(); 
        var duel =  await _duelEventManager.MakeDuel(duelId);
        var fencerBPoints =  duel.FencerBPoints;
        await Clients.All.SendAsync("ReceivePointsB", duelId, fencerBPoints,ratingsFencers);
    }
    public async Task TriggerLightA(Guid duelId){
        await Clients.All.SendAsync("ReceiveLightA", duelId);
    }

    public async Task TriggerLightB(Guid duelId){
        await Clients.All.SendAsync("ReceiveLightB", duelId);
    }

    public async Task UpdateWatch(string remainingTime){
        await Clients.All.SendAsync("ReceiveTime", remainingTime);
    }
    public async Task ResetWatch(){
        var initialTime = "03:00"; 
        await Clients.All.SendAsync("ReceiveTime", initialTime);
    }

    
    
    
}