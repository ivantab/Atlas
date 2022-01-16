using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Services.Query.Dtos;

namespace Users.Services.Query.Querys.User
{
    public interface IUserQueryService
    {
        Task<UserDto> GetAsync(int Id);
    }
}
