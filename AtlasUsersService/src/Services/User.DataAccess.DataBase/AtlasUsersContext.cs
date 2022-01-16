using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using User.Domain.Models;

#nullable disable

namespace User.DataAccess.DataBase
{
    public partial class AtlasUsersContext : DbContext
    {
        public AtlasUsersContext()
        {
        }

        public AtlasUsersContext(DbContextOptions<AtlasUsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User.Domain.Models.User> Users { get; set; }
        public virtual DbSet<UserWorkout> UserWorkouts { get; set; }
        public virtual DbSet<WorkoutStatus> WorkoutStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-B5D1Q8K;Initial Catalog=AtlasUsers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<User.Domain.Models.User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.HasIndex(e => e.Email, "UQ__Users__A9D105343D9FF636")
                    .IsUnique();

                entity.HasIndex(e => e.LoginName, "constraint_Login_unique")
                    .IsUnique();

                entity.HasIndex(e => e.NickName, "constraint_NickName_unique")
                    .IsUnique();

                entity.Property(e => e.Birth).HasColumnType("date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Deleted_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Kind).HasDefaultValueSql("((1))");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.PhotoId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<UserWorkout>(entity =>
            {
                entity.HasKey(e => e.IdUserWorkout);

                entity.ToTable("UserWorkout");

                entity.HasOne(d => d.IdWorkoutStatusNavigation)
                    .WithMany(p => p.UserWorkouts)
                    .HasForeignKey(d => d.IdWorkoutStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserWorkout_WorkoutStatus");
            });

            modelBuilder.Entity<WorkoutStatus>(entity =>
            {
                entity.HasKey(e => e.IdWorkoutStatus);

                entity.ToTable("WorkoutStatus");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
