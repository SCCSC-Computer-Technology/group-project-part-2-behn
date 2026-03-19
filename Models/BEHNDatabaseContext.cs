using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportsApp2.Models;

public partial class BEHNDatabaseContext : DbContext
{
    public BEHNDatabaseContext()
    {
    }

    public BEHNDatabaseContext(DbContextOptions<BEHNDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nbagame> Nbagames { get; set; }

    public virtual DbSet<Nbaplayer> Nbaplayers { get; set; }

    public virtual DbSet<Nbaschedule> Nbaschedules { get; set; }

    public virtual DbSet<NbaseasonStat> NbaseasonStats { get; set; }

    public virtual DbSet<Nbateam> Nbateams { get; set; }

    public virtual DbSet<Nflgame> Nflgames { get; set; }

    public virtual DbSet<Nflplayer> Nflplayers { get; set; }

    public virtual DbSet<Nflschedule> Nflschedules { get; set; }

    public virtual DbSet<NflseasonStat> NflseasonStats { get; set; }

    public virtual DbSet<Nflteam> Nflteams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Group-Project2\\group-project-part-2-behn\\App_Data\\BEHNDatabase.mdf;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nbagame>(entity =>
        {
            entity.HasKey(e => e.NbagameId).HasName("PK__NBAGames__2419F7604462E6EE");

            entity.ToTable("NBAGames");

            entity.Property(e => e.NbagameId).HasColumnName("NBAGameID");
            entity.Property(e => e.AwayTeamId).HasColumnName("AwayTeamID");
            entity.Property(e => e.GameDate).HasColumnType("datetime");
            entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.NbagameAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBAGames_AwayTeam");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.NbagameHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBAGames_HomeTeam");
        });

        modelBuilder.Entity<Nbaplayer>(entity =>
        {
            entity.HasKey(e => e.NbaplayerId).HasName("PK__NBAPlaye__9E1986D331B206B4");

            entity.ToTable("NBAPlayers");

            entity.Property(e => e.NbaplayerId).HasColumnName("NBAPlayerID");
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.NbateamId).HasColumnName("NBATeamID");
            entity.Property(e => e.PlayerName).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.YearsPlayed).HasMaxLength(50);

