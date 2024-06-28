using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Enums;
using Pin.LiveSports.Core.Services.Interfaces;
using Pin.LiveSports.Core.Services.Models;

namespace Pin.LiveSports.Core.Services;

public class PlayerService:ICrudService<Fencer>{
    private readonly FencingDbContext _fencingDbContext;
    private readonly IAvatarService _avatarService;
        
    public PlayerService(FencingDbContext fencingDbContext, IAvatarService avatarService)
    {
        _fencingDbContext = fencingDbContext;
        _avatarService = avatarService;
    }
    

    public Task<IQueryable<Fencer>> GetAllAsync(){
        var teams = _fencingDbContext.Teams.AsQueryable();
        return Task.FromResult(_fencingDbContext
            .Players
            .Include(x => x.Team)
            .Select(x => new Fencer{
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                Rating = x.Rating,
                TeamId = x.TeamId,
                AvatarPicture = x.AvatarPicture,
                Team = teams.FirstOrDefault(t => t.Id == x.TeamId)
            }).OrderByDescending(p => p.Team.Players.Count).AsQueryable());
    }

    public Task<Fencer> GetAsync(Guid id){
        return Task.FromResult(_fencingDbContext
            .Players
            .Include(x => x.Team)
            .FirstOrDefault(p => p.Id == id));
    }

    public Task CreateAsync(Fencer player){
        player.Id = Guid.NewGuid();
        player.AvatarPicture = _avatarService.GetAvatarUrl(player.Gender.ToText(),player.Id.ToString());
        _fencingDbContext.Players.Add(player);
        _fencingDbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Fencer item){
        var existing = await GetAsync(item.Id);
        if (existing == null) throw new ArgumentException("Player not found");
        existing.Name = item.Name;
        existing.TeamId = item.TeamId;
        existing.Rating = item.Rating;
        existing.Gender = item.Gender;
        existing.AvatarPicture = _avatarService.GetAvatarUrl(item.Gender.ToText(),item.Id.ToString());
        _fencingDbContext.SaveChanges();
    }

    public async Task DeleteAsync(Guid fencerId)
    {
        var fencer = await _fencingDbContext.Players.FindAsync(fencerId);
        if (fencer == null)
        {
            throw new InvalidOperationException("Fencer not found.");
        }

       
        var relatedDuels = _fencingDbContext.Duels
            .Where(d => d.FencerAId == fencerId || d.FencerBId == fencerId);

        _fencingDbContext.Duels.RemoveRange(relatedDuels);
        await _fencingDbContext.SaveChangesAsync();

        
        _fencingDbContext.Players.Remove(fencer);
        await _fencingDbContext.SaveChangesAsync();
    }


    public IQueryable<Fencer> GetAll()
    {
        return _fencingDbContext.Players.AsQueryable();
    }
}