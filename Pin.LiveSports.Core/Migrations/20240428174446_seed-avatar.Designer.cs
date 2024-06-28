﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pin.LiveSports.Core.Data;

#nullable disable

namespace Pin.LiveSports.Core.Migrations
{
    [DbContext(typeof(FencingDbContext))]
    [Migration("20240428174446_seed-avatar")]
    partial class seedavatar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DuelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DuelId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Duel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FencerAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FencerAPoints")
                        .HasColumnType("int");

                    b.Property<Guid>("FencerBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FencerBPoints")
                        .HasColumnType("int");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FencerAId");

                    b.HasIndex("FencerBId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Duels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000012"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000001"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000002"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000013"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000003"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000004"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000016"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000005"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000006"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000017"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000001"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000006"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000018"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000002"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000005"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000019"),
                            FencerAId = new Guid("00000000-0000-0000-0000-000000000003"),
                            FencerAPoints = 0,
                            FencerBId = new Guid("00000000-0000-0000-0000-000000000004"),
                            FencerBPoints = 0,
                            TournamentId = new Guid("00000000-0000-0000-0000-000000000011")
                        });
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Fencer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsFemale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=zorro",
                            Gender = 0,
                            IsFemale = false,
                            IsMale = true,
                            Name = "Zorro",
                            Rating = 500,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=luke",
                            Gender = 0,
                            IsFemale = false,
                            IsMale = true,
                            Name = "Luke Skywalker",
                            Rating = 300,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=athos",
                            Gender = 0,
                            IsFemale = false,
                            IsMale = true,
                            Name = "Athos",
                            Rating = 800,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=porthos",
                            Gender = 0,
                            IsFemale = false,
                            IsMale = true,
                            Name = "Porthos",
                            Rating = 1500,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&top%5B%5D=dreads01,dreads02,frizzle,shortCurly,shortFlat,shortRound,shortWaved,sides,theCaesar,theCaesarAndSidePart&seed=Aramis",
                            Gender = 0,
                            IsFemale = false,
                            IsMale = true,
                            Name = "Aramis",
                            Rating = 1300,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            AvatarPicture = "https://api.dicebear.com/5.x/avataaars/svg?mouth=default&facialHairProbability=0&top%5B%5D=bigHair,bob,bun,curvy,longButNotTooLong,shaggy,shaggyMullet,shavedSides,straightAndStrand,straight01,straight02&seed=joan",
                            Gender = 1,
                            IsFemale = true,
                            IsMale = false,
                            Name = "Joan of Arc",
                            Rating = 1900,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000009")
                        });
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            CountryCode = "GB",
                            Flag = "https://flagsapi.com/GB/shiny/64.png",
                            Name = "The Screeners"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            CountryCode = "FR",
                            Flag = "https://flagsapi.com/FR/shiny/64.png",
                            Name = "The Three Musketeers"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            CountryCode = "ES",
                            Flag = "https://flagsapi.com/ES/shiny/64.png",
                            Name = "Maiden Warrior"
                        });
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000010"),
                            EndDate = new DateTime(2024, 8, 6, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5040),
                            Name = "The Grand Duelist Gala",
                            StartDate = new DateTime(2024, 8, 4, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(4990)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            EndDate = new DateTime(2024, 9, 25, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5050),
                            Name = "The Blade Masters Summit",
                            StartDate = new DateTime(2024, 9, 20, 19, 44, 46, 37, DateTimeKind.Local).AddTicks(5050)
                        });
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeamsId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("TeamTournament");

                    b.HasData(
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000007"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000008"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000009"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000007"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000008"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            TeamsId = new Guid("00000000-0000-0000-0000-000000000009"),
                            TournamentsId = new Guid("00000000-0000-0000-0000-000000000011")
                        });
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Comment", b =>
                {
                    b.HasOne("Pin.LiveSports.Core.Entities.Duel", "Duel")
                        .WithMany("Comments")
                        .HasForeignKey("DuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duel");
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Duel", b =>
                {
                    b.HasOne("Pin.LiveSports.Core.Entities.Fencer", "FencerA")
                        .WithMany()
                        .HasForeignKey("FencerAId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pin.LiveSports.Core.Entities.Fencer", "FencerB")
                        .WithMany()
                        .HasForeignKey("FencerBId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Pin.LiveSports.Core.Entities.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FencerA");

                    b.Navigation("FencerB");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Fencer", b =>
                {
                    b.HasOne("Pin.LiveSports.Core.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.HasOne("Pin.LiveSports.Core.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.LiveSports.Core.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Duel", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Pin.LiveSports.Core.Entities.Tournament", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
