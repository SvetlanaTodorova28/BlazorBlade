using Pin.LiveSports.Core.Entities;

using Pin.LiveSports.Blazor.Dto_s;

namespace Pin.LiveSports.Blazor.Services;

public interface IDuelEventManager{

    /*Task StartTournament();*/
    Task ResetDuels(DuelDto[] duelsForTheDayDto);
    Task EndTournament(DuelDto [] duelsOfDtos);
    Task<DuelDto> MakeDuel(Guid duelId);
    Task<DuelDto[]> GetDuelDtos();
    
     Task AddComment(Guid duelId, string comment);
     Task AddPointsA(Guid duelId, int points);
     Task AddPointsB(Guid duelId, int points);
     Task<Dictionary<string, int>> GetFencersForRang();
}