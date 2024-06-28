using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services.Interfaces;


namespace Pin.LiveSports.Core.Services;

public class TournamentService:ITournamentService{
    private readonly FencingDbContext _fencingDbContext;
    public TournamentService(FencingDbContext fencingDbContext)
    {
        _fencingDbContext = fencingDbContext;
    }
 

    public Task<IQueryable<Tournament>> GetAllAsync(){
        return Task.FromResult(_fencingDbContext
            .Tournaments
            .Include(x => x.Teams)
            .Select(x => new Tournament{
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                Teams = x.Teams.Select(t => new Team(){
                Id = t.Id,
                Name = t.Name
            }).ToList()
            }));
    }

    

    public Task<Tournament> GetAsync(Guid id){
        return Task.FromResult(_fencingDbContext
            .Tournaments
            .Include(x => x.Teams)
            .ThenInclude(t => t.Players)
            .FirstOrDefault(p => p.Id == id));
    }

    public Task CreateAsync(Tournament tournament){
        tournament.Id = Guid.NewGuid();
        _fencingDbContext.Tournaments.Add(tournament);
        _fencingDbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Tournament item){
        var existing = await GetAsync(item.Id);
        if (existing == null) throw new ArgumentException("Tournament not found");
        existing.Name = item.Name;
        existing.Teams.Clear();
        existing.Teams.AddRange(item.Teams);
        existing.StartDate = item.StartDate;
        _fencingDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id){
        var tournamentToDelete = await _fencingDbContext.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
        if (tournamentToDelete != null)
        {
            _fencingDbContext.Tournaments.Remove(tournamentToDelete);
            await _fencingDbContext.SaveChangesAsync();
        }
    }


    public IQueryable<Tournament> GetAll(){
       return _fencingDbContext
           .Tournaments
           .Include(t =>t.Teams)
           .AsQueryable();
    }

    public async  Task<bool> IsTournamentDayAsync(DateTime date){
        return await _fencingDbContext.Tournaments.AnyAsync(t => t.StartDate.Date == date || t.StartDate.Date <= date);
    }

    public async Task<Tournament> TournamentOfTheDayAsync(DateTime date){
        return await _fencingDbContext
            .Tournaments
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.StartDate.Date == date.Date || t.StartDate.Date <= date);
        
    }
    

   
}