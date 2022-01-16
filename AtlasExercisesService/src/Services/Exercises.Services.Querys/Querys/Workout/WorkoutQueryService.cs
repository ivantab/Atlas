using Exercise.DataAccess.DataBase;
using Exercise.Domain.Models;
using Exercise.Services.Querys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys
{
    public class WorkoutQueryService : IWorkoutQueryService
    {
        public readonly AtlasExercisesContext _context;

        public WorkoutQueryService(AtlasExercisesContext context)
        {
            _context = context;
        }

        public async Task<WorkoutDto> GetAsync(int id)
        {
            WorkoutDto workoutDto = new WorkoutDto();

            workoutDto.ExerciseDto = new List<ExerciseDto>();

            var output = await _context.Workouts.Join(_context.TrsExercisesInWorkouts, work => work.IdWorkout,
                tre_e => tre_e.IdWorkout, (work, tre_e) => new { work, tre_e }).Where(idwork => idwork.work.IdWorkout == id).Join(_context.Exercises,
                join2 => join2.tre_e.IdExercise, exe => exe.IdExercise, (join2, exe) => new { join2, exe }).Join(_context.Movements, join3 => join3.exe.IdMovement,mov => mov.IdMovement,
                (join3, mov) => new { join3, mov }).Join(_context.Muscles,join4 => join4.mov.MainMuscle,musc => musc.IdMuscle,
                (join4,musc) => new { join4,musc}).Join(_context.Difficulties , join5 => join5.join4.mov.IdDifficulty,dif => dif.IdDifficulty,(
                join5,dif) => new { join5 , dif}).Join(_context.Disciplines,join6 => join6.join5.join4.mov.IdDiscipline,dis => dis.IdDiscipline,
                (join6,dis) => new { join6 , dis }).Join(_context.Locations, join7 => join7.join6.join5.musc.LocationId , loc => loc.LocationId,
                (join7,loc) => new { join7 , loc}).ToArrayAsync();
            foreach (var data in output)
            {
                if (workoutDto != null && workoutDto.IdWorkout != data.join7.join6.join5.join4.join3.join2.work.IdWorkout)
                {
                    workoutDto.Name = data.join7.join6.join5.join4.join3.join2.work.Name;
                    workoutDto.CreationDate = data.join7.join6.join5.join4.join3.join2.work.CreationDate;
                    workoutDto.IdWorkout = data.join7.join6.join5.join4.join3.join2.work.IdWorkout;
                }
                  
                ExerciseDto excercise = new ExerciseDto()
                {
                    IdExercise = data.join7.join6.join5.join4.join3.exe.IdExercise,
                    Prpercentage = data.join7.join6.join5.join4.join3.exe.Prpercentage,
                    Repetitions = data.join7.join6.join5.join4.join3.exe.Repetitions,
                    RestBetweenRounds = data.join7.join6.join5.join4.join3.exe.RestBetweenRounds,
                    Rounds = data.join7.join6.join5.join4.join3.exe.Rounds,
                    MovementDto = new MovementDto()
                    {
                        Description = data.join7.join6.join5.join4.mov.Description,
                        Name = data.join7.join6.join5.join4.mov.Name,
                        MainMuscle = new MuscleDto
                        {
                            Description = data.join7.join6.join5.musc.Description,
                            Name = data.join7.join6.join5.musc.Name,                          
                            IdMuscle = data.join7.join6.join5.musc.IdMuscle,
                            Location = new LocationDto() 
                            {
                                Description = data.loc.Description,
                                Ubication = data.loc.Ubication,
                                LocationId = data.loc.LocationId,                                 
                            },                                  
                        },
                         Difficulty = new DifficultyDto()
                         {
                              IdDifficulty = data.join7.join6.dif.IdDifficulty,
                              Name = data.join7.join6.dif.Name,                                 
                         },
                          Discipline = new DisciplineDto()
                          {
                               IdDiscipline = data.join7.dis.IdDiscipline,
                                Name = data.join7.dis.Name,
                          },
                           IdMovement = data.join7.join6.join5.join4.mov.IdMovement,
                    }                     
                };
                workoutDto.ExerciseDto.Add(excercise);
            }
            return workoutDto;
        }
    }
}
