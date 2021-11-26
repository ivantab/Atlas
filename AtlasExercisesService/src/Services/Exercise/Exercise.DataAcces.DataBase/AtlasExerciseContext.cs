using System;
using Exercise.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Exercise.DataAccess.DataBase
{
    public partial class AtlasExerciseContext : DbContext
    {
        public AtlasExerciseContext()
        {
        }

        public AtlasExerciseContext(DbContextOptions<AtlasExerciseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Difficulty> Difficulties { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Exercise.Domain.Models.Exercise> Exercises { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<Muscle> Muscles { get; set; }
        public virtual DbSet<TrsExercisesInWorkout> TrsExercisesInWorkouts { get; set; }
        public virtual DbSet<TrsSecondaryMusclesInMovement> TrsSecondaryMusclesInMovements { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Data Source=DESKTOP-B5D1Q8K;Initial Catalog=AtlasExercise;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Difficulty>(entity =>
            {
                entity.HasKey(e => e.IdDifficulty);

                entity.ToTable("Difficulty");

                entity.Property(e => e.IdDifficulty).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.IdDiscipline);

                entity.ToTable("Discipline");

                entity.Property(e => e.IdDiscipline).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exercise.Domain.Models.Exercise>(entity =>
            {
                entity.HasKey(e => e.IdExercise);

                entity.ToTable("Exercise");

                entity.Property(e => e.Prpercentage).HasColumnName("PRPercentage");

                entity.HasOne(d => d.IdMovementNavigation)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.IdMovement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exercise_Movement");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubication)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.IdMovement);

                entity.ToTable("Movement");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDisciplineNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.IdDiscipline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movement_Discipline");

                entity.HasOne(d => d.MainMuscleNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.MainMuscle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movement_Muscle");
            });

            modelBuilder.Entity<Muscle>(entity =>
            {
                entity.HasKey(e => e.IdMuscle);

                entity.ToTable("Muscle");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Muscles)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Muscle_Location");
            });

            modelBuilder.Entity<TrsExercisesInWorkout>(entity =>
            {
                entity.HasKey(e => e.IdExerciseWorkout)
                    .HasName("PK_TRS_ExercisesOfWorkout");

                entity.ToTable("TRS_ExercisesInWorkout");

                entity.HasOne(d => d.IdExerciseNavigation)
                    .WithMany(p => p.TrsExercisesInWorkouts)
                    .HasForeignKey(d => d.IdExercise)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkoutExercises_Exercises");

                entity.HasOne(d => d.IdWorkoutNavigation)
                    .WithMany(p => p.TrsExercisesInWorkouts)
                    .HasForeignKey(d => d.IdWorkout)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkoutExercises_Workout");
            });

            modelBuilder.Entity<TrsSecondaryMusclesInMovement>(entity =>
            {
                entity.HasKey(e => e.IdMuscleMovement)
                    .HasName("PK_TRS_Muscles_Movement");

                entity.ToTable("TRS_SecondaryMusclesInMovement");

                entity.HasOne(d => d.IdMovementNavigation)
                    .WithMany(p => p.TrsSecondaryMusclesInMovements)
                    .HasForeignKey(d => d.IdMovement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRS_SecondaryMusclesInMovement_Movement");

                entity.HasOne(d => d.IdMuscleNavigation)
                    .WithMany(p => p.TrsSecondaryMusclesInMovements)
                    .HasForeignKey(d => d.IdMuscle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRS_SecondaryMusclesInMovement_Muscle");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(e => e.IdWorkout);

                entity.ToTable("Workout");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
