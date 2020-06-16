using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF
{
    public partial class FootballContext : DbContext
    {
        public FootballContext()
        {
        }

        public FootballContext(DbContextOptions<FootballContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlayerTeams> PlayerTeams { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Football;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeams>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__PlayerTe__2CDA01D1ED4D04BE");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TeamId).HasColumnName("teamID");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.PlayerTeams)
                    .HasForeignKey<PlayerTeams>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerTea__playe__44CA3770");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlayerTeams)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__PlayerTea__teamI__45BE5BA9");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__Players__2CDA01D19E2748C2");

                entity.Property(e => e.PlayerId).HasColumnName("playerID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__Players__positio__41EDCAC5");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PositionId)
                    .HasName("PK__Position__B07CF58E2EE71A96");

                entity.Property(e => e.PositionId).HasColumnName("positionID");

                entity.Property(e => e.PositionDescription)
                    .IsRequired()
                    .HasColumnName("positionDescription")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PK__Teams__5ED7534A8E7A699E");

                entity.Property(e => e.TeamId).HasColumnName("teamID");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("teamName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
