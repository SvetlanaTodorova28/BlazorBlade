


using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Enums;
using Pin.LiveSports.Utilities;

namespace Pin.LiveSports.Core.Data.Seeding;

public class Seeder{

    public static void Seed(ModelBuilder modelBuilder){

        var teams = new Team[]{
            new Team{ Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "The Screeners", 
                CountryCode = CountryCode.GB.ToString(),Flag = $"https://flagsapi.com/{CountryCode.GB.ToString()}/shiny/64.png" },
            new Team{
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "The Three Musketeers",
                CountryCode = CountryCode.FR.ToString(),Flag = $"https://flagsapi.com/{CountryCode.FR.ToString()}/shiny/64.png" 
            },
            new Team{
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Maiden Warrior" ,
                CountryCode = CountryCode.ES.ToString(),Flag = $"https://flagsapi.com/{CountryCode.ES.ToString()}/shiny/64.png" 
            },
        };

        var players = new Fencer[]{
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Zorro", Rating = 500,IsMale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=zorro",
                TeamId = teams[0].Id
            },
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Luke Skywalker", Rating = 300,IsMale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=luke",
                TeamId = teams[0].Id
            },
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Athos", Rating = 800,IsMale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=athos",
                TeamId = teams[1].Id
            },
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Porthos", Rating = 1500,IsMale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=porthos",
                TeamId = teams[1].Id
            },
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Aramis", Rating = 1300,IsMale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=Aramis",
                TeamId = teams[1].Id
            },
            new Fencer(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Joan of Arc", Rating = 1900,IsFemale = true,
                AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&facialHairProbability=0&top%5B%5D=bigHair,bob,bun,curvy,longButNotTooLong,shaggy,shaggyMullet,shavedSides,straightAndStrand,straight01,straight02&seed=joan",
                TeamId = teams[2].Id
            },
        };

        var tournaments = new Tournament[]{
            new Tournament(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                Name = "The Grand Duelist Gala",
                StartDate = DateTime.Now.AddDays(98),
                EndDate = DateTime.Now.AddDays(100)
            },
            new Tournament(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), 
                Name = "The Blade Masters Summit",
                StartDate = DateTime.Now.AddDays(145),
                EndDate = DateTime.Now.AddDays(150)
            }
        };

        var duels = new Duel[]{
            //three games the first round per tournament
            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                TournamentId = tournaments[0].Id,
                FencerAId = players[0].Id, 
                FencerBId = players[1].Id,
            },
            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                TournamentId = tournaments[0].Id,
                FencerAId = players[2].Id,
                FencerBId = players[3].Id
            },

            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                TournamentId = tournaments[0].Id,
                FencerAId = players[4].Id,
                FencerBId = players[5].Id
            },

            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                TournamentId = tournaments[1].Id,
                FencerAId = players[0].Id,
                FencerBId = players[5].Id
            },
            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                TournamentId = tournaments[1].Id,
                FencerAId = players[1].Id,
                FencerBId = players[4].Id
            },
            new Duel(){
                Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                TournamentId = tournaments[1].Id,
                FencerAId = players[2].Id,
                FencerBId = players[3].Id
            }
        };

       
        var teamsTournaments = new[]{
            new{
                TeamsId = teams[0].Id,
                TournamentsId = tournaments[0].Id
            },
            new{
                TeamsId = teams[1].Id,
                TournamentsId = tournaments[0].Id
            },
            new{
                TeamsId = teams[2].Id,
                TournamentsId = tournaments[0].Id
            },
            new{
                TeamsId = teams[0].Id,
                TournamentsId = tournaments[1].Id
            },
            new{
                TeamsId = teams[1].Id,
                TournamentsId = tournaments[1].Id
            },
            new{
                TeamsId = teams[2].Id,
                TournamentsId = tournaments[1].Id
            },

        };
     
        modelBuilder.Entity<Team>().HasData(teams);
        modelBuilder.Entity<Fencer>().HasData(players);
        modelBuilder.Entity<Duel>().HasData(duels);
        modelBuilder.Entity<Tournament>().HasData(tournaments);
       
        modelBuilder
            .Entity($"{nameof(Team)}{nameof(Tournament)}")
            .HasData(teamsTournaments);
       
    }
}

        