using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Models
{
    public class UserRefreshToken
    {
        public string UserId { get; set; }//bu refresh token kime ait
        public string Code { get; set; }//Refresh Token
        public DateTime Expiration { get; set; }
    }
}
