using Pin.LiveSports.Core.Entities;

namespace Pin.LiveSports.Core.Services.Interfaces;

public interface ITournamentService:ICrudService<Tournament>{
    Task<bool> IsTournamentDayAsync(DateTime date);
    Task<Tournament> TournamentOfTheDayAsync(DateTime date);
}