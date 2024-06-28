using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services.Interfaces;

namespace Pin.LiveSports.Core.Services;

public class DuelService:ICrudService<Duel>{
    private readonly FencingDbContext _fencingDbContext;

    public DuelService(FencingDbContext fencingDbContext){
        _fencingDbContext = fencingDbContext;
    }

    public Task<IQueryable<Duel>> GetAllAsync(){

        return Task.FromResult(_fencingDbContext
            .Duels
            .Include(x => x.Tournament)
            .Include(x => x.FencerA)
            .Include(x => x.FencerB)
            .Select(x => new Duel{
                Id = x.Id,
                Tournament = x.Tournament,
                TournamentId = x.TournamentId,
                FencerA = x.FencerA,
                FencerB = x.FencerB,
                FencerAId = x.FencerAId,
                FencerBId = x.FencerBId
            }).OrderBy(d => d.Tournament.StartDate).ToList().AsQueryable());
    }
    
    public Task<Duel> GetAsync(Guid id){
        return Task.FromResult(_fencingDbContext
            .Duels
            .Include(x => x.Tournament)
            .Include(x =>x.Tournament.Teams)
            .Include(x => x.FencerA)
            .Include(x => x.FencerB)
            .FirstOrDefault(p => p.Id == id));
    }

    public Task CreateAsync(Duel duel){
        duel.Id = Guid.NewGuid();
        _fencingDbContext.Duels.Add(duel);
        _fencingDbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Duel item){
        var existing = await GetAsync(item.Id);
        if (existing == null) throw new ArgumentException("Duel not found");
        existing.FencerAId = item.FencerAId;
        existing.FencerBId = item.FencerBId;
        existing.FencerAPoints = item.FencerAPoints;
        existing.FencerBPoints = item.FencerBPoints;
        existing.Tournament = item.Tournament;
        existing.Comments = item.Comments;
       await _fencingDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id){
        var duelToDelete = await _fencingDbContext
            .Duels.FirstOrDefaultAsync(t => t.Id == id);
        if (duelToDelete != null){
            _fencingDbContext.Duels.Remove(duelToDelete);
            await _fencingDbContext.SaveChangesAsync();
        }
    }


    public IQueryable<Duel> GetAll(){
        return _fencingDbContext
            .Duels
            .Include(t => t.Tournament)
            .Include(t => t.FencerA)
            .Include(t => t.FencerB)
            .AsQueryable();
    }
}

