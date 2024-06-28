
using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Data.Seeding;
using Pin.LiveSports.Core.Entities;

namespace Pin.LiveSports.Core.Data;

public class FencingDbContext:DbContext {
    
    public DbSet<Team> Teams { get; set; }
    public DbSet<Fencer> Players { get; set; } 
    public DbSet<Duel> Duels { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    
    public FencingDbContext(DbContextOptions<FencingDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Fencer>()
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Team>()
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Tournament>()
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        
        modelBuilder.Entity<Duel>()
            .HasOne<Fencer>(g => g.FencerA)
            .WithMany() // Geen navigatie-eigenschap aan de andere kant
            .HasForeignKey(g => g.FencerAId)
            .OnDelete(DeleteBehavior.Cascade); // Geen cascade delete
        
        modelBuilder.Entity<Duel>()
            .HasOne<Fencer>(g => g.FencerB)
            .WithMany() // Geen navigatie-eigenschap aan de andere kant
            .HasForeignKey(g => g.FencerBId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        modelBuilder.Entity<Duel>()
            .HasOne<Fencer>(g => g.FencerA)
            .WithMany()
            .HasForeignKey(g => g.FencerAId)
            .OnDelete(DeleteBehavior.Restrict); // Geen actie ondernemen bij het verwijderen van Duel

        modelBuilder.Entity<Duel>()
            .HasOne<Fencer>(g => g.FencerB)
            .WithMany()
            .HasForeignKey(g => g.FencerBId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Duel>()
            .HasMany<Comment>(d => d.Comments) // Geen navigatie-eigenschap aan de andere kant
            .WithOne(g => g.Duel)
            .HasForeignKey(c => c.DuelId) 
            .OnDelete(DeleteBehavior.Cascade); 
        
       

       
        Seeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}