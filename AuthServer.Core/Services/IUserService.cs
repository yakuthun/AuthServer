using AuthServer.Core.DTOs;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {//burası direkt olarak Presentation Layer(API) ile haberleşecek
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto userDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);//user bilgilerini alacak
    }
}
