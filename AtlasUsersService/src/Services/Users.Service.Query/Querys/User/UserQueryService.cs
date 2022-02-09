using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.DataAccess.DataBase;
using Users.Services.Query.Dtos;

namespace Users.Services.Query.Querys.User
{
    public class UserQueryService : IUserQueryService
    {
        private AtlasUsersContext _context;
        public UserQueryService(AtlasUsersContext context)
        {
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



    }
}
