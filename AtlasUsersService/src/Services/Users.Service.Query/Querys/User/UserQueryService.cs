using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.DataAccess.DataBase;
using Users.Services.Proxies.Exercises;
using Users.Services.Query.Dtos;

namespace Users.Services.Query.Querys.User
{
    public class UserQueryService : IUserQueryService
    {
        private readonly AtlasUsersContext _context;
        private readonly IExerciseProxie _exerciseProxie;
        public UserQueryService(AtlasUsersContext context, IExerciseProxie exerciseProxie )
        {
            _exerciseProxie = exerciseProxie;
            _context = context;
        }
        public async Task<UserDto> GetAsync(int Id)
        {
            UserDto result = new UserDto();

            var data = await _context.Users.SingleOrDefaultAsync(x => x.IdUser == Id);
            if (data == null)
                result = null;
            else
            {
                result = new UserDto()
                {
                    IdUser = data.IdUser,
                    Birth = data.Birth,
                    CreatedAt = data.CreatedAt,
                    DeletedAt = data.DeletedAt,
                    Email = data.Email,
                    Height = data.Height,
                    Kind = data.Kind,
                    Lastname = data.Lastname,
                    LoginName = data.LoginName,
                    Name = data.Name,
                    NickName = data.NickName,
                    Password = data.Password,
                    PhotoId = data.PhotoId,
                    Status = data.Status,
                    Weight = data.Weight,
                };
            }

            return result;
        }

        public async Task<WorkoutDto> GetWorkoutSubscribedByUserId(int Id)
        {
            WorkoutDto result = new WorkoutDto();

            var data = await _exerciseProxie.GetWorkOutAsync(Id);
            

            return result;
        }


    }
}
