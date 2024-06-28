using Microsoft.AspNetCore.SignalR.Client;
using Pin.LiveSports.Blazor.Dto_s;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services.Interfaces;


namespace Pin.LiveSports.Blazor.Services;

public class DuelEventManager:IDuelEventManager {
    private readonly ICrudService<Duel> _duelService;
    private readonly ICrudService<Fencer> _fencerService;
    private readonly ICrudService<DuelDto> _duelDtoService;
    private readonly ITournamentService _tournamentService;
    private  HubConnection hubConnection;
    private Duel[] duelsForTheDay;
    private DuelDto[] duelsForTheDayDto;
   
  
    
    public DuelEventManager(ICrudService<Duel> duelService, ICrudService<Fencer> fencerService,
        ITournamentService tournamentService){
        _duelService = duelService;
        _fencerService = fencerService;
        _tournamentService = tournamentService;
    }
  
    public async Task <DuelDto[]> GetDuelDtos(){
        duelsForTheDay =  await GetDuelsOfTheDayAsync();
        return await MakeDtos(duelsForTheDay);
    }
    private async Task<Duel[]> GetDuelsOfTheDayAsync(){
        var tournamentOfTheDay = await TournamentOfTheDay();
        return tournamentOfTheDay.Games.ToArray();
    }
    private async Task<Tournament> TournamentOfTheDay(){
        return await _tournamentService
            .TournamentOfTheDayAsync(DateTime.Today);
    }
    private async Task<DuelDto[]> MakeDtos(Duel[] duels) {
        var tasks = duels.Select(async duel => await MakeDuel(duel.Id));
        var results = await Task.WhenAll(tasks);
        return results.Where(dto => dto != null).ToArray(); 
    }
    public async Task<DuelDto> MakeDuel(Guid duelId){
        var duel = await GetDuel(duelId);
        if (duel == null) return null;
        DuelDto duelDto = new();
        duelDto.Id = duel.Id;
        var playerA = await _fencerService.GetAsync(duel.FencerAId);
        duelDto.FencerAName = playerA.Name;
        duelDto.FencerAFlag = playerA.Team.Flag;
        duelDto.FencerAPoints = duel.FencerAPoints;
        duelDto.FencerARating = playerA.Rating;
        var playerB = await _fencerService.GetAsync(duel.FencerBId);
        duelDto.FencerBName = playerB.Name;
        duelDto.FencerBFlag = playerB.Team.Flag;
        duelDto.FencerBRating = playerB.Rating;
        duelDto.FencerBPoints = duel.FencerBPoints;
        var comments = duel.Comments.Select(c => c.Content).ToList();
        duelDto.Comments = comments;
        duelDto.TimeLeft = TimeSpan.FromMinutes(3);
        duelDto.TournamentId = duel.TournamentId;
        return duelDto;
    }

    public async Task<Dictionary<string, int>> GetFencersForRang(){
        Dictionary<string, int> fencersWithRating = new();
        var fencers = await _fencerService.GetAllAsync();
        foreach (var fencer in fencers){
            fencersWithRating.Add(fencer.Name, fencer.Rating);
        }
        return fencersWithRating;
    }

    public async Task<Duel> GetDuel(Guid duelId){
        return await _duelService.GetAsync(duelId);
    }
    public async Task AddComment(Guid duelId, string comment){
        var duel = await GetDuel(duelId);
        duel.Comments.Add(new Comment{ Content = comment });
        await _duelService.UpdateAsync(duel);
    }
    public async Task AddPointsA(Guid duelId, int points){
        var duel = await _duelService.GetAsync(duelId);
        duel.FencerA.Rating += points;
        duel.FencerAPoints += points;
        await _duelService.UpdateAsync(duel);
    }
    public async Task AddPointsB(Guid duelId, int points){
        var duel = await _duelService.GetAsync(duelId);
        duel.FencerB.Rating += points;
        duel.FencerBPoints  += points;
        await _duelService.UpdateAsync(duel);
    }
    public async Task ResetDuels(DuelDto [] duelsForTheDayDto){
        var duels = await DuelsForTheDay(duelsForTheDayDto);
        foreach (var duel in duels){
            duel.FencerAPoints = 0;
            duel.FencerBPoints = 0;
            await _duelService.UpdateAsync(duel);
            
        }

    }

    public async Task EndTournament(DuelDto [] duelsForTheDayDto){
       ResetDuels(duelsForTheDayDto);
       var tournamentOfTheDay = await TournamentOfTheDay();
       await _tournamentService.DeleteAsync(tournamentOfTheDay.Id);
    }

    private async Task<Duel[]> DuelsForTheDay(DuelDto[] duelsForTheDayDto){
        List<Guid> duelIds = duelsForTheDayDto.Select(dto => dto.Id).ToList();
        return   _duelService
            .GetAll()
            .Where(duel => duelIds.Contains(duel.Id))
            .ToArray();
    }
    
    
    
   
    

}