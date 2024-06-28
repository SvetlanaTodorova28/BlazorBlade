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
    [Migration("20240428170540_gender")]
    partial class gender
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

                    b.Property<int>("Gender")
                        .HasColumnType("int");

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
                            Gender = 0,
                            Name = "Zorro",
                            Rating = 500,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Gender = 0,
                            Name = "Luke Skywalker",
                            Rating = 300,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Gender = 0,
                            Name = "Athos",
                            Rating = 800,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            Gender = 0,
                            Name = "Porthos",
                            Rating = 1500,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            Gender = 0,
                            Name = "Aramis",
                            Rating = 1300,
                            TeamId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            Gender = 0,
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
                            EndDate = new DateTime(2024, 8, 6, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9970),
                            Name = "The Grand Duelist Gala",
                            StartDate = new DateTime(2024, 8, 4, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9920)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            EndDate = new DateTime(2024, 9, 25, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9980),
                            Name = "The Blade Masters Summit",
                            StartDate = new DateTime(2024, 9, 20, 19, 5, 40, 713, DateTimeKind.Local).AddTicks(9980)
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