            entity.HasOne(d => d.Nbateam).WithMany(p => p.Nbaplayers)
                .HasForeignKey(d => d.NbateamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBAPlayers_NBATeams");
        });

        modelBuilder.Entity<Nbaschedule>(entity =>
        {
            entity.HasKey(e => e.NbascheduleId).HasName("PK__NBASched__0826B4576E51F27E");

            entity.ToTable("NBASchedule");

            entity.Property(e => e.NbascheduleId).HasColumnName("NBAScheduleID");
            entity.Property(e => e.AwayTeamId).HasColumnName("AwayTeamID");
            entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.NbascheduleAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBASchedule_AwayTeam");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.NbascheduleHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBASchedule_HomeTeam");
        });

        modelBuilder.Entity<NbaseasonStat>(entity =>
        {
            entity.HasKey(e => e.NbateamId).HasName("PK__NBASeaso__B5C90A7C3A1B3CC4");

            entity.ToTable("NBASeasonStats");

            entity.Property(e => e.NbateamId)
                .ValueGeneratedNever()
                .HasColumnName("NBATeamID");
            entity.Property(e => e.AssistsPerGame).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gp).HasColumnName("GP");
            entity.Property(e => e.PointsPerGame).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReboundsPerGame).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Nbateam).WithOne(p => p.NbaseasonStat)
                .HasForeignKey<NbaseasonStat>(d => d.NbateamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NBASeasonStats_NBATeams");
        });

        modelBuilder.Entity<Nbateam>(entity =>
        {
            entity.HasKey(e => e.NbateamId).HasName("PK__NBATeams__B5C90A7C6CA5D932");

            entity.ToTable("NBATeams");

            entity.HasIndex(e => e.Abbreviation, "UQ_NBATeams_Abbreviation").IsUnique();

            entity.HasIndex(e => e.TeamName, "UQ_NBATeams_TeamName").IsUnique();

            entity.Property(e => e.NbateamId).HasColumnName("NBATeamID");
            entity.Property(e => e.Abbreviation).HasMaxLength(10);
            entity.Property(e => e.Conference).HasMaxLength(20);
            entity.Property(e => e.Division).HasMaxLength(50);
            entity.Property(e => e.TeamName).HasMaxLength(100);
        });

        modelBuilder.Entity<Nflgame>(entity =>
        {
            entity.HasKey(e => e.NflgameId).HasName("PK__NFLGames__21213C36ACD6D096");

            entity.ToTable("NFLGames");

            entity.Property(e => e.NflgameId).HasColumnName("NFLGameID");
            entity.Property(e => e.AwayTeamId).HasColumnName("AwayTeamID");
            entity.Property(e => e.GameDate).HasColumnType("datetime");
            entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.NflgameAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NFLGames_AwayTeam");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.NflgameHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NFLGames_HomeTeam");
        });

        modelBuilder.Entity<Nflplayer>(entity =>
        {
            entity.HasKey(e => e.NflplayerId).HasName("PK__NFLPlaye__58E253964F5C9FEA");

            entity.ToTable("NFLPlayers");

            entity.Property(e => e.NflplayerId).HasColumnName("NFLPlayerID");
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.Height).HasMaxLength(50);
            entity.Property(e => e.NflteamId).HasColumnName("NFLTeamID");
            entity.Property(e => e.PlayerName).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.YearsPlayed).HasMaxLength(50);

            entity.HasOne(d => d.Nflteam).WithMany(p => p.Nflplayers)
                .HasForeignKey(d => d.NflteamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NFLPlayers_NFLTeams");
        });

        modelBuilder.Entity<Nflschedule>(entity =>
        {
            entity.HasKey(e => e.NflscheduleId).HasName("PK__NFLSched__4AD73DF4EC960DB8");

            entity.ToTable("NFLSchedule");

            entity.Property(e => e.NflscheduleId).HasColumnName("NFLScheduleID");
            entity.Property(e => e.AwayTeamId).HasColumnName("AwayTeamID");
            entity.Property(e => e.HomeTeamId).HasColumnName("HomeTeamID");
            entity.Property(e => e.KickoffEt)
                .HasMaxLength(50)
                .HasColumnName("KickoffET");
            entity.Property(e => e.KickoffLocal).HasMaxLength(50);
            entity.Property(e => e.Network).HasMaxLength(50);
            entity.Property(e => e.SiteNote).HasMaxLength(50);

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.NflscheduleAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NFLSchedule_AwayTeam");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.NflscheduleHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NFLSchedule_HomeTeam");
        });

        modelBuilder.Entity<NflseasonStat>(entity =>
        {
            entity.HasKey(e => e.NflteamId).HasName("PK__NFLSeaso__99B2ECADC2D159F4");

            entity.ToTable("NFLSeasonStats");

            entity.Property(e => e.NflteamId)
                .ValueGeneratedNever()
                .HasColumnName("NFLTeamID");
            entity.Property(e => e.Gp).HasColumnName("GP");
            entity.Property(e => e.PassingYardsPerGame).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PointsPerGame).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RushingYardsPerGame).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalYardsPerGame).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Nflteam>(entity =>
        {
            entity.HasKey(e => e.NflteamId).HasName("PK__NFLTeams__99B2ECADFFA4249E");

            entity.ToTable("NFLTeams");

            entity.HasIndex(e => e.Abbreviation, "UQ_NFLTeams_Abbreviation").IsUnique();

            entity.HasIndex(e => e.TeamName, "UQ_NFLTeams_TeamName").IsUnique();

            entity.Property(e => e.NflteamId).HasColumnName("NFLTeamID");
            entity.Property(e => e.Abbreviation).HasMaxLength(10);
            entity.Property(e => e.Conference).HasMaxLength(20);
            entity.Property(e => e.Stadium).HasMaxLength(100);
            entity.Property(e => e.TeamName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
