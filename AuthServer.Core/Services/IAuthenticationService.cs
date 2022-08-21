using AuthServer.Core.DTOs;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
    //kullanıcıdan username ve passwordu alacağım ve doğruysa token döndereceğim.
    Task<Response<TokenDto>> CreateToktenAsync(LoginDto loginDto);//başarılı ise dönüş yapar.
    Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        //refresh token ile yeni bir token alabilir.

    Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);//logout olursa null yapar.
    Task<Response<ClientTokenDto>> CreateTokenByClient(ClientLoginDto loginDto);
     //api'nin appsettings.json'unda client verilerini tutacağız.
    }
}
