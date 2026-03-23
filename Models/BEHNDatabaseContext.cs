using Microsoft.EntityFrameworkCore;

namespace SportsApp2.Models
{
    public class BEHNDatabaseContext : DbContext
    {
        public BEHNDatabaseContext(DbContextOptions<BEHNDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Nbagame> Nbagames { get; set; }
        public DbSet<Nbaplayer> Nbaplayers { get; set; }
        public DbSet<Nbaschedule> Nbaschedules { get; set; }
        public DbSet<Nbateam> Nbateams { get; set; }

        public DbSet<Nflgame> Nflgames { get; set; }
        public DbSet<Nflplayer> Nflplayers { get; set; }
        public DbSet<Nflschedule> Nflschedules { get; set; }
       
        public DbSet<Nflteam> Nflteams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nbagame>(entity =>
            {
                entity.HasKey(e => e.NbagameId);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.NbagameAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.NbagameHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nbaschedule>(entity =>
            {
                entity.HasKey(e => e.NbascheduleId);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.NbascheduleAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.NbascheduleHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nbaplayer>(entity =>
            {
                entity.HasKey(e => e.NbaplayerId);

                entity.HasOne(d => d.Nbateam)
                    .WithMany(p => p.Nbaplayers)
                    .HasForeignKey(d => d.NbateamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nflgame>(entity =>
            {
                entity.HasKey(e => e.NflgameId);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.NflgameAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.NflgameHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nflschedule>(entity =>
            {
                entity.HasKey(e => e.NflscheduleId);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.NflscheduleAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.NflscheduleHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Nflplayer>(entity =>
            {
                entity.HasKey(e => e.NflplayerId);

                entity.HasOne(d => d.Nflteam)
                    .WithMany(p => p.Nflplayers)
                    .HasForeignKey(d => d.NflteamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}