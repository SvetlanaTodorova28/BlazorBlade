using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services.Interfaces;


namespace Pin.LiveSports.Core.Services;

public class TeamService:ICrudService<Team>{
    private readonly FencingDbContext _fencingDbContext;
    public TeamService(FencingDbContext fencingDbContext)
    {
        _fencingDbContext = fencingDbContext;
    }
 

    public Task<IQueryable<Team>> GetAllAsync(){
        return Task.FromResult(_fencingDbContext
            .Teams
            .Include(x => x.Players)
            .Select(x => new Team(){
                Id = x.Id,
                Name = x.Name,
                Flag = x.Flag,
                Players = x.Players.Select(p => new Fencer{
                    Id = p.Id,
                    Name = p.Name,
                    Rating = p.Rating,
                    TeamId = p.TeamId,
                }).ToList()
            }));
    }

    public Task<Team> GetAsync(Guid id){
        return Task.FromResult(_fencingDbContext
            .Teams
            .Include(x => x.Players)
            .FirstOrDefault(p => p.Id == id));
    }

    public Task CreateAsync(Team item){
        item.Id = Guid.NewGuid();
        _fencingDbContext.Teams.Add(item);
        _fencingDbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Team item){
        var existing = await GetAsync(item.Id);
        if (existing == null) throw new ArgumentException("Team not found");
        existing.Name = item.Name;
        existing.CountryCode = item.CountryCode;
        existing.Flag = item.Flag;
        _fencingDbContext.SaveChanges();
    }

    public async Task DeleteAsync(Guid id){
        var teamToDelete = await _fencingDbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (teamToDelete != null)
        {
            _fencingDbContext.Teams.Remove(teamToDelete);
            await _fencingDbContext.SaveChangesAsync();
        }
    }

    public IQueryable<Team> GetAll(){
       return _fencingDbContext.Teams.AsQueryable();
    }
}