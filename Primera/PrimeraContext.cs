using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primera.Models;

namespace Primera
{
    public class PrimeraContext : DbContext
    {
        public PrimeraContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public PrimeraContext(DbContextOptions<PrimeraContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=PrimeraP32;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.Match)
                .WithMany(m => m.Goals)
                .HasForeignKey(g => g.MatchId);
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.Player)
                .WithMany(p => p.Goals)
                .HasForeignKey(g => g.PlayerId);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(t => t.Matches1)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.Team1Id);
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany(t => t.Matches2)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.Team2Id);
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);


            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Real Madrid", City = "Madrid" },
                new Team { Id = 2, Name = "Barcelona", City = "Barcelona" },
                new Team { Id = 3, Name = "Atletico Madrid", City = "Madrid" },
                new Team { Id = 4, Name = "Valencia", City = "Valencia" },
                new Team { Id = 5, Name = "Sevilla", City = "Sevilla" }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Goalkeeper" },
                new Position { Id = 2, Name = "Defender" },
                new Position { Id = 3, Name = "Midfielder" },
                new Position { Id = 4, Name = "Forward" }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Thibaut Courtois", TeamId = 1, PositionId = 1 },
                new Player { Id = 2, Name = "Sergio Ramos", TeamId = 1, PositionId = 2 },
                new Player { Id = 3, Name = "Luka Modric", TeamId = 1, PositionId = 3 },
                new Player { Id = 4, Name = "Karim Benzema", TeamId = 1, PositionId = 4 },
                new Player { Id = 5, Name = "Marc-Andre ter Stegen", TeamId = 2, PositionId = 1 },
                new Player { Id = 6, Name = "Gerard Pique", TeamId = 2, PositionId = 2 },
                new Player { Id = 7, Name = "Frenkie de Jong", TeamId = 2, PositionId = 3 },
                new Player { Id = 8, Name = "Lionel Messi", TeamId = 2, PositionId = 4 }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match { Id = 1, Team1Id = 1, Team2Id = 2, Date = new DateOnly(2021, 9, 1) },
                new Match { Id = 2, Team1Id = 3, Team2Id = 4, Date = new DateOnly(2021, 9, 2) },
                new Match { Id = 3, Team1Id = 5, Team2Id = 1, Date = new DateOnly(2021, 9, 3) }
            );

            modelBuilder.Entity<Goal>().HasData(
                new Goal { Id = 1, MatchId = 1, PlayerId = 4, Minute = 10 },
                new Goal { Id = 2, MatchId = 1, PlayerId = 8, Minute = 20 },
                new Goal { Id = 3, MatchId = 2, PlayerId = 8, Minute = 30 },
                new Goal { Id = 4, MatchId = 3, PlayerId = 4, Minute = 40 }
            );
        }
    }
}
